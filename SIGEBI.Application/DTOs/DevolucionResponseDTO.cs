using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public class DevolucionResponseDTO
    {
        public int IdDevolucion { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public string CondicionLibro { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;

        public int IdPrestamo { get; set; }

        // Propiedades de ayuda para la UI

        public string idusuario { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string IdBibliotecario { get; set; } = string.Empty;
        public bool GeneroPenalizacion { get; set; }
        public int DiasRetraso { get; set; }

        public List<string> TitulosLibros { get; set; } = new();



    }
}
