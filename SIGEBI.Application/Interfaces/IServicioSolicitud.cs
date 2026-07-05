using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioSolicitud
    {
        Task<SolicitudResponseDTO> CrearSolicitudAsync(SolicitudRequestDTO peticion);

        Task<SolicitudResponseDTO?> ObtenerPorIdAsync(int IdSolicitud);

        Task<IEnumerable<SolicitudResponseDTO>> ConsultarPendientesAsync();

        Task<IEnumerable<SolicitudResponseDTO>> ConsultarPorUsuarioAsync(string MatriculaONUmeroEmpleado);
    }
}
