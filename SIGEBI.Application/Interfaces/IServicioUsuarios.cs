using SIGEBI.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioUsuarios
    {
        // modifican
        Task RegistrarUsuarioAsync(UsuarioRequestDTO dto, int idResponsable);
        Task SuspenderUsuarioPorIdentificadorAsync(string identificador, int idResponsable);
        Task SuspenderUsuarioAsync(int idUsuario, int idResponsable);
        Task ActualizarUsuarioAsync(int idUsuario, UsuarioUpdateRequestDTO dto, int idResponsable);
        Task ActualizarPorIdentificadorAsync(string identificador, UsuarioUpdateRequestDTO dto, int idResponsable);
        Task CambiarPropiaPasswordAsync(string identificador, PasswordUpdateDTO dto, int idResponsable);

        // solo lectura
        Task<UsuarioResponseDTO?> ObtenerPorMatriculaONumeroEmpleadoAsync(string identificador);
        Task<IEnumerable<UsuarioResponseDTO>> ConsultarTodosAsync();
        Task<UsuarioResponseDTO?> ObtenerUsuarioPorIdAsync(int idUsuario);
    }
}