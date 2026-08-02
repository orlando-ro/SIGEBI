using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SIGEBI.AppEscritorio.DTOs.Catalogo;
using SIGEBI.AppEscritorio.Services.Interfaces;
using SIGEBI.AppEscritorio.Services.Helper;

namespace SIGEBI.AppEscritorio.Services.Implementations
{
    public class ServicioCatalogoApi : IServicioCatalogoApi
    {
        private readonly HttpClient _httpClient;

        public ServicioCatalogoApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<LibroResponseDTO>> ConsultarTodosAsync()
        {
            var response = await _httpClient.GetAsync("Catalogo");
            await response.ProcesarErrorApiAsync();

            var resultado = await response.Content.ReadFromJsonAsync<IEnumerable<LibroResponseDTO>>();
            return resultado ?? new List<LibroResponseDTO>();
        }

        public async Task<LibroResponseDTO?> BuscarPorIsbnAsync(string isbn)
        {
            var response = await _httpClient.GetAsync($"Catalogo/{isbn}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            await response.ProcesarErrorApiAsync();
            return await response.Content.ReadFromJsonAsync<LibroResponseDTO>();
        }

        public async Task<bool> ActualizarLibroAsync(string isbn, LibroUpdateDTO request)
        {
            var response = await _httpClient.PutAsJsonAsync($"Catalogo/{isbn}", request);
            await response.ProcesarErrorApiAsync();
            return true;
        }

        public async Task<bool> DesactivarLibroAsync(string isbn)
        {
            var response = await _httpClient.PutAsJsonAsync($"Catalogo/{isbn}/desactivar", (object?)null);
            await response.ProcesarErrorApiAsync();
            return true;
        }

        public async Task<bool> RegistrarLibroAsync(string isbn, string titulo, string autor, int anio, int copias, int idCategoria, string? rutaImagen)
        {
            using var content = new MultipartFormDataContent();

            content.Add(new StringContent(isbn), "ISBN");
            content.Add(new StringContent(titulo), "Titulo");
            content.Add(new StringContent(autor), "NombreAutor");
            content.Add(new StringContent(anio.ToString()), "AnioPublicacion");
            content.Add(new StringContent(copias.ToString()), "CopiasTotales");
            content.Add(new StringContent(idCategoria.ToString()), "IdCategoria");

            if (!string.IsNullOrEmpty(rutaImagen) && File.Exists(rutaImagen))
            {
                var fileStream = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read);
                var streamContent = new StreamContent(fileStream);
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                content.Add(streamContent, "Imagen", Path.GetFileName(rutaImagen));
            }

            var response = await _httpClient.PostAsync("Catalogo/registrar", content);
            await response.ProcesarErrorApiAsync();
            return true;
        }
        public async Task<bool> AgregarEjemplaresAsync(string isbn, int cantidad)
        {
            var request = new { Cantidad = cantidad };

            var response = await _httpClient.PostAsJsonAsync($"Catalogo/{isbn}/ejemplares", request);

            await response.ProcesarErrorApiAsync();

            return true;
        }
    }
}