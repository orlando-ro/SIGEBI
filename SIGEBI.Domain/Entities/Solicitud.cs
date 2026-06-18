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

        // El estado ahora está protegido con private set
        public string Estado { get; private set; }

        // Relaciones protegidas
        public string IdUsuario { get; private set; }
        public Usuario Usuario { get; set; }
        public ICollection<Libro> LibrosSolicitados { get; private set; } = new List<Libro>();

        // Historial de resolución (Aprobación o Rechazo)
        public Resolucion Resolucion { get; private set; }

        // Constructor vacío requerido por Entity Framework
        protected Solicitud() { }

        // Constructor para garantizar que la solicitud nazca en un estado válido
        public Solicitud(string idUsuario, List<Libro> librosSolicitados)
        {
            if (string.IsNullOrWhiteSpace(idUsuario))
                throw new NegocioExeption("La solicitud debe estar asociada a un usuario válido.");

            if (librosSolicitados == null || !librosSolicitados.Any())
                throw new NegocioExeption("La solicitud debe contener al menos un libro.");

            IdUsuario = idUsuario;
            FechaSolicitud = DateTime.Now;
            Estado = "Pendiente"; // Toda solicitud nace como pendiente
            LibrosSolicitados = librosSolicitados;
        }

        // Reglas de negocio (Métodos de Dominio)
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
