using Microsoft.Extensions.DependencyInjection;
using SIGEBI.AppEscritorio.DTOs.Usuarios;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Usuarios
{
    public partial class formGestionUsuarios : Form
    {
        private readonly IServicioUsuarioApi _servicioUsuarioApi;

        public formGestionUsuarios(IServicioUsuarioApi servicioUsuarioApi)
        {
            InitializeComponent();
            _servicioUsuarioApi = servicioUsuarioApi;

            this.Load += FormGestionUsuarios_Load;
            this.btnBuscar.Click += BtnBuscar_Click;
            this.btnSuspender.Click += BtnSuspender_Click;
            this.btnNuevo.Click += BtnNuevo_Click;
            this.btnEditar.Click += BtnEditar_Click;
        }

        private async void FormGestionUsuarios_Load(object? sender, EventArgs e)
        {
            await CargarUsuariosGrid();
        }

        private async Task CargarUsuariosGrid()
        {
            try
            {
                dgvUsuarios.DataSource = null;
                var listaUsuarios = await _servicioUsuarioApi.ObtenerTodosAsync();
                dgvUsuarios.DataSource = listaUsuarios.ToList();

                if (dgvUsuarios.Columns["IdUsuario"] != null)
                    dgvUsuarios.Columns["IdUsuario"].Visible = false;

                if (dgvUsuarios.Columns["HabilitadoParaPrestamos"] != null)
                    dgvUsuarios.Columns["HabilitadoParaPrestamos"].HeaderText = "Puede Prestar";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- FUNCIONALIDAD: BUSCAR USUARIO ---
        private async void BtnBuscar_Click(object? sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(busqueda))
            {
                await CargarUsuariosGrid();
                return;
            }

            try
            {
                btnBuscar.Enabled = false;
                var usuario = await _servicioUsuarioApi.ObtenerPorIdentificadorAsync(busqueda);

                if (usuario != null)
                {
                    dgvUsuarios.DataSource = new[] { usuario }.ToList();
                }
                else
                {
                    MessageBox.Show("No se encontró ningún usuario con ese identificador.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnBuscar.Enabled = true;
            }
        }

        // --- FUNCIONALIDAD: SUSPENDER USUARIO ---
        private async void BtnSuspender_Click(object? sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la lista primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["IdUsuario"].Value);
            string nombreUsuario = dgvUsuarios.SelectedRows[0].Cells["Nombre"].Value.ToString() ?? "Desconocido";

            var confirmacion = MessageBox.Show($"¿Está seguro que desea suspender al usuario {nombreUsuario}?", "Confirmar Suspensión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    btnSuspender.Enabled = false;
                    await _servicioUsuarioApi.SuspenderUsuarioAsync(idUsuario);

                    MessageBox.Show("Usuario suspendido exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarUsuariosGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    btnSuspender.Enabled = true;
                }
            }
        }

        // --- FUNCIONALIDAD: NUEVO Y EDITAR ---
        private async void BtnNuevo_Click(object? sender, EventArgs e)
        {
            var formModal = Program.ServiceProvider.GetRequiredService<FormUsuarioMantenimiento>();

            if (formModal.ShowDialog() == DialogResult.OK)
            {
                await CargarUsuariosGrid();
            }
        }

        private async void BtnEditar_Click(object? sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dgvUsuarios.SelectedRows[0];

            var usuarioEditado = new UsuarioResponseDTO
            {
                IdUsuario = Convert.ToInt32(fila.Cells["IdUsuario"].Value),
                Nombre = fila.Cells["Nombre"].Value?.ToString() ?? "",
                Email = fila.Cells["Email"].Value?.ToString() ?? "",
                Matricula = fila.Cells["Matricula"].Value?.ToString(),
                NumeroEmpleado = fila.Cells["NumeroEmpleado"].Value?.ToString(),
                TipoUsuario = fila.Cells["TipoUsuario"].Value?.ToString() ?? "",
                Estado = fila.Cells["Estado"].Value?.ToString() ?? "Activo"
            };

            var formModal = Program.ServiceProvider.GetRequiredService<FormUsuarioMantenimiento>();

            formModal.CargarDatosParaEdicion(usuarioEditado);

            if (formModal.ShowDialog() == DialogResult.OK)
            {
                await CargarUsuariosGrid();
            }
        }
    }
}