using System;

namespace SIGEBI.Application.DTOs.ReportesDTO
{
    public record DetallePenalizacionDTO
    {
        public string NombreUsuario { get; set; } = string.Empty; // En lugar de IdUsuario
        public string? Motivo { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public bool Pagada { get; set; }
    }
}