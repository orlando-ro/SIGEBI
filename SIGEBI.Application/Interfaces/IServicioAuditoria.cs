using SIGEBI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioAuditoria
    {
        
        Task RegistrarAccionAsync(int idUsuario, 
            string tipoAccion, 
            string entidadAfectada, 
            string detalles = "");

        
        Task<IEnumerable<AuditoriaResponseDTO>> ConsultarHistorialAsync(int? idUsuarioActor = null, 
            string? entidadAfectada = null);

        Task<byte[]> ExportarHistorialPDFAsync(
           int? idUsuarioActor = null,
           string? entidadAfectada = null);
    }
}
