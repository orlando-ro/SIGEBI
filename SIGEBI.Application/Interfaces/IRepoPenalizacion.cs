using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepoPenalizacion : IBaseRepository<Penalizacion>
    {
        Task<IEnumerable<Penalizacion>> ObtenerPendientesPorUsuariosAsync(string IdUsuario);

    }
}
