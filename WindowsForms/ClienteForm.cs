using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Services;
using DTOs;

namespace WindowsForms
{
    public partial class ClienteForm : Form
    {
        private readonly IClienteService clienteService;
        private DataGridView dgvClientes;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Label lblBuscar;

        public ClienteForm(IClienteService clienteService)
        {
            this.clienteService = clienteService;
            InitializeComponent();
            _ = LoadClientes();
        }

        private void InitializeComponent()
        {
            this.Text = "Gestión de Clientes";
            this.Width = 750;
            this.Height = 450;
            this.StartPosition = FormStartPosition.CenterParent;

            lblBuscar = new Label() { Text = "Buscar:", Left = 12, Top = 15, Width = 50 };
            txtBuscar = new TextBox() { Left = 70, Top = 12, Width = 200 };
            btnBuscar = new Button() { Text = "Filtrar", Left = 280, Top = 10, Width = 75 };

            dgvClientes = new DataGridView()
            {
                Left = 12,
                Top = 50,
                Width = 710,
                Height = 310,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true
            };

            btnAgregar = new Button() { Text = "Nuevo", Left = 12, Top = 375, Width = 90 };
            btnModificar = new Button() { Text = "Modificar", Left = 110, Top = 375, Width = 90 };
            btnEliminar = new Button() { Text = "Eliminar", Left = 210, Top = 375, Width = 90 };

            btnBuscar.Click += async (s, e) => await LoadClientes(txtBuscar.Text);
            btnAgregar.Click += BtnAgregar_Click;
            btnModificar.Click += BtnModificar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            this.Controls.Add(lblBuscar);
            this.Controls.Add(txtBuscar);
            this.Controls.Add(btnBuscar);
            this.Controls.Add(dgvClientes);
            this.Controls.Add(btnAgregar);
            this.Controls.Add(btnModificar);
            this.Controls.Add(btnEliminar);
        }

        private async Task LoadClientes(string filter = "")
        {
            try
            {
                var clientes = await clienteService.GetAllAsync();
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    clientes = clientes.Where(c => c.Nombre.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                                                   c.Apellido.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                                                   c.Email.Contains(filter, StringComparison.OrdinalIgnoreCase));
                }
                dgvClientes.DataSource = clientes.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnAgregar_Click(object sender, EventArgs e)
        {
            var inputForm = new ClienteDetailForm(clienteService, null);
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                await LoadClientes();
            }
        }

        private async void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                var cliente = (ClienteDTO)dgvClientes.SelectedRows[0].DataBoundItem;
                var inputForm = new ClienteDetailForm(clienteService, cliente);
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    await LoadClientes();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                var cliente = (ClienteDTO)dgvClientes.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show($"¿Eliminar a {cliente.Nombre} {cliente.Apellido}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        await clienteService.DeleteAsync(cliente.Id);
                        await LoadClientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
