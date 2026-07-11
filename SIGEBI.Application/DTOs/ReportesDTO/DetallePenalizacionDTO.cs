using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEBI.Domain.Enums;

namespace SIGEBI.Application.DTOs.ReportesDTO
{
    public record DetallePenalizacionDTO
    {
        public int IdUsuario {get; set;}

        public string? Motivo { get; set; }

        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public bool Pagada { get; set; }


    }
}
