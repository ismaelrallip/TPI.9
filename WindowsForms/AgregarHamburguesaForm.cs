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
            checkedListBoxIngredientes.DisplayMember = "Nombre";
            checkedListBoxIngredientes.Items.Clear();
            var ingredientes = await IngredienteApiClient.GetAllAsync();
            if (ingredientes != null)
            {
                checkedListBoxIngredientes.Items.AddRange(ingredientes.ToArray());
            }
        }

        private void buttonAddIngrediente_Click(object sender, EventArgs e)
        {
            try 
            {
                string nombre = textBoxNombre.Text;
                string descripcion = textBoxDescripcion.Text;
                // precio
                decimal precio = decimal.Parse(textBoxPrecio.Text);
                DateTime fechaDesde = DateTime.Now;

                Precio _precio = new Precio(fechaDesde, precio);
                //
                Ingrediente[] ingredientesSeleccionados = checkedListBoxIngredientes.CheckedItems.Cast<Ingrediente>().ToArray();

                HamburguesaDTO nuevaHamburguesa = new HamburguesaDTO();
                nuevaHamburguesa.Id = 0;
                nuevaHamburguesa.Nombre = nombre;
                nuevaHamburguesa.Descripcion = descripcion;
                nuevaHamburguesa.Precio = _precio;
                nuevaHamburguesa.Ingredientes = ingredientesSeleccionados.ToList();

                HamburguesaApiClient.AddAsync(nuevaHamburguesa);
                

            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores validos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
