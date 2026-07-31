using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
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

        // 👇 NUEVO BOTÓN
        private async void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                var resultados = await _servicioPrestamo.ConsultarTodosAsync();
                dgvPrestamos.DataSource = resultados;
                txtIdentificador.Clear();
                txtIsbn.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void FormConsultarActivos_Load(object sender, EventArgs e)
        {
        }
    }
}