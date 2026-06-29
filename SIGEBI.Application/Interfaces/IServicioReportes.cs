using SIGEBI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioReportes
    {
        Task SolicitarGeneracionReporteAsync(ReporteRequestDTO peticion);
    }
}
