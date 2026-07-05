using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    internal interface IServiciosObtenerPorUsuarios
    {
        Task<Usuario> ObtenerUsuarioPorIdentificadorAsync(string matriculaONumeroEmpleado);

        Task<Usuario> ObtenerBibliotecarioAsync(string matriculaONumeroEmpleadoBibliotecario);
    }
}
