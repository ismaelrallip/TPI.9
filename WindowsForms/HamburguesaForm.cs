using Domain.Model;
using API.Clients;
using DTOs;
using System.Data;

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
            LoadHamburguesas();
        }

        // FUNCIONES
        private async Task LoadHamburguesas()
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar hamburguesas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxBuscarHamburguesa_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBoxBuscarHamburguesa.Text;
            if (burgas != null)
            {
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    burgas = burgas.Where(i => i.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                                                          i.Descripcion.Contains(filtro, StringComparison.OrdinalIgnoreCase));
                }
                dataGridViewHamburguesas.DataSource = burgas.ToList();
            }
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
        private void dataGridViewHamburguesas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dataGridViewHamburguesas.Rows[e.RowIndex];

            int id = Convert.ToInt32(fila.Cells["Id"].Value);

            ActualizarHamburguesa(id);
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
    }
}
