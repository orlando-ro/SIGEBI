using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using SIGEBI.AppEscritorio.DTOs.Categorias;
using SIGEBI.AppEscritorio.Services.Interfaces;
using SIGEBI.AppEscritorio.Services.Helper;

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
            var response = await _httpClient.GetAsync("Categoria");

            await response.ProcesarErrorApiAsync();

            var resultado = await response.Content.ReadFromJsonAsync<IEnumerable<CategoriaResponseDTO>>();
            return resultado ?? new List<CategoriaResponseDTO>();
        }

        public async Task<bool> RegistrarCategoriaAsync(CategoriaRequestDTO request)
        {
            var response = await _httpClient.PostAsJsonAsync("Categoria/registrar", request);

            await response.ProcesarErrorApiAsync();

            return true;
        }

        public async Task<bool> ActualizarCategoriaAsync(int id, CategoriaRequestDTO request)
        {
            var response = await _httpClient.PutAsJsonAsync($"Categoria/{id}", request);

            await response.ProcesarErrorApiAsync();

            return true;
        }

        public async Task<bool> EliminarAsync(int idCategoria)
        {
            var response = await _httpClient.DeleteAsync($"Categoria/{idCategoria}");

            await response.ProcesarErrorApiAsync();

            return true;
        }
    }
}