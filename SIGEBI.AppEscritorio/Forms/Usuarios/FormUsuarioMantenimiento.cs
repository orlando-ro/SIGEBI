using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIGEBI.AppEscritorio.DTOs.Usuarios;
using SIGEBI.AppEscritorio.Services.Interfaces;

namespace SIGEBI.AppEscritorio.Forms.Usuarios
{
    public partial class FormUsuarioMantenimiento : Form
    {
        private readonly IServicioUsuarioApi _servicioUsuarioApi;
        private bool _esModoEdicion = false;
        private int _idUsuarioActual = 0;

        public FormUsuarioMantenimiento(IServicioUsuarioApi servicioUsuarioApi)
        {
            InitializeComponent();
            _servicioUsuarioApi = servicioUsuarioApi;

            this.Load += FormUsuarioMantenimiento_Load;
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;
        }

        private void FormUsuarioMantenimiento_Load(object? sender, EventArgs e)
        {
            cmbTipoUsuario.Items.AddRange(new string[] { "Estudiante", "Docente", "PersonalBibliotecario", "Administrador", "Auditor" });
            cmbEstado.Items.AddRange(new string[] { "Activo", "Inactivo" });

            if (!_esModoEdicion)
            {
                lblTitulo.Text = "Nuevo Usuario";
                cmbTipoUsuario.SelectedIndex = 0;
                cmbEstado.Visible = false;
                lblEstado.Visible = false;
            }
        }

        public void CargarDatosParaEdicion(UsuarioResponseDTO usuario)
        {
            _esModoEdicion = true;
            _idUsuarioActual = usuario.IdUsuario;
            lblTitulo.Text = "Editar Usuario";

            txtNombre.Text = usuario.Nombre;
            txtEmail.Text = usuario.Email;
            txtMatricula.Text = usuario.Matricula;
            txtNumeroEmpleado.Text = usuario.NumeroEmpleado;

            cmbTipoUsuario.SelectedItem = usuario.TipoUsuario;
            cmbTipoUsuario.Enabled = false;

            cmbEstado.SelectedItem = usuario.Estado;
            cmbEstado.Visible = true;
            lblEstado.Visible = true;

            txtPassword.Visible = false;
            lblPassword.Visible = false;
        }

        private async void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("El nombre y el correo son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_esModoEdicion && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("La contraseña es obligatoria para usuarios nuevos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnGuardar.Enabled = false;
                btnGuardar.Text = "Guardando...";

                if (_esModoEdicion)
                {
                    var updateDto = new UsuarioUpdateRequestDTO
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Matricula = txtMatricula.Text.Trim(),
                        NumeroEmpleado = txtNumeroEmpleado.Text.Trim(),
                        Estado = cmbEstado.SelectedItem?.ToString()
                    };

                    await _servicioUsuarioApi.ActualizarUsuarioAsync(_idUsuarioActual, updateDto);
                }
                else
                {
                    var createDto = new UsuarioRequestDTO
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        TipoUsuario = cmbTipoUsuario.SelectedItem?.ToString() ?? "Estudiante",
                        Password = txtPassword.Text.Trim(),
                        Matricula = txtMatricula.Text.Trim(),
                        NumeroEmpleado = txtNumeroEmpleado.Text.Trim()
                    };

                    await _servicioUsuarioApi.RegistrarUsuarioAsync(createDto);
                }

                MessageBox.Show($"Usuario {(_esModoEdicion ? "actualizado" : "creado")} exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnGuardar.Enabled = true;
                btnGuardar.Text = "Guardar";
            }
        }

        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}