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
    public class RepositorioLibro : BaseRepository<Libro>, IRepositorioLibro
    {
        public RepositorioLibro(SIGEBIDbContext context) : base(context)
        {
        }

        public async Task<Libro?> ObtenerLibroConCategoriaAsync(string isbn)
        {
            //JOIN con la tabla Categorías
            return await _dbSet
                .Include(l => l.Categoria)
                .FirstOrDefaultAsync(l => l.ISBN == isbn);
        }

        public async Task<Libro?> BuscarLibroPorIsbnAsync(string isbn) {

            return await _dbSet.FirstOrDefaultAsync(l => l.ISBN == isbn);
        }
    }

}
