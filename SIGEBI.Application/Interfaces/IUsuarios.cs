using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Application.Interfaces
{
    // hereda de ibaserepository
    public interface IUsuarios : IBaseRepository<Usuario>
    {
        // metodo para cargar al usuario con todas sus listas relacionadas
        // necesario para penalizaciones en dominio
        Task<Usuario?> ObtenerUsuarioConDetallesAsync(string idUsuario);
    }
}
