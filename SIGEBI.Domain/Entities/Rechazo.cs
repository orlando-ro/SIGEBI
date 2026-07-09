using SIGEBI.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
     public class Rechazo : Resolucion
    {
        public string? MotivoRechazo { get; set; }

        protected Rechazo() { }
        

        public Rechazo(
            int idBibliotecario,
            int idSolicitud,
            string motivoRechazo)
            : base(idBibliotecario, idSolicitud)
        {
           

            MotivoRechazo = motivoRechazo.Trim();
        }

    }
}
