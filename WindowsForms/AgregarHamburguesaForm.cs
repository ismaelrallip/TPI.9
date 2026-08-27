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
    public partial class AgregarHamburguesaForm : Form
    {
        private readonly HamburguesaService _hamburguesaService;
        public AgregarHamburguesaForm(HamburguesaService hamburguesaService)
        {
            this._hamburguesaService = hamburguesaService;
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
            var ingredientes = await _hamburguesaService.GetAllAsync();
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

                _hamburguesaService.AddAsync(nuevaHamburguesa);
                

            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores validos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
