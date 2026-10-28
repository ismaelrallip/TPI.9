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
            this.Load += PrecioDeliveryHistorico_Load;
            PrecioDeliveryDataGridView.AutoGenerateColumns = false;
            ConfigurarColumnas();
        }

        private async void PrecioDeliveryHistorico_Load(object sender, EventArgs e)
        {
            dateTimePickerDesde.Value = DateTime.Today;
            dateTimePickerDesde.Checked = false; // Arranca destildado para mostrar todo el histórico

            // Carga inicial sin filtro (o con el valor de checked)
            await CargarPrecioDeliveryAsync(dateTimePickerDesde.Checked ? dateTimePickerDesde.Value : null);
        }

        private void ConfigurarColumnas()
        {
            PrecioDeliveryDataGridView.Columns.Clear();
            PrecioDeliveryDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", DataPropertyName = "Id", Width = 60 });
            PrecioDeliveryDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "FechaDesde", HeaderText = "Fecha Desde", DataPropertyName = "FechaDesde", Width = 150 });
            PrecioDeliveryDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Monto", HeaderText = "Monto", DataPropertyName = "Monto", Width = 100 });
        }

        private async void buscarButton_Click(object sender, EventArgs e)
        {
            // Si está tildado envía la fecha seleccionada; si no, envía null para traer todos
            DateTime? fechaFiltro = dateTimePickerDesde.Checked ? dateTimePickerDesde.Value.Date : null;
            await CargarPrecioDeliveryAsync(fechaFiltro);
        }

        public async Task CargarPrecioDeliveryAsync(DateTime? fechaFiltro = null)
        {
            try
            {
                DeshabilitarControles();

                IEnumerable<PrecioDeliveryDTO> preciosFiltrados = await PrecioDeliveryApiClient.GetByCriteriaAsync(fechaFiltro);

                PrecioDeliveryDataGridView.DataSource = preciosFiltrados.ToList();
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

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            using var detalle = new AgregarPrecioDeliveryForm();

            if (detalle.ShowDialog(this) == DialogResult.OK)
            {
                DateTime? fechaFiltro = dateTimePickerDesde.Checked ? dateTimePickerDesde.Value.Date : null;
                await CargarPrecioDeliveryAsync(fechaFiltro);
            }
        }
    }
}