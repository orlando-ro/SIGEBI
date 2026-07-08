using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepositorioNotificacion : IBaseRepository<Notificacion>
    {
        // trae todo el historial de notificaciones de un usuario
        Task<IEnumerable<Notificacion>> ObtenerPorUsuarioAsync(int idUsuario);

        // traae solo las notificaciones que tienen Leida == false
        Task<IEnumerable<Notificacion>> ObtenerNoLeidasPorUsuarioAsync(int idUsuario);

        // trae todo el historial completo
        Task<IEnumerable<Notificacion>> ObtenerTodoElHistorialAsync();
    }
}