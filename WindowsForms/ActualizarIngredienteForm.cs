using Domain.Model;
using DTOs;
using API.Clients;

namespace WindowsForms
{
    public partial class ActualizarIngredienteForm : Form
    {
        private Ingrediente _ingrediente;
        public ActualizarIngredienteForm(Ingrediente ingrediente)
        {
            this._ingrediente = ingrediente;
            InitializeComponent();
        }

        private void ActualizarIngredienteForm_Load(object sender, EventArgs e)
        {
            textBoxNombre.Text = _ingrediente.Nombre;
            textBoxDescripcion.Text = _ingrediente.Descripcion;
            numericUpDownStock.Value = _ingrediente.Stock;

        }

        private async void buttonUpdateIngrediente_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text;
            string descripcion = textBoxDescripcion.Text;
            int stock = (int)numericUpDownStock.Value;

            // Validar que el nombre no esté vacío
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrEmpty(descripcion) || stock < 0)
            {
                MessageBox.Show("Nombre y Descripcion no pueden estar vacíos y el stock no puede ser negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear un ingredientea actualizado
            IngredienteDTO ingredienteCambiado = new IngredienteDTO();
            ingredienteCambiado.Nombre = nombre;
            ingredienteCambiado.Descripcion = descripcion;
            ingredienteCambiado.Stock = stock;

            // Llamar al método para agregar el ingrediente a la base de datos

            try
            {
                await IngredienteApiClient.UpdateAsync(ingredienteCambiado);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el ingrediente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeleteIngrediente_Click(object sender, EventArgs e)
        {
            EliminarIngrediente();
        }

        private async void EliminarIngrediente() 
        {
            try
            {
                await IngredienteApiClient.DeleteAsync(_ingrediente.Id);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el ingrediente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
