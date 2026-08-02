using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Drawing;
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
            AplicarEstiloTablaModerna(dgvHistorial); // Aplicamos el diseño antes de cargar datos
            await RecargarHistorialAsync();
        }

        // Método de diseño inyectado
        private void AplicarEstiloTablaModerna(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.FromArgb(20, 24, 38);
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;

            // Líneas divisorias horizontales
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(70, 75, 90);

            // Estilo de filas normales
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(30, 34, 48);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(13, 110, 253);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            // Estilo de filas cebra
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(38, 43, 60);

            // Altura de filas
            dgv.RowTemplate.Height = 40;

            // Encabezados
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 18, 28);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 45;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
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

        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}