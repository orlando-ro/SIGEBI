using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public class PenalizacionResponseDTO
    {
        public int IdPenalizacion { get; set; }
        public double Monto { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public DateTime FechaEmision { get; set; }
        public bool Pagada { get; set; }

        public string IdUsuario { get; set; } = string.Empty;
    }
}
