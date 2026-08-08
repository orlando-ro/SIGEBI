using System;
using System.Collections.Generic;

namespace SIGEBI.Application.DTOs
{
    public record PrestamoResponseDTO
    {
        
        public int IdPrestamo { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Estado { get; set; } = string.Empty;

        public int DiasRetraso { get; set; }
        public bool EstaVencido => DiasRetraso > 0;

        public string? Matricula { get; set; } = string.Empty;
        public string? NumeroEmpleado { get; set; } = string.Empty;

        public string NombreUsuario { get; set; } = string.Empty;

        public List<string> TitulosLibros { get; set; } = new();
    }
}