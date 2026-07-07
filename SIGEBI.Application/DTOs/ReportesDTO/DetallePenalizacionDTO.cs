using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.DTOs.ReportesDTO
{
    public record DetallePenalizacionDTO
    {
        public int IdUsuario {get; set;}

        public string motivo { get; set; }

        public double monto { get; set; }
        public DateTime Fecha { get; set; }
        public bool pagada { get; set; }


    }
}
