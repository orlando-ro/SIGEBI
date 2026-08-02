using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Diagnostics;
using SIGEBI.AppEscritorio.Utils;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Reportes
{
    public partial class FormCentroReportes : Form
    {
        private readonly IServicioReportesApi _servicioReportes;

        public FormCentroReportes(IServicioReportesApi servicioReportes)
        {
            InitializeComponent();
            _servicioReportes = servicioReportes;
        }

        private void FormCentroReportes_Load(object sender, EventArgs e)
        {
            // 1. Limpiamos cualquier opción que esté configurada en el diseñador visual
            cmbTipoReporte.Items.Clear();

            // 2. Cargamos las opciones dinámicamente según el Rol
            if (SessionManager.TipoUsuario == "PersonalBibliotecario")
            {
                cmbTipoReporte.Items.Add("Inventario Físico");
            }
            else // Para Administrador y Auditor
            {
                cmbTipoReporte.Items.Add("Préstamos");
                cmbTipoReporte.Items.Add("Penalizaciones");
                cmbTipoReporte.Items.Add("Uso del Catálogo");
                cmbTipoReporte.Items.Add("Inventario Físico");
                cmbTipoReporte.Items.Add("Auditoría General");
            }

            // Seleccionamos la primera opción por defecto
            if (cmbTipoReporte.Items.Count > 0)
            {
                cmbTipoReporte.SelectedIndex = 0;
            }

            // Ponemos fechas lógicas por defecto (últimos 30 días)
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;
        }
    
        

        private void cmbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            string reporteSeleccionado = cmbTipoReporte.SelectedItem?.ToString() ?? "";

            // El reporte de Inventario y Auditoría en la API no usan rango de fechas, así que desactivamos los calendarios.
            bool usaFechas = reporteSeleccionado != "Inventario Físico" && reporteSeleccionado != "Auditoría General";
            dtpDesde.Enabled = usaFechas;
            dtpHasta.Enabled = usaFechas;
        }

        private async void btnGenerar_Click(object sender, EventArgs e)
        {
            string reporteSeleccionado = cmbTipoReporte.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrEmpty(reporteSeleccionado))
            {
                MessageBox.Show("Por favor, seleccione un tipo de reporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnGenerar.Enabled = false;
                btnGenerar.Text = "⏳ Generando documento...";

                byte[] archivoPdf = Array.Empty<byte>();
                string nombrePropuesto = "";

                // Llamamos a la API según la selección
                switch (reporteSeleccionado)
                {
                    case "Préstamos":
                        archivoPdf = await _servicioReportes.DescargarReportePrestamosPdfAsync(dtpDesde.Value, dtpHasta.Value);
                        nombrePropuesto = $"Reporte_Prestamos_{DateTime.Now:yyyyMMdd}.pdf";
                        break;
                    case "Penalizaciones":
                        archivoPdf = await _servicioReportes.DescargarReportePenalizacionesPdfAsync(dtpDesde.Value, dtpHasta.Value);
                        nombrePropuesto = $"Reporte_Penalizaciones_{DateTime.Now:yyyyMMdd}.pdf";
                        break;
                    case "Uso del Catálogo":
                        archivoPdf = await _servicioReportes.DescargarReporteCatalogoPdfAsync(dtpDesde.Value, dtpHasta.Value);
                        nombrePropuesto = $"Reporte_Catalogo_{DateTime.Now:yyyyMMdd}.pdf";
                        break;
                    case "Inventario Físico":
                        archivoPdf = await _servicioReportes.DescargarReporteInventarioPdfAsync();
                        nombrePropuesto = $"Reporte_Inventario_{DateTime.Now:yyyyMMdd}.pdf";
                        break;
                    case "Auditoría General":
                        archivoPdf = await _servicioReportes.DescargarReporteAuditoriaPdfAsync(); // Sin filtros para este formulario base
                        nombrePropuesto = $"Reporte_Auditoria_{DateTime.Now:yyyyMMdd}.pdf";
                        break;
                }

                if (archivoPdf != null && archivoPdf.Length > 0)
                {
                    GuardarYAbrirPdf(archivoPdf, nombrePropuesto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al generar reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnGenerar.Enabled = true;
                btnGenerar.Text = "📄 Generar y Descargar PDF";
            }
        }

        private void GuardarYAbrirPdf(byte[] pdfBytes, string nombreArchivoSugerido)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivos PDF (*.pdf)|*.pdf";
                sfd.FileName = nombreArchivoSugerido;
                sfd.Title = "Guardar Reporte";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Guardamos el archivo físico en la PC
                    File.WriteAllBytes(sfd.FileName, pdfBytes);

                    // Preguntamos si desea abrirlo de una vez
                    var abrir = MessageBox.Show("El reporte se ha guardado correctamente.\n\n¿Desea abrirlo ahora?", "Descarga Completa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (abrir == DialogResult.Yes)
                    {
                        // Abrimos el PDF con el lector predeterminado del sistema operativo (Ej: Chrome, Edge, Adobe)
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
        }
    }
}