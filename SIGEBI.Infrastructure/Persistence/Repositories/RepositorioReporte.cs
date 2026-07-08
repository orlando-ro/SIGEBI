using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using SIGEBI.Application.DTOs.ReportesDTO;
using SIGEBI.Domain.Enums;


namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    public class RepositorioReporte : IRepositorioReporte
    {
        private readonly SIGEBIDbContext _context;
        public RepositorioReporte(SIGEBIDbContext context) 
        {
            _context = context;
        }

        public async Task<ReportePenalizacionesDTO> ObtenerPenalizacionesAsync(DateTime FechaInicio, DateTime FechaFin)
        {
            var penalizaciones = await _context.Penalizaciones
                 .Include(p => p.Usuario)
                 .Where(p => p.FechaEmision >= FechaInicio && p.FechaEmision <= FechaFin)
                 .ToListAsync();

            return new ReportePenalizacionesDTO
            {
                TotalPenalizaciones = penalizaciones.Count,
                MontoTotal = penalizaciones.Sum(p => p.Monto),
                DetallesPenalizaciones = penalizaciones.Select(p => new DetallePenalizacionDTO
                {
                    IdUsuario = p.IdUsuario,
                    Motivo = p.Motivo,
                    Monto = p.Monto,
                    Fecha = p.FechaEmision,
                    Pagada = p.Pagada
                    


                }).ToList()


            };
        }

        public async Task<ReporteInventarioResponseDTO> ObtenerReporteInventarioAsync()
        {
            var Ejemplares = await _context.Ejemplares
                 .Include(e => e.Libro)
                 .ThenInclude(l => l.Categoria)
                 .ToListAsync();

            return new ReporteInventarioResponseDTO
            {
                TotalRecursos = Ejemplares.Count,
                RecursoDisponibles = Ejemplares.Count(e => e.Estado == EstadoEjemplar.Disponible),
                RecursosPrestados = Ejemplares.Count(e => e.Estado == EstadoEjemplar.Prestado),
                RecursosDaniados = Ejemplares.Count(e => e.Estado == EstadoEjemplar.FueraDeServicio),

                Recursos = Ejemplares.Select(e => new DetalleInventarioDTO
                {

                    Codigo = e.CodigoFisico,
                    Titulo = e.Libro != null ? e.Libro.Titulo : string.Empty,
                    Categoria = e.Libro?.Categoria != null ? e.Libro.Categoria.Nombre : string.Empty,
                    Estado = e.Estado.ToString()

                }).ToList()

            };
        }

        public async Task<ReportePrestamosResponseDTO> ObtenerReportesPrestamosAsync(DateTime FechaInicio, DateTime FechaFin)
        {
            var prestamos = await _context.Prestamos
                .Include(p => p.EjemplaresAprestar)
                    .ThenInclude(e => e.Libro)
                .Where(p => p.FechaInicio >= FechaInicio &&
                            p.FechaInicio <= FechaFin)
                .ToListAsync();

            var devoluciones = await _context.Devoluciones
                .Where(d => d.FechaDevolucion >= FechaInicio &&
                            d.FechaDevolucion <= FechaFin)
                .ToListAsync();

            return new ReportePrestamosResponseDTO
            {
                TotalPrestamos = prestamos.Count,

                PrestamosDevueltosATiempo = prestamos.Count(p =>
                    p.Estado == "Devuelto" &&
                    devoluciones.Any(d =>
                        d.IdPrestamo == p.IdPrestamo &&
                        d.FechaDevolucion <= p.FechaVencimiento)),

                PrestamosVencidos = prestamos.Count(p =>
                    p.Estado == "Activo" &&
                    DateTime.Now > p.FechaVencimiento),

                prestamos = prestamos
                    .SelectMany(p => p.EjemplaresAprestar.Select(e =>
                    {
                        var devolucion = devoluciones
                            .FirstOrDefault(d => d.IdPrestamo == p.IdPrestamo);

                        return new DetallesPrestamoDTO
                        {
                            IdPrestamo = p.IdPrestamo,
                            IdRecurso = e.ISBN,
                            FechaPrestamo = p.FechaInicio,
                            FechaDevolucion = devolucion?.FechaDevolucion,
                            Estado = p.Estado
                        };
                    }))
                    .ToList()
            };
        }

        public async Task<ReporteCatalogoResponseDTO> ObtenerReporteUsoCatalogoAsync(DateTime FechaInicio, DateTime FechaFin)
        {
            var prestamos = await _context.Prestamos
                 .Include(p => p.EjemplaresAprestar)
                     .ThenInclude(e => e.Libro)
                         .ThenInclude(l => l.Categoria)
                 .Where(p => p.FechaInicio >= FechaInicio &&
                             p.FechaInicio <= FechaFin)
                 .ToListAsync();

            var ejemplaresPrestados = prestamos
                .SelectMany(p => p.EjemplaresAprestar)
                .Where(e => e.Libro != null)
                .ToList();

            return new ReporteCatalogoResponseDTO
            {
                RecursosMasSolicitados = ejemplaresPrestados
                    .GroupBy(e => new
                    {
                        e.ISBN,
                        Titulo = e.Libro!.Titulo
                    })
                    .Select(g => new RecursoMasSolicitadosDTO
                    {
                        RecursoId = g.Key.ISBN,
                        titulo = g.Key.Titulo,
                        CantidadSolicitudes = g.Count()
                    })
                    .OrderByDescending(r => r.CantidadSolicitudes)
                    .ToList(),

                DemandaCategorias = ejemplaresPrestados
                    .GroupBy(e => e.Libro!.Categoria != null
                        ? e.Libro.Categoria.Nombre
                        : "Sin categoría")
                    .Select(g => new DemandaCategoriaDTO
                    {
                        Categoria = g.Key,
                        CantidadSolicitada = g.Count()
                    })
                    .OrderByDescending(c => c.CantidadSolicitada)
                    .ToList()
            };
        }
    }
}
