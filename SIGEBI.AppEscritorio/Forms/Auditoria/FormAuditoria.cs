using Microsoft.Extensions.DependencyInjection;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Auditoria
{
    public partial class FormAuditoria : Form
    {
        private readonly IServicioAuditoriaApi _servicioAuditoria;

        public FormAuditoria(IServicioAuditoriaApi servicioAuditoria)
        {
            InitializeComponent();
            _servicioAuditoria = servicioAuditoria;
        }

        private async void FormAuditoria_Load(object sender, EventArgs e)
        {
            await CargarHistorialAuditoria();
        }

        private async Task CargarHistorialAuditoria()
        {
            try
            {
                // Cambiamos el cursor para indicar que está cargando
                this.Cursor = Cursors.WaitCursor;

                // Llamamos a la API 
                var registros = await _servicioAuditoria.ConsultarHistorialAuditoriaAsync();

                // Asignamos la lista al DataGridView
                dgvAuditoria.DataSource = registros;

                // Ocultamos columnas técnicas y formateamos
                if (dgvAuditoria.Columns.Contains("IdResponsable"))
                    dgvAuditoria.Columns["IdResponsable"].Visible = false;

                if (dgvAuditoria.Columns.Contains("FechaHora"))
                    dgvAuditoria.Columns["FechaHora"].Visible = false; // Ocultamos la original porque usaremos la formateada

                if (dgvAuditoria.Columns.Contains("FechaFormateada"))
                    dgvAuditoria.Columns["FechaFormateada"].HeaderText = "Fecha y Hora";

                if (dgvAuditoria.Columns.Contains("Detalles"))
                    dgvAuditoria.Columns["Detalles"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar la auditoría:\n{ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}