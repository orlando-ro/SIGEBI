using System.ComponentModel.DataAnnotations;

namespace SIGEBI.AppWeb.Models.ViewModels.Perfil
{
    public class PerfilViewModel
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;

        public string EtiquetaIdentificador { get; set; } = string.Empty;
        public string ValorIdentificador { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña actual es obligatoria.")]
        public string PasswordActual { get; set; } = string.Empty;

        [Required(ErrorMessage = "La nueva contraseña es obligatoria.")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "La contraseña debe tener al menos 4 caracteres.")]
        public string NuevaPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe confirmar la nueva contraseña.")]
        [Compare("NuevaPassword", ErrorMessage = "Las contraseñas nuevas no coinciden.")]
        public string ConfirmarPassword { get; set; } = string.Empty;
    }
}