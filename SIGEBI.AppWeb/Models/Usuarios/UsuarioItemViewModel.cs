namespace SIGEBI.AppWeb.Models.Usuarios
{
    public class UsuarioItemViewModel
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string TipoUsuario { get; set; } = string.Empty;

        // Propiedad calculada para mostrar en la tabla fácilmente
        public string Identificador => Matricula ?? NumeroEmpleado ?? "N/A";

        public string? Matricula { get; set; }
        public string? NumeroEmpleado { get; set; }
        public bool HabilitadoParaPrestamos { get; set; }
    }
}