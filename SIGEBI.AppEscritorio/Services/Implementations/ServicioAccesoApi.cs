using SIGEBI.AppEscritorio.DTOs.Auth;
using SIGEBI.AppEscritorio.Services.Interfaces;
using SIGEBI.AppEscritorio.Utils;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Implementations
{
    public class ServicioAccesoApi : IServicioAccesoApi
    {
        private readonly HttpClient _httpClient;

        public ServicioAccesoApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> IniciarSesionAsync(LoginRequestDTO credenciales)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Acceso/login", credenciales);

                if (!response.IsSuccessStatusCode)
                {
                    return false; 
                }

                var resultado = await response.Content.ReadFromJsonAsync<LoginResponseDTO>();

                if (resultado != null && !string.IsNullOrEmpty(resultado.Token))
                {
                    SessionManager.IniciarSesion(
                        resultado.IdUsuario,
                        resultado.Matricula,
                        resultado.NumeroEmpleado,
                        resultado.Nombre,
                        resultado.Email,
                        resultado.TipoUsuario,
                        resultado.Estado,
                        resultado.HabilitadoParaPrestamos,
                        resultado.Token
                    );
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}