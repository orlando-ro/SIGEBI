using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Persistence; 

namespace SIGEBI.Infrastructure.Repositories
{
    public class RepositorioUsuario : BaseRepository<Usuario>, IUsuarios
    {
        // Inyectamos el DbContext y se lo pasamos a la clase base
        public RepositorioUsuario(SIGEBIDbContext context) : base(context)
        {
        }

        // se implementa metodo especifico
        public async Task<Usuario?> ObtenerUsuarioConDetallesAsync(string idUsuario)
        {
            
            return await _dbSet
                .Include(u => u.Notificaciones)
                .Include(u => u.Penalizaciones)
                .FirstOrDefaultAsync(u => u.IdUsuario == idUsuario);
        }
    }
}
