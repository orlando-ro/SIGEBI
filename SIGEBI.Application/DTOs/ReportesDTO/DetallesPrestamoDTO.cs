using System;
using System.Collections.Generic;

namespace SIGEBI.Application.DTOs.ReportesDTO
{
    public record DetallesPrestamoDTO
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public List<string> Libros { get; set; } = new List<string>(); // Lista para mostrarlos apilados
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}