using Application.Services;
using Domain.Model;
using System.Data;

namespace WindowsForms
{
    public partial class IngredientesForm : Form
    {
        private readonly IngredienteService _ingredienteService;

        private IEnumerable<Ingrediente> _ingredientes;


        public IngredientesForm(IngredienteService ingredienteService)
        {
            InitializeComponent();
            _ingredienteService = ingredienteService;
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
                var ingredientes = await _ingredienteService.GetAllAsync();
                _ingredientes = (IEnumerable<Ingrediente>)ingredientes;
                dataGridViewIngredientes.DataSource = ingredientes.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ingredientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewIngredientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var ingredienteSeleccionado = dataGridViewIngredientes.Rows[e.RowIndex].DataBoundItem as Ingrediente;

            if (ingredienteSeleccionado != null)
            {
                ActualizarIngrediente();
            }
        }

        private void AgregarIngrediente() 
        {
            using (var formModal = new AgregarIngredienteForm(_ingredienteService))
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
        private void ActualizarIngrediente() 
        {
            using (var formModal = new ActualizarIngredienteForm(_ingredienteService))
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
