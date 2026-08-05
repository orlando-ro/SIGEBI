using SIGEBI.AppEscritorio.DTOs.Devoluciones;
using SIGEBI.AppEscritorio.DTOs.Prestamos;
using SIGEBI.AppEscritorio.Enums;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Devoluciones
{
    public partial class FormProcesarDevolucion : Form
    {
        private readonly IServicioDevolucionApi _servicioDevolucion;
        private readonly PrestamoResponseDTO _prestamoActual;

        public FormProcesarDevolucion(PrestamoResponseDTO prestamo, IServicioDevolucionApi servicioDevolucion)
        {
            InitializeComponent();
            _servicioDevolucion = servicioDevolucion;
            _prestamoActual = prestamo;
        }

        private void FormProcesarDevolucion_Load(object sender, EventArgs e)
        {
            cmbCondicion.DataSource = Enum.GetValues(typeof(CondicionDevolucion));

            lblNombreUsuario.Text = _prestamoActual.NombreUsuario;
            lblIdentificador.Text = !string.IsNullOrEmpty(_prestamoActual.Matricula)
                ? $"Matrícula: {_prestamoActual.Matricula}"
                : $"N° Empleado: {_prestamoActual.NumeroEmpleado}";

            lblFechas.Text = $"Vigencia: {_prestamoActual.FechaInicio:d} al {_prestamoActual.FechaVencimiento:d}";

            if (_prestamoActual.DiasRetraso > 0)
            {
                lblRetraso.Text = $"⚠️ PRÉSTAMO VENCIDO ({_prestamoActual.DiasRetraso} días de retraso)";
                lblRetraso.Visible = true;
            }

            // Muestra los títulos puros respetando la arquitectura KISS
            var ejemplaresValidos = _prestamoActual.TitulosLibros?.Where(l => !string.IsNullOrWhiteSpace(l)).ToList();

            if (ejemplaresValidos != null && ejemplaresValidos.Count > 0)
            {
                txtEjemplares.Text = "• " + string.Join("\r\n• ", ejemplaresValidos);
            }
            else
            {
                txtEjemplares.Text = "No se encontraron ejemplares registrados para este préstamo.";
            }
        }

        private void cmbCondicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? condicion = cmbCondicion.SelectedItem?.ToString();

            if (condicion != null && condicion != "BuenEstado")
            {
                lblObservaciones.Text = "Observaciones (OBLIGATORIO):";
                lblObservaciones.ForeColor = Color.FromArgb(220, 53, 69);
            }
            else
            {
                lblObservaciones.Text = "Observaciones (Opcional):";
                lblObservaciones.ForeColor = Color.Gainsboro;
            }
        }

        private async void btnProcesar_Click(object sender, EventArgs e)
        {
            var condicionSeleccionada = cmbCondicion.SelectedItem ?? CondicionDevolucion.BuenEstado;
            string condicionStr = condicionSeleccionada.ToString() ?? string.Empty;

            if (condicionStr != "BuenEstado" && string.IsNullOrWhiteSpace(txtObservaciones.Text))
            {
                MessageBox.Show("Debes incluir observaciones detalladas cuando el ejemplar es reportado como Dañado o Extraviado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtObservaciones.Focus();
                return;
            }

            var peticion = new DevolucionRequestDTO
            {
                IdPrestamo = _prestamoActual.IdPrestamo,
                CondicionLibro = (CondicionDevolucion)condicionSeleccionada,
                Observaciones = txtObservaciones.Text.Trim()
            };

            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnProcesar.Enabled = false;

                var resultado = await _servicioDevolucion.ProcesarDevolucionAsync(peticion);

                if (resultado != null)
                {
                    string msjPenalizacion = resultado.GeneroPenalizacion
                        ? "\n\n⚠️ ATENCIÓN: Se ha generado una penalización en el sistema."
                        : "";

                    MessageBox.Show(
                        $"¡Devolución procesada con éxito!\nTransacción: {resultado.IdDevolucion}{msjPenalizacion}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al procesar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnProcesar.Enabled = true;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}