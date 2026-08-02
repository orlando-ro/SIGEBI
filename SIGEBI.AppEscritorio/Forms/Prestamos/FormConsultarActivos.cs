using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Drawing;
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

       
        private async void FormConsultarActivos_Load(object sender, EventArgs e)
        {
            AplicarEstiloTablaModerna(dgvPrestamos); 
            await RecargarTablaAsync();
        }

      
        private void AplicarEstiloTablaModerna(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.FromArgb(20, 24, 38);
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;

            
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(70, 75, 90);

           
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(30, 34, 48);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(13, 110, 253);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(38, 43, 60);

            
            dgv.RowTemplate.Height = 40;

            
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

        private void dgvPrestamos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}