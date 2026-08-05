using SIGEBI.AppEscritorio.DTOs.Prestamos;
using SIGEBI.AppEscritorio.Forms.Devoluciones;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Prestamos
{
    public partial class FormConsultarActivos : Form
    {
        private readonly IServicioPrestamoApi _servicioPrestamo;
        private readonly IServicioDevolucionApi _servicioDevolucion;

        public FormConsultarActivos(IServicioPrestamoApi servicioPrestamo, IServicioDevolucionApi servicioDevolucion)
        {
            InitializeComponent();
            _servicioPrestamo = servicioPrestamo;
            _servicioDevolucion = servicioDevolucion;
        }

        private async void FormConsultarActivos_Load(object sender, EventArgs e)
        {
            await RecargarTablaAsync();
        }

        private async Task RecargarTablaAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var resultados = await _servicioPrestamo.ConsultarTodosAsync();
                dgvPrestamos.DataSource = resultados;
                dgvPrestamos.ClearSelection();
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

                this.Cursor = Cursors.WaitCursor;
                var resultados = await _servicioPrestamo.ConsultarPrestamosActivosPorUsuarioAsync(identificador);
                dgvPrestamos.DataSource = resultados;
                dgvPrestamos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void btnBuscarPorRecurso_Click(object sender, EventArgs e)
        {
            try
            {
                string isbn = txtIsbn.Text.Trim();
                if (string.IsNullOrEmpty(isbn)) return;

                this.Cursor = Cursors.WaitCursor;
                var resultados = await _servicioPrestamo.ConsultarPrestamosActivosPorRecursoAsync(isbn);
                dgvPrestamos.DataSource = resultados;
                dgvPrestamos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void dgvPrestamos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var prestamoSeleccionado = (PrestamoResponseDTO)dgvPrestamos.Rows[e.RowIndex].DataBoundItem;

            using (var modalDevolucion = new FormProcesarDevolucion(prestamoSeleccionado, _servicioDevolucion))
            {
                if (modalDevolucion.ShowDialog() == DialogResult.OK)
                {
                    await RecargarTablaAsync();
                }
            }
        }
    }
}