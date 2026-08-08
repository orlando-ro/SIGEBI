using SIGEBI.AppEscritorio.DTOs.Auditoria;
using System;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Auditoria
{
    public partial class FormDetalleAuditoria : Form
    {
        private readonly AuditoriaResponseDTO _registro;

        public FormDetalleAuditoria(AuditoriaResponseDTO registro)
        {
            _registro = registro;
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            lblFechaVal.Text = _registro.FechaFormateada;
            lblAccionVal.Text = _registro.Accion;
            lblModuloVal.Text = _registro.EntidadAfectada;
            txtDetalles.Text = _registro.Detalles;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}