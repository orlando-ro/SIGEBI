using SIGEBI.AppEscritorio.DTOs.Prestamos;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Prestamos
{
    public partial class FormDetallePrestamo : Form
    {
        public FormDetallePrestamo(PrestamoResponseDTO prestamo)
        {
            InitializeComponent();
            ConfigurarUI();
            CargarDatos(prestamo);
        }

        private void ConfigurarUI()
        {
            this.BackColor = Color.FromArgb(30, 30, 45);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Detalles del Préstamo";
            this.Size = new Size(400, 450);
        }

        private void CargarDatos(PrestamoResponseDTO prestamo)
        {
            lblNombre.Text = $"Nombre: {prestamo.NombreUsuario}";
            lblIdentificador.Text = $"Matrícula/Emp: {prestamo.IdentificadorUsuario}";

            lblRetraso.Text = $"Retraso: {prestamo.DiasRetraso} días";
            lblRetraso.ForeColor = prestamo.DiasRetraso > 0 ? Color.Tomato : Color.LightGreen;

            // Llenamos la lista de libros
            lstLibros.Items.Clear();
            foreach (var titulo in prestamo.TitulosLibros)
            {
                lstLibros.Items.Add($"• {titulo}");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDetallePrestamo_Load(object sender, EventArgs e)
        {

        }
    }
}