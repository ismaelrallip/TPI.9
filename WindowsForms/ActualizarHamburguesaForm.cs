using Application.Services;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class ActualizarHamburguesaForm : Form
    {
        private readonly HamburguesaService _hamburguesaService;
        private Hamburguesa hamburguesa;
        public ActualizarHamburguesaForm(HamburguesaService hamburguesaService, Hamburguesa hamburguesa)
        {
            this._hamburguesaService = hamburguesaService;
            this.hamburguesa = hamburguesa;
            InitializeComponent();
        }

        private void ActualizarHamburguesaForm_Load(object sender, EventArgs e)
        {
            textBoxNombre.Text = hamburguesa.Nombre;
            textBoxDescripcion.Text = hamburguesa.Descripcion;
            textBoxPrecio.Text = hamburguesa.Precio.ToString();

            checkedListBoxIngredientes.DisplayMember = "Nombre";
            checkedListBoxIngredientes.Items.Clear();

            if (hamburguesa.Ingredientes != null)
            {
                checkedListBoxIngredientes.Items.AddRange(hamburguesa.Ingredientes.ToArray());
            }
        }

        private void buttonUpdateHamburguesa_Click(object sender, EventArgs e)
        {
            ActualizarHamburguesa();
        }

        private async void ActualizarHamburguesa() 
        {
            string nombre = textBoxNombre.Text;
            string descripcion = textBoxDescripcion.Text;
            decimal precio = decimal.Parse(textBoxPrecio.Text);
            List<Ingrediente> ingredientesSeleccionados = checkedListBoxIngredientes.CheckedItems
                                                .Cast<Ingrediente>()
                                                .ToList();

            // Validar que el nombre no esté vacío
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrEmpty(descripcion) || precio > 0)
            {
                MessageBox.Show("Nombre o Descripcion no validos o el precio no puede ser negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear un ingredientea actualizado
            HamburguesaDTO hambuCambiada = new HamburguesaDTO();
            hambuCambiada.Nombre = nombre;
            hambuCambiada.Descripcion = descripcion;
            hambuCambiada.Precio = precio;
            hambuCambiada.Ingredientes = ingredientesSeleccionados;

            // Llamar al método para agregar el ingrediente a la base de datos

            try
            {
                await _hamburguesaService.UpdateAsync(hambuCambiada);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el ingrediente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
