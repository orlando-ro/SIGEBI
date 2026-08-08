using SIGEBI.AppEscritorio.DTOs.Prestamos;
using SIGEBI.AppEscritorio.DTOs.Solicitudes;
using SIGEBI.AppEscritorio.Services.Interfaces;
using SIGEBI.AppEscritorio.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Solicitudes
{
    public partial class FormGestionSolicitudes : Form
    {
        private readonly IServicioSolicitudApi _servicioSolicitud;
        private readonly IServicioPrestamoApi _servicioPrestamo;

        public FormGestionSolicitudes(IServicioSolicitudApi servicioSolicitud, IServicioPrestamoApi servicioPrestamo)
        {
            InitializeComponent();
            _servicioSolicitud = servicioSolicitud;
            _servicioPrestamo = servicioPrestamo;
        }

        private async void FormGestionSolicitudes_Load(object sender, EventArgs e)
        {
            cmbCriterioBusqueda.SelectedIndex = 0;
            await CargarSolicitudesPendientes();
        }

        private void cmbCriterioBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            string criterio = cmbCriterioBusqueda.SelectedItem?.ToString() ?? "";

            if (criterio == "Todas Pendientes")
            {
                txtBusqueda.Enabled = false;
                txtBusqueda.PlaceholderText = "Presione buscar para ver todas...";
                txtBusqueda.Clear();
            }
            else if (criterio == "Matrícula / Empleado")
            {
                txtBusqueda.Enabled = true;
                txtBusqueda.PlaceholderText = "Ej: 2025-2050";
            }
        }

        private async void btnRecargar_Click(object sender, EventArgs e)
        {
            cmbCriterioBusqueda.SelectedIndex = 0;
            txtBusqueda.Clear();
            await CargarSolicitudesPendientes();
        }

        private async System.Threading.Tasks.Task CargarSolicitudesPendientes()
        {
            try
            {
                var pendientes = await _servicioSolicitud.ConsultarPendientesAsync();
                dgvSolicitudes.DataSource = pendientes;
                ConfigurarColumnasAcciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = cmbCriterioBusqueda.SelectedItem?.ToString() ?? "";
            string valorBusqueda = txtBusqueda.Text.Trim();

            try
            {
                if (criterio == "Todas Pendientes")
                {
                    await CargarSolicitudesPendientes();
                    return;
                }

                if (string.IsNullOrEmpty(valorBusqueda))
                {
                    MessageBox.Show("Por favor, ingrese un valor para buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (criterio == "Matrícula / Empleado")
                {
                    var resultados = await _servicioSolicitud.ConsultarPorUsuarioAsync(valorBusqueda);
                    dgvSolicitudes.DataSource = resultados;
                    ConfigurarColumnasAcciones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en la búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 👇 INYECCIÓN DE BOTONES INLINE CON DISEÑO PROFESIONAL
        private void ConfigurarColumnasAcciones()
        {
            if (dgvSolicitudes.Columns.Contains("ColDetalles")) return;

            // 1. Botón de Detalles (Azul)
            DataGridViewButtonColumn colDetalles = new DataGridViewButtonColumn();
            colDetalles.Name = "ColDetalles";
            colDetalles.HeaderText = "Información";
            colDetalles.Text = "📄 Detalles";
            colDetalles.UseColumnTextForButtonValue = true;
            colDetalles.FlatStyle = FlatStyle.Flat;
            colDetalles.DefaultCellStyle.BackColor = Color.FromArgb(13, 110, 253);
            colDetalles.DefaultCellStyle.ForeColor = Color.White;
            colDetalles.DefaultCellStyle.Padding = new Padding(3); // Margen interno para que no toque los bordes
            dgvSolicitudes.Columns.Add(colDetalles);

            // Solo mostrar Aprobar y Rechazar si el usuario tiene permisos administrativos
            if (SessionManager.TipoUsuario == "PersonalBibliotecario" || SessionManager.TipoUsuario == "Administrador")
            {
                // 2. Botón de Aprobar (Verde)
                DataGridViewButtonColumn colAprobar = new DataGridViewButtonColumn();
                colAprobar.Name = "ColAprobar";
                colAprobar.HeaderText = "Aprobación";
                colAprobar.Text = "✓ Aprobar";
                colAprobar.UseColumnTextForButtonValue = true;
                colAprobar.FlatStyle = FlatStyle.Flat;
                colAprobar.DefaultCellStyle.BackColor = Color.FromArgb(25, 135, 84);
                colAprobar.DefaultCellStyle.ForeColor = Color.White;
                colAprobar.DefaultCellStyle.Padding = new Padding(3);
                dgvSolicitudes.Columns.Add(colAprobar);

                // 3. Botón de Rechazar (Rojo)
                DataGridViewButtonColumn colRechazar = new DataGridViewButtonColumn();
                colRechazar.Name = "ColRechazar";
                colRechazar.HeaderText = "Denegación";
                colRechazar.Text = "✖ Rechazar";
                colRechazar.UseColumnTextForButtonValue = true;
                colRechazar.FlatStyle = FlatStyle.Flat;
                colRechazar.DefaultCellStyle.BackColor = Color.FromArgb(220, 53, 69);
                colRechazar.DefaultCellStyle.ForeColor = Color.White;
                colRechazar.DefaultCellStyle.Padding = new Padding(3);
                dgvSolicitudes.Columns.Add(colRechazar);
            }
        }

        // 👇 ENRUTADOR DE EVENTOS DE CLIC EN LA TABLA
        private async void dgvSolicitudes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !(dgvSolicitudes.Columns[e.ColumnIndex] is DataGridViewButtonColumn)) return;

            var solicitud = (SolicitudResponseDTO)dgvSolicitudes.Rows[e.RowIndex].DataBoundItem;
            string columnaClickeada = dgvSolicitudes.Columns[e.ColumnIndex].Name;

            if (columnaClickeada == "ColDetalles")
            {
                MostrarDetallesEmergente(solicitud);
            }
            else if (columnaClickeada == "ColAprobar")
            {
                await ProcesarAprobacion(solicitud);
            }
            else if (columnaClickeada == "ColRechazar")
            {
                await ProcesarRechazo(solicitud);
            }
        }

        // 👇 LÓGICA DE NEGOCIO AISLADA
        private async System.Threading.Tasks.Task ProcesarAprobacion(SolicitudResponseDTO solicitud)
        {
            var confirmacion = MessageBox.Show($"¿Está seguro que desea APROBAR la solicitud de {solicitud.NombreUsuarioSolicitante}?", "Confirmar Aprobación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                var peticion = new PrestamoRequestDTO { IdSolicitud = solicitud.IdSolicitud };
                try
                {
                    var resultado = await _servicioPrestamo.AprobarYCrearPrestamoAsync(peticion);
                    if (resultado != null)
                    {
                        MessageBox.Show($"¡Solicitud aprobada exitosamente! Préstamo #{resultado.IdPrestamo} creado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarSolicitudesPendientes();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al aprobar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async System.Threading.Tasks.Task ProcesarRechazo(SolicitudResponseDTO solicitud)
        {
            string? motivo = SolicitarMotivoEmergente();
            if (motivo == null) return;

            if (string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show("Debe especificar un motivo para rechazar la solicitud.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show($"¿Desea RECHAZAR permanentemente esta solicitud?\n\nMotivo: {motivo}", "Confirmar Rechazo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                var peticion = new RechazoSolicitudRequestDTO { IdSolicitud = solicitud.IdSolicitud, MotivoRechazo = motivo };
                try
                {
                    await _servicioSolicitud.RechazarSolicitudAsync(peticion);
                    MessageBox.Show("La solicitud ha sido rechazada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarSolicitudesPendientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al rechazar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // VENTANA MODAL PARA DETALLES DE SOLICITUD
        private void MostrarDetallesEmergente(SolicitudResponseDTO solicitud)
        {
            Form detalles = new Form()
            {
                Width = 450,
                Height = 480,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Detalles Completos de Solicitud",
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(30, 30, 45),
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblHeader = new Label() { Left = 20, Top = 20, Text = "Información General", ForeColor = Color.FromArgb(13, 110, 253), AutoSize = true, Font = new Font("Segoe UI", 12F, FontStyle.Bold) };

            string identificador = !string.IsNullOrEmpty(solicitud.Matricula) ? $"Matrícula: {solicitud.Matricula}" : $"N° Empleado: {solicitud.NumeroEmpleado}";
            Label lblInfo = new Label() { Left = 20, Top = 55, Text = $"Fecha: {solicitud.FechaSolicitud}\nEstado: {solicitud.Estado}\n\nSolicitante: {solicitud.NombreUsuarioSolicitante}\n{identificador}", ForeColor = Color.White, AutoSize = true, Font = new Font("Segoe UI", 10.5F) };

            Label lblLibrosHeader = new Label() { Left = 20, Top = 180, Text = "Libros Solicitados", ForeColor = Color.FromArgb(13, 110, 253), AutoSize = true, Font = new Font("Segoe UI", 12F, FontStyle.Bold) };

            TextBox txtLibros = new TextBox() { Left = 20, Top = 215, Width = 390, Height = 140, Multiline = true, ReadOnly = true, BackColor = Color.FromArgb(40, 40, 60), ForeColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10.5F) };
            txtLibros.Text = solicitud.LibrosSolicitados.Replace(" | ", "\r\n• ");
            if (!txtLibros.Text.StartsWith("• ")) txtLibros.Text = "• " + txtLibros.Text;

            Button btnCerrar = new Button() { Text = "Cerrar", Left = 310, Width = 100, Top = 380, DialogResult = DialogResult.OK, BackColor = Color.FromArgb(70, 75, 90), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            btnCerrar.FlatAppearance.BorderSize = 0;

            detalles.Controls.Add(lblHeader);
            detalles.Controls.Add(lblInfo);
            detalles.Controls.Add(lblLibrosHeader);
            detalles.Controls.Add(txtLibros);
            detalles.Controls.Add(btnCerrar);
            detalles.AcceptButton = btnCerrar;

            detalles.ShowDialog();
        }

        // VENTANA MODAL PARA MOTIVO DE RECHAZO
        private string? SolicitarMotivoEmergente()
        {
            Form prompt = new Form()
            {
                Width = 450,
                Height = 250,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Denegar Solicitud",
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(30, 30, 45),
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = "Motivo del rechazo:", ForeColor = Color.White, AutoSize = true, Font = new Font("Segoe UI", 10.5F, FontStyle.Bold) };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 390, Height = 80, Multiline = true, BackColor = Color.FromArgb(40, 40, 60), ForeColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10.5F) };

            Button confirmation = new Button() { Text = "Confirmar", Left = 200, Width = 100, Top = 150, DialogResult = DialogResult.OK, BackColor = Color.FromArgb(220, 53, 69), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            confirmation.FlatAppearance.BorderSize = 0;

            Button cancel = new Button() { Text = "Cancelar", Left = 310, Width = 100, Top = 150, DialogResult = DialogResult.Cancel, BackColor = Color.FromArgb(70, 75, 90), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            cancel.FlatAppearance.BorderSize = 0;

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }
    }
}