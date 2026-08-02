using SIGEBI.AppEscritorio.DTOs.Prestamos;
using SIGEBI.AppEscritorio.Services.Helper;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Implementations
{
    public class ServicioPrestamoApi : IServicioPrestamoApi
    {
        private readonly HttpClient _Httpclient;

        public ServicioPrestamoApi(HttpClient httpclient)
        {
            _Httpclient = httpclient;
        }

        public async Task<PrestamoResponseDTO?> AprobarYCrearPrestamoAsync(PrestamoRequestDTO peticion)
        {
            var response = await _Httpclient.PostAsJsonAsync("Prestamos/aprobar", peticion);
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<PrestamoResponseDTO>();
        }

        public async Task<List<PrestamoResponseDTO>> ConsultarHistorialPrestamosPorRecursoAsync(string isbnLibro)
        {
            
            var response = await _Httpclient.GetAsync($"Prestamos/historial/recurso/{isbnLibro}");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<List<PrestamoResponseDTO>>() ?? new();
        }

        public async Task<List<PrestamoResponseDTO>> ConsultarHistorialPrestamosPorUsuarioAsync(string identificador)
        {
            var response = await _Httpclient.GetAsync($"Prestamos/historial/usuario/{identificador}");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<List<PrestamoResponseDTO>>() ?? new();
        }

        public async Task<List<PrestamoResponseDTO>> ConsultarPrestamosActivosPorRecursoAsync(string isbnLibro)
        {
            var response = await _Httpclient.GetAsync($"Prestamos/activos/recurso/{isbnLibro}");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<List<PrestamoResponseDTO>>() ?? new();
        }

        public async Task<List<PrestamoResponseDTO>> ConsultarPrestamosActivosPorUsuarioAsync(string identificador)
        {
            var response = await _Httpclient.GetAsync($"Prestamos/activos/usuario/{identificador}");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<List<PrestamoResponseDTO>>() ?? new();
        }

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarTodosAsync()
        {
            var response = await _Httpclient.GetAsync("Prestamos/activos");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<List<PrestamoResponseDTO>>() ?? new();
        }

       
        public async Task<List<PrestamoResponseDTO>> ConsultarHistorialCompletoAsync()
        {
            var response = await _Httpclient.GetAsync("Prestamos/historial/todos");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<List<PrestamoResponseDTO>>() ?? new();
        }
    }
}