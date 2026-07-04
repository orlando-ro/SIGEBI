using SIGEBI.Domain.Entities;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepoPenalizacion : IBaseRepository<Penalizacion>
    {
        Task<IEnumerable<Penalizacion>> ObtenerPendientesPorUsuariosAsync(string MatriculaONumeroEmpleado);

        Task<Penalizacion?> ObtenerPendientePorIdYUsuarioAsync(
           int idPenalizacion,
           string matriculaONumeroEmpleado
       );

    }
}
