using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioDevolucion
    {
        Task ProcesarDevolucionAsync(DevolucionRequestDTO peticion, string idBibliotecario);

        Task<IEnumerable<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorUsuario(string IdUsuario);

        Task<IEnumerable<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorRecurso(string isbnLibro);
    }
}
