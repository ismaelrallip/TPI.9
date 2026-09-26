using API.Clients;
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
    public partial class ResumenHamburguesaForm : Form
    {
        public ResumenHamburguesaForm(int id)
        {
            InitializeComponent();
            LoadDataHamburguesa(id);
        }

        private async void LoadDataHamburguesa(int id)
        {
            try
            {
                dataGridViewIngredientes.DataSource = null;
                dataGridViewPrecios.DataSource = null;

                HamburguesaDTO hambu = await HamburguesaApiClient.GetAsync(id);

                if (hambu == null) return;

                labelMostrarNombre.Text = hambu.Nombre;
                labelMostrarPrecio.Text = decimal.Parse(hambu.Precios.LastOrDefault()?.Monto.ToString() ?? "0").ToString("0.00");

                dataGridViewIngredientes.DataSource = hambu.Ingredientes.Select(i => new { i.Nombre, i.Descripcion }).ToList();
                dataGridViewPrecios.DataSource = hambu.Precios.Select(p => new { p.Monto, p.FechaDesde }).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }
    }
}
