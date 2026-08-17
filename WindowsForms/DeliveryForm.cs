using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Services;
using DTOs;

namespace WindowsForms
{
    public partial class DeliveryForm : Form
    {
        private readonly IDeliveryService deliveryService;
        private DataGridView dgvDeliveries;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;

        public DeliveryForm(IDeliveryService deliveryService)
        {
            this.deliveryService = deliveryService;
            InitializeComponent();
            _ = LoadDeliveries();
        }

        private void InitializeComponent()
        {
            this.Text = "Gestión de Deliveries";
            this.Width = 700;
            this.Height = 450;
            this.StartPosition = FormStartPosition.CenterParent;

            dgvDeliveries = new DataGridView()
            {
                Left = 12,
                Top = 12,
                Width = 660,
                Height = 340,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true
            };

            btnAgregar = new Button() { Text = "Nuevo", Left = 12, Top = 365, Width = 90 };
            btnModificar = new Button() { Text = "Modificar", Left = 110, Top = 365, Width = 90 };
            btnEliminar = new Button() { Text = "Eliminar", Left = 210, Top = 365, Width = 90 };

            btnAgregar.Click += BtnAgregar_Click;
            btnModificar.Click += BtnModificar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            this.Controls.Add(dgvDeliveries);
            this.Controls.Add(btnAgregar);
            this.Controls.Add(btnModificar);
            this.Controls.Add(btnEliminar);
        }

        private async Task LoadDeliveries()
        {
            try
            {
                var list = await deliveryService.GetAllAsync();
                dgvDeliveries.DataSource = list.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnAgregar_Click(object sender, EventArgs e)
        {
            var form = new DeliveryDetailForm(deliveryService, null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadDeliveries();
            }
        }

        private async void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDeliveries.SelectedRows.Count > 0)
            {
                var dto = (DeliveryDTO)dgvDeliveries.SelectedRows[0].DataBoundItem;
                var form = new DeliveryDetailForm(deliveryService, dto);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadDeliveries();
                }
            }
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDeliveries.SelectedRows.Count > 0)
            {
                var dto = (DeliveryDTO)dgvDeliveries.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show($"¿Eliminar delivery {dto.Nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await deliveryService.DeleteAsync(dto.IdDelivery);
                    await LoadDeliveries();
                }
            }
        }
    }
}
