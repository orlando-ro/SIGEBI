using SIGEBI.AppEscritorio.DTOs.Prestamos;
using SIGEBI.AppEscritorio.Forms.Devoluciones;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Prestamos
{
    public partial class FormConsultarActivos : Form
    {
        private readonly IServicioPrestamoApi _servicioPrestamo;
        private readonly IServicioDevolucionApi _servicioDevolucion;

        public FormConsultarActivos(IServicioPrestamoApi servicioPrestamo, IServicioDevolucionApi servicioDevolucion)
        {
            InitializeComponent();
            _servicioPrestamo = servicioPrestamo;
            _servicioDevolucion = servicioDevolucion;
        }

        private async void FormConsultarActivos_Load(object sender, EventArgs e)
        {
            cboCriterio.SelectedIndex = 0; // Selecciona "Matrícula / Empleado" por defecto
            await RecargarTablaAsync();
        }

        private async Task RecargarTablaAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var resultados = await _servicioPrestamo.ConsultarTodosAsync();
                dgvPrestamos.DataSource = resultados;
                dgvPrestamos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async Task EjecutarBusquedaAsync()
        {
            try
            {
                string valor = txtBusqueda.Text.Trim();

                // Si el campo está vacío, traemos todos
                if (string.IsNullOrEmpty(valor))
                {
                    await RecargarTablaAsync();
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                string criterioSeleccionado = cboCriterio.SelectedItem?.ToString() ?? "";

                // Mapeo para el Backend
                string criterioBackend = criterioSeleccionado == "Título del Libro" ? "Titulo" : "Usuario";

                var activos = await _servicioPrestamo.ConsultarActivosPorFiltroAsync(criterioBackend, valor);
                dgvPrestamos.DataSource = activos;
                dgvPrestamos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en la consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvPrestamos.DataSource = null;
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

        private async void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
            cboCriterio.SelectedIndex = 0;
            await RecargarTablaAsync();
        }

        private async void dgvPrestamos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var prestamoSeleccionado = (PrestamoResponseDTO)dgvPrestamos.Rows[e.RowIndex].DataBoundItem;

            using (var modalDevolucion = new FormProcesarDevolucion(prestamoSeleccionado, _servicioDevolucion))
            {
                if (modalDevolucion.ShowDialog() == DialogResult.OK)
                {
                    await RecargarTablaAsync();
                }
            }
        }

        // Exportación Profesional a Excel (CSV con UTF-8 BOM)
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Archivo Excel/CSV|*.csv", FileName = "Prestamos_Activos.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder csvData = new StringBuilder();

                        // Encabezados
                        for (int i = 0; i < dgvPrestamos.Columns.Count; i++)
                        {
                            if (dgvPrestamos.Columns[i].Visible)
                            {
                                csvData.Append(dgvPrestamos.Columns[i].HeaderText + ",");
                            }
                        }
                        csvData.AppendLine();

                        // Filas
                        foreach (DataGridViewRow row in dgvPrestamos.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.OwningColumn.Visible)
                                {
                                    string cellValue = cell.Value?.ToString()?.Replace(",", " ") ?? "";
                                    csvData.Append(cellValue + ",");
                                }
                            }
                            csvData.AppendLine();
                        }

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