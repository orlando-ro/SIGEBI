using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Services
{
    public class ServicioObtenerBibliotecario : IServiciosObtenerBibliotecario
    {
        public readonly IUsuarios _usuario;

        public ServicioObtenerBibliotecario(IUsuarios usuario) {

            _usuario = usuario;
        }
        

        public async Task<Usuario> ObtenerBibliotecarioAsync(string matriculaONumeroEmpleadoBibliotecario)
        {
            var usuario = await _usuario.ObtenerPorMatriculaONumeroEmpleadoAsync(matriculaONumeroEmpleadoBibliotecario);

            if (usuario is not PersonalBibliotecario)
                throw new NegocioExeption("Solo el personal bibliotecario puede aprobar, rechazar o registrar devoluciones.");

            return usuario;
        }
    }
}
