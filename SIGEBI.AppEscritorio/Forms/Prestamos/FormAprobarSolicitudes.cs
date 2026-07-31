using SIGEBI.AppEscritorio.DTOs.Prestamos;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Prestamos
{
    public partial class FormAprobarSolicitudes : Form
    {
        private readonly IServicioPrestamoApi _servicioPrestamo;

        public FormAprobarSolicitudes(IServicioPrestamoApi servicioPrestamo)
        {
            InitializeComponent();
            _servicioPrestamo = servicioPrestamo;
        }

        private async void btnAprobar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIdSolicitud.Text.Trim(), out int idSolicitud))
                {
                    MessageBox.Show("Por favor, introduzca un ID de solicitud válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var peticion = new PrestamoRequestDTO { IdSolicitud = idSolicitud };
                var resultado = await _servicioPrestamo.AprobarYCrearPrestamoAsync(peticion);

                if (resultado != null)
                {
                    MessageBox.Show($"¡Préstamo aprobado y registrado con éxito! ID de Préstamo: {resultado.IdPrestamo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIdSolicitud.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo completar la aprobación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al aprobar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormAprobarSolicitudes_Load(object sender, EventArgs e)
        {
        }
    }
}