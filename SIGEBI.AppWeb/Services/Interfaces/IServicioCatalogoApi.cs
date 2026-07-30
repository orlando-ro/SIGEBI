using SIGEBI.AppWeb.Models.DTOs.Catalogo;

namespace SIGEBI.AppWeb.Services.Interfaces
{
    public interface IServicioCatalogoApi
    {
        Task<IEnumerable<LibroResponseDTO>> ConsultarTodosAsync();
        Task<LibroResponseDTO?> BuscarPorIsbnAsync(string isbn);
        Task<IEnumerable<LibroResponseDTO>> ConsultarCatalogoAsync(FiltroCatalogoDTO filtros);

        Task<IEnumerable<CategoriaResponseDTO>> ObtenerCategoriasAsync();
    }
}
