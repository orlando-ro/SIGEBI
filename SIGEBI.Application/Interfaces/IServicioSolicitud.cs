using SIGEBI.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioSolicitud
    {
        Task RechasarSolicitudAsync(RechazoSolicitudRequestDTO peticion, int idBibliotecarioResponsable);

        Task<SolicitudResponseDTO> CrearSolicitudAsync(SolicitudRequestDTO peticion, int idUsuarioSolicitante);

        Task<SolicitudResponseDTO?> ObtenerPorIdAsync(int IdSolicitud);

        Task<IEnumerable<SolicitudResponseDTO>> ConsultarPendientesAsync();

        Task<IEnumerable<SolicitudResponseDTO>> ConsultarPorUsuarioAsync(string MatriculaONUmeroEmpleado);

        Task<IEnumerable<SolicitudResponseDTO>> ConsultarMisSolicitudesPendientesAsync(int idUsuario);
    }
}