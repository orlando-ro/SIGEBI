using SIGEBI.AppEscritorio.DTOs.Penalizaciones;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Penalizaciones
{
    public partial class FormDetallePenalizacion : Form
    {
        private readonly IServicioPenalizacionApi _servicioPenalizacion;
        private readonly PenalizacionResponseDTO _penalizacion;
        private readonly bool _esStaff;

        public FormDetallePenalizacion(PenalizacionResponseDTO penalizacion, IServicioPenalizacionApi servicioPenalizacion, bool esStaff)
        {
            InitializeComponent();
            _penalizacion = penalizacion;
            _servicioPenalizacion = servicioPenalizacion;
            _esStaff = esStaff;
        }

        private void FormDetallePenalizacion_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = _penalizacion.NombreUsuario;
            lblIdentificador.Text = !string.IsNullOrEmpty(_penalizacion.Matricula)
                ? $"Matrícula: {_penalizacion.Matricula}"
                : $"N° Empleado: {_penalizacion.NumeroEmpleado}";

            lblMonto.Text = $"RD$ {_penalizacion.Monto:N2}";
            lblFecha.Text = $"Emitida el: {_penalizacion.FechaEmision:dd/MM/yyyy}";
            txtMotivo.Text = _penalizacion.Motivo;

            if (!_penalizacion.Pagada)
            {
                lblEstado.Text = "ESTADO: PENDIENTE DE PAGO";
                lblEstado.ForeColor = Color.FromArgb(220, 53, 69); // Rojo
                lblMonto.ForeColor = Color.FromArgb(220, 53, 69);

                txtResolucion.Visible = true;

                // UX: Hacemos visualmente explícito que este campo es requerido
                lblResolucion.Text = "Motivo de Resolución (OBLIGATORIO):";
                lblResolucion.ForeColor = Color.FromArgb(220, 53, 69);

                btnProcesarPago.Visible = _esStaff; // Solo el staff puede ver el botón de pago
            }
            else
            {
                lblEstado.Text = "ESTADO: RESUELTA / PAGADA";
                lblEstado.ForeColor = Color.FromArgb(25, 135, 84); // Verde
                lblMonto.ForeColor = Color.FromArgb(25, 135, 84);

                txtResolucion.ReadOnly = true;
                txtResolucion.Text = _penalizacion.MotivoResolucion;

                string resolutor = !string.IsNullOrEmpty(_penalizacion.NombreResolutor)
                    ? _penalizacion.NombreResolutor
                    : "Administración del Sistema";

                lblResolucion.Text = $"Resuelta el: {_penalizacion.FechaResolucion:dd/MM/yyyy} por {resolutor}\nMotivo:";
                lblResolucion.ForeColor = Color.Gainsboro; // Restauramos el color normal

                btnProcesarPago.Visible = false;
            }
        }

        private async void btnProcesarPago_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtResolucion.Text))
            {
                MessageBox.Show("Debe especificar el método de pago o motivo de resolución.", "Validación Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtResolucion.Focus();
                return;
            }

            var confirmacion = MessageBox.Show($"¿Confirma que se ha recibido el pago de RD$ {_penalizacion.Monto:N2}?", "Confirmar Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                // 🔥 Aquí se corrige la advertencia CS8601 garantizando que nunca sea null
                var peticion = new PenalizacionRequestDTO
                {
                    MatriculaONumeroEmpleado = (!string.IsNullOrEmpty(_penalizacion.Matricula) ? _penalizacion.Matricula : _penalizacion.NumeroEmpleado) ?? string.Empty,
                    MotivoResolucion = txtResolucion.Text.Trim()
                };

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    btnProcesarPago.Enabled = false;

                    await _servicioPenalizacion.ProcesarPagoMultaAsync(_penalizacion.IdPenalizacion, peticion);

                    MessageBox.Show("¡La penalización ha sido marcada como resuelta exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al procesar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnProcesarPago.Enabled = true;
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}