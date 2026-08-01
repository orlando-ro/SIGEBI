using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIGEBI.AppEscritorio.Services;
using SIGEBI.AppEscritorio.Utils;

namespace SIGEBI.AppEscritorio.Forms.Notificaciones
{
    public partial class formGestionNotificaciones : Form
    {
        private readonly IServicioNotificacionApi _servicioNotificacionApi;

        public formGestionNotificaciones(IServicioNotificacionApi servicioNotificacionApi)
        {
            InitializeComponent();
            _servicioNotificacionApi = servicioNotificacionApi;

            ConfigurarAccesosPorRol();

            this.Load += FormGestionNotificaciones_Load;
            btnActualizar.Click += BtnActualizar_Click;
            btnDispararVencimientos.Click += BtnDispararVencimientos_Click;
        }

        private void ConfigurarAccesosPorRol()
        {
            if (SessionManager.TipoUsuario == "Auditor")
            {
                btnDispararVencimientos.Visible = false;
                lblDiasAntelacion.Visible = false;
                nudDiasAntelacion.Visible = false;
            }
        }

        private async void FormGestionNotificaciones_Load(object? sender, EventArgs e)
        {
            await CargarHistorialAsync();
        }

        private async void BtnActualizar_Click(object? sender, EventArgs e)
        {
            await CargarHistorialAsync();
        }

        private async void BtnDispararVencimientos_Click(object? sender, EventArgs e)
        {
            int diasSeleccionados = (int)nudDiasAntelacion.Value;

            var confirmacion = MessageBox.Show(
                $"¿Está seguro que desea disparar manualmente las alertas de vencimiento? " +
                $"Esto generará notificaciones para todos los usuarios con préstamos a {diasSeleccionados} días de vencer.",
                "Confirmar Acción",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    btnDispararVencimientos.Enabled = false;

                    bool exito = await _servicioNotificacionApi.TriggerVencimientosAsync(diasSeleccionados);

                    if (exito)
                    {
                        MessageBox.Show($"Las alertas a {diasSeleccionados} días se han generado y enviado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarHistorialAsync();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un problema al intentar generar las alertas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnDispararVencimientos.Enabled = true;
                }
            }
        }

        private async Task CargarHistorialAsync()
        {
            try
            {
                dgvNotificaciones.DataSource = null;
                var historial = await _servicioNotificacionApi.ConsultarHistorialGlobalAsync();

                var listaOrdenada = historial.OrderByDescending(n => n.FechaEnvio).ToList();
                dgvNotificaciones.DataSource = listaOrdenada;

                if (dgvNotificaciones.Columns.Count > 0)
                {
                    dgvNotificaciones.Columns["Id"].Width = 50;

                    dgvNotificaciones.Columns["Mensaje"].HeaderText = "Contenido del Mensaje";
                    dgvNotificaciones.Columns["Mensaje"].FillWeight = 200;

                    dgvNotificaciones.Columns["FechaEnvio"].HeaderText = "Fecha de Envío";
                    dgvNotificaciones.Columns["FechaEnvio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                    dgvNotificaciones.Columns["Tipo"].HeaderText = "Tipo de Alerta";

                    dgvNotificaciones.Columns["Leida"].HeaderText = "¿Fue Leída?";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo cargar el historial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formGestionNotificaciones_Load_1(object sender, EventArgs e)
        {

        }
    }
}