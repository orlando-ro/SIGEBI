using System;

namespace SIGEBI.AppWeb.Models.Penalizaciones
{
    public class PenalizacionItemViewModel
    {
        public int IdPenalizacion { get; set; }
        public double Monto { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public DateTime FechaEmision { get; set; }
        public bool Pagada { get; set; }
        public int? IdPrestamo { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Identificador { get; set; } = string.Empty;
    }
}