using SIGEBI.AppEscritorio.DTOs.Prestamos;
using SIGEBI.AppEscritorio.DTOs.Solicitudes;
using SIGEBI.AppEscritorio.Services.Interfaces;
using SIGEBI.AppEscritorio.Utils;
using System;
using System.Collections.Generic;
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
            // 1. REGLA DE SEGURIDAD: Ocultar acciones si no es Bibliotecario
            if (SessionManager.TipoUsuario != "PersonalBibliotecario")
            {
                panelAcciones.Visible = false;

                // Opcional: Estiramos la tabla hacia abajo para aprovechar el espacio vacío
                dgvSolicitudes.Height += panelAcciones.Height;
            }

            // 2. UX: Configuramos el ComboBox de búsqueda por defecto
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
            else if (criterio == "ID de Solicitud")
            {
                txtBusqueda.Enabled = true;
                txtBusqueda.PlaceholderText = "Ej: 1024";
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
                txtMotivoRechazo.Clear();
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

                if (criterio == "ID de Solicitud")
                {
                    if (!int.TryParse(valorBusqueda, out int idSolicitud))
                    {
                        MessageBox.Show("El ID debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var resultado = await _servicioSolicitud.ObtenerPorIdAsync(idSolicitud);

                    dgvSolicitudes.DataSource = resultado != null
                        ? new List<SolicitudResponseDTO> { resultado }
                        : new List<SolicitudResponseDTO>();
                }
                else if (criterio == "Matrícula / Empleado")
                {
                    var resultados = await _servicioSolicitud.ConsultarPorUsuarioAsync(valorBusqueda);
                    dgvSolicitudes.DataSource = resultados;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en la búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAprobar_Click(object sender, EventArgs e)
        {
            if (dgvSolicitudes.CurrentRow == null) return;

            int idSolicitud = Convert.ToInt32(dgvSolicitudes.CurrentRow.Cells["IdSolicitud"].Value);
            var peticion = new PrestamoRequestDTO { IdSolicitud = idSolicitud };

            try
            {
                var resultado = await _servicioPrestamo.AprobarYCrearPrestamoAsync(peticion);
                if (resultado != null)
                {
                    MessageBox.Show($"¡Solicitud aprobada! El préstamo #{resultado.IdPrestamo} ha sido creado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarSolicitudesPendientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al aprobar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRechazar_Click(object sender, EventArgs e)
        {
            if (dgvSolicitudes.CurrentRow == null) return;

            string motivo = txtMotivoRechazo.Text.Trim();
            if (string.IsNullOrEmpty(motivo))
            {
                MessageBox.Show("Debe escribir un motivo para rechazar la solicitud.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivoRechazo.Focus();
                return;
            }

            int idSolicitud = Convert.ToInt32(dgvSolicitudes.CurrentRow.Cells["IdSolicitud"].Value);
            var peticion = new RechazoSolicitudRequestDTO { IdSolicitud = idSolicitud, MotivoRechazo = motivo };

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

        private void dgvSolicitudes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}