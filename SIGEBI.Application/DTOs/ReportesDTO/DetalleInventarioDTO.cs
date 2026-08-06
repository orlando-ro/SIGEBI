namespace SIGEBI.Application.DTOs.ReportesDTO
{
    public record DetalleInventarioDTO
    {
       
        public string Titulo { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}