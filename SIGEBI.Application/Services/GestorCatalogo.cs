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

        public GestorCatalogo(IRepositorioLibro repositorioLibro, IServicioCategoria servicioCategoria)
        {
            _repositorioLibro = repositorioLibro;
            _servicioCategoria = servicioCategoria;
        }

        public async Task RegistrarLibroAsync(LibroRequestDTO dto)
        {
            if (await _repositorioLibro.ObtenerPorIdAsync(dto.ISBN) != null)
                throw new NegocioExeption("El ISBN ya está registrado.");

            var categorias = await _servicioCategoria.ConsultarTodasAsync();
            if (!categorias.Any(c => c.IdCategoria == dto.IdCategoria))
                throw new NegocioExeption("La categoría no existe.");

            var libro = new Libro(dto.ISBN, dto.Titulo)
            {
                NombreAutor = dto.NombreAutor,
                AnioPublicacion = dto.AnioPublicacion,
                CopiasTotales = dto.CopiasTotales,
                CopiasDisponibles = dto.CopiasTotales,
                IdCategoria = dto.IdCategoria
            };

            await _repositorioLibro.AgregarAsync(libro);
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
                CopiasDisponibles = libro.CopiasDisponibles,
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
    }
}