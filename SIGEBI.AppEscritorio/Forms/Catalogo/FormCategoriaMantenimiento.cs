using SIGEBI.AppEscritorio.DTOs.Categorias;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Catalogo
{
    public partial class FormCategoriaMantenimiento : Form
    {
        private readonly IServicioCategoriaApi _servicioCategoriaApi;
        private bool _esModoEdicion = false;
        private int _idCategoriaActual = 0;

        public FormCategoriaMantenimiento(IServicioCategoriaApi servicioCategoriaApi)
        {
            InitializeComponent();
            _servicioCategoriaApi = servicioCategoriaApi;

            this.Load += FormCategoriaMantenimiento_Load;
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;
        }

        private void FormCategoriaMantenimiento_Load(object? sender, EventArgs e)
        {
            if (!_esModoEdicion)
                lblTitulo.Text = "Nueva Categoría";
        }

        public void CargarDatosParaEdicion(CategoriaResponseDTO categoria)
        {
            _esModoEdicion = true;
            _idCategoriaActual = categoria.IdCategoria;
            lblTitulo.Text = "Editar Categoría";

            txtNombre.Text = categoria.Nombre;
            txtDescripcion.Text = categoria.Descripcion;
        }

        private async void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la categoría es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnGuardar.Enabled = false;
            btnGuardar.Text = "Guardando...";

            var requestDto = new CategoriaRequestDTO
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim()
            };

            bool exito = _esModoEdicion
                ? await _servicioCategoriaApi.ActualizarCategoriaAsync(_idCategoriaActual, requestDto)
                : await _servicioCategoriaApi.RegistrarCategoriaAsync(requestDto);

            if (exito)
            {
                MessageBox.Show($"Categoría {(_esModoEdicion ? "actualizada" : "registrada")} exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al procesar la solicitud.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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