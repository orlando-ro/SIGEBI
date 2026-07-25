using System.ComponentModel.DataAnnotations;

namespace SIGEBI.AppWeb.Models.Catalogo
{
    public class ActualizarLibroViewModel
    {
        public string ISBN { get; set; } = string.Empty;

        [Required(ErrorMessage = "El título del libro es obligatorio.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del autor es obligatorio.")]
        public string NombreAutor { get; set; } = string.Empty;

        [Required(ErrorMessage = "El año de publicación es obligatorio.")]
        public int AnioPublicacion { get; set; }

        [Required(ErrorMessage = "Debe especificar la categoría.")]
        public int IdCategoria { get; set; }
    }
}