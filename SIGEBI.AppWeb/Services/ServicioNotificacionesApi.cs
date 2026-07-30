using SIGEBI.AppWeb.Models.DTOs.Notificaciones;

namespace SIGEBI.AppWeb.Services
{
    public interface IServicioNotificacionesApi
    {
        Task<IEnumerable<NotificacionResponseDTO>> ObtenerPendientesAsync();
        Task<bool> MarcarComoLeidaAsync(int id);
    }

    public class ServicioNotificacionesApi : IServicioNotificacionesApi
    {
        private readonly HttpClient _httpClient;

        public ServicioNotificacionesApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<NotificacionResponseDTO>> ObtenerPendientesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<NotificacionResponseDTO>>("Notificaciones/pendientes")
                   ?? new List<NotificacionResponseDTO>();
        }

        public async Task<bool> MarcarComoLeidaAsync(int id)
        {
            var response = await _httpClient.PutAsync($"Notificaciones/{id}/leer", null);
            return response.IsSuccessStatusCode;
        }
    }
}