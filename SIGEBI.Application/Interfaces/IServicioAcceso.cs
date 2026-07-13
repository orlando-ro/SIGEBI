using System.Threading.Tasks;
using SIGEBI.Application.DTOs;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioAcceso
    {

        Task ValidarElegibilidadPorIdentificadorAsync(string identificador);
        Task <LoginResponseDTO> LoginAsync(LoginRequestDTO request);
    }
}