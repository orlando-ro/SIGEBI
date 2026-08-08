using SIGEBI.AppWeb.Models.DTOs.Usuarios;
using System.Net.Http.Json;
using SIGEBI.AppWeb.Services.Interfaces;

namespace SIGEBI.AppWeb.Services
{
    public class ServicioUsuarioApi : IServicioUsuarioApi
    {
        private readonly HttpClient _httpClient;

        public ServicioUsuarioApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CambiarPropiaPasswordAsync(string identificador, PasswordUpdateDTO dto)
        {
            // Hacemos la petición PUT respetando tu enrutamiento
            var response = await _httpClient.PutAsJsonAsync($"Usuario/identificador/{identificador}/password", dto);

            if (!response.IsSuccessStatusCode)
            {
                // Leemos el mensaje que mandó la API (ej. "La contraseña actual es incorrecta")
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }
        }
    }
}