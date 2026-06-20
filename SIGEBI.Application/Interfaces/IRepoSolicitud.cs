using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepoSolicitud : IBaseRepository<Solicitud>

    {

        Task<Solicitud?> ObtenerSolicitudConDetallesAsync(int id);

        Task<IEnumerable<Solicitud>> ObtenerPendientesAsync();

        Task GuardarResolucionAsync(Resolucion resolucion);
    }
}
