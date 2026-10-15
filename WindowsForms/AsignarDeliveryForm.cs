using System;
using System;
using System.Linq;
using System.Windows.Forms;
using API.Clients;
using DTOs;
using Domain.Model;

namespace WindowsForms
{
    public partial class AsignarDeliveryForm : Form
    {
        private readonly PedidoDTO _pedido;

        
        public AsignarDeliveryForm() { InitializeComponent(); }

        public AsignarDeliveryForm(PedidoDTO pedido) : this()
        {
            _pedido = pedido;
            this.Text = $"Asignar Repartidor a Pedido #{pedido.Id}";
        }

        private async void AsignarDeliveryForm_Load(object sender, EventArgs e)
        {
            btnAceptar.Enabled = false;
            try
            {
                var deliveries = await DeliveryApiClient.GetAllAsync();

                comboRepartidores.DisplayMember = "Nombre";
                comboRepartidores.ValueMember = "IdDelivery";
                comboRepartidores.DataSource = deliveries.Select(d => new
                {
                    d.IdDelivery,
                    Nombre = $"{d.Nombre} {d.Apellido} - DNI: {d.Dni}"
                }).ToList();
                comboRepartidores.SelectedValue = -1;
                //  Si el pedido ya tiene un delivery asignado, lo preseleccionamos
                if (_pedido.DeliveryId != null && _pedido.DeliveryId > 0)
                {
                    comboRepartidores.SelectedValue = _pedido.DeliveryId;
                    this.Text = $"Reasignar Repartidor a Pedido #{_pedido.Id}";
                }

                btnAceptar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar repartidores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (comboRepartidores.SelectedValue == null) return;

            string nombreRepartidor = comboRepartidores.Text;
            int nuevoDeliveryId = (int)comboRepartidores.SelectedValue;

            // Quitamos el bloqueo anticipado que podía causar falsos retornos si el ID venía en 0 o null

            string mensaje = (_pedido.DeliveryId != null && _pedido.DeliveryId > 0)
                ? $"¿Estás seguro que deseas cambiar el repartidor a {nombreRepartidor} para el pedido #{_pedido.Id}?"
                : $"¿Estás seguro que deseas asignar a {nombreRepartidor} al pedido #{_pedido.Id}?\n\n(Podrás cambiarlo luego si aún no está En Camino).";

            var confirmar = MessageBox.Show(mensaje, "Confirmar Repartidor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes) return;

            try
            {
                btnAceptar.Enabled = false;

                _pedido.DeliveryId = nuevoDeliveryId;
                _pedido.Estado = EstadoPedido.Asignado;

                await PedidoApiClient.UpdateAsync(_pedido);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al asignar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAceptar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}