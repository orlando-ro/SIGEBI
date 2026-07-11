using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Services
{
    public class ServicioPoliticaNegocio : IServicioPoliticaNegocio
    {
        public int ObtenerLimitePrestamosPorTipoUsuario(Usuario usuario)
        {
            if (usuario is Docente)
                return 5;

            if (usuario is Estudiante)
                return 3;

            return 2;
        }
    }
}
