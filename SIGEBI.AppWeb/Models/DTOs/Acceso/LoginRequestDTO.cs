namespace SIGEBI.AppWeb.Models.DTOs.Acceso
{
    public class LoginRequestDTO
    {
        public string Identificador { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}