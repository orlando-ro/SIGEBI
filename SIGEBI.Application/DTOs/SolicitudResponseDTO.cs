using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public class SolicitudResponseDTO
    {
        public int IdSolicitud { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Estado { get; set; } = string.Empty;

        public int IdUsuario { get; set; } 

        // En lugar de devolver las entidades Libro completas, 
        // a la interfaz gráfica normalmente solo le importan los títulos.
        public List<string> TitulosLibros { get; set; } = new List<string>();
    }
}
