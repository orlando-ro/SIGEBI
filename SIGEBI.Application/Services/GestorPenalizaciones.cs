using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Application.Services
{
    public class GestorPenalizaciones : IServicioPenalizacion
    {
        private readonly IRepoPenalizacion _repoPenalizacion;
        private readonly IServicioAuditoria _servicioAuditoria;
        private readonly IServicioNotificacion _servicioNotificacion;
        public GestorPenalizaciones(IRepoPenalizacion repoPenalizacion, IServicioAuditoria servicioAuditoria, IServicioNotificacion servicioNotificacion)
        {
            _repoPenalizacion = repoPenalizacion;
            _servicioAuditoria = servicioAuditoria;
            _servicioNotificacion = servicioNotificacion;
        }

        // Método automático llamado por GestorDevoluciones (CU-DEV-02)
        public async Task GenerarMultaPorRetrasoAsync(
          int idUsuario,
          int idPrestamo,
          int diasRetraso)
        {
            if (idUsuario <= 0)
                throw new NegocioExeption("El usuario es obligatorio.");

            if (idPrestamo <= 0)
                throw new NegocioExeption("El préstamo es obligatorio.");

            if (diasRetraso <= 0)
                throw new NegocioExeption("Los días de retraso deben ser mayores que cero.");

            double tarifaPorDia = 50.0;
            double montoTotal = diasRetraso * tarifaPorDia;

            var nuevaPenalizacion = new Penalizacion(
                idUsuario,
                montoTotal,
                $"Retraso de {diasRetraso} días en devolución.",
                idPrestamo
            );

            await _repoPenalizacion.AgregarAsync(nuevaPenalizacion);

            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuario,
                "Generar penalización por retraso",
                "Penalizacion",
                $"El usuario con ID {idUsuario} recibió una penalización por retraso de {diasRetraso} días en el préstamo #{idPrestamo}."
            );

            await _servicioNotificacion.EnviarNotificacionAsync(
                idUsuario,
                $"Se generó una penalización por retraso en el préstamo #{idPrestamo}. " +
                $"Días de retraso: {diasRetraso}. " +
                $"Monto: RD$ {montoTotal:N2}.",
                TipoNotificacion.AvisoPenalizacion
);
        }

        public async Task GenerarPenalizacionPorCondicionAsync(
          int idUsuario,
          int idPrestamo,
          CondicionDevolucion condicion)
        {
            double monto = condicion switch
            {
                CondicionDevolucion.Dañado => 500,
                CondicionDevolucion.Extraviado => 1500,
                _ => 0
            };

            if (monto <= 0)
                return;

            string motivo = condicion switch
            {
                CondicionDevolucion.Dañado => "Daño del recurso bibliográfico",
                CondicionDevolucion.Extraviado => "Extravío del recurso bibliográfico",
                _ => string.Empty
            };

            var penalizacion = new Penalizacion(
                idUsuario,
                monto,
                motivo,
                idPrestamo
            );

            await _repoPenalizacion.AgregarAsync(penalizacion);

            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuario,
                "Generar penalización por condición",
                "Penalizacion",
                $"El usuario con ID {idUsuario} recibió una penalización por condición del recurso. Motivo: {motivo}. Préstamo #{idPrestamo}."
            );
            await _servicioNotificacion.EnviarNotificacionAsync(
               idUsuario,
               $"Se generó una penalización asociada al préstamo #{idPrestamo}. " +
               $"Motivo: {motivo}. " +
               $"Monto: RD$ {monto:N2}.",
               TipoNotificacion.AvisoPenalizacion                   
);
        }

        public async Task ProcesarPagoMultaAsync(int idPenalizacion, PenalizacionRequestDTO peticion, int idUsuarioResolutor)
        {
            if (peticion == null)
                throw new NegocioExeption("La petición no puede ser nula.");

            if (idUsuarioResolutor <= 0)
                throw new NegocioExeption("El usuario resolutor es obligatorio.");

            var penalizacion = await _repoPenalizacion.ObtenerPendientePorIdYUsuarioAsync(
                idPenalizacion,
                peticion.MatriculaONumeroEmpleado
            );

            if (penalizacion == null)
                throw new NegocioExeption("La penalización indicada no existe.");

            // Lógica de Dominio
            penalizacion.MarcarComoPagada(
            idUsuarioResolutor,
            peticion.MotivoResolucion
             );

            // Persistencia
            await _repoPenalizacion.ActualizarAsync(penalizacion);

            // Auditoría
            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuarioResolutor,
                "Resolver Penalización",
                "Penalizacion",
                $"La penalizacion del usuario con identificacion {peticion.MatriculaONumeroEmpleado} ha sido marcada como pagada. Motivo: {peticion.MotivoResolucion}"
            );
            await _servicioNotificacion.EnviarNotificacionAsync(
                 penalizacion.IdUsuario,
                 $"Tu penalización #{penalizacion.IdPenalizacion} fue resuelta. " +
                 $"Motivo de resolución: {peticion.MotivoResolucion}.",
                 TipoNotificacion.penalizacionResuelta
);
        }

        
        
    }
}
