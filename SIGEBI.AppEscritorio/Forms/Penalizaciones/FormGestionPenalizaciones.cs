using SIGEBI.AppEscritorio.DTOs.Penalizaciones;
using SIGEBI.AppEscritorio.Services.Interfaces;
using SIGEBI.AppEscritorio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Penalizaciones
{
    public partial class FormGestionPenalizaciones : Form
    {
        private readonly IServicioPenalizacionApi _servicioPenalizacion;

        public FormGestionPenalizaciones(IServicioPenalizacionApi servicioPenalizacion)
        {
            InitializeComponent();
            _servicioPenalizacion = servicioPenalizacion;
        }

        private async void FormGestionPenalizaciones_Load(object sender, EventArgs e)
        {
            // Inicializar el ComboBox de Filtros
            cmbFiltroEstado.Items.Add("Multas Pendientes");
            cmbFiltroEstado.Items.Add("Historial de Pagos");
            cmbFiltroEstado.SelectedIndex = 0; // Selecciona "Pendientes" por defecto

            await CargarDatosAsync();
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string identificador = txtBusqueda.Text.Trim();
                bool viendoHistorial = cmbFiltroEstado.SelectedIndex == 1;

                IEnumerable<PenalizacionResponseDTO> resultados;

                if (string.IsNullOrEmpty(identificador))
                {
                    resultados = viendoHistorial
                        ? await _servicioPenalizacion.ObtenerTodasHistorialAsync()
                        : await _servicioPenalizacion.ObtenerTodasPendientesAsync();
                }
                else
                {
                    resultados = viendoHistorial
                        ? await _servicioPenalizacion.ObtenerHistorialPorUsuarioAsync(identificador)
                        : await _servicioPenalizacion.ObtenerPendientesPorUsuariosAsync(identificador);
                }

                dgvPenalizaciones.DataSource = resultados.ToList();
                dgvPenalizaciones.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvPenalizaciones.DataSource = null;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBusqueda.Text.Trim()))
            {
                MessageBox.Show("Por favor, ingrese la matrícula o número de empleado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBusqueda.Focus();
                return;
            }
            await CargarDatosAsync();
        }

        private async void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
            await CargarDatosAsync();
        }

        private async void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            await CargarDatosAsync();
        }

        private async void dgvPenalizaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Extraemos el objeto completo con la metadata oculta
            var penalizacion = (PenalizacionResponseDTO)dgvPenalizaciones.Rows[e.RowIndex].DataBoundItem;

            // Bloquear acciones si es un usuario normal (solo personal/admin pueden procesar pagos)
            bool esStaff = SessionManager.TipoUsuario == "PersonalBibliotecario" || SessionManager.TipoUsuario == "Administrador";

            using (var modal = new FormDetallePenalizacion(penalizacion, _servicioPenalizacion, esStaff))
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    await CargarDatosAsync(); // Recarga si se efectuó un pago
                }
            }
        }
    }
}