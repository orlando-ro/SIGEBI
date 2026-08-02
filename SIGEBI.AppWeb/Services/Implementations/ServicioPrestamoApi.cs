using SIGEBI.AppWeb.Models.DTOs.Prestamos;
using System.Net.Http.Json;
using SIGEBI.AppWeb.Services.Interfaces;

namespace SIGEBI.AppWeb.Services
{
    
    public class ServicioPrestamoApi : IServicioPrestamoApi
    {
        private readonly HttpClient _httpClient;
        public ServicioPrestamoApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PrestamoResponseDTO>> ObtenerPrestamosPorUsuarioAsync(string identificador)
        {
            var response = await _httpClient.GetAsync($"prestamos/activos/usuario/{identificador}");

            if (response.IsSuccessStatusCode)
            {
                var prestamos = await response.Content.ReadFromJsonAsync<List<PrestamoResponseDTO>>();
                return prestamos ?? new List<PrestamoResponseDTO>();
            }

            await ApiHelper.ProcesarErrorApiAsync(response);
            return new List<PrestamoResponseDTO>();
        }
    }
}