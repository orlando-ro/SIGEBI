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
            try
            {
                // Hace un GET a la ruta base "Usuario"
                var resultado = await _httpClient.GetFromJsonAsync<IEnumerable<UsuarioResponseDTO>>("Usuario");
                return resultado ?? new List<UsuarioResponseDTO>();
            }
            catch
            {
                // En caso de error de conexión, devolvemos una lista vacía para que no se caiga la app
                return new List<UsuarioResponseDTO>();
            }
        }

        public async Task<UsuarioResponseDTO?> ObtenerPorIdAsync(int id)
        {
            ConfigurarAutenticacion();
            try
            {
                return await _httpClient.GetFromJsonAsync<UsuarioResponseDTO>($"Usuario/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<UsuarioResponseDTO?> ObtenerPorIdentificadorAsync(string identificador)
        {
            ConfigurarAutenticacion();
            try
            {
                return await _httpClient.GetFromJsonAsync<UsuarioResponseDTO>($"Usuario/identificador/{identificador}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> RegistrarUsuarioAsync(UsuarioRequestDTO request)
        {
            ConfigurarAutenticacion();
            var response = await _httpClient.PostAsJsonAsync("Usuario/registrar", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ActualizarUsuarioAsync(int id, UsuarioUpdateRequestDTO request)
        {
            ConfigurarAutenticacion();
            var response = await _httpClient.PutAsJsonAsync($"Usuario/{id}", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> SuspenderUsuarioAsync(int id)
        {
            ConfigurarAutenticacion();
            var response = await _httpClient.PutAsJsonAsync($"Usuario/{id}/suspender", (object?)null);
            return response.IsSuccessStatusCode;
        }
    }
}