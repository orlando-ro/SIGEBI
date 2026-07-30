using SIGEBI.AppWeb.Models.DTOs.Acceso;
using System.Text.Json;

namespace SIGEBI.AppWeb.Services
{
    public interface IServicioAccesoApi
    {
        Task<string> IniciarSesionAsync(LoginRequestDTO credenciales);
    }

    public class ServicioAccesoApi : IServicioAccesoApi
    {
        private readonly HttpClient _httpClient;

        public ServicioAccesoApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> IniciarSesionAsync(LoginRequestDTO credenciales)
        {
            var response = await _httpClient.PostAsJsonAsync("Acceso/login", credenciales);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error de autenticación: Verifica tus credenciales.");
            }

            var resultado = await response.Content.ReadFromJsonAsync<LoginResponseDTO>();

            if (resultado == null || string.IsNullOrEmpty(resultado.Token))
            {
                throw new Exception("El servidor no devolvió un token válido.");
            }

            return resultado.Token;
        }
    }
}