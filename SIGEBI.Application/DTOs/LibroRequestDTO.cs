using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public class LibroRequestDTO
    {
        [Required(ErrorMessage = "El ISBN del libro es obligatorio.")]
        public string ISBN { get; set; } = string.Empty;

        [Required(ErrorMessage = "El título del libro es obligatorio.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del autor es obligatorio.")]
        public string NombreAutor { get; set; } = string.Empty;

        [Required(ErrorMessage = "El año de publicación es obligatorio.")]
        public int AnioPublicacion { get; set; }

        [Required(ErrorMessage = "Debe especificar la cantidad total de copias.")]
        public int CopiasTotales { get; set; }

        [Required(ErrorMessage = "Debe especificar el ID de la categoría a la que pertenece.")]
        public int IdCategoria { get; set; }
    }
}