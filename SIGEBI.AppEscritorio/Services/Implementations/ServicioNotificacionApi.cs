using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using SIGEBI.AppEscritorio.Models;
using SIGEBI.AppEscritorio.Services.Helper;

namespace SIGEBI.AppEscritorio.Services
{
    public class ServicioNotificacionApi : IServicioNotificacionApi
    {
        private readonly HttpClient _httpClient;

        public ServicioNotificacionApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<NotificacionResponseDTO>> ObtenerPendientesAsync()
        {
            var response = await _httpClient.GetAsync("Notificaciones/pendientes");

            await response.ProcesarErrorApiAsync();

            return await response.Content.ReadFromJsonAsync<IEnumerable<NotificacionResponseDTO>>()
                   ?? Array.Empty<NotificacionResponseDTO>();
        }

        public async Task<bool> MarcarComoLeidaAsync(int id)
        {
            var response = await _httpClient.PutAsync($"Notificaciones/{id}/leer", null);

            await response.ProcesarErrorApiAsync();
            return true;
        }

        public async Task<IEnumerable<NotificacionResponseDTO>> ConsultarHistorialGlobalAsync()
        {
            var response = await _httpClient.GetAsync("Notificaciones/historial");

            await response.ProcesarErrorApiAsync();

            return await response.Content.ReadFromJsonAsync<IEnumerable<NotificacionResponseDTO>>()
                   ?? Array.Empty<NotificacionResponseDTO>();
        }

        public async Task<bool> TriggerVencimientosAsync(int diasAntelacion = 3)
        {
            var response = await _httpClient.PostAsync($"Notificaciones/trigger-vencimientos?diasAntelacion={diasAntelacion}", null);

            await response.ProcesarErrorApiAsync();
            return true;
        }
    }
}