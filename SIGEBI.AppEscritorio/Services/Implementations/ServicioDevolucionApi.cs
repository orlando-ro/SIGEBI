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

        public async Task<List<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorUsuarioAsync(string identificador)
        {
            var response = await _httpClient.GetAsync($"Devoluciones/consultar/devoluciones/usuario/{identificador}");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<List<DevolucionResponseDTO>>() ?? new();
        }

        public async Task<List<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorRecursoAsync(string isbnLibro)
        {
            var response = await _httpClient.GetAsync($"Devoluciones/consultar/devoluciones/recurso/{isbnLibro}");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<List<DevolucionResponseDTO>>() ?? new();
        }

        public async Task<List<DevolucionResponseDTO>> ConsultarHistorialCompletoAsync()
        {
            var response = await _httpClient.GetAsync("Devoluciones/consultar/devoluciones/todas");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<List<DevolucionResponseDTO>>() ?? new();
        }
    }
}