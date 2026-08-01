using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using SIGEBI.AppEscritorio.Models;

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
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<NotificacionResponseDTO>>()
                       ?? Array.Empty<NotificacionResponseDTO>();
            }
            return Array.Empty<NotificacionResponseDTO>();
        }

        public async Task<bool> MarcarComoLeidaAsync(int id)
        {
            var response = await _httpClient.PutAsync($"Notificaciones/{id}/leer", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<NotificacionResponseDTO>> ConsultarHistorialGlobalAsync()
        {
            var response = await _httpClient.GetAsync("Notificaciones/historial");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<NotificacionResponseDTO>>()
                       ?? Array.Empty<NotificacionResponseDTO>();
            }
            return Array.Empty<NotificacionResponseDTO>();
        }

        public async Task<bool> TriggerVencimientosAsync(int diasAntelacion = 3)
        {
            var response = await _httpClient.PostAsync($"Notificaciones/trigger-vencimientos?diasAntelacion={diasAntelacion}", null);
            return response.IsSuccessStatusCode;
        }
    }
}