using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DTOs;
using API.Clients;

namespace WindowsForms
{
    public partial class DeliveryLista : Form
    {
        public DeliveryLista()
        {
            InitializeComponent();
            deliveriesDataGridView.AutoGenerateColumns = false;
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            deliveriesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdDelivery", HeaderText = "Id", DataPropertyName = "IdDelivery", Width = 60 });
            deliveriesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Nombre", DataPropertyName = "Nombre", Width = 150 });
            deliveriesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Apellido", HeaderText = "Apellido", DataPropertyName = "Apellido", Width = 150 });
            deliveriesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefono", HeaderText = "Teléfono", DataPropertyName = "Telefono", Width = 140 });
            deliveriesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Dni", HeaderText = "DNI", DataPropertyName = "Dni", Width = 100 });
        }

        private async void DeliveryLista_Load(object sender, EventArgs e)
        {
            await CargarDeliveriesAsync();
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            using var detalle = new DeliveryDetalle(FormMode.Add, new DeliveryDTO());
            if (detalle.ShowDialog(this) == DialogResult.OK)
            {
                await CargarDeliveriesAsync();
            }
        }

        private async void actualizarButton_Click(object sender, EventArgs e)
        {
            var seleccionado = DeliverySeleccionado();
            if (seleccionado == null) return;

            try
            {
                DeshabilitarControles();
                var delivery = await DeliveryApiClient.GetAsync(seleccionado.IdDelivery);
                using var detalle = new DeliveryDetalle(FormMode.Update, delivery);
                if (detalle.ShowDialog(this) == DialogResult.OK)
                {
                    await CargarDeliveriesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar delivery: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            var seleccionado = DeliverySeleccionado();
            if (seleccionado == null) return;

            var confirmar = MessageBox.Show($"¿Eliminar a {seleccionado.Nombre} {seleccionado.Apellido}?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            try
            {
                DeshabilitarControles();
                await DeliveryApiClient.DeleteAsync(seleccionado.IdDelivery);
                await CargarDeliveriesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar delivery: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void buscarButton_Click(object sender, EventArgs e)
        {
            await CargarDeliveriesAsync(buscarTextBox.Text.Trim());
        }

        private async Task CargarDeliveriesAsync(string texto = "")
        {
            try
            {
                DeshabilitarControles();

                IEnumerable<DeliveryDTO> deliveries = string.IsNullOrWhiteSpace(texto)
                    ? await DeliveryApiClient.GetAllAsync()
                    : await DeliveryApiClient.GetByCriteriaAsync(texto);

                deliveriesDataGridView.DataSource = deliveries.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar deliveries: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private DeliveryDTO? DeliverySeleccionado() =>
            deliveriesDataGridView.SelectedRows.Count == 0 ? null : (DeliveryDTO)deliveriesDataGridView.SelectedRows[0].DataBoundItem;

        private void deliveriesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var haySeleccion = DeliverySeleccionado() != null;
            actualizarButton.Enabled = haySeleccion;
            eliminarButton.Enabled = haySeleccion;
        }

        private void DeshabilitarControles()
        {
            buscarButton.Enabled = false;
            agregarButton.Enabled = false;
            actualizarButton.Enabled = false;
            eliminarButton.Enabled = false;
            deliveriesDataGridView.Enabled = false;
        }

        private void HabilitarControles()
        {
            buscarButton.Enabled = true;
            agregarButton.Enabled = true;
            deliveriesDataGridView.Enabled = true;
            var haySeleccion = DeliverySeleccionado() != null;
            actualizarButton.Enabled = haySeleccion;
            eliminarButton.Enabled = haySeleccion;
        }
    }
}