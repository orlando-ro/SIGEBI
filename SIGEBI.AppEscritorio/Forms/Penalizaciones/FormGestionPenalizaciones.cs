using SIGEBI.AppEscritorio.DTOs.Penalizaciones;
using SIGEBI.AppEscritorio.Services.Interfaces;
using SIGEBI.AppEscritorio.Utils;
using System;
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

        // 1. Carga automática con control de seguridad
        private async void FormGestionPenalizaciones_Load(object sender, EventArgs e)
        {
            if (SessionManager.TipoUsuario != "PersonalBibliotecario" && SessionManager.TipoUsuario != "Administrador")
            {
                panelAcciones.Visible = false;
                dgvPenalizaciones.Height += panelAcciones.Height;
            }

            await RecargarPendientesAsync();
        }

        // 2. Método centralizado
        private async Task RecargarPendientesAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var pendientes = await _servicioPenalizacion.ObtenerTodasPendientesAsync();
                dgvPenalizaciones.DataSource = pendientes.ToList();
                txtMotivoResolucion.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvPenalizaciones.DataSource = null;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string identificador = txtBusqueda.Text.Trim();

            if (string.IsNullOrEmpty(identificador))
            {
                MessageBox.Show("Por favor, ingrese la matrícula o número de empleado a buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBusqueda.Focus();
                return;
            }

            await CargarPendientesUsuario(identificador);
        }

        // 3. El botón ahora funciona como "Refrescar"
        private async void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
            await RecargarPendientesAsync();

            // Si después de recargar manual la tabla está vacía, mostramos aviso
            if (dgvPenalizaciones.Rows.Count == 0)
            {
                MessageBox.Show("No hay penalizaciones pendientes en el sistema.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task CargarPendientesUsuario(string identificador)
        {
            try
            {
                var pendientes = await _servicioPenalizacion.ObtenerPendientesPorUsuariosAsync(identificador);
                dgvPenalizaciones.DataSource = pendientes;
                txtMotivoResolucion.Clear();

                if (!pendientes.Any())
                {
                    MessageBox.Show("Este usuario no tiene penalizaciones pendientes de pago.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en la búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvPenalizaciones.DataSource = null;
            }
        }

        private async void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (dgvPenalizaciones.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione una penalización de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string motivoResolucion = txtMotivoResolucion.Text.Trim();
            if (string.IsNullOrEmpty(motivoResolucion))
            {
                MessageBox.Show("Debe especificar el método o motivo de resolución (Ej: Pago en efectivo, Exoneración).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivoResolucion.Focus();
                return;
            }

            int idPenalizacion = Convert.ToInt32(dgvPenalizaciones.CurrentRow.Cells["IdPenalizacion"].Value);

            string matricula = dgvPenalizaciones.CurrentRow.Cells["Matricula"].Value?.ToString() ?? "";
            string empleado = dgvPenalizaciones.CurrentRow.Cells["NumeroEmpleado"].Value?.ToString() ?? "";
            string identificadorFinal = !string.IsNullOrEmpty(matricula) ? matricula : empleado;

            var peticion = new PenalizacionRequestDTO
            {
                MatriculaONumeroEmpleado = identificadorFinal,
                MotivoResolucion = motivoResolucion
            };

            try
            {
                await _servicioPenalizacion.ProcesarPagoMultaAsync(idPenalizacion, peticion);
                MessageBox.Show($"El pago de la penalización #{idPenalizacion} ha sido registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Si el textbox de búsqueda tiene texto, recarga solo ese usuario; si no, recarga todo
                if (!string.IsNullOrEmpty(txtBusqueda.Text.Trim()))
                {
                    await CargarPendientesUsuario(txtBusqueda.Text.Trim());
                }
                else
                {
                    await RecargarPendientesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}