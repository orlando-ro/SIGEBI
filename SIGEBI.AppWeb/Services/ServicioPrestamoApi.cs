using System.Net.Http;
using SIGEBI.AppWeb.Models.DTOs.Prestamos;

namespace SIGEBI.AppWeb.Services
{
    public class ServicioPrestamoApi
    {
        private readonly HttpClient _httpClient;
        public ServicioPrestamoApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<PrestamoResponseDTO>> ObtenerPrestamosPorUsuarioAsync(string identificador)
        {
            var response = await _httpClient.GetAsync($"api/prestamos/usuario/{identificador}");

            if(response.IsSuccessStatusCode) // si la respuesta es exitosa (código 200)
            {
                var prestamos = await response.Content.ReadFromJsonAsync<List<PrestamoResponseDTO>>(); // Deserialize the JSON response into a list of PrestamoResponseDTO
                return prestamos ?? new List<PrestamoResponseDTO>(); // si la deserialización falla, devuelve una lista vacía
            }
            
             
            return new List<PrestamoResponseDTO>();
        }
    }
}
