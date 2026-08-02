using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Threading.Tasks;
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

        // 1. Cargamos el historial automáticamente al abrir el formulario
        private async void FormHistorialPrestamos_Load(object sender, EventArgs e)
        {
            await RecargarHistorialAsync();
        }

        // 2. Método centralizado
        private async Task RecargarHistorialAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var historialCompleto = await _servicioPrestamo.ConsultarHistorialCompletoAsync();
                dgvHistorial.DataSource = historialCompleto;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar el historial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvHistorial.DataSource = null;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // 3. El botón ahora funciona como "Refrescar"
        private async void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            txtIdentificador.Clear();
            txtIsbn.Clear();
            await RecargarHistorialAsync();
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
    }
}