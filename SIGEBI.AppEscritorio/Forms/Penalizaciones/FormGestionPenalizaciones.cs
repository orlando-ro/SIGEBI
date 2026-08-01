using SIGEBI.AppEscritorio.DTOs.Penalizaciones;
using SIGEBI.AppEscritorio.Services.Interfaces;
using SIGEBI.AppEscritorio.Utils;
using System;
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

        private void FormGestionPenalizaciones_Load(object sender, EventArgs e)
        {
            // Seguridad: Solo Bibliotecarios y Administradores pueden registrar pagos.
            // (Aunque en FormPrincipal ya restringimos la entrada, es buena práctica blindar el panel de acciones).
            if (SessionManager.TipoUsuario != "PersonalBibliotecario" && SessionManager.TipoUsuario != "Administrador")
            {
                panelAcciones.Visible = false;
                dgvPenalizaciones.Height += panelAcciones.Height;
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

            await CargarPendientes(identificador);
        }

        private async void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            try
            {
                var pendientes = await _servicioPenalizacion.ObtenerTodasPendientesAsync();
                dgvPenalizaciones.DataSource = pendientes.ToList();
                txtMotivoResolucion.Clear();
                txtBusqueda.Clear();

                if (!pendientes.Any())
                {
                    MessageBox.Show("No hay penalizaciones pendientes en el sistema.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvPenalizaciones.DataSource = null;
            }
        }

        private async System.Threading.Tasks.Task CargarPendientes(string identificador)
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

            // Extraemos el identificador de la fila seleccionada por si cambió el TextBox de búsqueda
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

                // Recargamos la tabla con el usuario actual
                await CargarPendientes(txtBusqueda.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}