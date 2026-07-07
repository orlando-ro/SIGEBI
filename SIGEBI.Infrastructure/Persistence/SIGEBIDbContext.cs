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

        
        public DbSet<RegistroAuditoria> RegistroAuditorias { get; set; }

        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Resolucion> Resoluciones { get; set; }
        public DbSet<Aprobacion> Aprobaciones { get; set; }
        public DbSet<Rechazo> Rechazos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Ejemplar> Ejemplares { get; set; } // <- nuevo DbSet
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<Penalizacion> Penalizaciones { get; set; }
        public DbSet<Devolucion> Devoluciones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigurarUsuarios(modelBuilder);
            ConfigurarNotificaciones(modelBuilder);
            ConfigurarPenalizaciones(modelBuilder);
            ConfigurarPrestamos(modelBuilder);
            ConfigurarSolicitudes(modelBuilder);
            ConfigurarResoluciones(modelBuilder);
            ConfigurarRegistroAuditorias(modelBuilder);
            ConfigurarCategorias(modelBuilder);
            ConfigurarLibros(modelBuilder);
            ConfigurarEjemplares(modelBuilder); // <- llamada a la nueva configuarion
            ConfigurarDevoluciones(modelBuilder);
        }

        private static void ConfigurarUsuarios(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");

                entity.HasKey(u => u.IdUsuario);

                entity.Property(u => u.IdUsuario)
                    .ValueGeneratedOnAdd();

                entity.Property(u => u.Nombre)
                    .IsRequired();

                entity.Property(u => u.Email)
                    .IsRequired();

                entity.Property(u => u.Estado)
                    .IsRequired();

                entity.Property(u => u.Password)
                    .IsRequired();

                entity.Property(u => u.NumeroEmpleado)
                    .IsRequired(false);

                entity.HasDiscriminator<string>("TipoUsuario")
                    .HasValue<Administrador>("Administrador")
                    .HasValue<Auditor>("Auditor")
                    .HasValue<Docente>("Docente")
                    .HasValue<Estudiante>("Estudiante")
                    .HasValue<PersonalBibliotecario>("PersonalBibliotecario");
            });
        }

        private static void ConfigurarNotificaciones(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notificacion>(entity =>
            {
                entity.ToTable("Notificaciones");

                entity.HasKey(n => n.IdNotificacion);

                entity.Property(n => n.Mensaje)
                    .IsRequired();

                entity.Property(n => n.FechaEnvio)
                    .IsRequired();

                entity.Property(n => n.Leida)
                    .IsRequired();

                entity.Property(n => n.Tipo)
                    .IsRequired();

                entity.HasOne(n => n.Usuario)
                    .WithMany(u => u.Notificaciones)
                    .HasForeignKey(n => n.IdUsuario)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigurarPenalizaciones(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Penalizacion>(entity =>
            {
                entity.ToTable("Penalizaciones");

                entity.HasKey(p => p.IdPenalizacion);

                entity.Property(p => p.Monto)
                    .IsRequired();

                entity.Property(p => p.Motivo)
                    .IsRequired();

                entity.Property(p => p.FechaEmision)
                    .IsRequired();

                entity.Property(p => p.Pagada)
                    .IsRequired();

                entity.HasOne(p => p.Usuario)
                    .WithMany(u => u.Penalizaciones)
                    .HasForeignKey(p => p.IdUsuario)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigurarPrestamos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.ToTable("Prestamos");

                entity.HasKey(p => p.IdPrestamo);

                entity.Property(p => p.FechaInicio)
                    .IsRequired();

                entity.Property(p => p.FechaVencimiento)
                    .IsRequired();

                entity.Property(p => p.Estado)
                    .IsRequired();

                entity.HasOne(p => p.Usuario)
                    .WithMany(u => u.Prestamos)
                    .HasForeignKey(p => p.IdUsuario)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(p => p.Libros)
                    .WithOne()
                    .HasForeignKey("PrestamoIdPrestamo")
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigurarSolicitudes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.ToTable("Solicitudes");

                entity.HasKey(s => s.IdSolicitud);

                entity.Property(s => s.FechaSolicitud)
                    .IsRequired();

                entity.Property(s => s.Estado)
                    .IsRequired();

                entity.HasOne(s => s.Usuario)
                    .WithMany(u => u.Solicitudes)
                    .HasForeignKey(s => s.IdUsuario)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(s => s.LibrosSolicitados)
                    .WithOne()
                    .HasForeignKey("SolicitudIdSolicitud")
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.Resolucion)
                    .WithOne(r => r.Solicitud)
                    .HasForeignKey<Resolucion>(r => r.IdSolicitud)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigurarResoluciones(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resolucion>(entity =>
            {
                entity.ToTable("Resoluciones");

                entity.HasKey(r => r.IdResolucion);

                entity.Property(r => r.FechaResolucion)
                    .IsRequired();

                entity.Property(r => r.IdBibliotecario)
                    .IsRequired();

                entity.Property(r => r.IdSolicitud)
                    .IsRequired();

                entity.HasOne(r => r.Bibliotecario)
                    .WithMany()
                    .HasForeignKey(r => r.IdBibliotecario)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.Solicitud)
                    .WithOne(s => s.Resolucion)
                    .HasForeignKey<Resolucion>(r => r.IdSolicitud)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasDiscriminator<string>("TipoResolucion")
                    .HasValue<Aprobacion>("Aprobacion")
                    .HasValue<Rechazo>("Rechazo");
            });

            modelBuilder.Entity<Aprobacion>(entity =>
            {
                entity.HasOne(a => a.PrestamoGenerado)
                    .WithMany()
                    .HasForeignKey(a => a.IdPrestamoGenerado)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Rechazo>(entity =>
            {
                entity.Property(r => r.MotivoRechazo)
                    .IsRequired(false);
            });
        }

       
        

        private static void ConfigurarRegistroAuditorias(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistroAuditoria>(entity =>
            {
                entity.ToTable("RegistroAuditorias");

                entity.HasKey(r => r.IdAuditoria);

                entity.Property(r => r.FechaHora)
                    .IsRequired();

                entity.Property(r => r.IdUsuario)
                    .IsRequired();

                entity.Property(r => r.Accion)
                    .IsRequired();

                entity.Property(r => r.EntidadAfectada)
                    .IsRequired();

                entity.Property(r => r.Detalles)
                    .IsRequired();

                entity.HasOne<Usuario>()
                    .WithMany()
                    .HasForeignKey(r => r.IdUsuario)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigurarCategorias(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("Categorias");

                entity.HasKey(c => c.IdCategoria);

                entity.Property(c => c.Nombre)
                    .IsRequired();

                entity.Property(c => c.Descripcion)
                    .IsRequired();
            });
        }

        private static void ConfigurarLibros(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>(entity =>
            {
                entity.ToTable("Libros");

                entity.HasKey(l => l.ISBN);

                entity.Property(l => l.ISBN)
                    .ValueGeneratedNever();

                entity.Property(l => l.Titulo)
                    .IsRequired();

                entity.Property(l => l.NombreAutor)
                    .IsRequired();

                entity.Property(l => l.AnioPublicacion)
                    .IsRequired();

                // Eliminados: CopiasTotales y CopiasDisponibles (ya no son propiedades persistentes)

                entity.Property(l => l.UrlImagen)
                    .IsRequired(false);

                entity.HasOne(l => l.Categoria)
                    .WithMany(c => c.Libros)
                    .HasForeignKey(l => l.IdCategoria)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        // --- NUEVA CONFIGURACION PARA EJEMPLAR ---
        private static void ConfigurarEjemplares(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ejemplar>(entity =>
            {
                entity.ToTable("Ejemplares");

                entity.HasKey(e => e.IdEjemplar);

                entity.Property(e => e.CodigoFisico)
                    .IsRequired()
                    .HasMaxLength(50);

                // Forza al Enum se guarde como un String ("Disponible", "Prestado")
                entity.Property(e => e.Estado)
                    .HasConversion<string>()
                    .HasMaxLength(30)
                    .IsRequired();

                // Relación de 1 a Muchos: Un libro tiene muchos ejemplares físicos
                entity.HasOne(e => e.Libro)
                    .WithMany(l => l.Ejemplares)
                    .HasForeignKey(e => e.ISBN)
                    .OnDelete(DeleteBehavior.Cascade); // Si se borra un libro, se borran sus ejemplares
            });
        }

        private static void ConfigurarDevoluciones(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Devolucion>(entity =>
            {
                entity.ToTable("Devoluciones");

                entity.HasKey(d => d.IdDevolucion);

                entity.Property(d => d.FechaDevolucion)
                    .IsRequired();

                entity.Property(d => d.CondicionLibro)
                    .IsRequired();

                entity.Property(d => d.Observaciones)
                    .IsRequired();

                entity.HasOne(d => d.Prestamo)
                    .WithMany()
                    .HasForeignKey(d => d.IdPrestamo)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}