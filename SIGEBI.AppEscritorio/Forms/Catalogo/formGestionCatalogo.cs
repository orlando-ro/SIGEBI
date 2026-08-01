using Microsoft.Extensions.DependencyInjection;
using SIGEBI.AppEscritorio.DTOs.Catalogo;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SIGEBI.AppEscritorio.Forms.Catalogo
{
    public partial class formGestionCatalogo : Form
    {
        private readonly IServicioCatalogoApi _servicioCatalogoApi;

        public formGestionCatalogo(IServicioCatalogoApi servicioCatalogoApi)
        {
            InitializeComponent();
            _servicioCatalogoApi = servicioCatalogoApi;

            this.Load += FormGestionCatalogo_Load;
            this.btnBuscar.Click += BtnBuscar_Click;
            this.btnDesactivar.Click += BtnDesactivar_Click;
            this.btnNuevo.Click += BtnNuevo_Click;
            this.btnEditar.Click += BtnEditar_Click;
            this.btnEjemplares.Click += BtnEjemplares_Click;
        }

        private async void FormGestionCatalogo_Load(object? sender, EventArgs e)
        {
            await CargarLibrosGrid();
            btnEjemplares.Visible = false;
        }

        private async Task CargarLibrosGrid()
        {
            dgvLibros.DataSource = null;
            var listaLibros = await _servicioCatalogoApi.ConsultarTodosAsync();
            dgvLibros.DataSource = listaLibros.ToList();

            if (dgvLibros.Columns["UrlImagen"] != null)
                dgvLibros.Columns["UrlImagen"].Visible = false;

            dgvLibros.RowTemplate.Height = 80;

            if (!dgvLibros.Columns.Contains("PortadaCol"))
            {
                var imgCol = new DataGridViewImageColumn
                {
                    Name = "PortadaCol",
                    HeaderText = "Portada",
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = 60
                };

                imgCol.DefaultCellStyle.NullValue = new Bitmap(1, 1);
                dgvLibros.Columns.Insert(0, imgCol);
            }

            CargarImagenesGridAsync();
        }

        private async void CargarImagenesGridAsync()
        {
            var handler = new System.Net.Http.HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
            };

            using var httpClient = new System.Net.Http.HttpClient(handler);
            string baseUrl = "https://localhost:7291";

            foreach (DataGridViewRow row in dgvLibros.Rows)
            {
                row.Cells["PortadaCol"].Value = new Bitmap(1, 1); 

                var url = row.Cells["UrlImagen"].Value?.ToString();

                if (!string.IsNullOrWhiteSpace(url))
                {
                    if (!url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!url.StartsWith("/")) url = "/" + url;
                        url = baseUrl + url;
                    }

                    try
                    {
                        var imageBytes = await httpClient.GetByteArrayAsync(url);
                        using var ms = new System.IO.MemoryStream(imageBytes);
                        row.Cells["PortadaCol"].Value = Image.FromStream(ms);
                    }
                    catch
                    {
                    }
                }
            }
        }

        private async void BtnBuscar_Click(object? sender, EventArgs e)
        {
            string isbn = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(isbn))
            {
                await CargarLibrosGrid();
                return;
            }

            var libro = await _servicioCatalogoApi.BuscarPorIsbnAsync(isbn);

            if (libro != null)
            {
                dgvLibros.DataSource = new[] { libro }.ToList();
            }
            else
            {
                MessageBox.Show("No se encontró ningún libro con ese ISBN.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void BtnDesactivar_Click(object? sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un libro para desactivar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string isbn = dgvLibros.SelectedRows[0].Cells["ISBN"].Value.ToString() ?? "";
            string titulo = dgvLibros.SelectedRows[0].Cells["Titulo"].Value.ToString() ?? "";

            var confirmacion = MessageBox.Show($"¿Desea desactivar el libro '{titulo}' (ISBN: {isbn})?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                bool exito = await _servicioCatalogoApi.DesactivarLibroAsync(isbn);
                if (exito)
                {
                    MessageBox.Show("Libro desactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarLibrosGrid();
                }
                else
                {
                    MessageBox.Show("Error al intentar desactivar el libro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void BtnNuevo_Click(object? sender, EventArgs e)
        {
            var formModal = Program.ServiceProvider.GetRequiredService<FormLibroMantenimiento>();
            if (formModal.ShowDialog() == DialogResult.OK)
            {
                await CargarLibrosGrid();
            }
        }

        private async void BtnEditar_Click(object? sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un libro para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dgvLibros.SelectedRows[0];
            var libroEditado = new LibroResponseDTO
            {
                ISBN = fila.Cells["ISBN"].Value?.ToString() ?? "",
                Titulo = fila.Cells["Titulo"].Value?.ToString() ?? "",
                NombreAutor = fila.Cells["NombreAutor"].Value?.ToString() ?? "",
                AnioPublicacion = Convert.ToInt32(fila.Cells["AnioPublicacion"].Value),
                CopiasDisponibles = Convert.ToInt32(fila.Cells["CopiasDisponibles"].Value),
                Categoria = fila.Cells["Categoria"].Value?.ToString() ?? ""
            };

            var formModal = Program.ServiceProvider.GetRequiredService<FormLibroMantenimiento>();
            formModal.CargarDatosParaEdicion(libroEditado);

            if (formModal.ShowDialog() == DialogResult.OK)
            {
                await CargarLibrosGrid();
            }
        }

        private void BtnEjemplares_Click(object? sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count == 0) return;
            MessageBox.Show("Aquí abriremos FormGestionEjemplares para este libro.", "Próximo paso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}