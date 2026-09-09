using API.Clients;
using Domain.Model;
using DTOs;
using System.Data;


namespace WindowsForms
{
    public partial class ActualizarHamburguesaForm : Form
    {
        private HamburguesaDTO _hamburguesa;
        private int idRecibida;
        private string nombre;
        private string descripcion;
        private decimal precio;
        private DateTime fechaDesde;
        private List<Ingrediente> ingredientesSeleccionados;

        private HamburguesaDTO hambuCambiada = new HamburguesaDTO();

        public ActualizarHamburguesaForm(int id)
        {
            this.idRecibida = id;
            InitializeComponent();
        }

        private async void ActualizarHamburguesaForm_Load(object sender, EventArgs e)
        {
            _hamburguesa = await HamburguesaApiClient.GetAsync(idRecibida);

            textBoxNombre.Text = _hamburguesa.Nombre;
            textBoxDescripcion.Text = _hamburguesa.Descripcion;


            if (_hamburguesa.Precios.Last() != null)
            {
                textBoxPrecio.Text = (_hamburguesa.Precios.Last()).Monto.ToString();
            }
            

            checkedListBoxIngredientes.DisplayMember = "Nombre";
            checkedListBoxIngredientes.Items.Clear();

            if (_hamburguesa.Ingredientes != null)
            {
                checkedListBoxIngredientes.Items.AddRange(_hamburguesa.Ingredientes.ToArray());
            }
        }

        private void buttonUpdateHamburguesa_Click(object sender, EventArgs e)
        {
            ActualizarHamburguesa();
        }

        private async void ActualizarHamburguesa()
        {
            try
            {
                SeleccionarDatos();
                await HamburguesaApiClient.UpdateAsync(hambuCambiada);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el ingrediente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarDatos()
        {
            nombre = textBoxNombre.Text;
            descripcion = textBoxDescripcion.Text;
            // precio
            if ((_hamburguesa.Precios.Last()).Monto != decimal.Parse(textBoxPrecio.Text))
            {
                precio = decimal.Parse(textBoxPrecio.Text);
                fechaDesde = DateTime.Now;
                Precio _precio = new Precio(fechaDesde, precio);

                hambuCambiada.Precios.Add(_precio);
            }
            else
            {
                hambuCambiada.Precios = _hamburguesa.Precios;

            }
            //
            ingredientesSeleccionados = checkedListBoxIngredientes.CheckedItems
                                                    .Cast<Ingrediente>()
                                                    .ToList();

            // Validar que el nombre no esté vacío
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrEmpty(descripcion) || precio > 0)
            {
                MessageBox.Show("Nombre o Descripcion no validos o el precio no puede ser negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear un ingredientea actualizado
            hambuCambiada.Id = idRecibida;
            hambuCambiada.Nombre = nombre;
            hambuCambiada.Descripcion = descripcion;
            hambuCambiada.Ingredientes = ingredientesSeleccionados;
        }

        private async void buttonDeleteHamburguesa_Click(object sender, EventArgs e)
        {
            EliminarHamburguesa();
        }

        private async void EliminarHamburguesa() 
        {
            try
            {
                await HamburguesaApiClient.DeleteAsync(idRecibida);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el ingrediente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
