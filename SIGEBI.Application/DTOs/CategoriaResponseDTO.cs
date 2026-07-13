namespace SIGEBI.Application.DTOs
{
    public record CategoriaResponseDTO
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
    }
}