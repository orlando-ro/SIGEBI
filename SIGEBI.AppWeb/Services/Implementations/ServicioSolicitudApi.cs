using System.Net.Http.Json;
using SIGEBI.AppWeb.Models.DTOs.Solicitudes;
using SIGEBI.AppWeb.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.AppWeb.Services
{
    public class ServicioSolicitudApi : IServicioSolicitudApi
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

            await ApiHelper.ProcesarErrorApiAsync(respuesta);
            return new();
        }

        public async Task<List<SolicitudResponseDTO>> ConsultarMisSolicitudesPendientesAsync()
        {
           
            var respuesta = await _httpClient.GetAsync("Solicitudes/mis-pendientes");

            if (respuesta.IsSuccessStatusCode)
            {
                return await respuesta.Content.ReadFromJsonAsync<List<SolicitudResponseDTO>>() ?? new List<SolicitudResponseDTO>();
            }

            await ApiHelper.ProcesarErrorApiAsync(respuesta);
            return new List<SolicitudResponseDTO>();
        }
    }
}