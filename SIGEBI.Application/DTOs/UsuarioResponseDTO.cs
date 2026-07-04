using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public class UsuarioResponseDTO
    {
        public int IdUsuario { get; set; } 
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string TipoUsuario { get; set; } = string.Empty;

        public string? Matricula { get; set; } 
        public string? NumeroEmpleado { get; set; }
        public bool HabilitadoParaPrestamos { get; set; }
    }
}