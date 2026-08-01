using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using SIGEBI.AppEscritorio.DTOs.Categorias;
using SIGEBI.AppEscritorio.Services.Interfaces;

namespace SIGEBI.AppEscritorio.Services.Implementations
{
    public class ServicioCategoriaApi : IServicioCategoriaApi
    {
        private readonly HttpClient _httpClient;

        public ServicioCategoriaApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoriaResponseDTO>> ConsultarTodasAsync()
        {
            try
            {
                var resultado = await _httpClient.GetFromJsonAsync<IEnumerable<CategoriaResponseDTO>>("Categoria");
                return resultado ?? new List<CategoriaResponseDTO>();
            }
            catch { return new List<CategoriaResponseDTO>(); }
        }

        public async Task<bool> RegistrarCategoriaAsync(CategoriaRequestDTO request)
        {
            var response = await _httpClient.PostAsJsonAsync("Categoria/registrar", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ActualizarCategoriaAsync(int id, CategoriaRequestDTO request)
        {
            var response = await _httpClient.PutAsJsonAsync($"Categoria/{id}", request);
            return response.IsSuccessStatusCode;
        }
    }
}