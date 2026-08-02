using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Application.Services
{
    public class GestorCategoria : IServicioCategoria
    {
        private readonly IRepositorioCategoria _repositorio;
        private readonly IServicioAuditoria _servicioAuditoria;

        public GestorCategoria(IRepositorioCategoria repositorio, IServicioAuditoria servicioAuditoria)
        {
            _repositorio = repositorio;
            _servicioAuditoria = servicioAuditoria;
        }

        public async Task RegistrarCategoriaAsync(CategoriaRequestDTO dto, int idResponsable)
        {
            var existe = await _repositorio.ObtenerPorNombreAsync(dto.Nombre);
            if (existe != null)
                throw new NegocioExeption("Ya existe esta categoría.");

            var nuevaCategoria = new Categoria
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion?.Trim() ?? string.Empty
            };

            await _repositorio.AgregarAsync(nuevaCategoria);

            await _servicioAuditoria.RegistrarAccionAsync(
                idResponsable: idResponsable,
                tipoAccion: "Registrar categoría",
                entidadAfectada: "Categoria",
                detalles: $"Se ha registrado la categoría {nuevaCategoria.Nombre}."
            );
        }

        public async Task ActualizarCategoriaAsync(int idCategoria, CategoriaRequestDTO dto, int idResponsable)
        {
            var categoria = await _repositorio.ObtenerPorIdAsync(idCategoria);
            if (categoria == null)
                throw new NegocioExeption("La categoría no existe.");

            // Validar si el nuevo nombre choca con otra categoría existente
            var existe = await _repositorio.ObtenerPorNombreAsync(dto.Nombre);
            if (existe != null && existe.IdCategoria != idCategoria) 
                throw new NegocioExeption("Ya existe otra categoría con ese nombre.");

            categoria.Nombre = dto.Nombre.Trim();
            categoria.Descripcion = dto.Descripcion?.Trim() ?? string.Empty;

            await _repositorio.ActualizarAsync(categoria);

            await _servicioAuditoria.RegistrarAccionAsync(
                idResponsable: idResponsable,
                tipoAccion: "Actualizar categoría",
                entidadAfectada: "Categoria",
                detalles: $"Se ha actualizado la categoría con ID {idCategoria}."
            );
        }

        public async Task<IEnumerable<CategoriaResponseDTO>> ConsultarTodasAsync()
        {
            var cats = await _repositorio.ObtenerTodosAsync();
            return cats.Select(c => new CategoriaResponseDTO
            {
                IdCategoria = c.IdCategoria,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion
            });
        }

        public async Task<CategoriaResponseDTO?> ObtenerPorIdAsync(int idCategoria)
        {
            var categoria = await _repositorio.ObtenerPorIdAsync(idCategoria);

            if (categoria == null)
                return null;

            return new CategoriaResponseDTO
            {
                IdCategoria = categoria.IdCategoria,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion
            };
        }

        public async Task EliminarCategoriaAsync(int idCategoria, int idResponsable)
        {
            var categoria = await _repositorio.ObtenerPorIdAsync(idCategoria);
            if (categoria == null)
                throw new NegocioExeption("La categoría no existe o ya fue eliminada.");

            try
            {
                await _repositorio.EliminarAsync(categoria);

                await _servicioAuditoria.RegistrarAccionAsync(
                    idResponsable: idResponsable,
                    tipoAccion: "Eliminar categoría",
                    entidadAfectada: "Categoria",
                    detalles: $"Se ha eliminado la categoría {categoria.Nombre} con ID {idCategoria}."
                );
            }
            catch (Exception)
            {
                throw new NegocioExeption("No se puede eliminar esta categoría porque actualmente hay libros en el catálogo que la están utilizando.");
            }
        }
    }
}