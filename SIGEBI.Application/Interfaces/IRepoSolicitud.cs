using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepoSolicitud : IBaseRepository<Solicitud>

    {

        Task<Solicitud?> ObtenerSolicitudConDetallesAsync(int idSolicitud);

        Task<IEnumerable<Solicitud>> ObtenerPorUsuarioAsync(int idusuario);

        Task<IEnumerable<Solicitud>> ObtenerPendientesAsync();

        Task GuardarResolucionAsync(Resolucion resolucion);

        Task<bool> ExisteSolicitudPendienteAsync(int IdUsuario, string isbn);
        Task<IEnumerable<Solicitud>> ObtenerPendientesPorUsuarioAsync(int idUsuario);
    }
}
