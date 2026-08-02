using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIGEBI.AppEscritorio.Services.Interfaces;

namespace SIGEBI.AppEscritorio.Forms.Catalogo
{
    public partial class FormGestionEjemplares : Form
    {
        private readonly IServicioCatalogoApi _servicioCatalogoApi;
        private string _isbnActual = "";

        public FormGestionEjemplares(IServicioCatalogoApi servicioCatalogoApi)
        {
            InitializeComponent();
            _servicioCatalogoApi = servicioCatalogoApi;

            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;
            this.txtCantidad.KeyPress += TxtCantidad_KeyPress;
        }

        public void CargarDatosLibro(string isbn, string titulo)
        {
            _isbnActual = isbn;
            lblTituloLibro.Text = $"Agregando ejemplares a:\n{titulo}\n(ISBN: {isbn})";
            txtCantidad.Text = "1"; 
        }

        private void TxtCantidad_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Por favor, ingrese una cantidad válida mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnGuardar.Enabled = false;
                btnGuardar.Text = "Guardando...";

                await _servicioCatalogoApi.AgregarEjemplaresAsync(_isbnActual, cantidad);

                MessageBox.Show($"Se han agregado {cantidad} ejemplares exitosamente al catálogo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
