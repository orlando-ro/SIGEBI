using SIGEBI.AppWeb.Models.DTOs.Usuarios;
using System.Threading.Tasks;

namespace SIGEBI.AppWeb.Services.Interfaces
{
    public interface IServicioUsuarioApi
    {
        Task CambiarPropiaPasswordAsync(string identificador, PasswordUpdateDTO dto);
    }
}