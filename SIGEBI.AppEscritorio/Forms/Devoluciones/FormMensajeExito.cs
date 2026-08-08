using System;
using System.Drawing;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Devoluciones
{
    public partial class FormMensajeExito : Form
    {
        public FormMensajeExito(string mensaje, string titulo = "Operación Exitosa")
        {
            InitializeComponent();
            lblTitulo.Text = titulo;
            lblMensaje.Text = mensaje;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMensajeExito_Load(object sender, EventArgs e)
        {

        }
    }
}