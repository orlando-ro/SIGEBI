using System.ComponentModel.DataAnnotations;

namespace SIGEBI.Application.DTOs
{
    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "El Email es obligatorio.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; } = string.Empty;
    }
}