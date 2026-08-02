using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using SIGEBI.AppEscritorio.DTOs.Categorias;
using SIGEBI.AppEscritorio.Services.Interfaces;

namespace SIGEBI.AppEscritorio.Forms.Catalogo
{
    public partial class formGestionCategorias : Form
    {
        private readonly IServicioCategoriaApi _servicioCategoriaApi;

        public formGestionCategorias(IServicioCategoriaApi servicioCategoriaApi)
        {
            InitializeComponent();
            _servicioCategoriaApi = servicioCategoriaApi;

            this.Load += FormGestionCategorias_Load;
            this.btnNuevo.Click += BtnNuevo_Click;
            this.btnEditar.Click += BtnEditar_Click;
            this.btnEliminar.Click += BtnEliminar_Click; // Evento del nuevo botón
        }

        private async void FormGestionCategorias_Load(object? sender, EventArgs e)
        {
            await CargarCategoriasGrid();
        }

        private async Task CargarCategoriasGrid()
        {
            dgvCategorias.DataSource = null;
            var categorias = await _servicioCategoriaApi.ConsultarTodasAsync();
            dgvCategorias.DataSource = categorias.ToList();

            if (dgvCategorias.Columns["IdCategoria"] != null)
                dgvCategorias.Columns["IdCategoria"].Visible = false;
        }

        private async void BtnNuevo_Click(object? sender, EventArgs e)
        {
            var formModal = Program.ServiceProvider.GetRequiredService<FormCategoriaMantenimiento>();
            if (formModal.ShowDialog() == DialogResult.OK)
            {
                await CargarCategoriasGrid();
            }
        }

        private async void BtnEditar_Click(object? sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una categoría para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dgvCategorias.SelectedRows[0];
            var categoriaEditada = new CategoriaResponseDTO
            {
                IdCategoria = Convert.ToInt32(fila.Cells["IdCategoria"].Value),
                Nombre = fila.Cells["Nombre"].Value?.ToString() ?? "",
                Descripcion = fila.Cells["Descripcion"].Value?.ToString()
            };

            var formModal = Program.ServiceProvider.GetRequiredService<FormCategoriaMantenimiento>();
            formModal.CargarDatosParaEdicion(categoriaEditada);

            if (formModal.ShowDialog() == DialogResult.OK)
            {
                await CargarCategoriasGrid();
            }
        }

        private async void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una categoría de la tabla para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dgvCategorias.SelectedRows[0];
            int idCategoria = Convert.ToInt32(fila.Cells["IdCategoria"].Value);
            string nombreCategoria = fila.Cells["Nombre"].Value?.ToString() ?? "esta categoría";

            var confirmacion = MessageBox.Show(
                $"¿Está seguro que desea eliminar la categoría '{nombreCategoria}'?\n\nEsta acción no se puede deshacer.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    btnEliminar.Enabled = false;
                    bool exito = await _servicioCategoriaApi.EliminarAsync(idCategoria);

                    if (exito)
                    {
                        MessageBox.Show("Categoría eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarCategoriasGrid(); // Refrescar el DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al intentar eliminar la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo eliminar: {ex.Message}", "Error de Servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnEliminar.Enabled = true;
                }
            }
        }
    }
}