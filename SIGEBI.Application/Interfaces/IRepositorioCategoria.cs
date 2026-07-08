using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepositorioCategoria : IBaseRepository<Categoria>
    {
        // Método especializado para evitar duplicados en la base de datos
        Task<Categoria?> ObtenerPorNombreAsync(string nombre);
    }
}