using SIGEBI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioAuditoria
    {
        
        Task RegistrarAccionAsync(int? idResponsable, 
            string tipoAccion, 
            string entidadAfectada, 
            string detalles = "");

        
        Task<IEnumerable<AuditoriaResponseDTO>> ConsultarHistorialAsync(int? idResponsable = null, 
            string? entidadAfectada = null);

        Task<byte[]> ExportarHistorialPDFAsync(
           int? idResponsable = null,
           string? entidadAfectada = null);
    }
}
