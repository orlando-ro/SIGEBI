using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Application.Services
{
    public class GestorPenalizaciones : IServicioPenalizacion
    {
        private readonly IRepoPenalizacion _repoPenalizacion;
        private readonly IServicioAuditoria _servicioAuditoria;

        public GestorPenalizaciones(IRepoPenalizacion repoPenalizacion, IServicioAuditoria servicioAuditoria)
        {
            _repoPenalizacion = repoPenalizacion;
            _servicioAuditoria = servicioAuditoria;
        }

        // Método automático llamado por GestorDevoluciones (CU-DEV-02)
        public async Task GenerarMultaPorRetrasoAsync(int idUsuario, int diasRetraso)
        {

            if (idUsuario <= 0)
                throw new NegocioExeption("El usuario es obligatorio.");

            if (diasRetraso <= 0)
                throw new NegocioExeption("Los días de retraso deben ser mayores que cero.");

            double tarifaPorDia = 50.0;
            double montoTotal = diasRetraso * tarifaPorDia;

            var nuevaPenalizacion = new Penalizacion(idUsuario, montoTotal, $"Retraso de {diasRetraso} días en devolución.");

            await _repoPenalizacion.AgregarAsync(nuevaPenalizacion);

            await _servicioAuditoria.RegistrarAccionAsync(
                
                idUsuario,
                "Multa Por Retraso",
                "Penalizacion",
                $"El Usuario con el id: {idUsuario} harecivido una penalizacion por retraso de {diasRetraso} dias de la entrega del libro"
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
            penalizacion.MarcarComoPagada();

            // Persistencia
            await _repoPenalizacion.ActualizarAsync(penalizacion);

            // Auditoría
            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuarioResolutor,
                "Resolver Penalización",
                "Penalizacion",
                $"La penalizacion del usuario con identificacion {peticion.MatriculaONumeroEmpleado} ha sido marcada como pagada. Motivo: {peticion.MotivoResolucion}"
            );
        }

        
        
    }
}
