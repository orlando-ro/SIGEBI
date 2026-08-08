using SIGEBI.AppEscritorio.DTOs.Devoluciones;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Devoluciones
{
    public partial class FormHistorialDevoluciones : Form
    {
        private readonly IServicioDevolucionApi _servicioDevolucion;
        private bool _isLoaded = false;

        public FormHistorialDevoluciones(IServicioDevolucionApi servicioDevolucion)
        {
            InitializeComponent();
            _servicioDevolucion = servicioDevolucion;
        }

        private async void FormHistorialDevoluciones_Load(object sender, EventArgs e)
        {
            // Llenamos el ComboBox con los Estados de Devolución
            cmbCondicion.Items.Clear();
            cmbCondicion.Items.Add("Todos");
            cmbCondicion.Items.Add("BuenEstado");
            cmbCondicion.Items.Add("Dañado");
            cmbCondicion.Items.Add("Extraviado");
            cmbCondicion.SelectedIndex = 0;

            txtBusqueda.PlaceholderText = "Buscar matrícula, empleado o título...";

            _isLoaded = true;
            await RealizarBusquedaAsync();
        }

        // 🔥 MÉTODO CENTRAL: Omni-Search Inteligente
        private async Task RealizarBusquedaAsync()
        {
            string valor = txtBusqueda.Text.Trim();
            string condicion = cmbCondicion.SelectedItem?.ToString() ?? "Todos";

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Si no hay texto, buscamos todo filtrado por la condición actual
                if (string.IsNullOrEmpty(valor))
                {
                    var historialCompleto = await _servicioDevolucion.ConsultarHistorialCompletoAsync(condicion);
                    dgvHistorial.DataSource = historialCompleto;
                    return;
                }

                // Omni-Search: Intentamos primero buscar como Identificador (Matrícula/Empleado)
                try
                {
                    var historialUsuario = await _servicioDevolucion.ConsultarHistorialDevolucionesPorUsuarioAsync(valor, condicion);
                    dgvHistorial.DataSource = historialUsuario;
                }
                catch
                {
                    // Si el backend da error (no existe el usuario), atrapamos el error silenciosamente 
                    // y hacemos un fallback automático buscando por Título de Libro.
                    var historialLibro = await _servicioDevolucion.ConsultarHistorialDevolucionesPorTituloLibroAsync(valor, condicion);
                    dgvHistorial.DataSource = historialLibro;
                }
            }
            catch (Exception)
            {
                // Si la segunda búsqueda también falla, mostramos que no hay resultados
                MessageBox.Show("No se encontraron resultados que coincidan con la búsqueda y los filtros actuales.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvHistorial.DataSource = null;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await RealizarBusquedaAsync();
        }

        // Cuando cambia el filtro, buscamos automáticamente para mejor UX
        private async void cmbCondicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoaded)
            {
                await RealizarBusquedaAsync();
            }
        }

        // CORRECCIÓN: Se eliminó 'async' ya que este método no contiene ningún operador 'await'
        private void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
            cmbCondicion.SelectedIndex = 0; // Al cambiar el índice, buscará todo automáticamente
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo Excel (CSV)|*.csv";
                sfd.FileName = $"Historial_Devoluciones_{DateTime.Now:yyyyMMdd}.csv";
                sfd.Title = "Exportar Historial a Excel";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        StringBuilder sb = new StringBuilder();

                        var headers = dgvHistorial.Columns.Cast<DataGridViewColumn>()
                            .Where(c => c.Visible)
                            .Select(c => $"\"{c.HeaderText}\"")
                            .ToArray();
                        sb.AppendLine(string.Join(",", headers));

                        foreach (DataGridViewRow row in dgvHistorial.Rows)
                        {
                            var cells = row.Cells.Cast<DataGridViewCell>()
                                .Where(c => dgvHistorial.Columns[c.ColumnIndex].Visible)
                                .Select(c => $"\"{c.Value?.ToString()?.Replace("\"", "\"\"")}\"")
                                .ToArray();
                            sb.AppendLine(string.Join(",", cells));
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));

                        using (var modalExito = new FormMensajeExito("¡Datos exportados exitosamente! Puede abrir el archivo en Excel."))
                        {
                            modalExito.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al intentar exportar el archivo: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void dgvHistorial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var devolucion = (DevolucionResponseDTO)dgvHistorial.Rows[e.RowIndex].DataBoundItem;

            using (var modalDetalle = new FormDetalleTransaccion(devolucion))
            {
                modalDetalle.ShowDialog();
            }
        }

        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}