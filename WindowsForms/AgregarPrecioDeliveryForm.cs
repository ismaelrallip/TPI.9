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
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Enabled = false;
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
            DateTime fecha = DateTime.Now;
            if (!decimal.TryParse(textBox1.Text, out var precio) || precio <= 0)
            {
                MessageBox.Show("Ingrese un monto numérico mayor que cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

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
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el precio delivery: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
