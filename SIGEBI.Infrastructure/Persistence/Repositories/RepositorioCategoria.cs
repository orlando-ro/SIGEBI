using System;
using System.Collections.Generic;
using System.Text;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Persistence;

namespace SIGEBI.Infrastructure.Repositories
{
    public class RepositorioCategoria : BaseRepository<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoria(SIGEBIDbContext context) : base(context)
        {
        }
    }
}