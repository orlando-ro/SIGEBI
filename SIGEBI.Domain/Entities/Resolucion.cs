using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
    public abstract class Resolucion
    {
        public int IdResolucion { get; set; }
        public DateTime FechaResolucion { get; set; }

        public string IdBibliotecario { get; set; }
        public Usuario Bibliotecario { get; set; }

        public int IdSolicitud { get; set; }
        public Solicitud Solicitud { get; set; }
    }
}
