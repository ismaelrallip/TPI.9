using Application.Services;
using Domain.Model;
using DTOs;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
        private Hamburguesa _hamburguesa;
        private string nombre;
        private string descripcion;
        private decimal precio;
        private DateTime fechaDesde;
        private List<Ingrediente> ingredientesSeleccionados;

        private HamburguesaDTO hambuCambiada = new HamburguesaDTO();

        public ActualizarHamburguesaForm(HamburguesaService hamburguesaService, Hamburguesa hamburguesa)
        {
            this._hamburguesaService = hamburguesaService;
            this._hamburguesa = hamburguesa;
            InitializeComponent();
        }

        private void ActualizarHamburguesaForm_Load(object sender, EventArgs e)
        {
            textBoxNombre.Text = _hamburguesa.Nombre;
            textBoxDescripcion.Text = _hamburguesa.Descripcion;
            textBoxPrecio.Text = _hamburguesa.Precio.Monto.ToString();

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
                await _hamburguesaService.UpdateAsync(hambuCambiada);
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
            if (_hamburguesa.Precio.Monto != decimal.Parse(textBoxPrecio.Text))
            {
                precio = decimal.Parse(textBoxPrecio.Text);
                fechaDesde = DateTime.Now;
            }
            else
            {
                precio = _hamburguesa.Precio.Monto;
                fechaDesde = _hamburguesa.Precio.FechaDesde;
            }
            Precio _precio = new Precio(fechaDesde, precio);
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
            hambuCambiada.Nombre = nombre;
            hambuCambiada.Descripcion = descripcion;
            hambuCambiada.Precio = _precio;
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
                await _hamburguesaService.DeleteAsync(_hamburguesa.Id);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el ingrediente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
