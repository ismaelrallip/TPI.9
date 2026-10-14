using API.Clients;
using DTOs;
using System.Data;

namespace WindowsForms
{
    public partial class AgregarHamburguesaForm : Form
    {
        public AgregarHamburguesaForm()
        {
            InitializeComponent();
        }

        private void AgregarHamburguesaForm_Load(object sender, EventArgs e)
        {
            CargarIngredientes();

        }

        private async Task CargarIngredientes()
        {
            checkedListBoxIngredientes.Items.Clear();

            IEnumerable<IngredienteDTO> ingredientes = await IngredienteApiClient.GetAllAsync();
            if (ingredientes != null)
            {
                checkedListBoxIngredientes.Items.AddRange(ingredientes.ToArray());
                checkedListBoxIngredientes.DisplayMember = "Nombre";
                checkedListBoxIngredientes.ValueMember = "Id";
            }
        }

        private async void buttonAddHamburguesa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
               string.IsNullOrWhiteSpace(textBoxDescripcion.Text) ||
               string.IsNullOrWhiteSpace(textBoxPrecio.Text) ||
               checkedListBoxIngredientes.CheckedItems.Count == 0)
            {
                MessageBox.Show("Por favor, complete todos los campos y seleccione al menos un ingrediente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                decimal precio = decimal.Parse(textBoxPrecio.Text);
                IngredienteDTO[] ingredientesSeleccionados = checkedListBoxIngredientes.CheckedItems.Cast<IngredienteDTO>().ToArray();

                // El formulario solo manda datos simples (DTO). El servicio arma las entidades:
                // el precio con la fecha de hoy y los ingredientes existentes.
                HamburguesaDTO nuevaHamburguesa = new HamburguesaDTO
                {
                    Id = 0,
                    Nombre = textBoxNombre.Text,
                    Descripcion = textBoxDescripcion.Text,
                    Precios = new List<PrecioDTO> { new PrecioDTO { Monto = precio } },
                    Ingredientes = ingredientesSeleccionados.ToList()
                };

                await HamburguesaApiClient.AddAsync(nuevaHamburguesa);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores validos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Las validaciones ahora las hace el servicio 
                MessageBox.Show($"Error al agregar la hamburguesa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}