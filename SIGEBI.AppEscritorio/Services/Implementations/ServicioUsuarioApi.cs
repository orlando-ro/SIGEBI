using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using SIGEBI.AppEscritorio.DTOs.Usuarios;
using SIGEBI.AppEscritorio.Services.Interfaces;
using SIGEBI.AppEscritorio.Utils;
using SIGEBI.AppEscritorio.Services.Helper;

namespace SIGEBI.AppEscritorio.Services.Implementations
{
    public class ServicioUsuarioApi : IServicioUsuarioApi
    {
        private readonly HttpClient _httpClient;

        public ServicioUsuarioApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private void ConfigurarAutenticacion()
        {
            if (SessionManager.IsLoggedIn)
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", SessionManager.Token);
            }
        }

        public async Task<IEnumerable<UsuarioResponseDTO>> ObtenerTodosAsync()
        {
            var response = await _httpClient.GetAsync("Usuario");
            await response.ProcesarErrorApiAsync();

            var resultado = await response.Content.ReadFromJsonAsync<IEnumerable<UsuarioResponseDTO>>();
            return resultado ?? new List<UsuarioResponseDTO>();
        }

        public async Task<UsuarioResponseDTO?> ObtenerPorIdAsync(int id)
        {
            ConfigurarAutenticacion();
            var response = await _httpClient.GetAsync($"Usuario/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;

            await response.ProcesarErrorApiAsync();
            return await response.Content.ReadFromJsonAsync<UsuarioResponseDTO>();
        }

        public async Task<UsuarioResponseDTO?> ObtenerPorIdentificadorAsync(string identificador)
        {
            ConfigurarAutenticacion();
            var response = await _httpClient.GetAsync($"Usuario/identificador/{identificador}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;

            await response.ProcesarErrorApiAsync();
            return await response.Content.ReadFromJsonAsync<UsuarioResponseDTO>();
        }

        public async Task<bool> RegistrarUsuarioAsync(UsuarioRequestDTO request)
        {
            ConfigurarAutenticacion();
            var response = await _httpClient.PostAsJsonAsync("Usuario/registrar", request);

            await response.ProcesarErrorApiAsync();
            return true;
        }

        public async Task<bool> ActualizarUsuarioAsync(int id, UsuarioUpdateRequestDTO request)
        {
            ConfigurarAutenticacion();
            var response = await _httpClient.PutAsJsonAsync($"Usuario/{id}", request);

            await response.ProcesarErrorApiAsync();
            return true;
        }

        public async Task<bool> SuspenderUsuarioAsync(int id)
        {
            ConfigurarAutenticacion();
            var response = await _httpClient.PutAsJsonAsync($"Usuario/{id}/suspender", (object?)null);

            await response.ProcesarErrorApiAsync();
            return true;
        }
    }
}