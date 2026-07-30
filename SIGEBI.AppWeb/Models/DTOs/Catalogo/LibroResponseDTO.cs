namespace SIGEBI.AppWeb.Models.DTOs.Catalogo
{
    public class LibroResponseDTO
    {
        public string ISBN { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string NombreAutor { get; set; } = string.Empty;
        public int AnioPublicacion { get; set; }
        public int CopiasDisponibles { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public string? UrlImagen { get; set; }
    }
}