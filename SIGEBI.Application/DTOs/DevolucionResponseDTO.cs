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
        public bool GeneroPenalizacion { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
    }
}
