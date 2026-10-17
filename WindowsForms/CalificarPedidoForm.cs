using System;
using System.Windows.Forms;
using API.Clients;
using Domain.Model;
using DTOs;

namespace WindowsForms
{
    public partial class CalificarPedidoForm : Form
    {
        private readonly PedidoDTO _pedido;

        public CalificarPedidoForm(PedidoDTO pedido)
        {
            InitializeComponent();
            _pedido = pedido;
            CargarDatosExistentes();
        }

        private void CargarDatosExistentes()
        {
            // Título informativo
            this.Text = $"Calificar Pedido #{_pedido.Id}";

            // Si es delivery, mostramos los controles de delivery. Si es takeaway, los ocultamos/desactivamos.
            bool esDelivery = _pedido.Modalidad == ModalidadPedido.Delivery;
            lblCalifDelivery.Visible = esDelivery;
            numCalifDelivery.Visible = esDelivery;

            // Cargamos datos existentes si los hubiera (si ya fue calificado antes)
            if (_pedido.CalificacionPedido.HasValue)
            {
                numCalifPedido.Value = Math.Clamp(_pedido.CalificacionPedido.Value, 1, 5);
            }
            else
            {
                numCalifPedido.Value = 5; // Valor por defecto si viene nulo
            }

            if (esDelivery)
            {
                if (_pedido.CalificacionDelivery.HasValue && _pedido.CalificacionDelivery.Value > 0)
                {
                    numCalifDelivery.Value = Math.Clamp(_pedido.CalificacionDelivery.Value, 1, 5);
                }
                else
                {
                    numCalifDelivery.Value = 5;
                }
            }

            txtComentarioFinal.Text = _pedido.ComentarioFinal ?? string.Empty;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Actualizamos los campos en el DTO del pedido
                _pedido.CalificacionPedido = (int)numCalifPedido.Value;

                if (_pedido.Modalidad == ModalidadPedido.Delivery)
                {
                    _pedido.CalificacionDelivery = (int)numCalifDelivery.Value;
                }
                else
                {
                    _pedido.CalificacionDelivery = null; // TakeAway no lleva calificación de delivery
                }

                _pedido.ComentarioFinal = txtComentarioFinal.Text.Trim();

                // Enviamos la actualización a la API usando el cliente existente
                await PedidoApiClient.UpdateAsync(_pedido);

                MessageBox.Show("¡Calificación y comentario guardados con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la calificación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}