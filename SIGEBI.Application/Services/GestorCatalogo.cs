using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Application.Services
{
    public class GestorCatalogo : IServicioCatalogo
    {
        private readonly IRepositorioLibro _repositorioLibro;
        private readonly IServicioCategoria _servicioCategoria;
        private readonly IServicioAuditoria _servicioAuditoria;

        public GestorCatalogo(IRepositorioLibro repositorioLibro, IServicioCategoria servicioCategoria, IServicioAuditoria servicioAuditoria)
        {
            _repositorioLibro = repositorioLibro;
            _servicioCategoria = servicioCategoria;
            _servicioAuditoria = servicioAuditoria;
        }

        public async Task RegistrarLibroAsync(LibroRequestDTO dto, int IdUsuarioResponsable)
        {
            if (await _repositorioLibro.ObtenerPorIdAsync(dto.ISBN) != null)
                throw new NegocioExeption("El ISBN ya está registrado.");

            var categoria = await _servicioCategoria.ObtenerPorIdAsync(dto.IdCategoria);
            if (categoria == null)
                throw new NegocioExeption("La categoría no existe.");

            var libro = new Libro(dto.ISBN, dto.Titulo)
            {
                NombreAutor = dto.NombreAutor,
                AnioPublicacion = dto.AnioPublicacion,
                IdCategoria = dto.IdCategoria
            };

            for (int i = 1; i <= dto.CopiasTotales; i++)
            {
                string codigoFisico = $"{dto.ISBN}-{i:D2}";
                var ejemplar = new Ejemplar(dto.ISBN, codigoFisico);

                libro.AgregarEjemplar(ejemplar);
            }

            await _repositorioLibro.AgregarAsync(libro);

            await _servicioAuditoria.RegistrarAccionAsync(
                 idUsuario: IdUsuarioResponsable,
                 tipoAccion: "Creacion de libro y ejemplares",
                 entidadAfectada: "Libro/Ejemplar",
                 detalles: $"Se registró el libro: {libro.Titulo} con {dto.CopiasTotales} ejemplares físicos."
             );
        }

        public async Task<LibroResponseDTO?> BuscarPorIsbnAsync(string isbn)
        {
            var libro = await _repositorioLibro.ObtenerLibroConCategoriaAsync(isbn);
            if (libro == null) return null;

            return new LibroResponseDTO
            {
                ISBN = libro.ISBN,
                Titulo = libro.Titulo,
                NombreAutor = libro.NombreAutor,
                Categoria = libro.Categoria?.Nombre ?? "N/A"
            };
        }

        public async Task<IEnumerable<LibroResponseDTO>> ConsultarTodoAsync()
        {
            var libros = await _repositorioLibro.ObtenerTodosAsync();

            return libros.Select(l => new LibroResponseDTO
            {
                ISBN = l.ISBN,
                Titulo = l.Titulo,
                NombreAutor = l.NombreAutor,
                CopiasDisponibles = l.CopiasDisponibles,
                Categoria = "N/A"
            });
        }

        public async Task ActualizarLibroAsync(string isbn, LibroUpdateDTO dto, int idUsuarioResponsable)
        {
            var libro = await _repositorioLibro.ObtenerPorIdAsync(isbn);
            if (libro == null)
                throw new NegocioExeption($"No se encontró ningún libro con el ISBN {isbn}.");

            if (libro.IdCategoria != dto.IdCategoria)
            {
                var categoria = await _servicioCategoria.ObtenerPorIdAsync(dto.IdCategoria);
                if (categoria == null)
                    throw new NegocioExeption("La nueva categoría asignada no existe en el sistema.");
            }

            var cambios = new List<string>();

            if (libro.Titulo != dto.Titulo)
                cambios.Add($"Título: '{libro.Titulo}' -> '{dto.Titulo}'");

            if (libro.NombreAutor != dto.NombreAutor)
                cambios.Add($"Autor: '{libro.NombreAutor}' -> '{dto.NombreAutor}'");

            if (libro.AnioPublicacion != dto.AnioPublicacion)
                cambios.Add($"Año: {libro.AnioPublicacion} -> {dto.AnioPublicacion}");

            if (libro.IdCategoria != dto.IdCategoria)
                cambios.Add($"Categoría ID: {libro.IdCategoria} -> {dto.IdCategoria}");

            if (!cambios.Any())
                return;

            string detallesAuditoria = $"Cambios en ISBN {isbn}: " + string.Join(", ", cambios);

            libro.ActualizarDatos(dto.Titulo, dto.NombreAutor, dto.AnioPublicacion, dto.IdCategoria);

            await _repositorioLibro.ActualizarAsync(libro);

            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuario: idUsuarioResponsable,
                tipoAccion: "Actualizacion de libro",
                entidadAfectada: "Libro",
                detalles: detallesAuditoria
            );
        }
    }
}