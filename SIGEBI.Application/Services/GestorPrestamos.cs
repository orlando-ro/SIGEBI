using SIGEBI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SIGEBI.Domain.Exceptions;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Application.Services
{
    public class GestorPrestamos
    {
        private readonly IRepositorioPrestamo _repoPrestamo;
        private readonly IRepoSolicitud _repoSolicitud;
        private readonly IRepositorioLibro _repoLibro;
        private readonly IServicioPenalizacion _servicioPenalizacion;
        private readonly IServicioAuditoria _servicioAuditoria;

        public GestorPrestamos(
            IRepositorioPrestamo repoPrestamo,
            IRepoSolicitud repoSolicitud,
            IRepositorioLibro repoLibro,
            IServicioPenalizacion servicioPenalizacion,
            IServicioAuditoria servicioAuditoria)
        {
            _repoPrestamo = repoPrestamo;
            _repoSolicitud = repoSolicitud;
            _repoLibro = repoLibro;
            _servicioPenalizacion = servicioPenalizacion;
            _servicioAuditoria = servicioAuditoria;
        }

        public async Task AprobarYRegistrarPrestamoAsync(int idSolicitud, string idBibliotecario)
        {
            // 1. Buscamos los datos de la solicitud 
            var solicitud = await _repoSolicitud.ObtenerSolicitudConDetallesAsync(idSolicitud);
            if (solicitud == null) throw new NegocioExeption("La solicitud no existe.");

            // 2. Modificar el estado de la Solicitud 
            solicitud.Aprobar(); 

            // 3. Crear la Resolución de Aprobación
            var aprobacion = new Aprobacion
            {
                IdSolicitud = solicitud.IdSolicitud,
                IdBibliotecario = idBibliotecario,
                FechaResolucion = DateTime.Now
            };
            // prestamo aprovado

            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuario: idBibliotecario,
                tipoAccion: "Aprovacion",
                 entidadAfectada: "Prestamo",
                 detalles: $" Se registro el prestamo de la solicitud: ({idSolicitud})"
                );


            // 4. Creamos el prestamo oficial
            DateTime fechaInicio = DateTime.Now;
            DateTime fechaVencimiento = fechaInicio.AddDays(7);

            var nuevoPrestamo = new Prestamo(
                solicitud.IdUsuario,
                fechaInicio,
                fechaVencimiento,
                new List<Libro>(solicitud.LibrosSolicitados)
            );

            // 5. Decrementar el inventario fisico de los libros prestados
            foreach (var libro in solicitud.LibrosSolicitados)
            {
                libro.PrestarCopia();
                await _repoLibro.ActualizarAsync(libro); 
            }

            // 6. Guardamos todo
            await _repoSolicitud.ActualizarAsync(solicitud);
            await _repoSolicitud.GuardarResolucionAsync(aprobacion);

            aprobacion.PrestamoGenerado = nuevoPrestamo; 
            await _repoPrestamo.AgregarAsync(nuevoPrestamo);

            // agregamos el prestamo generado a auditoria para que el auditor pueda verla 

            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuario: idBibliotecario,
                tipoAccion: "Registrar prestamo",
                 entidadAfectada: "Prestamo",
                 detalles: $" el bibliotecario con id: ({idBibliotecario}) registro el prestamo ({nuevoPrestamo})"
                );

        }

        public async Task ProcesarDevolucionAsync(int idPrestamo, string condicionLibro)
        {
            // 1. Obtener el préstamo
            var prestamo = await _repoPrestamo.obtenerPrestamoConDetalleAsync(idPrestamo);
            if (prestamo == null) throw new NegocioExeption("El préstamo no fue encontrado.");

            // 2. ¿Cuántos días de retraso tuvo? (Calculado por la entidad)
            int diasRetraso = prestamo.CalcularDiasRetraso();

            // 3. Registrar la devolución en el Dominio (cambia estado y restaura copias de libros)
            prestamo.RegistrarDevolucion();

            // 4. Crear la entidad de Devolución
            var devolucion = new Devolucion(idPrestamo, condicionLibro);

            // 5. Generar penalización si hubo retraso (Integración entre módulos)
            if (diasRetraso > 0)
            {
                
                await _servicioPenalizacion.GenerarMultaPorRetrasoAsync(prestamo.IdUsuario, diasRetraso);
            }

            // 6. Actualizar Base de Datos
            await _repoPrestamo.ActualizarAsync(prestamo);

            


        }
    }
}
