using SIGEBI.AppWeb.Models.DTOs.Catalogo;
using SIGEBI.AppWeb.Services.Interfaces;

namespace SIGEBI.AppWeb.Services
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
            return await _httpClient.GetFromJsonAsync<IEnumerable<LibroResponseDTO>>("Catalogo")
                   ?? new List<LibroResponseDTO>();
        }

        public async Task<LibroResponseDTO?> BuscarPorIsbnAsync(string isbn)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<LibroResponseDTO>($"Catalogo/{isbn}");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null; // El libro no existe
            }
        }

        public async Task<IEnumerable<LibroResponseDTO>> ConsultarCatalogoAsync(FiltroCatalogoDTO filtros)
        {
            var query = new List<string>();

            if (!string.IsNullOrEmpty(filtros.Titulo)) query.Add($"Titulo={filtros.Titulo}");
            if (!string.IsNullOrEmpty(filtros.NombreAutor)) query.Add($"NombreAutor={filtros.NombreAutor}");
            if (filtros.IdCategoria.HasValue) query.Add($"IdCategoria={filtros.IdCategoria}");
            if (filtros.SoloDisponibles) query.Add($"SoloDisponibles=true");

            string queryString = query.Count > 0 ? "?" + string.Join("&", query) : "";

            return await _httpClient.GetFromJsonAsync<IEnumerable<LibroResponseDTO>>($"Catalogo/buscar{queryString}")
                   ?? new List<LibroResponseDTO>();
        }

        public async Task<IEnumerable<CategoriaResponseDTO>> ObtenerCategoriasAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CategoriaResponseDTO>>("Categoria")
                   ?? new List<CategoriaResponseDTO>();
        }
    }
}