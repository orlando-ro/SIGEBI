using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEBI.AppEscritorio.DTOs.Categorias;

namespace SIGEBI.AppEscritorio.Services.Interfaces
{
    public interface IServicioCategoriaApi
    {
        Task<IEnumerable<CategoriaResponseDTO>> ConsultarTodasAsync();
        Task<bool> RegistrarCategoriaAsync(CategoriaRequestDTO request);
        Task<bool> ActualizarCategoriaAsync(int id, CategoriaRequestDTO request);
        Task<bool> EliminarAsync(int idCategoria);
    }
}