namespace SIGEBI.AppWeb.Models.DTOs.Catalogo
{
    public class CategoriaResponseDTO
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
    }
}