using System;
using System.Collections.Generic;
using System.Text;
using SIGEBI.Domain.Entities; 
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

             
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<RegistroAuditoria> RegistroAuditorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // configuracion de las llaves primarias
            modelBuilder.Entity<Reporte>().HasKey(r => r.IdReporte);
            
            modelBuilder.Entity<RegistroAuditoria>().HasKey(r => r.IdAuditoria);

        }

            // --- ZONA DE TABLAS (DbSets) ---
            // van las tablas a medida que avancen en sus módulos.
            // Ejemplo (no lo descomenten hasta que la clase Usuario exista):
            // public DbSet<Usuario> Usuarios { get; set; }
        }
    }



