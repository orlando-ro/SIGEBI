using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
    public class Aprobacion : Resolucion
    {
        public int? IdPrestamoGenerado { get; set; }
        public Prestamo PrestamoGenerado { get; set; }
    }
}
