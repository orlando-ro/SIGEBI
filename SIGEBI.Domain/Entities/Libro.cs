using System;
using System.Collections.Generic;
using System.Linq;
using SIGEBI.Domain.Enums;
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

        public int IdCategoria { get; set; }
        public virtual Categoria? Categoria { get; set; }

        public bool Activo { get; set; } = true;

        // la colección de ejemplares asociados a este libro
        public virtual ICollection<Ejemplar> Ejemplares { get; private set; } = new List<Ejemplar>();

        protected Libro() { } // Requerido por Entity Framework

        public Libro(string isbn, string titulo)
        {
            ISBN = isbn;
            Titulo = titulo;
        }

        public void AsignarImagen(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new NegocioExeption("La ruta de la imagen no puede estar vacia.");

            UrlImagen = url;
        }

        // el total de copias es la cantidad de ejemplares asociados a este libro, sin importar su estado físico
        public int CopiasTotales => Ejemplares.Count;

        // son los ejemplares que están disponibles para préstamo, su estado es "Disponible"
        public int CopiasDisponibles => Ejemplares.Count(e => e.Estado == EstadoEjemplar.Disponible);

        public bool EstaDisponible()
        {
            return CopiasDisponibles > 0;
        }

        // _________gestion de ejemplares_________

        public void AgregarEjemplar(Ejemplar ejemplar)
        {
            if (ejemplar == null)
                throw new NegocioExeption("No se puede registrar un ejemplar nulo.");

            Ejemplares.Add(ejemplar);
        }

        // -------------- actualizacion de libros --------------------
        public void ActualizarDatos(string titulo, string nombreAutor, int anioPublicacion, int idCategoria)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new NegocioExeption("El título del libro no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nombreAutor))
                throw new NegocioExeption("El nombre del autor no puede estar vacío.");
            if (anioPublicacion <= 0)
                throw new NegocioExeption("El año de publicación debe ser un número positivo.");
            if (idCategoria <= 0)
                throw new NegocioExeption("La categoría del libro no es válida.");

            Titulo = titulo;
            NombreAutor = nombreAutor;
            AnioPublicacion = anioPublicacion;
            IdCategoria = idCategoria;
        }

        // -------------- verificacion de compromiso --------------------
        public bool TieneCompromisosActivos()
        {
            return Ejemplares.Any(e =>
                e.Estado == EstadoEjemplar.Prestado ||
                e.Estado == EstadoEjemplar.Reservado);
        }

        // -------------- desactivacion de libros --------------------
        public void Desactivar()
        {
            if (TieneCompromisosActivos())
                throw new NegocioExeption("No se puede retirar el recurso bibliográfico porque tiene copias en préstamo o reservadas.");

            Activo = false;
        }
    }
}