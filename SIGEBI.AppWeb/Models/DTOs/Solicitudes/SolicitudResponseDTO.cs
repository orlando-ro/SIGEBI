namespace SIGEBI.AppWeb.Models.DTOs.Solicitudes
{
    public class SolicitudResponseDTO
    {
        public int IdSolicitud { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Estado { get; set; } = string.Empty;
        public List<string> ISBNs { get; set; } = new();
        public List<string> TitulosLibros { get; set; } = new();
    }
}
