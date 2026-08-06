using SIGEBI.AppEscritorio.DTOs.Devoluciones;
using SIGEBI.AppEscritorio.Services.Helper;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Implementations
{
    public class ServicioDevolucionApi : IServicioDevolucionApi
    {
        private readonly HttpClient _httpClient;

        public ServicioDevolucionApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DevolucionResponseDTO?> ProcesarDevolucionAsync(DevolucionRequestDTO devolucion)
        {
            var response = await _httpClient.PostAsJsonAsync("Devoluciones/Procesar/devolucion", devolucion);
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<DevolucionResponseDTO>();
        }

        public async Task<List<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorUsuarioAsync(string identificador, string condicion)
        {
            var response = await _httpClient.GetAsync($"Devoluciones/consultar/devoluciones/usuario/{identificador}?condicion={condicion}");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<List<DevolucionResponseDTO>>() ?? new();
        }

        public async Task<List<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorTituloLibroAsync(string tituloLibro, string condicion)
        {
            var response = await _httpClient.GetAsync($"Devoluciones/consultar/devoluciones/recurso/{tituloLibro}?condicion={condicion}");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<List<DevolucionResponseDTO>>() ?? new();
        }

        public async Task<List<DevolucionResponseDTO>> ConsultarHistorialCompletoAsync(string condicion)
        {
            var response = await _httpClient.GetAsync($"Devoluciones/consultar/devoluciones/todas?condicion={condicion}");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<List<DevolucionResponseDTO>>() ?? new();
        }
    }
}