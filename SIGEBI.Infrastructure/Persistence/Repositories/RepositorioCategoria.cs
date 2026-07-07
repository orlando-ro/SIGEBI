using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Infrastructure.Repositories
{
    namespace SIGEBI.Infrastructure.Repositories
    {
        public class RepositorioCategoria : BaseRepository<Categoria>, IRepositorioCategoria
        {
            public RepositorioCategoria(SIGEBIDbContext context) : base(context)
            {
            }

            // se ejecuta la busqueda en la base de datos para obtener la categoria por nombre
            public async Task<Categoria?> ObtenerPorNombreAsync(string nombre)
            {
                return await _context.Categorias
                    .FirstOrDefaultAsync(c => c.Nombre.ToLower() == nombre.ToLower());
            }
        }
    }
}