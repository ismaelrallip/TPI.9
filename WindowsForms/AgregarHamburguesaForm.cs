using API.Clients;
using Domain.Model;
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
            if(string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
               string.IsNullOrWhiteSpace(textBoxDescripcion.Text) ||
               string.IsNullOrWhiteSpace(textBoxPrecio.Text) ||
               checkedListBoxIngredientes.CheckedItems.Count == 0)
            {
                MessageBox.Show("Por favor, complete todos los campos y seleccione al menos un ingrediente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try 
            {
                string nombre = textBoxNombre.Text;
                string descripcion = textBoxDescripcion.Text;
                // precio
                decimal precio = decimal.Parse(textBoxPrecio.Text);
                DateTime fechaDesde = DateTime.Now;

                Precio _precio = new Precio(fechaDesde, precio);
                //
                IngredienteDTO[] ingredientesSeleccionados = checkedListBoxIngredientes.CheckedItems.Cast<IngredienteDTO>().ToArray();
                List<Ingrediente> ingredientes = ingredientesSeleccionados.Select(
                    dto => new Ingrediente(
                            dto.Id,
                            dto.Nombre,
                            dto.Descripcion,
                            dto.Stock
                            )).ToList();

                List<Precio> precios = new List<Precio>();
                precios.Add(_precio);

                HamburguesaDTO nuevaHamburguesa = new HamburguesaDTO();
                nuevaHamburguesa.Id = 0;
                nuevaHamburguesa.Nombre = nombre;
                nuevaHamburguesa.Descripcion = descripcion;
                nuevaHamburguesa.Precios = precios;
                nuevaHamburguesa.Ingredientes = ingredientes;

                await HamburguesaApiClient.AddAsync(nuevaHamburguesa);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores validos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
