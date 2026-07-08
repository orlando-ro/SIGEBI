namespace SIGEBI.Application.DTOs
{
    public record PenalizacionResponseDTO
    {
        public int IdPenalizacion { get; set; }

        public double Monto { get; set; }

        public string Motivo { get; set; } = string.Empty;

        public DateTime FechaEmision { get; set; }

        public bool Pagada { get; set; }

        public int IdUsuario { get; set; }

        public int? IdPrestamo { get; set; }

        public DateTime? FechaResolucion { get; set; }

        public int? IdUsuarioResolutor { get; set; }

        public string MotivoResolucion { get; set; } = string.Empty;
    }
}