using Microsoft.Extensions.DependencyInjection;
using SIGEBI.AppEscritorio.DTOs.Auditoria;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.IO;
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
            cboModulo.SelectedIndex = 0; // "Todos"
            dtpFechaInicio.Value = DateTime.Now.AddDays(-30);
            dtpFechaFin.Value = DateTime.Now;

            await EjecutarBusquedaAsync();
        }

        private async Task EjecutarBusquedaAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DateTime? inicio = chkUsarFechas.Checked ? dtpFechaInicio.Value.Date : null;
                DateTime? fin = chkUsarFechas.Checked ? dtpFechaFin.Value.Date : null;
                string accion = txtAccion.Text.Trim();
                string modulo = cboModulo.SelectedItem?.ToString() ?? "Todos";

                var registros = await _servicioAuditoria.ConsultarHistorialAuditoriaAsync(inicio, fin, accion, modulo);

                dgvAuditoria.DataSource = registros;
                dgvAuditoria.ClearSelection();

                // 🔥 Ocultamos la columna detalles de la tabla principal para mejor experiencia de usuario
                if (dgvAuditoria.Columns.Contains("Detalles"))
                {
                    dgvAuditoria.Columns["Detalles"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar la auditoría:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvAuditoria.DataSource = null;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await EjecutarBusquedaAsync();
        }

        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            txtAccion.Clear();
            cboModulo.SelectedIndex = 0;
            chkUsarFechas.Checked = false;
            dtpFechaInicio.Value = DateTime.Now.AddDays(-30);
            dtpFechaFin.Value = DateTime.Now;
            await EjecutarBusquedaAsync();
        }

        // 🔥 Doble clic para abrir el formulario elegante de detalles
        private void dgvAuditoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvAuditoria.Rows[e.RowIndex].DataBoundItem is AuditoriaResponseDTO registroSeleccionado)
            {
                using var modalDetalle = new FormDetalleAuditoria(registroSeleccionado);
                modalDetalle.ShowDialog(this);
            }
        }

        // Exportación a Excel Profesional (CSV)
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvAuditoria.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Archivo Excel/CSV|*.csv", FileName = "Historial_Auditoria.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new System.Text.StringBuilder();
                        sb.AppendLine("Fecha y Hora,Acción Realizada,Módulo / Entidad");

                        foreach (DataGridViewRow row in dgvAuditoria.Rows)
                        {
                            if (row.DataBoundItem is AuditoriaResponseDTO reg)
                            {
                                sb.AppendLine($"{reg.FechaFormateada},{reg.Accion},{reg.EntidadAfectada}");
                            }
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), new System.Text.UTF8Encoding(true));
                        MessageBox.Show("Datos exportados exitosamente a Excel.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // 🔥 Exportación a PDF llamando a la API
        private async void btnExportarPdf_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DateTime? inicio = chkUsarFechas.Checked ? dtpFechaInicio.Value.Date : null;
                DateTime? fin = chkUsarFechas.Checked ? dtpFechaFin.Value.Date : null;
                string accion = txtAccion.Text.Trim();
                string modulo = cboModulo.SelectedItem?.ToString() ?? "Todos";

                var pdfBytes = await _servicioAuditoria.ExportarHistorialPDFAsync(inicio, fin, accion, modulo);

                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Archivo PDF|*.pdf", FileName = $"ReporteAuditoria_{DateTime.Now:yyyyMMdd_HHmmss}.pdf" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(sfd.FileName, pdfBytes);
                        MessageBox.Show("Reporte PDF generado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el PDF:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void dgvAuditoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}