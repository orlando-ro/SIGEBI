using SIGEBI.AppEscritorio.DTOs.Auditoria;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Interfaces
{
    public interface IServicioAuditoriaApi
    {
        Task<List<AuditoriaResponseDTO>> ConsultarHistorialAuditoriaAsync(int? idResponsable = null, string? entidadAfectada = null);
    }
}