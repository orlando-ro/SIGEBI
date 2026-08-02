using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIGEBI.AppEscritorio.DTOs.Catalogo;
using SIGEBI.AppEscritorio.DTOs.Categorias;
using SIGEBI.AppEscritorio.Services.Interfaces;

namespace SIGEBI.AppEscritorio.Forms.Catalogo
{
    public partial class FormLibroMantenimiento : Form
    {
        private readonly IServicioCatalogoApi _servicioCatalogoApi;
        private readonly IServicioCategoriaApi _servicioCategoriaApi;
        private bool _esModoEdicion = false;
        private string? _rutaImagenSeleccionada = null;

        public FormLibroMantenimiento(IServicioCatalogoApi servicioCatalogoApi, IServicioCategoriaApi servicioCategoriaApi)
        {
            InitializeComponent();
            _servicioCatalogoApi = servicioCatalogoApi;
            _servicioCategoriaApi = servicioCategoriaApi;

            this.Load += FormLibroMantenimiento_Load;
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;
            this.btnSeleccionarImagen.Click += BtnSeleccionarImagen_Click;
        }

        private async void FormLibroMantenimiento_Load(object? sender, EventArgs e)
        {
            await CargarCategoriasAsync();

            if (!_esModoEdicion)
            {
                lblTitulo.Text = "Nuevo Libro";
            }
        }

        private async Task CargarCategoriasAsync()
        {
            try
            {
                var categorias = await _servicioCategoriaApi.ConsultarTodasAsync();
                cmbCategoria.DataSource = categorias.ToList();
                cmbCategoria.DisplayMember = "Nombre";
                cmbCategoria.ValueMember = "IdCategoria";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void CargarDatosParaEdicion(LibroResponseDTO libro)
        {
            _esModoEdicion = true;
            lblTitulo.Text = "Editar Libro";

            txtIsbn.Text = libro.ISBN;
            txtIsbn.Enabled = false;
            txtTitulo.Text = libro.Titulo;
            txtAutor.Text = libro.NombreAutor;
            txtAnio.Text = libro.AnioPublicacion.ToString();
            txtCopias.Text = libro.CopiasDisponibles.ToString();
            txtCopias.Enabled = false;

            if (cmbCategoria.Items.Count > 0)
            {
                var index = cmbCategoria.Items.Cast<CategoriaResponseDTO>()
                            .ToList().FindIndex(c => c.Nombre == libro.Categoria);
                if (index >= 0) cmbCategoria.SelectedIndex = index;
            }
        }

        private void BtnSeleccionarImagen_Click(object? sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Seleccionar Portada";
            openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _rutaImagenSeleccionada = openFileDialog.FileName;

                using (var ms = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(_rutaImagenSeleccionada)))
                {
                    picPortada.Image = Image.FromStream(ms);
                }
            }
        }

        private async void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIsbn.Text) || string.IsNullOrWhiteSpace(txtTitulo.Text) || cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios (*).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtAnio.Text, out int anio) || !int.TryParse(txtCopias.Text, out int copias))
            {
                MessageBox.Show("El Año y las Copias deben ser valores numéricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnGuardar.Enabled = false;
                btnGuardar.Text = "Guardando...";

                if (_esModoEdicion)
                {
                    var updateDto = new LibroUpdateDTO
                    {
                        Titulo = txtTitulo.Text.Trim(),
                        NombreAutor = txtAutor.Text.Trim(),
                        AnioPublicacion = anio,
                        IdCategoria = (int)cmbCategoria.SelectedValue
                    };
                    await _servicioCatalogoApi.ActualizarLibroAsync(txtIsbn.Text.Trim(), updateDto, _rutaImagenSeleccionada);
                }
                else
                {
                    await _servicioCatalogoApi.RegistrarLibroAsync(
                        txtIsbn.Text.Trim(),
                        txtTitulo.Text.Trim(),
                        txtAutor.Text.Trim(),
                        anio,
                        copias,
                        (int)cmbCategoria.SelectedValue,
                        _rutaImagenSeleccionada
                    );
                }

                MessageBox.Show($"Libro {(_esModoEdicion ? "actualizado" : "registrado")} exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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