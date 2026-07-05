using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Application.Interfaces
{
    
    public interface IUsuarios : IBaseRepository<Usuario>
    {
        
        Task<Usuario?> ObtenerUsuarioConDetallesAsync(int idUsuario);

        Task<IEnumerable<Usuario>> ObtenerTodosConDetallesAsync();
        Task<Usuario?> ObtenerPorMatriculaONumeroEmpleadoAsync(string identificador);

        // dejamos el obtener por email para validar el login 
        Task<Usuario?> ObtenerPorEmailAsync(string email);
    }
}
