using System.Net.Http.Json;
using SIGEBI.AppWeb.Models.DTOs.Solicitudes; 

namespace SIGEBI.AppWeb.Services
{
    public class ServicioSolicitudApi
    {
        private readonly HttpClient _httpClient;

        public ServicioSolicitudApi(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7001/");
        }

        public async Task<SolicitudResponseDTO> CrearSolicitudAsync(SolicitudRequestDTO peticion)
        {
            var respuesta = await _httpClient.PostAsJsonAsync("api/Solicitudes/crear", peticion);

            if (respuesta.IsSuccessStatusCode)
            {
                return await respuesta.Content.ReadFromJsonAsync<SolicitudResponseDTO>() ?? new(); 
            }

            var error = await respuesta.Content.ReadAsStringAsync();
            throw new Exception(string.IsNullOrEmpty(error) ? "Error al procesar en la API." : error);
        }

       
    }
}