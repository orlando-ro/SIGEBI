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
        public string CondicionLibro { get; private set; } // Ej: "Buen estado", "Dañado", "Extraviado"
        public string Observaciones { get; private set; }

        public int IdPrestamo { get; private set; }
        public Prestamo Prestamo { get; set; }

        
        protected Devolucion() { }

       
        public Devolucion(int idPrestamo, string condicionLibro, string observaciones = "")
        {
            if (idPrestamo <= 0)
                throw new NegocioExeption("La devolución debe estar asociada a un préstamo válido.");

            if (string.IsNullOrWhiteSpace(condicionLibro))
                throw new NegocioExeption("Se debe especificar la condición física del recurso devuelto.");

            IdPrestamo = idPrestamo;
            CondicionLibro = condicionLibro;
            Observaciones = observaciones ?? "";
            FechaDevolucion = DateTime.Now;
        }

        
        public bool RequierePenalizacionPorDano()
        {
            
            return CondicionLibro.Equals("Dañado", StringComparison.OrdinalIgnoreCase) ||
                   CondicionLibro.Equals("Extraviado", StringComparison.OrdinalIgnoreCase);
        }
    }
}
