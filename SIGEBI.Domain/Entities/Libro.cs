using System;
using System.Collections.Generic;
using System.Text;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Domain.Entities
{
    public class Libro
    {
        
        public string ISBN { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string NombreAutor { get; set; } = string.Empty;
        public int AnioPublicacion { get; set; }

        public string? UrlImagen { get; private set; }

        
        public int CopiasTotales { get; set; }
        public int CopiasDisponibles { get; set; }

        
        public int IdCategoria { get; set; }
        public virtual Categoria? Categoria { get; set; }

        protected Libro() { } // este constructor es necesario para el EF Core

        public Libro(string isbn, string titulo) {

            ISBN = isbn;
            Titulo = titulo;

        }


        public void AsignarImagen(string url) {

            if (string.IsNullOrWhiteSpace(url))
                throw new NegocioExeption(" La ruta de la imagen no puede estar vacia. ");

            UrlImagen = url;
        }

        

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

        public bool EstaDispinible() {

            if (CopiasDisponibles <= 0) return false;

            return true;
        }
    }
}
