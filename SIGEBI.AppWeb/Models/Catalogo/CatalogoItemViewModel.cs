namespace SIGEBI.AppWeb.Models.Catalogo
{
    public class CatalogoItemViewModel
    {
        public string ISBN { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string NombreAutor { get; set; } = string.Empty;
        public string NombreCategoria { get; set; } = string.Empty;
        public int AnioPublicacion { get; set; }
        public int CopiasDisponibles { get; set; }
        public string? UrlImagen { get; set; }
    }
}