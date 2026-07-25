using System;

namespace SIGEBI.AppWeb.Models.Prestamos
{
    public class PrestamoItemViewModel
    {
        public int IdPrestamo { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string? Matricula { get; set; }
        public string? NumeroEmpleado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Estado { get; set; } = string.Empty;
        public int DiasRetraso { get; set; }
        public bool EstaVencido { get; set; }
    }
}