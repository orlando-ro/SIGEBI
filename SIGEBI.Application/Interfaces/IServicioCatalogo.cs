using System.Collections.Generic;
using System.Threading.Tasks;
using SIGEBI.Application.DTOs;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioCatalogo
    {
        Task RegistrarLibroAsync(LibroRequestDTO dto);
        Task<LibroResponseDTO?> BuscarPorIsbnAsync(string isbn);
        Task<IEnumerable<LibroResponseDTO>> ConsultarTodoAsync();
    }
}