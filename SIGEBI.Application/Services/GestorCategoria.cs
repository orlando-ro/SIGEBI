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

        public GestorCategoria(IRepositorioCategoria repositorio) => _repositorio = repositorio;

        public async Task RegistrarCategoriaAsync(CategoriaRequestDTO dto)
        {
            var existe = await _repositorio.ObtenerPorNombreAsync(dto.Nombre);
            if (existe != null)
                throw new NegocioExeption("Ya existe esta categoría.");
            await _repositorio.AgregarAsync(new Categoria { Nombre = dto.Nombre });
        }

        public async Task<IEnumerable<CategoriaResponseDTO>> ConsultarTodasAsync()
        {
            var cats = await _repositorio.ObtenerTodosAsync();
            return cats.Select(c => new CategoriaResponseDTO { IdCategoria = c.IdCategoria, Nombre = c.Nombre });
        }

        public async Task<CategoriaResponseDTO?> ObtenerPorIdAsync(int idCategoria)
        {
            var categoria = await _repositorio.ObtenerPorIdAsync(idCategoria);

            if (categoria == null)
                return null;

            return new CategoriaResponseDTO
            {
                IdCategoria = categoria.IdCategoria,
                Nombre = categoria.Nombre
            };
        }
    }
}