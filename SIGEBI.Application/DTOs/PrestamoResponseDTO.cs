using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public class PrestamoResponseDTO
    {
        public int IdPrestamo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Estado { get; set; } = string.Empty;

        
        public int DiasRetraso { get; set; }
        public bool EstaVencido => DiasRetraso > 0;

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;

        public List<string> TitulosLibros { get; set; } = new List<string>();
    }
}
