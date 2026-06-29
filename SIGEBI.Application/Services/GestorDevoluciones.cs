using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.Services
{
    public class GestorDevoluciones : IServicioDevolucion
    {
        private readonly IRepositorioPrestamo _repoPrestamo;
        private readonly IRepositorioDevolucion _repoDevolucion;
        private readonly IServicioPenalizacion _servicioPenalizacion;
        private readonly IServicioAuditoria _servicioAuditoria;

        public GestorDevoluciones(
            IRepositorioPrestamo repoPrestamo,
            IRepositorioDevolucion repoDevolucion,
            IServicioPenalizacion servicioPenalizacion,
            IServicioAuditoria servicioAuditoria)
        {
            _repoPrestamo = repoPrestamo;
            _repoDevolucion = repoDevolucion;
            _servicioPenalizacion = servicioPenalizacion;
            _servicioAuditoria = servicioAuditoria;
        }

        public async Task ProcesarDevolucionAsync(DevolucionRequestDTO peticion, string idBibliotecario)
        {
            // 1. Obtener el préstamo
            var prestamo = await _repoPrestamo.obtenerPrestamoConDetalleAsync(peticion.IdPrestamo);
            if (prestamo == null)
                throw new NegocioExeption("El préstamo indicado no existe.");

            // 2. Calcular días de retraso antes de mutar el estado
            int diasRetraso = prestamo.CalcularDiasRetraso();

            // 3. Registrar devolución en el Dominio
            prestamo.RegistrarDevolucion();

            // 4. Crear entidad de Devolución
            var devolucion = new Devolucion(peticion.IdPrestamo, peticion.CondicionLibro, peticion.Observaciones);

            // 5. Integración: Multa por Retraso
            if (diasRetraso > 0)
            {
                await _servicioPenalizacion.GenerarMultaPorRetrasoAsync(prestamo.IdUsuario, diasRetraso);
            }

            // 6. Integración: Multa por Daño (Regla opcional extraída de la entidad Devolucion)
            if (devolucion.RequierePenalizacionPorDano())
            {
                // En un caso real, la tarifa por daño podría variar o venir de configuración
                double tarifaDano = 500.0;
                var nuevaMultaDano = new Penalizacion(prestamo.IdUsuario, tarifaDano, $"Recurso dañado o extraviado: {peticion.CondicionLibro}");
                // Nota: Aquí podrías exponer un método en IServicioPenalizacion para daños
            }

            // 7. Persistir cambios
            await _repoDevolucion.AgregarAsync(devolucion);
            await _repoPrestamo.ActualizarAsync(prestamo);

            // 8. Auditar la acción
            await _servicioAuditoria.RegistrarAccionAsync(
                idBibliotecario,
                "Prestamo",
                "Devolucion",
                $"Devolución procesada para Préstamo {peticion.IdPrestamo}. Retraso: {diasRetraso} días. Condición: {peticion.CondicionLibro}"
            );
        }
    }
}
