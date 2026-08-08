using SIGEBI.AppEscritorio.DTOs.Devoluciones;
using SIGEBI.AppEscritorio.DTOs.Prestamos;
using SIGEBI.AppEscritorio.Enums;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Devoluciones
{
    public partial class FormProcesarDevolucion : Form
    {
        private readonly IServicioDevolucionApi _servicioDevolucion;
        private readonly PrestamoResponseDTO _prestamoActual;

        public FormProcesarDevolucion(PrestamoResponseDTO prestamo, IServicioDevolucionApi servicioDevolucion)
        {
            InitializeComponent();
            _servicioDevolucion = servicioDevolucion;
            _prestamoActual = prestamo;
        }

        // 🔥 CORRECCIÓN NULABILIDAD: object? sender
        private void FormProcesarDevolucion_Load(object? sender, EventArgs e)
        {
            lblNombreUsuario.Text = _prestamoActual.NombreUsuario;
            lblIdentificador.Text = !string.IsNullOrEmpty(_prestamoActual.Matricula)
                ? $"Matrícula: {_prestamoActual.Matricula}"
                : $"N° Empleado: {_prestamoActual.NumeroEmpleado}";

            lblFechas.Text = $"Vigencia: {_prestamoActual.FechaInicio:d} al {_prestamoActual.FechaVencimiento:d}";

            if (_prestamoActual.DiasRetraso > 0)
            {
                lblRetraso.Text = $"⚠️ PRÉSTAMO VENCIDO ({_prestamoActual.DiasRetraso} días de retraso)";
                lblRetraso.Visible = true;
            }

            ConfigurarGridEvaluacion();
        }

        private void ConfigurarGridEvaluacion()
        {
            var colTitulo = new DataGridViewTextBoxColumn
            {
                Name = "Titulo",
                HeaderText = "Recurso Bibliográfico",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            var colCondicion = new DataGridViewComboBoxColumn
            {
                Name = "Condicion",
                HeaderText = "Condición Física",
                Width = 140,
                FlatStyle = FlatStyle.Flat
            };
            colCondicion.Items.AddRange("BuenEstado", "Dañado", "Extraviado");

            var colObservacion = new DataGridViewTextBoxColumn
            {
                Name = "Observaciones",
                HeaderText = "Notas (Obligatorio si hay daño)",
                Width = 230
            };

            dgvEjemplares.Columns.AddRange(colTitulo, colCondicion, colObservacion);

            dgvEjemplares.CurrentCellDirtyStateChanged += DgvEjemplares_CurrentCellDirtyStateChanged;
            dgvEjemplares.CellValueChanged += DgvEjemplares_CellValueChanged;

            var ejemplaresValidos = _prestamoActual.TitulosLibros?.Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
            if (ejemplaresValidos != null && ejemplaresValidos.Count > 0)
            {
                foreach (var titulo in ejemplaresValidos)
                {
                    dgvEjemplares.Rows.Add(titulo, "BuenEstado", "");
                }
            }
        }

        // 🔥 CORRECCIÓN NULABILIDAD: object? sender
        private void DgvEjemplares_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dgvEjemplares.IsCurrentCellDirty)
            {
                dgvEjemplares.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // 🔥 CORRECCIÓN NULABILIDAD: object? sender
        private void DgvEjemplares_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvEjemplares.Columns[e.ColumnIndex].Name == "Condicion")
            {
                var row = dgvEjemplares.Rows[e.RowIndex];
                string condicion = row.Cells["Condicion"].Value?.ToString() ?? "BuenEstado";
                var celdaObs = row.Cells["Observaciones"];

                if (condicion != "BuenEstado")
                {
                    celdaObs.Style.BackColor = Color.FromArgb(80, 30, 30);
                    celdaObs.Style.SelectionBackColor = Color.FromArgb(120, 40, 40);
                }
                else
                {
                    celdaObs.Style.BackColor = Color.FromArgb(40, 40, 60);
                    celdaObs.Style.SelectionBackColor = Color.FromArgb(13, 110, 253);
                    celdaObs.Value = "";
                }
            }
        }

        // 🔥 CORRECCIÓN NULABILIDAD: object? sender
        private async void btnProcesar_Click(object? sender, EventArgs e)
        {
            CondicionDevolucion condicionFinal = CondicionDevolucion.BuenEstado;
            List<string> desgloseObservaciones = new List<string>();
            bool requiereObservacion = false;

            foreach (DataGridViewRow row in dgvEjemplares.Rows)
            {
                string titulo = row.Cells["Titulo"].Value?.ToString() ?? "Libro desconocido";
                string condicion = row.Cells["Condicion"].Value?.ToString() ?? "BuenEstado";
                string obs = row.Cells["Observaciones"].Value?.ToString() ?? "";

                if (condicion == "Extraviado") condicionFinal = CondicionDevolucion.Extraviado;
                else if (condicion == "Dañado" && condicionFinal != CondicionDevolucion.Extraviado) condicionFinal = CondicionDevolucion.Dañado;

                if (condicion != "BuenEstado")
                {
                    requiereObservacion = true;
                    if (string.IsNullOrWhiteSpace(obs))
                    {
                        dgvEjemplares.CurrentCell = row.Cells["Observaciones"];
                        dgvEjemplares.BeginEdit(true);

                        MessageBox.Show($"Debe escribir una observación obligatoria para el recurso: '{titulo}' ya que fue reportado como {condicion}.", "Validación Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    desgloseObservaciones.Add($"[{condicion.ToUpper()}] {titulo}: {obs}");
                }
            }

            string observacionGlobal = requiereObservacion
                ? string.Join(" | ", desgloseObservaciones)
                : "Todos los recursos devueltos en buen estado.";

            var peticion = new DevolucionRequestDTO
            {
                IdPrestamo = _prestamoActual.IdPrestamo,
                CondicionLibro = condicionFinal,
                Observaciones = observacionGlobal
            };

            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnProcesar.Enabled = false;

                var resultado = await _servicioDevolucion.ProcesarDevolucionAsync(peticion);

                if (resultado != null)
                {
                    string msjPenalizacion = resultado.GeneroPenalizacion
                        ? "\n\n⚠️ ATENCIÓN: Se ha generado una penalización por las condiciones reportadas o el retraso."
                        : "";

                    MessageBox.Show(
                        $"¡Devolución procesada con éxito!\nTransacción: {resultado.IdDevolucion}{msjPenalizacion}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al procesar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnProcesar.Enabled = true;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // 🔥 CORRECCIÓN NULABILIDAD: object? sender
        private void btnCerrar_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}