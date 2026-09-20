using API.Clients;
using Domain.Model;
using System.Data;
using DTOs;

namespace WindowsForms
{
    public partial class IngredientesForm : Form
    {

        private IEnumerable<IngredienteDTO> _ingredientes;


        public IngredientesForm()
        {
            InitializeComponent();
        }

        private void IngredientesForm_Load(object sender, EventArgs e)
        {
            LoadIngredientes();
        }

        private void textBoxBuscarIngredientes_TextChanged(object sender, EventArgs e)
        {
            if (_ingredientes == null) return;

            string filtro = textBoxBuscarIngredientes.Text?.Trim() ?? string.Empty;

            // 1. Si no hay filtro, mostramos la lista completa original
            // 2. Si hay filtro, filtramos sobre _ingredientes SIN sobrescribirlo
            var ingredientesFiltrados = string.IsNullOrWhiteSpace(filtro)
                ? _ingredientes
                : _ingredientes.Where(i => (i.Nombre != null && i.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase)) ||
                                          (i.Descripcion != null && i.Descripcion.Contains(filtro, StringComparison.OrdinalIgnoreCase)));

            // 3. Asignar el resultado al DataGridView
            dataGridViewIngredientes.DataSource = null;
            dataGridViewIngredientes.DataSource = ingredientesFiltrados.ToList();
        }

        private void buttonAddIngrediente_Click(object sender, EventArgs e)
        {
            AgregarIngrediente();
        }

        // FUNCIONES
        private async Task LoadIngredientes()
        {
            try
            {
                var ingredientes = await IngredienteApiClient.GetAllAsync();
                _ingredientes = ingredientes;
                dataGridViewIngredientes.DataSource = ingredientes.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ingredientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewIngredientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dataGridViewIngredientes.Rows[e.RowIndex];

            int id = Convert.ToInt32(fila.Cells["Id"].Value);

            ActualizarIngrediente(id);
        }

        private async void AgregarIngrediente() 
        {
            using (var formModal = new AgregarIngredienteForm())
            {
                // ShowDialog() lo abre como popup modal
                if (formModal.ShowDialog() == DialogResult.OK)
                {
                    // Si guardó con éxito, recarga el gridView
                    textBoxBuscarIngredientes.Text = string.Empty;
                    await LoadIngredientes();
                }
            }
        }
        private async void ActualizarIngrediente(int id) 
        {
            using (var formModal = new ActualizarIngredienteForm(id))
            {
                // ShowDialog() lo abre como popup modal
                if (formModal.ShowDialog() == DialogResult.OK)
                {
                    // Si guardó con éxito, recarga el gridView
                    textBoxBuscarIngredientes.Text = string.Empty;
                    await LoadIngredientes();
                }
            }
            
        }
    }
}
