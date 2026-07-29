namespace SIGEBI.AppWeb.Models.DTOs.Prestamos
{
    public class PrestamoResponseDTO
    {
        public int IdPrestamo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Estado { get; set; } = string.Empty;
        public bool EstaVencido { get; set; }
        public int DiasRetraso { get; set; }
    }
}
