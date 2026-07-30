using System.Text.Json.Serialization;

namespace SIGEBI.AppEscritorio.DTOs.Auth
{
    public class LoginRequestDTO
    {
        public string Identificador { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}