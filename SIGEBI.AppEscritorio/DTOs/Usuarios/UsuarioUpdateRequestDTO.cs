using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace SIGEBI.AppEscritorio.DTOs.Usuarios
{
    public class UsuarioUpdateRequestDTO
    {
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("matricula")]
        public string? Matricula { get; set; }

        [JsonPropertyName("numeroEmpleado")]
        public string? NumeroEmpleado { get; set; }

        [JsonPropertyName("estado")]
        public string? Estado { get; set; }
    }
}