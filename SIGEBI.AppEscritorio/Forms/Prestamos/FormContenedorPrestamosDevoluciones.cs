using Microsoft.Extensions.DependencyInjection;
using SIGEBI.AppEscritorio.Forms.Devoluciones;
using SIGEBI.AppEscritorio.Forms.Prestamos;
using SIGEBI.AppEscritorio.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Prestamos
{
    public partial class FormContenedorPrestamosDevoluciones : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public FormContenedorPrestamosDevoluciones(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void FormContenedorPrestamosDevoluciones_Load(object sender, EventArgs e)
        {
            ConfigurarEstilosTabs();
            ConfigurarYCargarPestañasPorRol(); // 🔥 Reemplazamos los dos métodos viejos por este unificado
        }

        private void ConfigurarEstilosTabs()
        {
            // Ocultamos las pestañas superiores nativas para manejarlas con nuestros propios botones
            tabContenedor.Appearance = TabAppearance.FlatButtons;
            tabContenedor.ItemSize = new Size(0, 1);
            tabContenedor.SizeMode = TabSizeMode.Fixed;
        }

        private void ConfigurarYCargarPestañasPorRol()
        {
            string rol = SessionManager.TipoUsuario ?? "";

            // 1. Cargamos SIEMPRE los historiales (Todos los roles tienen acceso a estos dos)
            var formHistorialP = _serviceProvider.GetRequiredService<FormHistorialPrestamos>();
            CargarFormEnTabPage(formHistorialP, tabPageHistorialPrestamos);

            var formHistorialD = _serviceProvider.GetRequiredService<FormHistorialDevoluciones>();
            CargarFormEnTabPage(formHistorialD, tabPageHistorialDevoluciones);

            // 2. Evaluamos qué hacer con la pestaña de "Activos" según el rol
            if (rol == "Auditor")
            {
                // Si es auditor, NO instanciamos el formulario de Activos para evitar llamadas no autorizadas a la API
                btnTabActivos.Visible = false;
                tabContenedor.TabPages.Remove(tabPageActivos); // Quitamos la pestaña visualmente

                // Reubicamos los botones a la izquierda para cubrir el hueco
                btnTabHistorialPrestamos.Location = new Point(25, 12);
                btnTabHistorialDevoluciones.Location = new Point(200, 12);

                // Seleccionamos Historial de Préstamos por defecto
                tabContenedor.SelectedTab = tabPageHistorialPrestamos;
                ResaltarBotonActivo(btnTabHistorialPrestamos);
            }
            else
            {
                // Si es Admin o Bibliotecario, SÍ cargamos el formulario de Activos
                var formActivos = _serviceProvider.GetRequiredService<FormConsultarActivos>();
                CargarFormEnTabPage(formActivos, tabPageActivos);

                // Seleccionamos Activos por defecto
                tabContenedor.SelectedTab = tabPageActivos;
                ResaltarBotonActivo(btnTabActivos);
            }
        }

        private void CargarFormEnTabPage(Form formHijo, TabPage pagina)
        {
            formHijo.TopLevel = false;
            formHijo.Dock = DockStyle.Fill;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            pagina.Controls.Add(formHijo);
            formHijo.Show();
        }

        // Eventos de Navegación
        private void btnTabActivos_Click(object sender, EventArgs e)
        {
            tabContenedor.SelectedTab = tabPageActivos;
            ResaltarBotonActivo(btnTabActivos);
        }

        private void btnTabHistorialPrestamos_Click(object sender, EventArgs e)
        {
            tabContenedor.SelectedTab = tabPageHistorialPrestamos;
            ResaltarBotonActivo(btnTabHistorialPrestamos);
        }

        private void btnTabHistorialDevoluciones_Click(object sender, EventArgs e)
        {
            tabContenedor.SelectedTab = tabPageHistorialDevoluciones;
            ResaltarBotonActivo(btnTabHistorialDevoluciones);
        }

        private void ResaltarBotonActivo(Button botonActivo)
        {
            // Resetear colores
            btnTabActivos.BackColor = Color.FromArgb(40, 44, 60);
            btnTabHistorialPrestamos.BackColor = Color.FromArgb(40, 44, 60);
            btnTabHistorialDevoluciones.BackColor = Color.FromArgb(40, 44, 60);

            // Destacar el seleccionado
            botonActivo.BackColor = Color.FromArgb(13, 110, 253);
        }

        private void tabPageActivos_Click(object sender, EventArgs e) { }
    }
}