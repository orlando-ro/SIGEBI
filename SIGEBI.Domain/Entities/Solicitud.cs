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

        
        public string? Estado { get; private set; }

        
        public int IdUsuario { get; private set; }
        public Usuario? Usuario { get; set; }
        public ICollection<Ejemplar> EjemplaresSolicitados { get; private set; } = new List<Ejemplar>();

        
        public Resolucion? Resolucion { get; private set; }

        
        protected Solicitud() { }

        
        public Solicitud(int idUsuario, List<Ejemplar> ejemplaresSolicitados)
        {
            if (idUsuario <= 0)
                throw new NegocioExeption("La solicitud debe estar asociada a un usuario válido.");

            if (ejemplaresSolicitados == null || !ejemplaresSolicitados.Any())
                throw new NegocioExeption("La solicitud debe contener al menos un libro.");

            IdUsuario = idUsuario;
            FechaSolicitud = DateTime.Now;
            Estado = "Pendiente";
            EjemplaresSolicitados = ejemplaresSolicitados;
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
