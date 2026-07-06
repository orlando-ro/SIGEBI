using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.DTOs
{
    public record LoginResponseDTO
    {
        public int IdUsuario { get; set; } 
        public string? Matricula { get; set; }
        public string? NumeroEmpleado { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string TipoUsuario { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public bool HabilitadoParaPrestamos { get; set; }

        // a futur se podria usar jwt para generar un token de autenticacion y enviarlo al cliente, pero por ahora se esta pensando
    }
}
