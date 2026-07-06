using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;

        public List<string> ISBNs { get; set; } = new();

        public List<string> TitulosLibros { get; set; } = new();
    }
}
