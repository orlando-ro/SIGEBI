using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    public class RepositorioPrestamo : BaseRepository<Prestamo>, IRepositorioPrestamo
    {
        public RepositorioPrestamo(SIGEBIDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Prestamo>> ObtenerActivoPorUsuarioAsync(int idUsuario)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(p => p.IdPrestamo)
                .Include(p => p.IdUsuario)
                .Include(p => p.Libros)
                .Where(p => p.IdUsuario == idUsuario && p.Estado == "Activo").ToListAsync();
        }

        public async Task<IEnumerable<Prestamo>> ObtenerActivosPorRecursoAsync(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return new List<Prestamo>();

            string NormalizarIsbn = isbn.Trim();

            return await _dbSet
                .AsNoTracking()
                .Include(p => p.Libros)
                .Include(p => p.Usuario)
                .Where(p => p.Estado == "Activo" && p.Libros.Any(l => l.ISBN == isbn)).ToListAsync();
        }

        public async Task<IEnumerable<Prestamo>> ObtenerHistorialPorRecurso(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return new List<Prestamo>();

            string NormalizarIsbn = isbn.Trim();

            return await _dbSet
                .AsNoTracking()
                .Include(p => p.Libros)
                .Include(p => p.Usuario)
                .Where(p => p.Estado == "Activo" && p.Libros.Any(l => l.ISBN == NormalizarIsbn))
                .ToListAsync();
        }

        public async Task<IEnumerable<Prestamo>> ObtenerHistorialPorUsuarioAsync(int idUsuario)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(p => p.Libros)
                .Include(p => p.Usuario)
                .Where(p => p.IdUsuario == idUsuario)
                .OrderByDescending(p => p.FechaInicio)
                .ToListAsync();

        }

        public async Task<Prestamo?> obtenerPrestamoConDetalleAsync(int id)
        {
            return await _dbSet
                .AsNoTracking()
               .Include(p => p.IdPrestamo)
               .Include(p => p.Libros)
               .Include(p => p.Usuario)
               .FirstOrDefaultAsync(p => p.IdPrestamo == id);
        }
    }
}
