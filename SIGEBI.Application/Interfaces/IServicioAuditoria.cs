using SIGEBI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioAuditoria
    {
        Task RegistrarAccionAsync(int? idResponsable, string tipoAccion, string entidadAfectada, string detalles = "");

        Task<IEnumerable<AuditoriaResponseDTO>> ConsultarHistorialAsync(
            DateTime? fechaInicio = null,
            DateTime? fechaFin = null,
            string? accion = null,
            string? entidadAfectada = null);

        Task<byte[]> ExportarHistorialPDFAsync(
            DateTime? fechaInicio = null,
            DateTime? fechaFin = null,
            string? accion = null,
            string? entidadAfectada = null);
    }
}