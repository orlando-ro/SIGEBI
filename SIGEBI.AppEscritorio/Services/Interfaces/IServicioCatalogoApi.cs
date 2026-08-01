using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEBI.AppEscritorio.DTOs.Catalogo;

namespace SIGEBI.AppEscritorio.Services.Interfaces
{
    public interface IServicioCatalogoApi
    {
        Task<IEnumerable<LibroResponseDTO>> ConsultarTodosAsync();
        Task<LibroResponseDTO?> BuscarPorIsbnAsync(string isbn);
        Task<bool> ActualizarLibroAsync(string isbn, LibroUpdateDTO request);
        Task<bool> DesactivarLibroAsync(string isbn);

        Task<bool> RegistrarLibroAsync(string isbn, string titulo, string autor, int anio, int copias, int idCategoria, string? rutaImagen);
    }
}