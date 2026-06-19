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

        // agregue unas cuantas para que ef me dejara subir la migracion porque algunas de mis entidades requerian de algunas entidades



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // configuracion de las llaves primarias
            modelBuilder.Entity<Reporte>().HasKey(r => r.IdReporte);
            
            modelBuilder.Entity<RegistroAuditoria>().HasKey(r => r.IdAuditoria);

            modelBuilder.Entity<Prestamo>().HasKey(p => p.IdPrestamo);
            modelBuilder.Entity<Solicitud>().HasKey(s => s.IdSolicitud);
            modelBuilder.Entity<Resolucion>().HasKey(r => r.IdResolucion);

            modelBuilder.Entity<Categoria>().HasKey(c => c.IdCategoria);
            modelBuilder.Entity<Libro>().HasKey(l => l.ISBN);
            modelBuilder.Entity<Usuario>().HasKey(u => u.IdUsuario);
            // --- NUEVO: SOLUCIÓN AL ERROR DE USUARIO ABSTRACTO (TPH) ---
            // Le decimos a EF Core cuáles son las clases hijas reales que sí se pueden instanciar
            modelBuilder.Entity<Usuario>()
                .HasDiscriminator<string>("TipoUsuario")
                .HasValue<Estudiante>("Estudiante")
                .HasValue<Docente>("Docente")
                .HasValue<Administrador>("Administrador")
                .HasValue<Auditor>("Auditor")
                .HasValue<PersonalBibliotecario>("PersonalBibliotecario");

            modelBuilder.Entity<Notificacion>().HasKey(n => n.IdNotificacion);
            modelBuilder.Entity<Penalizacion>().HasKey(p => p.IdPenalizacion);
            modelBuilder.Entity<Devolucion>().HasKey(d => d.IdDevolucion);

            // espesificamos quien guasdara la llave foranea
            modelBuilder.Entity<Solicitud>()
               .HasOne(s => s.Resolucion)
               .WithOne(r => r.Solicitud)
               .HasForeignKey<Resolucion>(r => r.IdSolicitud)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Resolucion>()
               .HasOne(r => r.Bibliotecario)
               .WithMany() // Un usuario puede ser bibliotecario de muchas resoluciones
               .HasForeignKey(r => r.IdBibliotecario)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Prestamos)
                .HasForeignKey(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            // Devolución <-> Préstamo
            modelBuilder.Entity<Devolucion>()
                .HasOne(d => d.Prestamo)
                .WithMany()
                .HasForeignKey(d => d.IdPrestamo)
                .OnDelete(DeleteBehavior.Restrict);

            // Notificaciones <-> Usuario
            modelBuilder.Entity<Notificacion>()
                .HasOne(n => n.Usuario)
                .WithMany()
                .HasForeignKey(n => n.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración del TPH (Table-Per-Hierarchy) para Resoluciones
            modelBuilder.Entity<Resolucion>()
                .HasDiscriminator<string>("TipoResolucion")
                .HasValue<Aprobacion>("Aprobacion")
                .HasValue<Rechazo>("Rechazo");

        }

            
        }
    }



