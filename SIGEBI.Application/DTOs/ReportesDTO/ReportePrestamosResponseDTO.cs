using SIGEBI.Application.DTOs.ReportesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.DTOs
{
    public record ReportePrestamosResponseDTO
    {
        public int TotalPrestamos { get; set; }
        public int PrestamosDevueltosATiempo { get; set; }
        public int PrestamosVencidos { get; set; }
        public List<DetallesPrestamoDTO> prestamos { get; set; } = [];


    }
}
