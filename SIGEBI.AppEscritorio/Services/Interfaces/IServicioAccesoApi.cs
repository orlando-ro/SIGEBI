using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEBI.AppEscritorio.DTOs.Auth;

namespace SIGEBI.AppEscritorio.Services.Interfaces
{
    public interface IServicioAccesoApi
    {
        Task<bool> IniciarSesionAsync(LoginRequestDTO credenciales);
    }
}