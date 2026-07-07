using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.DTOs.ReportesDTO
{
    public record RecursoMasSolicitadosDTO
    {
        public string RecursoId { get; set; } = string.Empty;
        public string titulo { get; set; } = string.Empty;
        public int CantidadSolicitudes { get; set; }


    }
}
