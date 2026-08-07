using SIGEBI.AppWeb.Models.DTOs.Penalizaciones;

namespace SIGEBI.AppWeb.Services.Interfaces
{
    public interface IServicioPenalizacionesApi
    {
        Task<List<PenalizacionesResponse>> ObtenerPenalizacionesPendientesPorUsuario(string matriculaONumeroEmpleado);

        Task<List<PenalizacionesResponse>> ObtenerTodasPenalizacionesPendientes();
    }
}
