using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGEBI.Infrastructure.Services
{
    public class ServicioAuditoria : IServicioAuditoria
    {
        private readonly IRepositorioAuditoria _repoAuditoria;
        private readonly IPDFService _pdfService;

        public ServicioAuditoria(IRepositorioAuditoria repoAuditoria, IPDFService pdfService)
        {
            _repoAuditoria = repoAuditoria;
            _pdfService = pdfService;
        }

        public async Task<IEnumerable<AuditoriaResponseDTO>> ConsultarHistorialAsync(
            DateTime? fechaInicio = null,
            DateTime? fechaFin = null,
            string? accion = null,
            string? entidadAfectada = null)
        {
            var registros = await _repoAuditoria.ConsultarHistorialAsync(fechaInicio, fechaFin, accion, entidadAfectada);
            return registros.Select(MapearAuditoriaResponse).ToList();
        }

        public async Task<byte[]> ExportarHistorialPDFAsync(
            DateTime? fechaInicio = null,
            DateTime? fechaFin = null,
            string? accion = null,
            string? entidadAfectada = null)
        {
            var registros = await ConsultarHistorialAsync(fechaInicio, fechaFin, accion, entidadAfectada);
            return _pdfService.GenerarReporteAuditoriaPDF(registros);
        }

        public async Task RegistrarAccionAsync(int? idResponsable, string tipoAccion, string entidadAfectada, string detalles = "")
        {
            if (idResponsable.HasValue && idResponsable <= 0)
                throw new Exception("El usuario que realiza la acción no es válido.");

            if (string.IsNullOrWhiteSpace(tipoAccion))
                throw new Exception("El tipo de acción es obligatorio.");

            if (string.IsNullOrWhiteSpace(entidadAfectada))
                throw new Exception("La entidad afectada es obligatoria.");

            var nuevoRegistro = new RegistroAuditoria(idResponsable, tipoAccion, entidadAfectada, detalles);
            await _repoAuditoria.AgregarAsync(nuevoRegistro);
        }

        private static AuditoriaResponseDTO MapearAuditoriaResponse(RegistroAuditoria registro)
        {
            return new AuditoriaResponseDTO
            {
                IdAuditoria = registro.IdAuditoria,
                FechaHora = registro.FechaHora,
                Accion = registro.Accion,
                EntidadAfectada = registro.EntidadAfectada,
                Detalles = registro.Detalles
            };
        }
    }
}