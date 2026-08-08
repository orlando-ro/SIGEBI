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
            // 🔥 UX FIX: Prevenimos que el color de selección arruine el color del botón
            colDetalles.DefaultCellStyle.SelectionBackColor = Color.FromArgb(13, 110, 253);
            colDetalles.DefaultCellStyle.Padding = new Padding(3);
            dgvSolicitudes.Columns.Add(colDetalles);

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
                // 🔥 UX FIX: Mantiene el verde incluso si la fila está seleccionada
                colAprobar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(25, 135, 84);
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
                // 🔥 UX FIX: Mantiene el rojo incluso si la fila está seleccionada
                colRechazar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 53, 69);
                colRechazar.DefaultCellStyle.Padding = new Padding(3);
                dgvSolicitudes.Columns.Add(colRechazar);
            }
        }

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

        // 🔥 UX FIX: POSICIONAMIENTO RELATIVO PARA EVITAR OVERLAP EN RESOLUCIONES ALTAS
        private void MostrarDetallesEmergente(SolicitudResponseDTO solicitud)
        {
            Form detalles = new Form()
            {
                Width = 450,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Detalles Completos de Solicitud",
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(30, 30, 45),
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblHeader = new Label() { Text = "Información General", ForeColor = Color.FromArgb(13, 110, 253), AutoSize = true, Font = new Font("Segoe UI", 12F, FontStyle.Bold) };
            lblHeader.Location = new Point(20, 20);
            detalles.Controls.Add(lblHeader);

            string identificador = !string.IsNullOrEmpty(solicitud.Matricula) ? $"Matrícula: {solicitud.Matricula}" : $"N° Empleado: {solicitud.NumeroEmpleado}";
            Label lblInfo = new Label() { Text = $"Fecha: {solicitud.FechaSolicitud}\nEstado: {solicitud.Estado}\n\nSolicitante: {solicitud.NombreUsuarioSolicitante}\n{identificador}", ForeColor = Color.White, AutoSize = true, Font = new Font("Segoe UI", 10.5F) };
            lblInfo.Location = new Point(20, lblHeader.Location.Y + lblHeader.PreferredHeight + 15);
            detalles.Controls.Add(lblInfo);

            Label lblLibrosHeader = new Label() { Text = "Libros Solicitados", ForeColor = Color.FromArgb(13, 110, 253), AutoSize = true, Font = new Font("Segoe UI", 12F, FontStyle.Bold) };
            lblLibrosHeader.Location = new Point(20, lblInfo.Location.Y + lblInfo.PreferredHeight + 20);
            detalles.Controls.Add(lblLibrosHeader);

            TextBox txtLibros = new TextBox() { Width = 390, Height = 140, Multiline = true, ReadOnly = true, BackColor = Color.FromArgb(40, 40, 60), ForeColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10.5F) };
            txtLibros.Text = solicitud.LibrosSolicitados.Replace(" | ", "\r\n• ");
            if (!txtLibros.Text.StartsWith("• ")) txtLibros.Text = "• " + txtLibros.Text;
            txtLibros.Location = new Point(20, lblLibrosHeader.Location.Y + lblLibrosHeader.PreferredHeight + 10);
            detalles.Controls.Add(txtLibros);

            Button btnCerrar = new Button() { Text = "Cerrar", Width = 100, Height = 35, DialogResult = DialogResult.OK, BackColor = Color.FromArgb(70, 75, 90), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Location = new Point(detalles.ClientSize.Width - btnCerrar.Width - 20, txtLibros.Location.Y + txtLibros.Height + 20);
            detalles.Controls.Add(btnCerrar);

            // Ajustamos el tamaño final de la ventana basado en dónde quedó el último botón
            detalles.ClientSize = new Size(430, btnCerrar.Location.Y + btnCerrar.Height + 20);
            detalles.AcceptButton = btnCerrar;

            detalles.ShowDialog();
        }

        // 🔥 UX FIX: POSICIONAMIENTO RELATIVO APLICADO TAMBIÉN AQUÍ
        private string? SolicitarMotivoEmergente()
        {
            Form prompt = new Form()
            {
                Width = 450,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Denegar Solicitud",
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(30, 30, 45),
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Text = "Motivo del rechazo:", ForeColor = Color.White, AutoSize = true, Font = new Font("Segoe UI", 10.5F, FontStyle.Bold) };
            textLabel.Location = new Point(20, 20);
            prompt.Controls.Add(textLabel);

            TextBox textBox = new TextBox() { Width = 390, Height = 80, Multiline = true, BackColor = Color.FromArgb(40, 40, 60), ForeColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10.5F) };
            textBox.Location = new Point(20, textLabel.Location.Y + textLabel.PreferredHeight + 10);
            prompt.Controls.Add(textBox);

            Button cancel = new Button() { Text = "Cancelar", Width = 100, Height = 35, DialogResult = DialogResult.Cancel, BackColor = Color.FromArgb(70, 75, 90), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            cancel.FlatAppearance.BorderSize = 0;
            cancel.Location = new Point(prompt.ClientSize.Width - cancel.Width - 20, textBox.Location.Y + textBox.Height + 20);
            prompt.Controls.Add(cancel);

            Button confirmation = new Button() { Text = "Confirmar", Width = 100, Height = 35, DialogResult = DialogResult.OK, BackColor = Color.FromArgb(220, 53, 69), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            confirmation.FlatAppearance.BorderSize = 0;
            confirmation.Location = new Point(cancel.Left - confirmation.Width - 10, textBox.Location.Y + textBox.Height + 20);
            prompt.Controls.Add(confirmation);

            prompt.ClientSize = new Size(430, cancel.Location.Y + cancel.Height + 20);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }
    }
}