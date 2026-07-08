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
        public async Task<Usuario?> ObtenerUsuarioConDetallesAsync(int idUsuario)
        {
            
            return await _dbSet
                .Include(u => u.Notificaciones)
                .Include(u => u.Penalizaciones)
                .Include(u => u.Prestamos)
                .Include(u => u.Solicitudes)
                .FirstOrDefaultAsync(u => u.IdUsuario == idUsuario);
        }

        

        public async Task<IEnumerable<Usuario>> ObtenerTodosConDetallesAsync()
        {
            return await _dbSet
                .Include(u => u.Notificaciones)
                .Include(u => u.Penalizaciones)
                .Include(u => u.Prestamos)
                .Include(u => u.Solicitudes)
                .ToListAsync();

        }

        public async Task<Usuario?> ObtenerPorMatriculaONumeroEmpleadoAsync(string identificador)
        {
            if (string.IsNullOrWhiteSpace(identificador))
                return null;
            string valor = identificador.Trim();

            var UsuarioPorNumeroEmpleado = await _context.Usuarios
                .Where(u => u.NumeroEmpleado == valor)
                .ToArrayAsync();

            var UsuariosPorMatricula = await _context.Usuarios
                .OfType<Estudiante>()
                .Where(e => e.Matricula == valor)
                .Cast<Usuario>()
                .ToListAsync();

            var UsuariosEncontrados = UsuarioPorNumeroEmpleado
                .Concat(UsuariosPorMatricula)
                .GroupBy(u => u.IdUsuario)
                .Select(g => g.First())
                .ToList();

            if (UsuariosEncontrados.Count > 1)
                throw new InvalidOperationException("El identificador coincide con más de un usuario.");

            return UsuariosEncontrados.FirstOrDefault();
        }

        public async Task<Usuario?> ObtenerPorEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            string emailNormalizado = email.Trim();

            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == emailNormalizado);
        }
    }
}
