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

        public async Task<IEnumerable<AuditoriaResponseDTO>> ConsultarHistorialAsync(
            string? idUsuarioActor = null,
            string? entidadAfectada = null)
        {
            IEnumerable<RegistroAuditoria> registros;

            if (!string.IsNullOrWhiteSpace(idUsuarioActor))
            {
                registros = await _repoAuditoria.ObtenerPorActorAsync(idUsuarioActor);
            }
            else if (!string.IsNullOrWhiteSpace(entidadAfectada))
            {
                registros = await _repoAuditoria.ObtenerPorEntidadAsync(entidadAfectada);
            }
            else
            {
                registros = await _repoAuditoria.ObtenerTodosAsync();
            }

            registros = registros.OrderByDescending(r => r.FechaHora);

            return registros.Select(r => new AuditoriaResponseDTO
            {
                IdRegistro = r.IdAuditoria,
                IdUsuarioActor = r.IdUsuario,
                FechaHora = r.FechaHora,
                TipoAccion = r.Accion,
                EntidadAfectada = r.EntidadAfectada,
                DetallesAdicionales = r.Detalles
            });
        }

        public async Task RegistrarAccionAsync(
            string idUsuario,
            string tipoAccion,
            string entidadAfectada,
            string detalles = "")
        {
            var nuevoRegistro = new RegistroAuditoria(
                idUsuario,
                tipoAccion,
                entidadAfectada,
                detalles
            );

            await _repoAuditoria.AgregarAsync(nuevoRegistro);
        }
    }
}