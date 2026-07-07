using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.DTOs.ReportesDTO
{
    public record DetallesPrestamoDTO
    {
        public int IdPrestamo { get; set; }
        public string IdRecurso { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string Estado { get; set; }

    }
}
