using SIGEBI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SIGEBI.Domain.Exceptions;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Application.Services
{
    public class GestorSolicitudes
    {
        private readonly IRepoSolicitud _repoSolicitud;
        private readonly IUsuarios _usuarios;
        private readonly IRepositorioLibro _repositorioLibro;
        private readonly IServicioAuditoria _servicioAuditoria;
        private readonly IRepositorioPrestamo _repositorioPrestamo;


        public GestorSolicitudes(IRepoSolicitud repoSolicitud, IUsuarios usuarios, IRepositorioLibro repositorioLibro, IServicioAuditoria servicioAuditoria, IRepositorioPrestamo repositorioPrestamo)
        {

            _repoSolicitud = repoSolicitud;
            _usuarios = usuarios;
            _repositorioLibro = repositorioLibro;
            _servicioAuditoria = servicioAuditoria;
            _repositorioPrestamo = repositorioPrestamo;
        }

        public async Task CrearSolicitudAsync(string idUsuario, List<string> isbnsLibros)
        {

            var usuario = await _usuarios.ObtenerPorIdAsync(idUsuario);

            if (usuario == null)
                throw new NegocioExeption("El usuario no está registrado en el sistema.");

            usuario.ValidarElegibilidadParaPrestamo();

            var prestamosActivos = await _repositorioPrestamo.ObtenerActivoPorUsuarioAsync(idUsuario);
            int cantidadPrestamosActivos = prestamosActivos.Count();

            int limitePrestamos = ObtenerLimitePrestamosPorTipoUsuario(usuario);

            if (limitePrestamos <= 0)
                throw new NegocioExeption("Este tipo de usuario no está autorizado para solicitar préstamos.");

            if (cantidadPrestamosActivos >= limitePrestamos)
            {
                throw new NegocioExeption(
                    $"No puede solicitar más préstamos. " +
                    $"Límite permitido: {limitePrestamos}. " +
                    $"Préstamos activos actuales: {cantidadPrestamosActivos}.");
            }

            var librosSolicitados = new List<Libro>();

            foreach (var isbn in isbnsLibros)
            {
                var libro = await _repositorioLibro.BuscarLibroPorIsbnAsync(isbn);

                if (libro == null)
                    throw new NegocioExeption($"El libro con ISBN {isbn} no existe.");

                if (!libro.EstaDispinible())
                    throw new NegocioExeption($"El libro {libro.Titulo} no tiene copias disponibles.");

                librosSolicitados.Add(libro);
            }

            if (cantidadPrestamosActivos + librosSolicitados.Count > limitePrestamos)
            {
                throw new NegocioExeption(
                    $"La solicitud excede el límite de préstamos. " +
                    $"Límite permitido: {limitePrestamos}. " +
                    $"Préstamos activos actuales: {cantidadPrestamosActivos}. " +
                    $"Libros solicitados: {librosSolicitados.Count}.");
            }

            var nuevaSolicitud = new Solicitud(idUsuario, librosSolicitados);

            await _repoSolicitud.AgregarAsync(nuevaSolicitud);

            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuario: idUsuario,
                tipoAccion: "Solicitar préstamo",
                entidadAfectada: "Solicitud",
                detalles: $"El usuario {idUsuario} creó la solicitud #{nuevaSolicitud.IdSolicitud} para los libros: {string.Join(", ", isbnsLibros)}"
            );

        }
        private int ObtenerLimitePrestamosPorTipoUsuario(Usuario usuario)
        {
            if (usuario is Estudiante)
                return 3;

            if (usuario is Docente)
                return 5;

            return 0;
        }


    }

    }
