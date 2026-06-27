using SIGEBI.Application.DTOs;
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
    }
}
