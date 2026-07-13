using System.Collections.Generic;
using System.Threading.Tasks;
using SIGEBI.Application.DTOs;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioUsuarios
    {
        Task RegistrarUsuarioAsync(UsuarioRequestDTO dto);
        
        Task SuspenderUsuarioPorIdentificadorAsync(string identificador);

        Task SuspenderUsuarioAsync(int idUsuario);
        Task<UsuarioResponseDTO?> ObtenerPorMatriculaONumeroEmpleadoAsync(string identificador);
        Task<IEnumerable<UsuarioResponseDTO>> ConsultarTodosAsync();

        Task<UsuarioResponseDTO?> ObtenerUsuarioPorIdAsync(int idUsuario);

        Task ActualizarUsuarioAsync(int idUsuario, UsuarioUpdateRequestDTO dto);

        Task ActualizarPorIdentificadorAsync(string identificador, UsuarioUpdateRequestDTO dto);
    }

}