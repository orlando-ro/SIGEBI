using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public record SolicitudResponseDTO
    {
        public int IdSolicitud { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Estado { get; set; } = string.Empty;

        public int IdUsuario { get; set; }

        public string NombreUsuarioSolicitante { get; set; } = string.Empty;

        public string? Matricula { get; set; } = string.Empty;

        public string? NumeroEmpleado { get; set; } = string.Empty;

        public List<Libro> ISBN { get; set; } = new();
        public List<string> TitulosLibros { get; set; } = new();
    }
}
