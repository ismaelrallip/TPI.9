using API.Clients;
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
        private List<IngredienteDTO> ingredientesSeleccionados;

        private HamburguesaDTO hambuCambiada = new HamburguesaDTO();

        public ActualizarHamburguesaForm(int id)
        {
            this.idRecibida = id;
            InitializeComponent();
        }

        private async void ActualizarHamburguesaForm_Load(object sender, EventArgs e)
        {
            buttonUpdateHamburguesa.Enabled = false;
            buttonDeleteHamburguesa.Enabled = false;

            _hamburguesa = await HamburguesaApiClient.GetAsync(idRecibida);


            textBoxNombre.Text = _hamburguesa.Nombre;
            textBoxDescripcion.Text = _hamburguesa.Descripcion;


            if (_hamburguesa.Precios.Last() != null)
            {
                textBoxPrecio.Text = (_hamburguesa.Precios.Last()).Monto.ToString();
            }

            await CargarIngredientes();
            await MarcarIngredientesDeHamburguesa(_hamburguesa);

            buttonUpdateHamburguesa.Enabled = true;
            buttonDeleteHamburguesa.Enabled = true;
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

        private async Task MarcarIngredientesDeHamburguesa(HamburguesaDTO burga)
        {
            // 1. Desmarcamos todos los elementos previamente seleccionados
            for (int i = 0; i < checkedListBoxIngredientes.Items.Count; i++)
            {
                checkedListBoxIngredientes.SetItemChecked(i, false);
            }

            if (burga?.Ingredientes == null || !burga.Ingredientes.Any())
                return;

            // 2. Extraemos los Ids de los ingredientes de la hamburguesa en un HashSet para búsqueda rápida O(1)
            var idsIngredientesHamburguesa = burga.Ingredientes
                                                .Select(i => i.Id)
                                                .ToHashSet();

            // 3. Recorremos los elementos cargados en el CheckedListBox
            for (int i = 0; i < checkedListBoxIngredientes.Items.Count; i++)
            {
                if (checkedListBoxIngredientes.Items[i] is IngredienteDTO ing)
                {
                    if (idsIngredientesHamburguesa.Contains(ing.Id))
                    {
                        checkedListBoxIngredientes.SetItemChecked(i, true);
                    }
                }
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
                if (!SeleccionarDatos()) return;

                await HamburguesaApiClient.UpdateAsync(hambuCambiada);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la hamburguesa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Arma el DTO con los datos del formulario. Devuelve false si falta algo.
        private bool SeleccionarDatos()
        {
            nombre = textBoxNombre.Text;
            descripcion = textBoxDescripcion.Text;

            // Validar que el nombre y la descripción no estén vacíos y que el precio sea válido
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(descripcion) ||
                !decimal.TryParse(textBoxPrecio.Text, out precio) || precio < 0)
            {
                MessageBox.Show("Nombre o Descripcion no validos o el precio no puede ser negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ingredientesSeleccionados = checkedListBoxIngredientes.CheckedItems
                                                            .Cast<IngredienteDTO>()
                                                            .ToList();

            hambuCambiada.Id = idRecibida;
            hambuCambiada.Nombre = nombre;
            hambuCambiada.Descripcion = descripcion;
            hambuCambiada.Ingredientes = ingredientesSeleccionados;

            // Se manda el precio del formulario: el servicio compara con el vigente y,
            // solo si es distinto, crea un precio nuevo con la fecha de hoy.
            hambuCambiada.Precios = new List<PrecioDTO> { new PrecioDTO { Monto = precio } };

            return true;
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
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la hamburguesa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}