using SIGEBI.AppEscritorio.DTOs.Devoluciones;
using SIGEBI.AppEscritorio.Enums;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Devoluciones
{
    public partial class FormProcesarDevolucion : Form
    {
        private readonly IServicioDevolucionApi _servicioDevolucion;

        public FormProcesarDevolucion(IServicioDevolucionApi servicioDevolucion)
        {
            InitializeComponent();
            _servicioDevolucion = servicioDevolucion;
        }

        private void FormProcesarDevolucion_Load(object sender, EventArgs e)
        {
            // Cargar el Enum en el ComboBox de forma automática
            cmbCondicion.DataSource = Enum.GetValues(typeof(CondicionDevolucion));
        }

        private async void btnProcesar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdPrestamo.Text.Trim(), out int idPrestamo))
            {
                MessageBox.Show("Por favor, introduzca un ID de préstamo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var condicionSeleccionada = cmbCondicion.SelectedItem ?? CondicionDevolucion.BuenEstado;

            var peticion = new DevolucionRequestDTO
            {
                IdPrestamo = idPrestamo,
                CondicionLibro =  (CondicionDevolucion)condicionSeleccionada,
                Observaciones = txtObservaciones.Text.Trim()
            };

            try
            {
                var resultado = await _servicioDevolucion.ProcesarDevolucionAsync(peticion);

                if (resultado != null)
                {
                    string msjPenalizacion = resultado.GeneroPenalizacion
                        ? "\n⚠️ ATENCIÓN: Se ha generado una penalización por retraso o daño."
                        : "";

                    MessageBox.Show(
                        $"¡Devolución procesada con éxito!\nID Devolución: {resultado.IdDevolucion}\nLibros: {string.Join(", ", resultado.TitulosLibros)}{msjPenalizacion}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al procesar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtIdPrestamo.Clear();
            txtObservaciones.Clear();
            cmbCondicion.SelectedIndex = 0;
            txtIdPrestamo.Focus();
        }
    }
}