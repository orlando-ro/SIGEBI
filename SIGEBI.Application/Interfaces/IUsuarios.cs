using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Application.Interfaces
{
    // hereda de ibaserepository
    public interface IUsuarios : IBaseRepository<Usuario>
    {
        // metodo para cargar al usuario con todas sus listas relacionadas
        // necesario para penalizaciones en dominio
        Task<Usuario?> ObtenerUsuarioConDetallesAsync(string idUsuario);

        // metodo para obtener un usuario por email, es necesario para el login, ya que el email es unico y el usuario final no conoce su idUsuario
        Task<Usuario?> ObtenerPorEmailAsync(string email);

        // obtener por id secundarios para 
        Task<Estudiante?> ObtenerPorMatriculaAsync(string matricula);
        Task<Usuario?> ObtenerPorNumeroEmpleadoAsync(string numeroEmpleado);
    }
}
