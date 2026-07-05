using SIGEBI.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
    public abstract class Resolucion
    {
        public int IdResolucion { get; set; }
        public DateTime FechaResolucion { get; set; }

        public int IdBibliotecario { get; set; }
        public Usuario Bibliotecario { get; set; }

        public int IdSolicitud { get; set; }
        public Solicitud Solicitud { get; set; }

        protected Resolucion() { }
        protected Resolucion(int idBibliotecario, int idSolicitud)
        {
            if (idBibliotecario <= 0)
                throw new NegocioExeption("La resolución debe estar asociada a un bibliotecario válido.");

            if (idSolicitud <= 0)
                throw new NegocioExeption("La resolución debe estar asociada a una solicitud válida.");

            IdBibliotecario = idBibliotecario;
            IdSolicitud = idSolicitud;
            FechaResolucion = DateTime.Now;
        }
    }
}
