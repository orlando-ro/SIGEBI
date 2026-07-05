using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Infrastructure.Services
{
    public class ServicioAuditoria : IServicioAuditoria
    {
        private readonly IRepositorioAuditoria _repoAuditoria;

        public ServicioAuditoria(IRepositorioAuditoria repoAuditoria)
        {
            _repoAuditoria = repoAuditoria;
        }

        public async Task<IEnumerable<AuditoriaResponseDTO>> ConsultarHistorialAsync(int? idUsuarioActor = null, string? entidadAfectada = null)
        {
            IEnumerable<RegistroAuditoria> registros;

            if (idUsuarioActor.HasValue)
            {
                registros = await _repoAuditoria.ObtenerPorActorAsync(idUsuarioActor.Value);
            }
            else if (!string.IsNullOrWhiteSpace(entidadAfectada))
            {
                registros = await _repoAuditoria.ObtenerPorEntidadAsync(entidadAfectada);
            }
            else
            {
                registros = await _repoAuditoria.ObtenerTodosAsync();
            }

            return registros
                .OrderByDescending(r => r.FechaHora)
                .Select(MapearAuditoriaResponse);
        }

        public async Task RegistrarAccionAsync(
            int idUsuario,
            string tipoAccion,
            string entidadAfectada,
            string detalles = "")
        {

            if (idUsuario <= 0)
                throw new Exception("El usuario que realiza la accion no es valido");


            var nuevoRegistro = new RegistroAuditoria(
                idUsuario,
                tipoAccion,
                entidadAfectada,
                detalles
            );

            await _repoAuditoria.AgregarAsync(nuevoRegistro);
        }

        private static AuditoriaResponseDTO MapearAuditoriaResponse(RegistroAuditoria registro) {

            return new AuditoriaResponseDTO
            {
                IdAuditoria = registro.IdAuditoria,
                IdUsuarioActor = registro.IdUsuario,
                FechaHora = registro.FechaHora,
                Accion = registro.Accion,
                EntidadAfectada = registro.EntidadAfectada,
                Detalles = registro.Detalles


            };
        }

    }
}