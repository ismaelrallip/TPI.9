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
    public partial class AgregarPrecioDeliveryForm : Form
    {
        public AgregarPrecioDeliveryForm()
        {
            InitializeComponent();
        }

        private void AgregarPrecioDelivery_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void agregarPrecioDelivery_Click(object sender, EventArgs e)
        {
            DateTime fecha = dateTimePicker1.Value;
            decimal precio = Convert.ToDecimal(textBox1.Text);

            // Crear un nuevo PrecioDelivery
            PrecioDeliveryDTO nuevoPrecioDelivery = new PrecioDeliveryDTO
            {
                FechaDesde = fecha,
                Monto = precio
            };


            // Llamar al método para agregar el PrecioDelivery a la base de datos

            try
            {
                await PrecioDeliveryApiClient.AddAsync(nuevoPrecioDelivery);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el precio delivery: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
