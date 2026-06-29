using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public class UsuarioRequestDTO
    {
        [Required(ErrorMessage = "El ID/Matrícula del usuario es obligatorio.")]
        public string IdUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del usuario es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe especificar el tipo de usuario (Ej: Estudiante, Docente).")]
        public string TipoUsuario { get; set; } = string.Empty;

        // los campos sigtes. no son Required porque dependen del TipoUsuario
        public string Matricula { get; set; } = string.Empty;
        public string NumeroEmpleado { get; set; } = string.Empty;
    }
}