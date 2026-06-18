using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        // una categoria puede tener varios libros
        public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}