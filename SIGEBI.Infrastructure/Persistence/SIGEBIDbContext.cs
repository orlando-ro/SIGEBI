using System;
using System.Collections.Generic;
using System.Text;
using SIGEBI.Domain.Entities; 
using Microsoft.EntityFrameworkCore;


namespace SIGEBI.Infrastructure.Persistence
{
   public class SIGEBIDbContext : DbContext
   {
            
            public SIGEBIDbContext(DbContextOptions<SIGEBIDbContext> options) : base(options)
            {

                
            }

             
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<RegistroAuditoria> RegistroAuditorias { get; set; }

        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Resolucion> Resoluciones { get; set; }
        public DbSet<Aprobacion> Aprobaciones { get; set; }
        public DbSet<Rechazo> Rechazos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<Penalizacion> Penalizaciones { get; set; }
        public DbSet<Devolucion> Devoluciones { get; set; }

        



        

            
        }
    }



