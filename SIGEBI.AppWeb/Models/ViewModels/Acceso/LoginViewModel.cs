using System.ComponentModel.DataAnnotations;

namespace SIGEBI.AppWeb.Models.Acceso
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Debe ingresar su matrícula o número de empleado.")]
        [Display(Name = "Matrícula o Número de Empleado")]
        public string Identificador { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}