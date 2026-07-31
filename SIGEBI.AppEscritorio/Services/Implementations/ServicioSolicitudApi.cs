using SIGEBI.AppEscritorio.DTOs.Solicitudes;
using SIGEBI.AppEscritorio.Services.Interfaces;
using SIGEBI.AppEscritorio.Services.Helper;
using SIGEBI.AppEscritorio.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Implementations
{
    public class ServicioSolicitudApi : IServicioSolicitudApi
    {
        private readonly HttpClient _httpClient;

        public ServicioSolicitudApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task RechazarSolicitudAsync(RechazoSolicitudRequestDTO peticion)
        {
            var response = await _httpClient.PatchAsJsonAsync("Solicitudes/rechazar", peticion);
            await ApiHelper.ProcesarErrorApiAsync(response);
        }

        public async Task<SolicitudResponseDTO?> ObtenerPorIdAsync(int idSolicitud)
        {
            var response = await _httpClient.GetAsync($"Solicitudes/{idSolicitud}");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<SolicitudResponseDTO>();
        }

        public async Task<List<SolicitudResponseDTO>> ConsultarPendientesAsync()
        {
            var response = await _httpClient.GetAsync("Solicitudes/pendientes");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<List<SolicitudResponseDTO>>() ?? new();
        }

        public async Task<List<SolicitudResponseDTO>> ConsultarPorUsuarioAsync(string identificador)
        {
            var response = await _httpClient.GetAsync($"Solicitudes/usuario/{identificador}");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<List<SolicitudResponseDTO>>() ?? new();
        }
    }
}