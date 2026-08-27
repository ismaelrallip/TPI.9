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
    public partial class ClienteLista : Form
    {
        public ClienteLista()
        {
            InitializeComponent();
            clientesDataGridView.AutoGenerateColumns = false;
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            clientesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", DataPropertyName = "Id", Width = 60 });
            clientesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Nombre", DataPropertyName = "Nombre", Width = 150 });
            clientesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Apellido", HeaderText = "Apellido", DataPropertyName = "Apellido", Width = 150 });
            clientesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", DataPropertyName = "Email", Width = 240 });
            clientesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefono", HeaderText = "Teléfono", DataPropertyName = "Telefono", Width = 140 });
        }

        private async void ClienteLista_Load(object sender, EventArgs e)
        {
            await CargarClientesAsync();
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            using var detalle = new ClienteDetalle(FormMode.Add, new ClienteDTO());
            if (detalle.ShowDialog(this) == DialogResult.OK)
            {
                await CargarClientesAsync();
            }
        }

        private async void actualizarButton_Click(object sender, EventArgs e)
        {
            var seleccionado = ClienteSeleccionado();
            if (seleccionado == null) return;

            try
            {
                DeshabilitarControles();
                var cliente = await ClienteApiClient.GetAsync(seleccionado.Id);
                using var detalle = new ClienteDetalle(FormMode.Update, cliente);
                if (detalle.ShowDialog(this) == DialogResult.OK)
                {
                    await CargarClientesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            var seleccionado = ClienteSeleccionado();
            if (seleccionado == null) return;

            var confirmar = MessageBox.Show($"¿Eliminar a {seleccionado.Nombre} {seleccionado.Apellido}?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            try
            {
                DeshabilitarControles();
                await ClienteApiClient.DeleteAsync(seleccionado.Id);
                await CargarClientesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void buscarButton_Click(object sender, EventArgs e)
        {
            await CargarClientesAsync(buscarTextBox.Text.Trim());
        }

        private async Task CargarClientesAsync(string texto = "")
        {
            try
            {
                DeshabilitarControles();

                IEnumerable<ClienteDTO> clientes = string.IsNullOrWhiteSpace(texto)
                    ? await ClienteApiClient.GetAllAsync()
                    : await ClienteApiClient.GetByCriteriaAsync(texto);

                clientesDataGridView.DataSource = clientes.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private ClienteDTO? ClienteSeleccionado() =>
            clientesDataGridView.SelectedRows.Count == 0 ? null : (ClienteDTO)clientesDataGridView.SelectedRows[0].DataBoundItem;

        private void clientesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var haySeleccion = ClienteSeleccionado() != null;
            actualizarButton.Enabled = haySeleccion;
            eliminarButton.Enabled = haySeleccion;
        }

        private void DeshabilitarControles()
        {
            buscarButton.Enabled = false;
            agregarButton.Enabled = false;
            actualizarButton.Enabled = false;
            eliminarButton.Enabled = false;
            clientesDataGridView.Enabled = false;
        }

        private void HabilitarControles()
        {
            buscarButton.Enabled = true;
            agregarButton.Enabled = true;
            clientesDataGridView.Enabled = true;
            var haySeleccion = ClienteSeleccionado() != null;
            actualizarButton.Enabled = haySeleccion;
            eliminarButton.Enabled = haySeleccion;
        }
    }
}