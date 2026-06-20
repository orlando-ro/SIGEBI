using SIGEBI.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
    public class Solicitud
    {
        public int IdSolicitud { get; set; }
        public DateTime FechaSolicitud { get; private set; }

        
        public string Estado { get; private set; }

        
        public string IdUsuario { get; private set; }
        public Usuario Usuario { get; set; }
        public ICollection<Libro> LibrosSolicitados { get; private set; } = new List<Libro>();

        
        public Resolucion Resolucion { get; private set; }

        
        protected Solicitud() { }

        
        public Solicitud(string idUsuario, List<Libro> librosSolicitados)
        {
            if (string.IsNullOrWhiteSpace(idUsuario))
                throw new NegocioExeption("La solicitud debe estar asociada a un usuario válido.");

            if (librosSolicitados == null || !librosSolicitados.Any())
                throw new NegocioExeption("La solicitud debe contener al menos un libro.");

            IdUsuario = idUsuario;
            FechaSolicitud = DateTime.Now;
            Estado = "Pendiente"; 
            LibrosSolicitados = librosSolicitados;
        }

        
        public void Aprobar()
        {
            if (Estado != "Pendiente")
                throw new NegocioExeption($"No se puede aprobar una solicitud que ya se encuentra en estado '{Estado}'.");

            Estado = "Aprobada";
        }

        public void Rechazar()
        {
            if (Estado != "Pendiente")
                throw new NegocioExeption($"No se puede rechazar una solicitud que ya se encuentra en estado '{Estado}'.");

            Estado = "Rechazada";
        }
    }
}
