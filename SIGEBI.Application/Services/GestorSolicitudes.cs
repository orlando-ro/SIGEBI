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


        public GestorSolicitudes(IRepoSolicitud repoSolicitud, IUsuarios usuarios, IRepositorioLibro repositorioLibro) {

            _repoSolicitud = repoSolicitud;
            _usuarios = usuarios;
            _repositorioLibro = repositorioLibro;
        }

        public async Task CrearSolicitudAsync(string idUsuario, List<string> isbnsLibros) {

            // Paso 1: Buscar la informacion
            var Usuario = await _usuarios.ObtenerPorIdAsync(idUsuario);
            if(Usuario == null)
            throw new NegocioExeption("El usuario no esta registrado en el sistema. ");

            // Paso 2: Validar Reglas de negocio con el dominio
            if (Usuario.VerificarPenalizaciones())
                throw new NegocioExeption("No puedes solicitar prestamos porque tienes penalizaciones activas. ");

            // paso 3: Recopilar los libros solicitados 
            var librosSolicitados = new List<Libro>();
            foreach (var isbn in isbnsLibros) {

                var libro = await _repositorioLibro.BuscarLibroPorIsbnAsync(isbn);
                if (libro == null) throw new NegocioExeption($" El libro {libro} no existe. ");

                if (!libro.EstaDispinible())
                    throw new NegocioExeption($"El libro {libro.Titulo} no tiene copias disponibles");

                librosSolicitados.Add(libro);
            }
            // PASO 4: Crear la nueva entidad
            var nuevaSolicitud = new Solicitud(idUsuario, librosSolicitados);

            // PASO 5: Guardar
            await _repoSolicitud.AgregarAsync(nuevaSolicitud);
        }
    }
}
