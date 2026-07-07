using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Domain.Entities
{
    public class Ejemplar
    {
        public int IdEjemplar { get; private set; } // ID autoincrementable
        public string CodigoFisico { get; private set; } = string.Empty; // Ej: "ISBN-01", "ISBN-02"
        public EstadoEjemplar Estado { get; private set; }

        // llave foranea para conectarlo con el Libro
        public string ISBN { get; private set; } = string.Empty;
        public virtual Libro? Libro { get; private set; }

        protected Ejemplar() { } // Requerido por Entity Framework

        public Ejemplar(string isbn, string codigoFisico)
        {
            ISBN = isbn;
            CodigoFisico = codigoFisico;
            Estado = EstadoEjemplar.Disponible; // todo ejemplar nuevo nace disponible
        }


        // metodos de rich domain model

        public void HabilitarParaPrestamo()
        {
            Estado = EstadoEjemplar.Disponible;
        }

        public void MarcarComoFueraDeServicio()
        {
            Estado = EstadoEjemplar.FueraDeServicio;
        }

        public void MarcarComoReservado()
        {
            // solo se puede reservar si esta en la biblioteca y sin asignar
            if (Estado != EstadoEjemplar.Disponible)
                throw new NegocioExeption($"El ejemplar {CodigoFisico} no está disponible para ser reservado.");

            Estado = EstadoEjemplar.Reservado;
        }

        public void AsignarAPrestamo()
        {
            // el sistema permite prestar un ejemplar si está disponible (Disponible) 
            //o si el usuario lo tiene reservado (Reservado). En cualquier otro estado, no se puede prestar.
            if (Estado != EstadoEjemplar.Disponible && Estado != EstadoEjemplar.Reservado)
                throw new NegocioExeption($"El ejemplar {CodigoFisico} no puede ser prestado en su estado actual ({Estado}).");

            Estado = EstadoEjemplar.Prestado;
        }
    }
}