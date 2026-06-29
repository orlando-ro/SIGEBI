using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.DTOs
{
    public class UsuarioResponseDTO
    {
        public string IdUsuario { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string TipoUsuario { get; set; } = string.Empty;
        public bool HabilitadoParaPrestamos { get; set; }
    }
}