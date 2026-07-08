using System.Collections.Generic;
using System.Threading.Tasks;
using SIGEBI.Application.DTOs;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioCatalogo
    {
        Task RegistrarLibroAsync(LibroRequestDTO dto, int IdUsuarioResponsable);
        Task<LibroResponseDTO?> BuscarPorIsbnAsync(string isbn);
        Task<IEnumerable<LibroResponseDTO>> ConsultarTodoAsync();
        Task ActualizarLibroAsync(string isbn, LibroUpdateDTO dto, int idUsuarioResponsable);
        Task EliminarLibroAsync(string isbn, int idUsuarioResponsable);

        Task<IEnumerable<LibroCatalogoResponseDTO>> ConsultarCatalogoAsync(FiltroCatalogoDTO filtros);
    }
}