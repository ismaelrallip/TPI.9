using API.Clients;
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
    public partial class ActualizarPrecioDeliveryForm : Form
    {
        private PrecioDeliveryDTO _precioDelivery;
        public ActualizarPrecioDeliveryForm(PrecioDeliveryDTO precioDelivery)
        {
            this._precioDelivery = precioDelivery;
            InitializeComponent();
        }

        private async void buttonUpdatePrecioDelivery_Click(object sender, EventArgs e)
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

        private async void buttonDeletePrecioDelivery_Click(object sender, EventArgs e)
        {
            try
            {
                await PrecioDeliveryApiClient.DeleteAsync(_precioDelivery.Id);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el precio delivery: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
