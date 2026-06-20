using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepositorioReporte : IBaseRepository<Reporte>

    {
        Task<IEnumerable<Reporte>> ObtenerPorEstadoAsync(string estado);
    }
}
