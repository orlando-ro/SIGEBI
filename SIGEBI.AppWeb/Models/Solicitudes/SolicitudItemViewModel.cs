using System;
using System.Collections.Generic;

namespace SIGEBI.AppWeb.Models.Solicitudes
{
    public class SolicitudItemViewModel
    {
        public int IdSolicitud { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Estado { get; set; } = string.Empty;
        public string NombreUsuarioSolicitante { get; set; } = string.Empty;
        public string MatriculaONumeroEmpleado { get; set; } = string.Empty;
        public List<string> ISBNs { get; set; } = new();
        public List<string> TitulosLibros { get; set; } = new();
    }
}