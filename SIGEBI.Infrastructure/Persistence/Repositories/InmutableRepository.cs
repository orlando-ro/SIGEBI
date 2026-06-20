using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    public class InmutableRepository<T> : IInmutableRepository<T> where T : class
    {
        protected readonly SIGEBIDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public InmutableRepository(SIGEBIDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> ObtenerPorIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> ObtenerTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AgregarAsync(T entidad)
        {
            await _dbSet.AddAsync(entidad);
            await _context.SaveChangesAsync();
        }
    }
}
