using System.Collections.Generic;
using System.Threading.Tasks;
using SIGEBI.Application.DTOs;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioCategoria
    {
        Task RegistrarCategoriaAsync(CategoriaRequestDTO dto, int idResponsable);

        Task ActualizarCategoriaAsync(int idCategoria, CategoriaRequestDTO dto, int idResponsable);
        Task<IEnumerable<CategoriaResponseDTO>> ConsultarTodasAsync();
        Task<CategoriaResponseDTO?> ObtenerPorIdAsync(int idCategoria);
        Task EliminarCategoriaAsync(int idCategoria, int idResponsable);
    }
}