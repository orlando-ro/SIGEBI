using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Exceptions;
using BCrypt.Net;

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
                "administrador" => new Administrador { NumeroEmpleado = dto.NumeroEmpleado },
                "bibliotecario" => new PersonalBibliotecario { NumeroEmpleado = dto.NumeroEmpleado },
                "auditor" => new Auditor { NumeroEmpleado = dto.NumeroEmpleado },
                _ => throw new NegocioExeption("Tipo de usuario inválido.")
            };

            nuevoUsuario.IdUsuario = dto.IdUsuario;
            nuevoUsuario.Nombre = dto.Nombre;
            nuevoUsuario.Email = dto.Email;
            nuevoUsuario.Estado = "Activo";
            nuevoUsuario.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

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
                HabilitadoParaPrestamos = usuario.Estado == "Activo" && !usuario.VerificarPenalizaciones()
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

        public async Task<LoginResponseDTO> AutenticarUsuarioAsync(LoginRequestDTO dto)
        {
            var usuario = await _repositorioUsuario.ObtenerPorEmailAsync(dto.Email);

            if (usuario == null)
                throw new NegocioExeption("Credenciales incorrectas.");

            // se compara el password dado del dto con el password almacenado en la base de datos (que está hasheado)
            bool passwordValida = BCrypt.Net.BCrypt.Verify(dto.Password, usuario.Password);

            if (!passwordValida)
                throw new NegocioExeption("Credenciales incorrectas.");

            // valida que el usuario no este suspendido
            if (usuario.Estado == "Inactivo")
                throw new NegocioExeption("El usuario se encuentra suspendido.");

            return new LoginResponseDTO
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                TipoUsuario = usuario.GetType().Name
            };
        }

        // Implementación de los métodos de actualización

        public async Task ActualizarPorMatriculaAsync(string matricula, UsuarioUpdateRequestDTO dto)
        {
            // buscar el estudiante usando el método en el repositorio
            var estudiante = await _repositorioUsuario.ObtenerPorMatriculaAsync(matricula);

            if (estudiante == null)
                throw new NegocioExeption("No se encontró ningún estudiante con esa matrícula.");

            // actualizar los datos permitidos
            estudiante.Nombre = dto.Nombre;
            estudiante.Email = dto.Email;

            // si el dto trae una nueva matricula, se actualiza, de lo contrario se mantiene la existente
            if (!string.IsNullOrEmpty(dto.Matricula))
            {
                estudiante.Matricula = dto.Matricula;
            }

            // 3. Guardar cambios
            await _repositorioUsuario.ActualizarAsync(estudiante);
        }

        public async Task ActualizarPorNumeroEmpleadoAsync(string numeroEmpleado, UsuarioUpdateRequestDTO dto)
        {
            // busucar usando el metodo en repositorio
            var empleado = await _repositorioUsuario.ObtenerPorNumeroEmpleadoAsync(numeroEmpleado);

            if (empleado == null)
                throw new NegocioExeption("No se encontró ningún empleado con ese número.");

            // actualizar los datos permitidos
            empleado.Nombre = dto.Nombre;
            empleado.Email = dto.Email;
            empleado.NumeroEmpleado = dto.NumeroEmpleado;

            // guardar cambios  
            await _repositorioUsuario.ActualizarAsync(empleado);
        }

        public async Task ActualizarPorEmailAsync(string email, UsuarioUpdateRequestDTO dto)
        {
            var usuario = await _repositorioUsuario.ObtenerPorEmailAsync(email);

            if (usuario == null)
                throw new NegocioExeption("No se encontró ningún usuario con ese correo.");

            usuario.Email = dto.Email;

            {
                usuario.NumeroEmpleado = dto.NumeroEmpleado;
            }

            if (usuario is Estudiante estudiante && !string.IsNullOrEmpty(dto.Matricula))
            {
                estudiante.Matricula = dto.Matricula;
            }

            await _repositorioUsuario.ActualizarAsync(usuario);
        }
    }
}