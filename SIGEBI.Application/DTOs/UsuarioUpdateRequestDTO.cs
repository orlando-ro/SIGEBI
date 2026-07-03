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
        [Required(ErrorMessage = "El identificador es obligatorio.")]
        public string IdUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido.")]
        public string Email { get; set; } = string.Empty;

        // campos opcionales por si cambiaron de matricula o numero de empleado
        public string? Matricula { get; set; }
        public string? NumeroEmpleado { get; set; }
    }
}