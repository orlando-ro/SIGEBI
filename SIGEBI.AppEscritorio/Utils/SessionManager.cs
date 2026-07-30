using System;

namespace SIGEBI.AppEscritorio.Utils
{
    public static class SessionManager
    {
        public static int IdUsuario { get; private set; }
        public static string Matricula { get; private set; } = string.Empty;
        public static string NumeroEmpleado { get; private set; } = string.Empty;
        public static string Nombre { get; private set; } = string.Empty;
        public static string Email { get; private set; } = string.Empty;
        public static string TipoUsuario { get; private set; } = string.Empty;
        public static string Estado { get; private set; } = string.Empty;
        public static bool HabilitadoParaPrestamos { get; private set; }

        public static string Token { get; private set; } = string.Empty;

        public static bool IsLoggedIn => !string.IsNullOrEmpty(Token);

        public static void IniciarSesion(
            int idUsuario,
            string matricula,
            string numeroEmpleado,
            string nombre,
            string email,
            string tipoUsuario,
            string estado,
            bool habilitadoParaPrestamos,
            string token)
        {
            IdUsuario = idUsuario;
            Matricula = matricula ?? string.Empty;
            NumeroEmpleado = numeroEmpleado ?? string.Empty;
            Nombre = nombre ?? string.Empty;
            Email = email ?? string.Empty;
            TipoUsuario = tipoUsuario ?? string.Empty;
            Estado = estado ?? string.Empty;
            HabilitadoParaPrestamos = habilitadoParaPrestamos;
            Token = token ?? string.Empty;
        }

        public static void CerrarSesion()
        {
            IdUsuario = 0;
            Matricula = string.Empty;
            NumeroEmpleado = string.Empty;
            Nombre = string.Empty;
            Email = string.Empty;
            TipoUsuario = string.Empty;
            Estado = string.Empty;
            HabilitadoParaPrestamos = false;
            Token = string.Empty;
        }
    }
}