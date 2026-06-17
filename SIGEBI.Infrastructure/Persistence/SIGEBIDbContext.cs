using System;
using System.Collections.Generic;
using System.Text;
// using SIGEBI.Domain.Entities; //  esto se desmontara cuando se creen las entidades
using Microsoft.EntityFrameworkCore;


namespace SIGEBI.Infrastructure.Persistence
{
   public class SIGEBIDbContext : DbContext
   {
            // Este constructor es OBLIGATORIO.
            // es lo que recibe el "Connection String" desde el Program.cs de la API
            public SIGEBIDbContext(DbContextOptions<SIGEBIDbContext> options) : base(options)
            {
            }

            // --- ZONA DE TABLAS (DbSets) ---
            // van las tablas a medida que avancen en sus módulos.
            // Ejemplo (no lo descomenten hasta que la clase Usuario exista):
            // public DbSet<Usuario> Usuarios { get; set; }
        }
    }



