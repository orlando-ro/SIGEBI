using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Application.Services
{
    public class GestorUsuarios : IServicioUsuarios
    {
        private readonly IUsuarios _repositorioUsuario;
        private readonly IServicioAuditoria _servicioAuditoria;

        public GestorUsuarios(IUsuarios repositorioUsuario, IServicioAuditoria servicioAuditoria)
        {
            _repositorioUsuario = repositorioUsuario;
            _servicioAuditoria = servicioAuditoria;
        }

        public async Task RegistrarUsuarioAsync(UsuarioRequestDTO dto)
        {
            var existe = await _repositorioUsuario.ObtenerPorIdAsync(dto.IdUsuario);
            if (existe != null) throw new NegocioExeption("El usuario ya se encuentra registrado.");

            Usuario nuevoUsuario = dto.TipoUsuario.ToLower() switch
            {
                "estudiante" => new Estudiante { Matricula = dto.Matricula },
                "docente" => new Docente { NumeroEmpleado = dto.NumeroEmpleado },
                "administrador" => new Administrador(),
                "bibliotecario" => new PersonalBibliotecario(),
                "auditor" => new Auditor(),
                _ => throw new NegocioExeption("Tipo de usuario inválido.")
            };

            nuevoUsuario.IdUsuario = dto.IdUsuario;
            nuevoUsuario.Nombre = dto.Nombre;
            nuevoUsuario.Email = dto.Email;
            nuevoUsuario.Estado = "Activo";

            await _repositorioUsuario.AgregarAsync(nuevoUsuario);

            await _servicioAuditoria.RegistrarAccionAsync(

                idUsuario: dto.IdUsuario,
                tipoAccion: "Registrar usuario",
                 entidadAfectada: "Prestamo",
                 detalles: $" Se ha agregado el usuario ({nuevoUsuario})"
                );

        }

        public async Task SuspenderUsuarioAsync(string idUsuario)
        {
            var usuario = await _repositorioUsuario.ObtenerPorIdAsync(idUsuario);
            if (usuario == null) throw new NegocioExeption("El usuario no fue encontrado.");

            usuario.Estado = "Inactivo";
            await _repositorioUsuario.ActualizarAsync(usuario);

            await _servicioAuditoria.RegistrarAccionAsync(

               idUsuario: idUsuario,
               tipoAccion: "Suspender usuario",
                entidadAfectada: "Usuario",
                detalles: $" Se ha suspendido el usuario con el id: ({ idUsuario})"
               );
        }

        public async Task<UsuarioResponseDTO?> ObtenerUsuarioPorIdAsync(string idUsuario)
        {
            var usuario = await _repositorioUsuario.ObtenerUsuarioConDetallesAsync(idUsuario);
            if (usuario == null) return null;

            return new UsuarioResponseDTO
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Estado = usuario.Estado,
                TipoUsuario = usuario.GetType().Name,
                HabilitadoParaPrestamos = !usuario.VerificarPenalizaciones()
            };

        }

        public async Task<IEnumerable<UsuarioResponseDTO>> ConsultarTodosAsync()
        {
            var usuarios = await _repositorioUsuario.ObtenerTodosAsync();
            return usuarios.Select(u => new UsuarioResponseDTO
            {
                IdUsuario = u.IdUsuario,
                Nombre = u.Nombre,
                Email = u.Email,
                Estado = u.Estado,
                TipoUsuario = u.GetType().Name,
                HabilitadoParaPrestamos = true
            });
        }
    }
}