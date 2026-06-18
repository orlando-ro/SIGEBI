using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
    public class Solicitud
    {
        public int IdSolicitud { get; set; }
        public DateTime FechaSolicitud { get; set; }

        public string Estado { get; set; }

        
        public string IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Libro> LibrosSolicitados { get; set; } = new List<Libro>();

        public Resolucion Resolucion { get; set; }
    }
}
