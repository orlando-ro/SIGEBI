using SIGEBI.Application.DTOs.ReportesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.DTOs
{
    public record ReportePenalizacionesDTO
    {
        public int TotalPenalizaciones { get; set; }
        public double MontoTotal { get; set; }
        public List<DetallePenalizacionDTO> DetallesPenalizaciones { get; set; } = [];


    }
}
