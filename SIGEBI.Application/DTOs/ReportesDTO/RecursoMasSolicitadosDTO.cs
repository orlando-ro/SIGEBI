namespace SIGEBI.Application.DTOs.ReportesDTO
{
    public record RecursoMasSolicitadosDTO
    {
        
        public string Titulo { get; set; } = string.Empty;
        public int CantidadSolicitudes { get; set; }
    }
}