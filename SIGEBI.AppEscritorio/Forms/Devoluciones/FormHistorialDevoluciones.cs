using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Devoluciones
{
    public partial class FormHistorialDevoluciones : Form
    {
        private readonly IServicioDevolucionApi _servicioDevolucion;

        public FormHistorialDevoluciones(IServicioDevolucionApi servicioDevolucion)
        {
            InitializeComponent();
            _servicioDevolucion = servicioDevolucion;
        }

        // 1. Cargamos el historial automáticamente al abrir
        private async void FormHistorialDevoluciones_Load(object sender, EventArgs e)
        {
            cmbCriterio.SelectedIndex = 0;
            await RecargarHistorialAsync();
        }

        // 2. Método centralizado
        private async Task RecargarHistorialAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var historialCompleto = await _servicioDevolucion.ConsultarHistorialCompletoAsync();
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

        private void cmbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string criterio = cmbCriterio.SelectedItem?.ToString() ?? "";
            txtBusqueda.Clear();
            txtBusqueda.PlaceholderText = criterio == "Matrícula / Empleado" ? "Ej: 2025-2050" : "Ej: 978-0132350884";
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = cmbCriterio.SelectedItem?.ToString() ?? "";
            string valor = txtBusqueda.Text.Trim();

            if (string.IsNullOrEmpty(valor))
            {
                MessageBox.Show("Por favor, ingrese un valor para buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (criterio == "Matrícula / Empleado")
                {
                    var historial = await _servicioDevolucion.ConsultarHistorialDevolucionesPorUsuarioAsync(valor);
                    dgvHistorial.DataSource = historial;
                }
                else if (criterio == "ISBN Libro")
                {
                    var historial = await _servicioDevolucion.ConsultarHistorialDevolucionesPorRecursoAsync(valor);
                    dgvHistorial.DataSource = historial;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. El botón ahora funciona como "Refrescar"
        private async void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
            await RecargarHistorialAsync();
        }

        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}