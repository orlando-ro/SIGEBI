using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioJwt
    {
        string GenerarToken(int idUsuario, string email, string rol);
    }
}