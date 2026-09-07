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
            string filtro = textBoxBuscarIngredientes.Text;
            if (_ingredientes != null)
            {
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    _ingredientes = _ingredientes.Where(i => i.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                                                          i.Descripcion.Contains(filtro, StringComparison.OrdinalIgnoreCase));
                }
                dataGridViewIngredientes.DataSource = _ingredientes.ToList();
            }
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

        private void AgregarIngrediente() 
        {
            using (var formModal = new AgregarIngredienteForm())
            {
                // ShowDialog() lo abre como popup modal
                if (formModal.ShowDialog() == DialogResult.OK)
                {
                    // Si guardó con éxito, recarga el gridView
                    textBoxBuscarIngredientes.Text = string.Empty;
                    LoadIngredientes();
                }
            }
        }
        private void ActualizarIngrediente(int id) 
        {
            using (var formModal = new ActualizarIngredienteForm(id))
            {
                // ShowDialog() lo abre como popup modal
                if (formModal.ShowDialog() == DialogResult.OK)
                {
                    // Si guardó con éxito, recarga el gridView
                    textBoxBuscarIngredientes.Text = string.Empty;
                    LoadIngredientes();
                }
            }
        }
    }
}
