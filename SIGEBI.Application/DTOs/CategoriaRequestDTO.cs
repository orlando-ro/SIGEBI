using System.ComponentModel.DataAnnotations;

namespace SIGEBI.Application.DTOs
{
    public class CategoriaRequestDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(255, ErrorMessage = "La descripción no puede exceder los 255 caracteres.")]
        public string? Descripcion { get; set; }
    }
}