using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Infrastructure.Services
{
    public class ServicioAuditoria : IServicioAuditoria
    {
        private readonly IRepositorioAuditoria _repoAuditoria;
        private readonly IPDFService _pdfService;

        public ServicioAuditoria(
            IRepositorioAuditoria repoAuditoria,
            IPDFService pdfService)
        {
            _repoAuditoria = repoAuditoria;
            _pdfService = pdfService;
        }

        public async Task<IEnumerable<AuditoriaResponseDTO>> ConsultarHistorialAsync(
            int? idResponsable = null,
            string? entidadAfectada = null)
        {
            IEnumerable<RegistroAuditoria> registros;

            if (idResponsable.HasValue)
            {
                registros = await _repoAuditoria.ConsultarHistorialAsync(idResponsable.Value);

                if (!string.IsNullOrWhiteSpace(entidadAfectada))
                {
                    registros = registros.Where(r =>
                        !string.IsNullOrWhiteSpace(r.EntidadAfectada) &&
                        r.EntidadAfectada.Contains(
                            entidadAfectada.Trim(),
                            StringComparison.OrdinalIgnoreCase));
                }
            }
            else if (!string.IsNullOrWhiteSpace(entidadAfectada))
            {
                registros = await _repoAuditoria.ConsultarHistorialAsync(entidadAfectada: entidadAfectada.Trim());
            }
            else
            {
                registros = await _repoAuditoria.ObtenerTodosAsync();
            }

            return registros
                .OrderByDescending(r => r.FechaHora)
                .Select(MapearAuditoriaResponse)
                .ToList();
        }

        public async Task<byte[]> ExportarHistorialPDFAsync(
            int? idUsuarioActor = null,
            string? entidadAfectada = null)
        {
            var registros = await ConsultarHistorialAsync(
                idUsuarioActor,
                entidadAfectada);

            return _pdfService.GenerarReporteAuditoriaPDF(registros);
        }

        public async Task RegistrarAccionAsync(
            int? idResponsable,
            string tipoAccion,
            string entidadAfectada,
            string detalles = "")
        {
            if (idResponsable.HasValue && idResponsable <= 0)
                throw new Exception("El usuario que realiza la acción no es válido.");

            if (string.IsNullOrWhiteSpace(tipoAccion))
                throw new Exception("El tipo de acción es obligatorio.");

            if (string.IsNullOrWhiteSpace(entidadAfectada))
                throw new Exception("La entidad afectada es obligatoria.");

            var nuevoRegistro = new RegistroAuditoria(
                idResponsable,
                tipoAccion,
                entidadAfectada,
                detalles
            );

            await _repoAuditoria.AgregarAsync(nuevoRegistro);
        }

        private static AuditoriaResponseDTO MapearAuditoriaResponse(
            RegistroAuditoria registro)
        {
            return new AuditoriaResponseDTO
            {
                IdAuditoria = registro.IdAuditoria,
                IdResponsable = registro.IdResponsable,
                FechaHora = registro.FechaHora,
                Accion = registro.Accion,
                EntidadAfectada = registro.EntidadAfectada,
                Detalles = registro.Detalles
            };
        }
    }
}