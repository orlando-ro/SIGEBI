namespace SIGEBI.AppWeb.Models.DTOs.Usuarios
{
    public class PasswordUpdateDTO
    {
        public string PasswordActual { get; set; } = string.Empty;
        public string NuevaPassword { get; set; } = string.Empty;
    }
}
