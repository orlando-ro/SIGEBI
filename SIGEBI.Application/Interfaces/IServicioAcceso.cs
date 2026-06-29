using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioAcceso
    {
        Task ValidarElegibilidadUsuarioAsync(string idUsuario);
    }
}