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


        Task<IEnumerable<Penalizacion>> ObtenerTodasPendientesAsync();

        Task<IEnumerable<Penalizacion>> ObtenerHistorialPorUsuarioAsync(int idUsuario);
        Task<IEnumerable<Penalizacion>> ObtenerHistorialCompletoAsync();
    }
}
