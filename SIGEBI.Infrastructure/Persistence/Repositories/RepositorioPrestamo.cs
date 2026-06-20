using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    internal class RepositorioPrestamo : BaseRepository<Prestamo>, IRepositorioPrestamo
    {
        public RepositorioPrestamo(SIGEBIDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Prestamo>> ObtenerActivoPorUsuarioAsync(string idUsuario)
        {
            return await _dbSet
                .Where(p => p.IdUsuario == idUsuario && p.Estado == "Activo").ToListAsync();
        }

        public async Task<Prestamo?> obtenerPrestamoConDetalleAsync(int id)
        {
            return await _dbSet
               .Include(p => p.Libros)
               .Include(p => p.Usuario)
               .FirstOrDefaultAsync(p => p.IdPrestamo == id);
        }
    }
}
