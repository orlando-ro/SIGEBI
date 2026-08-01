using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using SIGEBI.AppEscritorio.DTOs.Catalogo;
using SIGEBI.AppEscritorio.Services.Interfaces;

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
            try
            {
                var resultado = await _httpClient.GetFromJsonAsync<IEnumerable<LibroResponseDTO>>("Catalogo");
                return resultado ?? new List<LibroResponseDTO>();
            }
            catch { return new List<LibroResponseDTO>(); }
        }

        public async Task<LibroResponseDTO?> BuscarPorIsbnAsync(string isbn)
        {
            try { return await _httpClient.GetFromJsonAsync<LibroResponseDTO>($"Catalogo/{isbn}"); }
            catch { return null; }
        }

        public async Task<bool> ActualizarLibroAsync(string isbn, LibroUpdateDTO request)
        {
            var response = await _httpClient.PutAsJsonAsync($"Catalogo/{isbn}", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DesactivarLibroAsync(string isbn)
        {
            var response = await _httpClient.PutAsJsonAsync($"Catalogo/{isbn}/desactivar", (object?)null);
            return response.IsSuccessStatusCode;
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

            // Si el usuario selecciono una foto, se adjunta al form
            if (!string.IsNullOrEmpty(rutaImagen) && File.Exists(rutaImagen))
            {
                var fileStream = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read);
                var streamContent = new StreamContent(fileStream);
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                content.Add(streamContent, "Imagen", Path.GetFileName(rutaImagen));
            }

            var response = await _httpClient.PostAsync("Catalogo/registrar", content);
            return response.IsSuccessStatusCode;
        }
    }
}