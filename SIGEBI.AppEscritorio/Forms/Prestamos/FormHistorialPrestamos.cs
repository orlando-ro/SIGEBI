using SIGEBI.AppEscritorio.DTOs.Prestamos;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Prestamos
{
    public partial class FormHistorialPrestamos : Form
    {
        private readonly IServicioPrestamoApi _servicioPrestamo;

        public FormHistorialPrestamos(IServicioPrestamoApi servicioPrestamo)
        {
            InitializeComponent();
            _servicioPrestamo = servicioPrestamo;
        }

        private async void FormHistorialPrestamos_Load(object sender, EventArgs e)
        {
            cboEstado.SelectedIndex = 0; // "Todos" por defecto
            await EjecutarBusquedaAsync();
        }

        private async Task EjecutarBusquedaAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string termino = txtBusqueda.Text.Trim();
                string estado = cboEstado.SelectedItem?.ToString() ?? "Todos";

                var historial = await _servicioPrestamo.ConsultarHistorialAvanzadoAsync(termino, estado);
                dgvHistorial.DataSource = historial;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvHistorial.DataSource = null;
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

        private async void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
            cboEstado.SelectedIndex = 0;
            await EjecutarBusquedaAsync();
        }

        // Evento de Doble Clic para abrir el Modal Limpio
        private void dgvHistorial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvHistorial.Rows[e.RowIndex].DataBoundItem is PrestamoResponseDTO dtoSeleccionado)
            {
                using (var modal = new FormDetallePrestamo(dtoSeleccionado))
                {
                    modal.ShowDialog();
                }
            }
        }

        // Exportación Profesional a Excel (CSV con UTF-8 BOM)
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Archivo Excel/CSV|*.csv", FileName = "Historial_Prestamos.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder csvData = new StringBuilder();

                        // Escribir los encabezados (saltando las columnas invisibles)
                        for (int i = 0; i < dgvHistorial.Columns.Count; i++)
                        {
                            if (dgvHistorial.Columns[i].Visible)
                            {
                                csvData.Append(dgvHistorial.Columns[i].HeaderText + ",");
                            }
                        }
                        csvData.AppendLine();

                        // Escribir las filas
                        foreach (DataGridViewRow row in dgvHistorial.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.OwningColumn.Visible)
                                {
                                    string valor = cell.Value?.ToString()?.Replace(",", " ") ?? "";
                                    csvData.Append(valor + ",");
                                }
                            }
                            csvData.AppendLine();
                        }

                        // Guardar respetando acentos (UTF8 BOM)
                        File.WriteAllText(sfd.FileName, csvData.ToString(), new UTF8Encoding(true));
                        MessageBox.Show("Datos exportados exitosamente a Excel.", "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}