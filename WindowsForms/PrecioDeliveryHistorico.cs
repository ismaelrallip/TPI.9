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
    public partial class PrecioDeliveryHistorico : Form
    {
        public PrecioDeliveryHistorico()
        {
            InitializeComponent();
            PrecioDeliveryDataGridView.AutoGenerateColumns = false;
            ConfigurarColumnas();
        }

        private void PrecioDeliveryHistorico_Load(object sender, EventArgs e)
        {

        }
        private void ConfigurarColumnas()
        {
            PrecioDeliveryDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", DataPropertyName = "Id", Width = 60 });
            PrecioDeliveryDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "FechaDesde", HeaderText = "Fecha Desde", DataPropertyName = "FechaDesde", Width = 150 });
            PrecioDeliveryDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Monto", HeaderText = "Monto", DataPropertyName = "Monto", Width = 100 });
        }

        private async void buscarButton_Click(object sender, EventArgs e)
        {
            await CargarPrecioDeliveryAsync(dateTimePickerDesde.Value);
        }

        public async Task CargarPrecioDeliveryAsync(DateTime desde)
        {
            try
            {
                DeshabilitarControles();

                IEnumerable<PrecioDeliveryDTO> precios = await PrecioDeliveryApiClient.GetAllAsync();
                var preciosFiltrados = precios
                    .Where(p => p.FechaDesde >= desde)
                    .ToList();
                PrecioDeliveryDataGridView.DataSource = preciosFiltrados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar Precio Delivery: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }
        private PrecioDeliveryDTO? PrecioDeliverySeleccionado() =>
           PrecioDeliveryDataGridView.SelectedRows.Count == 0 ? null : (PrecioDeliveryDTO)PrecioDeliveryDataGridView.SelectedRows[0].DataBoundItem;

        private async void actualizarButton_Click(object sender, EventArgs e)
        {
            var seleccionado = PrecioDeliverySeleccionado();
            if (seleccionado == null) return;

            try
            {
                DeshabilitarControles();
                var precioDelivery = await PrecioDeliveryApiClient.GetAsync(seleccionado.Id);
                using var detalle = new AgregarPrecioDeliveryForm();
                if (detalle.ShowDialog(this) == DialogResult.OK)
                {
                    await CargarPrecioDeliveryAsync(dateTimePickerDesde.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar Precio Delivery: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            var seleccionado = PrecioDeliverySeleccionado();
            if (seleccionado == null) return;

            var confirmar = MessageBox.Show($"¿Eliminar {seleccionado.FechaDesde} {seleccionado.Monto}?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            try
            {
                DeshabilitarControles();
                await ClienteApiClient.DeleteAsync(seleccionado.Id);
                await CargarPrecioDeliveryAsync(dateTimePickerDesde.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar Precio Delivery: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private void DeshabilitarControles()
        {
            buscarButton.Enabled = false;
            agregarButton.Enabled = false;
            actualizarButton.Enabled = false;
            eliminarButton.Enabled = false;
            PrecioDeliveryDataGridView.Enabled = false;
        }

        private void HabilitarControles()
        {
            buscarButton.Enabled = true;
            agregarButton.Enabled = true;
            PrecioDeliveryDataGridView.Enabled = true;
            var haySeleccion = PrecioDeliverySeleccionado() != null;
            actualizarButton.Enabled = haySeleccion;
            eliminarButton.Enabled = haySeleccion;
        }

        private void PrecioDeliveryDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var haySeleccion = PrecioDeliverySeleccionado() != null;
            actualizarButton.Enabled = haySeleccion;
            eliminarButton.Enabled = haySeleccion;
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            using var detalle = new AgregarPrecioDeliveryForm();
            if (detalle.ShowDialog(this) == DialogResult.OK)
            {
                await CargarPrecioDeliveryAsync(dateTimePickerDesde.Value);
            }
        }
    }
}
