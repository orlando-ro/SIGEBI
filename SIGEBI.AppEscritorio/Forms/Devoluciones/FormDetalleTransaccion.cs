using SIGEBI.AppEscritorio.DTOs.Devoluciones;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Devoluciones
{
    public partial class FormDetalleTransaccion : Form
    {
        public FormDetalleTransaccion(DevolucionResponseDTO devolucion)
        {
            InitializeComponent();

            // UX: Aplicación estricta de pares Clave-Valor (Key-Value Pairing) para legibilidad instantánea
            lblNombreUsuario.Text = $"Nombre: {devolucion.NombreUsuario}";
            lblFecha.Text = $"Fecha de Devolución: {devolucion.FechaDevolucion:dd/MM/yyyy hh:mm tt}";
            lblCondicion.Text = $"Condición: {devolucion.CondicionLibro}";

            // UX: Coherencia semántica. Se elimina la contradicción lógica de "Retraso: Entregado a tiempo"
            if (devolucion.DiasRetraso > 0)
            {
                lblRetraso.Text = $"Retraso: {devolucion.DiasRetraso} días";
                lblRetraso.ForeColor = Color.FromArgb(220, 53, 69); // Rojo alerta visual
            }
            else
            {
                lblRetraso.Text = "Sin retraso (A tiempo)";
                lblRetraso.ForeColor = Color.FromArgb(25, 135, 84); // Verde éxito visual
            }

            if (devolucion.TitulosLibros != null && devolucion.TitulosLibros.Any())
            {
                txtLibros.Text = "• " + string.Join("\r\n• ", devolucion.TitulosLibros);
            }
            else
            {
                txtLibros.Text = "No hay información de libros registrados.";
            }

            txtObservaciones.Text = string.IsNullOrWhiteSpace(devolucion.Observaciones)
                ? "Sin observaciones adicionales."
                : devolucion.Observaciones;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDetalleTransaccion_Load(object sender, EventArgs e)
        {
        }
    }
}