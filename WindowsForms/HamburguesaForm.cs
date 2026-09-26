using API.Clients;
using Domain.Model;
using DTOs;
using System.Data;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class HamburguesaForm : Form
    {

        private IEnumerable<HamburguesaDTO> burgas;

        public HamburguesaForm()
        {
            InitializeComponent();
        }

        private void HamburguesaForm_Load(object sender, EventArgs e)
        {
            buttonUpdateHamburguesa.Enabled = false;
            LoadHamburguesas();
        }

        // FUNCIONES
        private async Task LoadHamburguesas()
        {
            try
            {
                buttonUpdateHamburguesa.Enabled = false;
                buttonVerResumen.Enabled = false;

                burgas = await HamburguesaApiClient.GetAllAsync();

                var datosParaGrid = burgas.Select(h =>
                {
                    // Buscamos el precio con la fecha más reciente
                    var ultimoPrecio = h.Precios?
                        .OrderByDescending(p => p.FechaDesde)
                        .FirstOrDefault();

                    return new
                    {
                        h.Id,
                        h.Nombre,
                        h.Descripcion,
                        // Si no hay precios o la lista es null, asigna 0m
                        Precio = ultimoPrecio?.Monto ?? 0m,
                        // Opcional: si querés mostrar cuándo se actualizó ese precio
                        FechaPrecio = ultimoPrecio?.FechaDesde.ToString("dd/MM/yyyy") ?? "Sin registrar"
                    };
                }).ToList();

                dataGridViewHamburguesas.DataSource = null;
                dataGridViewHamburguesas.DataSource = datosParaGrid;

                buttonUpdateHamburguesa.Enabled = true;
                buttonVerResumen.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar hamburguesas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxBuscarHamburguesa_TextChanged(object sender, EventArgs e)
        {
            if (burgas == null) return;

            string filtro = textBoxBuscarHamburguesa.Text?.Trim() ?? string.Empty;

            // 1. Filtrar sobre la lista original SIN reasignar 'burgas'
            var burgasFiltradas = string.IsNullOrWhiteSpace(filtro)
                ? burgas
                : burgas.Where(i => (i.Nombre != null && i.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase)) ||
                                    (i.Descripcion != null && i.Descripcion.Contains(filtro, StringComparison.OrdinalIgnoreCase)));

            // 2. Proyectar las columnas exactamente igual que en LoadHamburguesas
            var datosParaGrid = burgasFiltradas.Select(h =>
            {
                var ultimoPrecio = h.Precios?
                                    .OrderByDescending(p => p.FechaDesde)
                                    .FirstOrDefault();

                return new
                {
                    h.Id,
                    h.Nombre,
                    h.Descripcion,
                    Precio = ultimoPrecio?.Monto ?? 0m,
                    FechaPrecio = ultimoPrecio?.FechaDesde.ToString("dd/MM/yyyy") ?? "Sin registrar"
                };
            }).ToList();

            // 3. Refrescar el DataGridView
            dataGridViewHamburguesas.DataSource = null;
            dataGridViewHamburguesas.DataSource = datosParaGrid;
        }

        private void buttonAddHamburguesa_Click(object sender, EventArgs e)
        {
            CrearHamburguesa();
        }

        private async void CrearHamburguesa()
        {
            using (var formModal = new AgregarHamburguesaForm())
            {
                // ShowDialog() lo abre como popup modal
                if (formModal.ShowDialog() == DialogResult.OK)
                {
                    // Si guardó con éxito, recarga el gridView
                    textBoxBuscarHamburguesa.Text = string.Empty;
                    await LoadHamburguesas();
                }
            }
        }

        private void buttonUpdateHamburguesa_Click(object sender, EventArgs e)
        {
            // 1. Validar que exista al menos una fila seleccionada o una celda activa
            if (dataGridViewHamburguesas.CurrentRow != null && dataGridViewHamburguesas.CurrentRow.Index >= 0)
            {
                // 2. Obtener la celda "Id" (o el índice de columna correspondiente)
                var celdaId = dataGridViewHamburguesas.CurrentRow.Cells["Id"].Value;

                // 3. Validar que la celda no esté vacía o nula
                if (celdaId != null && int.TryParse(celdaId.ToString(), out int idSeleccionado))
                {
                    ActualizarHamburguesa(idSeleccionado);
                }
                else
                {
                    MessageBox.Show("La fila seleccionada no contiene un ID válido.");
                }
            }
        }

        private async void ActualizarHamburguesa(int id)
        {
            using (var formModal = new ActualizarHamburguesaForm(id))
            {
                // ShowDialog() lo abre como popup modal
                if (formModal.ShowDialog() == DialogResult.OK)
                {
                    // Si guardó con éxito, recarga el gridView
                    textBoxBuscarHamburguesa.Text = string.Empty;
                    await LoadHamburguesas();
                }
            }
        }

        private void buttonVerResumen_Click(object sender, EventArgs e)
        {
            if (dataGridViewHamburguesas.CurrentRow != null && dataGridViewHamburguesas.CurrentRow.Index >= 0)
            {
                // 2. Obtener la celda "Id" (o el índice de columna correspondiente)
                var celdaId = dataGridViewHamburguesas.CurrentRow.Cells["Id"].Value;

                // 3. Validar que la celda no esté vacía o nula
                if (celdaId != null && int.TryParse(celdaId.ToString(), out int idSeleccionado))
                {
                    VerResumen(idSeleccionado);
                }
                else
                {
                    MessageBox.Show("La fila seleccionada no contiene un ID válido.");
                }
            }
        }

        private async void VerResumen(int id)
        {
            using (var formModal = new ResumenHamburguesaForm(id))
            {
                // ShowDialog() lo abre como popup modal
                if (formModal.ShowDialog() == DialogResult.OK)
                {
                    // Si guardó con éxito, recarga el gridView
                    textBoxBuscarHamburguesa.Text = string.Empty;
                    await LoadHamburguesas();
                }
            }
        }
    }
}
