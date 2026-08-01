using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Prestamos
{
    public partial class FormHistorialPrestamos : Form
    {
        private readonly IServicioPrestamoApi _servicioPrestamo;

        public FormHistorialPrestamos(IServicioPrestamoApi servicioPrestamo)
        {
            InitializeComponent();
            _servicioPrestamo = servicioPrestamo;
        }

        private async void btnHistorialUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string identificador = txtIdentificador.Text.Trim();
                if (string.IsNullOrEmpty(identificador)) return;

                var historial = await _servicioPrestamo.ConsultarHistorialPrestamosPorUsuarioAsync(identificador);
                dgvHistorial.DataSource = historial;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            try
            {
                var historialCompleto = await _servicioPrestamo.ConsultarHistorialCompletoAsync();
                dgvHistorial.DataSource = historialCompleto;
                txtIdentificador.Clear();
                txtIsbn.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar el historial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvHistorial.DataSource = null;
            }
        }

        private async void btnHistorialRecurso_Click(object sender, EventArgs e)
        {
            try
            {
                string isbn = txtIsbn.Text.Trim();
                if (string.IsNullOrEmpty(isbn)) return;

                var historial = await _servicioPrestamo.ConsultarHistorialPrestamosPorRecursoAsync(isbn);
                dgvHistorial.DataSource = historial;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormHistorialPrestamos_Load(object sender, EventArgs e)
        {
        }
    }
}