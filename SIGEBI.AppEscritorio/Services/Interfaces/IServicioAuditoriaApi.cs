using SIGEBI.AppEscritorio.DTOs.Auditoria;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Interfaces
{
    public interface IServicioAuditoriaApi
    {
        Task<List<AuditoriaResponseDTO>> ConsultarHistorialAuditoriaAsync(
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