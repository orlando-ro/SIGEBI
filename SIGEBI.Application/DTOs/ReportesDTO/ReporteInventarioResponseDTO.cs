using SIGEBI.Application.DTOs.ReportesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.DTOs
{
    public record ReporteInventarioResponseDTO
    {
        public int TotalRecursos { get; set; }
        public int RecursoDisponibles { get; set; }
        public int RecursosPrestados { get; set; }
        public int RecursosDaniados { get; set; }
        public List<DetalleInventarioDTO> Recursos { get; set; } = [];

    }
}
