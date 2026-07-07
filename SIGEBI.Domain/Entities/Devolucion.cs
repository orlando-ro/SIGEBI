using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
    public class Devolucion
    {
        public int IdDevolucion { get; set; }

        
        public DateTime FechaDevolucion { get; private set; }
        public CondicionDevolucion CondicionLibro { get; private set; } // Ej: "Buen estado", "Dañado", "Extraviado"
        public string Observaciones { get; private set; }

        public int IdPrestamo { get; private set; }
        public Prestamo Prestamo { get; set; }

        
        protected Devolucion() { }

       
        public Devolucion(int idPrestamo, CondicionDevolucion condicionLibro, string observaciones = "")
        {
            if (idPrestamo <= 0)
                throw new NegocioExeption("La devolución debe estar asociada a un préstamo válido.");


            IdPrestamo = idPrestamo;
            CondicionLibro = condicionLibro;
            Observaciones = observaciones ?? "";
            FechaDevolucion = DateTime.Now;
        }

        
        public bool RequierePenalizacionPorDano()
        {
            
            return CondicionLibro == CondicionDevolucion.Dañado ||
                   CondicionLibro == CondicionDevolucion.Extraviado;
        }
    }
}
