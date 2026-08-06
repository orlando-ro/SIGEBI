using SIGEBI.AppEscritorio.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Main
{
    public partial class FormDashboard : Form
    {
        private readonly Action<string>? _onNavegar;

        public FormDashboard(Action<string>? onNavegar = null)
        {
            InitializeComponent();
            _onNavegar = onNavegar;
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            timerReloj.Start();
            ActualizarReloj();
            CargarTarjetasDinamicas();
        }

        private void timerReloj_Tick(object sender, EventArgs e)
        {
            ActualizarReloj();
        }

        private void ActualizarReloj()
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy").ToUpper();
        }

        private void CargarTarjetasDinamicas()
        {
            flpModulos.Controls.Clear();
            string rol = SessionManager.TipoUsuario ?? "Desconocido";

            // Tarjetas para Administrador y Personal Bibliotecario
            if (rol == "Administrador" || rol == "PersonalBibliotecario")
            {
                flpModulos.Controls.Add(CrearTarjeta("📝 Solicitudes", "Gestione las peticiones pendientes de los usuarios."));
                flpModulos.Controls.Add(CrearTarjeta("📦 Préstamos", "Controle los recursos prestados y devoluciones."));
                flpModulos.Controls.Add(CrearTarjeta("💰 Multas", "Procese los pagos y resuelva penalizaciones."));
                flpModulos.Controls.Add(CrearTarjeta("📚 Catálogo", "Gestione los libros y recursos bibliográficos."));
                flpModulos.Controls.Add(CrearTarjeta("🏷️ Categorías", "Administre las clasificaciones del sistema."));
            }

            // Tarjeta especial para el Auditor en lugar de "Préstamos"
            if (rol == "Auditor")
            {
                flpModulos.Controls.Add(CrearTarjeta("📁 Historiales", "Consulte el registro de préstamos y devoluciones."));
            }

            // Tarjeta exclusiva del Administrador
            if (rol == "Administrador")
            {
                flpModulos.Controls.Add(CrearTarjeta("👥 Usuarios", "Administre las cuentas y accesos al sistema."));
            }

            // Tarjetas compartidas entre Administrador y Auditor
            if (rol == "Administrador" || rol == "Auditor")
            {
                flpModulos.Controls.Add(CrearTarjeta("🔔 Notificaciones", "Revise las alertas y avisos enviados."));
                flpModulos.Controls.Add(CrearTarjeta("🛡️ Auditoría", "Supervise las acciones críticas en la plataforma."));
            }

            // Tarjeta compartida para todos los roles de Staff
            if (rol == "Administrador" || rol == "PersonalBibliotecario" || rol == "Auditor")
            {
                flpModulos.Controls.Add(CrearTarjeta("📊 Reportes", "Exporte la analítica del sistema en formato PDF."));
            }
        }

        private Panel CrearTarjeta(string titulo, string descripcion)
        {
            Panel card = new Panel
            {
                Size = new Size(230, 100),
                BackColor = Color.FromArgb(40, 44, 60),
                Margin = new Padding(0, 0, 15, 15),
                Cursor = Cursors.Hand
            };

            Label lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true,
                ForeColor = Color.FromArgb(13, 110, 253),
                Cursor = Cursors.Hand
            };

            Label lblDesc = new Label
            {
                Text = descripcion,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(15, 45),
                Size = new Size(200, 40),
                ForeColor = Color.Gainsboro,
                Cursor = Cursors.Hand
            };

            EventHandler eventoClick = (s, e) => _onNavegar?.Invoke(titulo);
            card.Click += eventoClick;
            lblTitulo.Click += eventoClick;
            lblDesc.Click += eventoClick;

            EventHandler eventoMouseEnter = (s, e) => card.BackColor = Color.FromArgb(50, 55, 75);
            EventHandler eventoMouseLeave = (s, e) => card.BackColor = Color.FromArgb(40, 44, 60);

            card.MouseEnter += eventoMouseEnter;
            card.MouseLeave += eventoMouseLeave;
            lblTitulo.MouseEnter += eventoMouseEnter;
            lblDesc.MouseEnter += eventoMouseEnter;

            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblDesc);

            return card;
        }
    }
}