namespace SIGEBI.AppWeb.Models.DTOs.Catalogo
{
    public class FiltroCatalogoDTO
    {
        public string? Titulo { get; set; }
        public string? NombreAutor { get; set; }
        public int? IdCategoria { get; set; }
        public bool SoloDisponibles { get; set; } = false;
    }
}