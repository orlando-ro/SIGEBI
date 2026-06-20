using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    internal class RepositorioDevoluciones : BaseRepository<Devolucion>, IRepositorioDevolucion
    {
        public RepositorioDevoluciones(SIGEBIDbContext context) : base(context) { }

        public async Task<Devolucion?> ObtenerPorPrestamoAsync(int IdPrestamo) {

            return await _dbSet.Include(d => d.Prestamo).FirstOrDefaultAsync(d => d.IdPrestamo == IdPrestamo);

        }

    }
}
