using System.Text.Json.Serialization;

namespace SIGEBI.AppEscritorio.DTOs.Auth
{
    public class LoginResponseDTO
    {
        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; }
        [JsonPropertyName("matricula")]
        public string? Matricula { get; set; }
        [JsonPropertyName("numeroEmpleado")]
        public string? NumeroEmpleado { get; set; }
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
        [JsonPropertyName("tipoUsuario")]
        public string TipoUsuario { get; set; } = string.Empty;
        [JsonPropertyName("estado")]
        public string Estado { get; set; } = string.Empty;
        [JsonPropertyName("habilitadoParaPrestamos")]
        public bool HabilitadoParaPrestamos { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;
    }
}