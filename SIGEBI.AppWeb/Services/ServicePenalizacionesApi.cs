using SIGEBI.AppWeb.Models.DTOs.Penalizaciones;
using System.Net.Http.Json;

namespace SIGEBI.AppWeb.Services
{
    public class ServicePenalizacionesApi
    {
        private readonly HttpClient _httpClient;

        public ServicePenalizacionesApi(HttpClient httpClient) { 
        
            _httpClient = httpClient;
        }

        public async Task<List<PenalizacionesResponse>> ObtenerPenalizacionesPendientesPorUsuario(string matriculaONumeroEmpleado) {

            var respuesta = await _httpClient.GetAsync($"Penalizaciones/Pendientes/Usuario/{matriculaONumeroEmpleado}");

            if (respuesta.IsSuccessStatusCode) {

                var penalizaciones = await respuesta.Content.ReadFromJsonAsync<List<PenalizacionesResponse>>();
                return penalizaciones ?? new List<PenalizacionesResponse>();
            }
            
            return new List<PenalizacionesResponse>();
        }

    }
}
