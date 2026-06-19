using System;
using System.Collections.Generic;
using System.Text;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Domain.Entities
{
    public class Libro
    {
        // id y datos basicos
        public string ISBN { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string NombreAutor { get; set; } = string.Empty;
        public int AnioPublicacion { get; set; }

        // control de inventario
        public int CopiasTotales { get; set; }
        public int CopiasDisponibles { get; set; }

        // llave foranea logica y navegacion solo para categoria
        public int IdCategoria { get; set; }
        public virtual Categoria? Categoria { get; set; }


        // reglas de negocio en dominio, puede cambiar si decidimos hacer toda la logica de negocios en servivios

        public void PrestarCopia()
        {
            if (CopiasDisponibles <= 0)
            {
                throw new NegocioExeption($"El libro '{Titulo}' no tiene copias disponibles para préstamo.");
            }
            CopiasDisponibles--;
        }

        public void DevolverCopia()
        {
            if (CopiasDisponibles >= CopiasTotales)
            {
                throw new NegocioExeption($"Inconsistencia: No se pueden devolver más copias de las totales registradas para el libro '{Titulo}'.");
            }
            CopiasDisponibles++;
        }

        public void IncrementarCopia()
        {
            CopiasDisponibles++;
            CopiasTotales++;
        }
    }
}
