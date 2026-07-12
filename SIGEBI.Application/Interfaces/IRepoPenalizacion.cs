using SIGEBI.Domain.Entities;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepoPenalizacion : IBaseRepository<Penalizacion>
    {
        Task<IEnumerable<Penalizacion>> ObtenerPendientesPorUsuarioAsync(int idUsuario);

        Task<Penalizacion?> ObtenerPendientePorIdYUsuarioAsync(
           int idPenalizacion,
           string matriculaONumeroEmpleado
       );

    }
}
