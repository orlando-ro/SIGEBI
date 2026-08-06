using SIGEBI.AppEscritorio.Services.Interfaces;
using SIGEBI.AppEscritorio.Utils;
using System;
using System.Diagnostics;
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
            cmbTipoReporte.Items.Clear();

            if (SessionManager.TipoUsuario == "PersonalBibliotecario")
            {
                cmbTipoReporte.Items.Add("Inventario Físico");
            }
            else
            {
                cmbTipoReporte.Items.Add("Préstamos");
                cmbTipoReporte.Items.Add("Penalizaciones");
                cmbTipoReporte.Items.Add("Uso del Catálogo");
                cmbTipoReporte.Items.Add("Inventario Físico");
                cmbTipoReporte.Items.Add("Auditoría General");
            }

            if (cmbTipoReporte.Items.Count > 0)
            {
                cmbTipoReporte.SelectedIndex = 0;
            }

            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;
        }

        private void cmbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            string reporteSeleccionado = cmbTipoReporte.SelectedItem?.ToString() ?? "";

            bool usaFechas = reporteSeleccionado != "Inventario Físico";
            dtpDesde.Enabled = usaFechas;
            dtpHasta.Enabled = usaFechas;

            ActualizarDetalleInformativo(reporteSeleccionado);
        }

        private void ActualizarDetalleInformativo(string tipoReporte)
        {
            switch (tipoReporte)
            {
                case "Préstamos":
                    lblInfoTitulo.Text = "📝 Reporte de Préstamos";
                    lblInfoBadge.Text = "REQUIERE FECHAS";
                    lblInfoBadge.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
                    lblInfoDescripcion.Text = "Visión analítica del flujo de circulación de libros. Ideal para auditar el volumen y la puntualidad.";
                    txtInfoMetricas.Text =
                        "• Total de préstamos procesados.\r\n\r\n" +
                        "• Desglose de devoluciones a tiempo vs. vencidos.\r\n\r\n" +
                        "• Índice global de puntualidad (%).\r\n\r\n" +
                        "• Listado detallado de ejemplares y estados.";
                    break;

                case "Penalizaciones":
                    lblInfoTitulo.Text = "💰 Multas y Penalidades";
                    lblInfoBadge.Text = "REQUIERE FECHAS";
                    lblInfoBadge.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
                    lblInfoDescripcion.Text = "Consolida las sanciones financieras y administrativas emitidas a usuarios por tardanzas o daños.";
                    txtInfoMetricas.Text =
                        "• Conteo total de penalizaciones registradas.\r\n\r\n" +
                        "• Monto financiero acumulado (RD$).\r\n\r\n" +
                        "• Comparativa de pago (Pagadas vs. Pendientes).\r\n\r\n" +
                        "• Listado por usuario, motivo y fecha.";
                    break;

                case "Uso del Catálogo":
                    lblInfoTitulo.Text = "📚 Demanda del Catálogo";
                    lblInfoBadge.Text = "REQUIERE FECHAS";
                    lblInfoBadge.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
                    lblInfoDescripcion.Text = "Analiza la popularidad y rotación del acervo. Ayuda en la decisión de nuevas adquisiciones.";
                    txtInfoMetricas.Text =
                        "• Top de libros y títulos más solicitados.\r\n\r\n" +
                        "• Distribución de demanda por categoría.\r\n\r\n" +
                        "• Total acumulado de solicitudes registradas.";
                    break;

                case "Inventario Físico":
                    lblInfoTitulo.Text = "📦 Inventario Físico";
                    lblInfoBadge.Text = "TIEMPO REAL";
                    lblInfoBadge.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
                    lblInfoDescripcion.Text = "Auditoría instantánea de la totalidad de ejemplares físicos registrados en este momento exacto.";
                    txtInfoMetricas.Text =
                        "• Volumen total de recursos físicos inventariados.\r\n\r\n" +
                        "• Cantidad de ejemplares Disponibles.\r\n\r\n" +
                        "• Cantidad de ejemplares Prestados o Dañados.\r\n\r\n" +
                        "• Listado maestro de códigos y categorías.";
                    break;

                case "Auditoría General":
                    lblInfoTitulo.Text = "🛡️ Auditoría del Sistema";
                    lblInfoBadge.Text = "FILTRO OPTATIVO";
                    lblInfoBadge.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
                    lblInfoDescripcion.Text = "Registro inmutable de seguridad de las operaciones ejecutadas por los usuarios en la plataforma.";
                    txtInfoMetricas.Text =
                        "• Conteo total de registros de seguridad.\r\n\r\n" +
                        "• Diversidad de usuarios y actores involucrados.\r\n\r\n" +
                        "• Módulos y entidades del sistema impactados.\r\n\r\n" +
                        "• Detalle cronológico preciso de cada acción.";
                    break;

                default:
                    lblInfoTitulo.Text = "Seleccione un Reporte";
                    lblInfoBadge.Text = "N/A";
                    lblInfoBadge.BackColor = System.Drawing.Color.Gray;
                    lblInfoDescripcion.Text = "Seleccione un tipo de reporte para visualizar sus detalles.";
                    txtInfoMetricas.Text = "";
                    break;
            }
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
                        archivoPdf = await _servicioReportes.DescargarReporteAuditoriaPdfAsync(dtpDesde.Value, dtpHasta.Value);
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
                    File.WriteAllBytes(sfd.FileName, pdfBytes);

                    var abrir = MessageBox.Show("El reporte se ha generado y guardado correctamente.\n\n¿Desea abrirlo ahora?", "Descarga Completa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (abrir == DialogResult.Yes)
                    {
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