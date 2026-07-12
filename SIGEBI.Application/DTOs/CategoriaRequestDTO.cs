using System.ComponentModel.DataAnnotations;

namespace SIGEBI.Application.DTOs
{
    public class CategoriaRequestDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
    }
}