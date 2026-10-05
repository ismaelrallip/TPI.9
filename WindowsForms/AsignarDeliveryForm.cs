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

           
            var confirmar = MessageBox.Show(
                $"¿Estás seguro que deseas asignar a {nombreRepartidor} al pedido #{_pedido.Id}?\n\nATENCIÓN: Esta acción NO se puede deshacer. Una vez asignado, no podrás cambiar el repartidor ni volver atrás.",
                "Confirmar Repartidor",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmar != DialogResult.Yes) return; 

            try
            {
                btnAceptar.Enabled = false;

                
                _pedido.DeliveryId = (int)comboRepartidores.SelectedValue;
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