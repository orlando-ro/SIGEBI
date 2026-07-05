using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SIGEBI.Application.DTOs
{
    public class UsuarioUpdateRequestDTO
    {

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido.")]
        public string Email { get; set; } = string.Empty;


        [StringLength(50, ErrorMessage = "La matricula no puede tener mas de 50 caracteres")]
        public string? Matricula { get; set; }
        [StringLength(50, ErrorMessage = "El numero de empleado no puede tener mas de 50 caracteres")]
        public string? NumeroEmpleado { get; set; }
    }
}