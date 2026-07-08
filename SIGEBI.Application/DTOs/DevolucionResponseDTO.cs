namespace SIGEBI.Application.DTOs
{
    public record DevolucionResponseDTO
    {
        public int IdDevolucion { get; set; }

        public DateTime FechaDevolucion { get; set; }

        public string CondicionLibro { get; set; } = string.Empty;

        public string Observaciones { get; set; } = string.Empty;

        public int IdPrestamo { get; set; }

        public int IdUsuario { get; set; }

        public string NombreUsuario { get; set; } = string.Empty;

        public int IdBibliotecario { get; set; }

        public bool GeneroPenalizacion { get; set; }

        public int DiasRetraso { get; set; }

        public List<string> TitulosLibros { get; set; } = new();
    }
}
