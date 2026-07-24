using System.ComponentModel.DataAnnotations;

namespace SIGEBI.AppWeb.Models.Categorias
{
    public class CategoriaFormViewModel
    {
        public int? IdCategoria { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(255, ErrorMessage = "La descripción no puede exceder los 255 caracteres.")]
        public string? Descripcion { get; set; }
    }
}