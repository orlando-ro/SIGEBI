using System.Collections.Generic;
using System.Threading.Tasks;
using SIGEBI.Application.DTOs;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioCategoria
    {
        Task RegistrarCategoriaAsync(CategoriaRequestDTO dto);
        Task<IEnumerable<CategoriaResponseDTO>> ConsultarTodasAsync();
    }
}