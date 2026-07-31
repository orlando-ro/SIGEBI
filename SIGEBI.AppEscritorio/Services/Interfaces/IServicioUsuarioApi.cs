using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEBI.AppEscritorio.DTOs.Usuarios;

namespace SIGEBI.AppEscritorio.Services.Interfaces
{
    public interface IServicioUsuarioApi
    {
        Task<IEnumerable<UsuarioResponseDTO>> ObtenerTodosAsync();
        Task<UsuarioResponseDTO?> ObtenerPorIdAsync(int id);
        Task<UsuarioResponseDTO?> ObtenerPorIdentificadorAsync(string identificador);
        Task<bool> RegistrarUsuarioAsync(UsuarioRequestDTO request);
        Task<bool> ActualizarUsuarioAsync(int id, UsuarioUpdateRequestDTO request);
        Task<bool> SuspenderUsuarioAsync(int id);
    }
}