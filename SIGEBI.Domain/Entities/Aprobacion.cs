using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
    public class Aprobacion : Resolucion
    {
        public int? IdPrestamoGenerado { get; set; }
        public Prestamo? PrestamoGenerado { get; set; }

        protected Aprobacion() { }

        public Aprobacion(
           int idBibliotecario,
           int idSolicitud,
          int idPrestamoGenerado
          )
           : base(idBibliotecario, idSolicitud)
        {


           IdPrestamoGenerado = idPrestamoGenerado;
            
        }
    }
}
