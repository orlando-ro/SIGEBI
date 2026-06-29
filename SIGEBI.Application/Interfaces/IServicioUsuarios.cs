using System.Collections.Generic;
using System.Threading.Tasks;
using SIGEBI.Application.DTOs;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioUsuarios
    {
        Task RegistrarUsuarioAsync(UsuarioRequestDTO dto);
        Task SuspenderUsuarioAsync(string idUsuario);
        Task<UsuarioResponseDTO?> ObtenerUsuarioPorIdAsync(string idUsuario);
        Task<IEnumerable<UsuarioResponseDTO>> ConsultarTodosAsync();
    }
}