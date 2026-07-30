using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SIGEBI.Application.DTOs
{
    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "El identificador es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debe ser el Correo de la institucion")]
        public string Identificador { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; } = string.Empty;
    }
}