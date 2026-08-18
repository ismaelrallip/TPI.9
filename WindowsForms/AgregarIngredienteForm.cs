using DTOs;
using Application.Services;

namespace WindowsForms
{
    public partial class AgregarIngredienteForm : Form
    {
        private readonly IngredienteService _ingredienteService;
        public AgregarIngredienteForm(IngredienteService ingredienteService)
        {
            this._ingredienteService = ingredienteService;
            InitializeComponent();
        }

        private async void buttonAddIngrediente_Click(object sender, EventArgs e)
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

            // Crear un nuevo ingrediente
            IngredienteDTO nuevoIngrediente = new IngredienteDTO();
            nuevoIngrediente.Nombre = nombre;
            nuevoIngrediente.Descripcion = descripcion;
            nuevoIngrediente.Stock = stock;

            // Llamar al método para agregar el ingrediente a la base de datos

            try
            {
                await _ingredienteService.AddAsync(nuevoIngrediente);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el ingrediente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
