using SIGEBI.AppEscritorio.DTOs.Penalizaciones;
using SIGEBI.AppEscritorio.Services.Helper;
using SIGEBI.AppEscritorio.Services.Interfaces;
using SIGEBI.AppEscritorio.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Implementations
{
    public class ServicioPenalizacionApi : IServicioPenalizacionApi
    {
        private readonly HttpClient _httpClient;

        public ServicioPenalizacionApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

       
        public async Task ProcesarPagoMultaAsync(int idPenalizacion, PenalizacionRequestDTO peticion)
        {
            var response = await _httpClient.PatchAsJsonAsync($"Penalizaciones/RegistrarPago/{idPenalizacion}", peticion);
            await ApiHelper.ProcesarErrorApiAsync(response);
        }

        public async Task<IEnumerable<PenalizacionResponseDTO>> ObtenerPendientesPorUsuariosAsync(string MatriculaONumeroEmpleado)
        {
            var response = await _httpClient.GetAsync($"Penalizaciones/Pendientes/Usuario/{MatriculaONumeroEmpleado}");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<List<PenalizacionResponseDTO>>() ?? new();
        }

        public async Task<IEnumerable<PenalizacionResponseDTO>> ObtenerTodasPendientesAsync()
        {
            var response = await _httpClient.GetAsync("Penalizaciones/Pendientes/Todas");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<List<PenalizacionResponseDTO>>() ?? new();
        }
    }
}