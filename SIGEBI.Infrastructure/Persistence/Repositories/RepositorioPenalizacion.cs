using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Repositories;


namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    internal class RepositorioPenalizacion : BaseRepository<Penalizacion>, IRepoPenalizacion
    {
        public RepositorioPenalizacion(SIGEBIDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Penalizacion>> ObtenerPendientesPorUsuariosAsync(string matriculaONumeroEmpleado)
        {
            int idUsuario = await ObtenerIdUsuarioPorIdentificadorAsync(matriculaONumeroEmpleado);

            return await _dbSet
                .AsNoTracking()
                .Include(p => p.Usuario)
                .Where(p => p.IdUsuario == idUsuario && !p.Pagada)
                .ToListAsync();
        }

        public async Task<Penalizacion?> ObtenerPendientePorIdYUsuarioAsync(
            int idPenalizacion,
            string matriculaONumeroEmpleado)
        {
            int idUsuario = await ObtenerIdUsuarioPorIdentificadorAsync(matriculaONumeroEmpleado);

            return await _dbSet
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(p =>
                    p.IdPenalizacion == idPenalizacion &&
                    p.IdUsuario == idUsuario &&
                    !p.Pagada
                );
        }

        private async Task<int> ObtenerIdUsuarioPorIdentificadorAsync(string matriculaONumeroEmpleado)
        {
            if (string.IsNullOrWhiteSpace(matriculaONumeroEmpleado))
                throw new ArgumentException("Debe indicar la matrícula o el número de empleado.");

            string identificador = matriculaONumeroEmpleado.Trim();

            var idsPorNumeroEmpleado = await _context.Usuarios
                .Where(u => u.NumeroEmpleado == identificador)
                .Select(u => u.IdUsuario)
                .ToListAsync();

            var idsPorMatricula = await _context.Usuarios
                .OfType<Estudiante>()
                .Where(e => e.Matricula == identificador)
                .Select(e => e.IdUsuario)
                .ToListAsync();

            var idsUsuarios = idsPorNumeroEmpleado
                .Concat(idsPorMatricula)
                .Distinct()
                .ToList();

            if (!idsUsuarios.Any())
                throw new InvalidOperationException("No existe un usuario con esa matrícula o número de empleado.");

            if (idsUsuarios.Count > 1)
                throw new InvalidOperationException("El identificador coincide con más de un usuario.");

            return idsUsuarios.First();
        }
    }
}

