using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    internal class RepositorioReporte : BaseRepository<IRepositorioReporte>
    {
        public RepositorioReporte(SIGEBIDbContext context) : base(context)
        {
        }

        public Task<ReportePenalizacionesDTO> ObtenerPanalizacionesAsync(DateTime FechaInicio, DateTime FechaFin)
        {
            throw new NotImplementedException();
        }

        public Task<ReporteInventarioResponseDTO> ObtenerReporteInventarioAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ReportePrestamosResponseDTO> ObtenerReportesPrestamosAsync(DateTime FechaInicio, DateTime FechaFin)
        {
            throw new NotImplementedException();
        }

        public Task<ReporteCatalogoResponseDTO> ObtenerReporteUsoCatalogoAsync(DateTime FechaInicio, DateTime FechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
