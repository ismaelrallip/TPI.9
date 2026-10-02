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
            dateTimePickerDesde.Value = dateTimePickerDesde.MinDate;
            _ = CargarPrecioDeliveryAsync(dateTimePickerDesde.Value);
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

        private void DeshabilitarControles()
        {
            buscarButton.Enabled = false;
            agregarButton.Enabled = false;
            PrecioDeliveryDataGridView.Enabled = false;
        }

        private void HabilitarControles()
        {
            buscarButton.Enabled = true;
            agregarButton.Enabled = true;
            PrecioDeliveryDataGridView.Enabled = true;
        }

        private void PrecioDeliveryDataGridView_SelectionChanged(object sender, EventArgs e)
        {
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
