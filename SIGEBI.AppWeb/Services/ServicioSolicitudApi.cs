using System.Net.Http.Json;
using System.Text.Json; // Agregamos esta librería para leer el JSON
using SIGEBI.AppWeb.Models.DTOs.Solicitudes;

namespace SIGEBI.AppWeb.Services
{
    public class ServicioSolicitudApi
    {
        private readonly HttpClient _httpClient;

        public ServicioSolicitudApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SolicitudResponseDTO> CrearSolicitudAsync(SolicitudRequestDTO peticion)
        {
            var respuesta = await _httpClient.PostAsJsonAsync("Solicitudes/crear", peticion);

            if (respuesta.IsSuccessStatusCode)
            {
                return await respuesta.Content.ReadFromJsonAsync<SolicitudResponseDTO>() ?? new();
            }

            var error = await respuesta.Content.ReadAsStringAsync();

            try
            {
                
                var json = JsonDocument.Parse(error);

                
                if (json.RootElement.TryGetProperty("mensaje", out var mensajeProp))
                {
                    
                    throw new Exception(mensajeProp.GetString());
                }

               
                throw new Exception("Error al procesar la solicitud.");
            }
            catch (JsonException)
            {
                
                throw new Exception(string.IsNullOrEmpty(error) ? "Error al procesar en la API." : error);
            }
            
        }
    }
}