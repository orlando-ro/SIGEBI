using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Prestamos
{
    public partial class FormConsultarActivos : Form
    {
        private readonly IServicioPrestamoApi _servicioPrestamo;

        public FormConsultarActivos(IServicioPrestamoApi servicioPrestamo)
        {
            InitializeComponent();
            _servicioPrestamo = servicioPrestamo;
        }

        // 1. Cargamos todo automáticamente al abrir el formulario
        private async void FormConsultarActivos_Load(object sender, EventArgs e)
        {
            await RecargarTablaAsync();
        }

        // 2. Método centralizado para cargar los datos
        private async Task RecargarTablaAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var resultados = await _servicioPrestamo.ConsultarTodosAsync();
                dgvPrestamos.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // 3. El botón ahora funciona como "Refrescar"
        private async void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtIdentificador.Clear();
            txtIsbn.Clear();
            await RecargarTablaAsync();
        }

        private async void btnBuscarPorUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string identificador = txtIdentificador.Text.Trim();
                if (string.IsNullOrEmpty(identificador)) return;

                var resultados = await _servicioPrestamo.ConsultarPrestamosActivosPorUsuarioAsync(identificador);
                dgvPrestamos.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnBuscarPorRecurso_Click(object sender, EventArgs e)
        {
            try
            {
                string isbn = txtIsbn.Text.Trim();
                if (string.IsNullOrEmpty(isbn)) return;

                var resultados = await _servicioPrestamo.ConsultarPrestamosActivosPorRecursoAsync(isbn);
                dgvPrestamos.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}