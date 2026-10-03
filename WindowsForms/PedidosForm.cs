using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace WindowsForms
{
    public partial class PedidosForm : Form
    {
        private IEnumerable<PedidoDTO> pedidos;
        public PedidosForm()
        {
            InitializeComponent();
        }

        private void PedidosForm_Load(object sender, EventArgs e)
        {
            buttonUpdatePedido.Enabled = false;
            dateTimePickerFiltro.Value = DateTime.Now;

            LoadPedidos();
        }


        // REVISAR SI CARGA LOS PEDIDOS
        private async Task LoadPedidos()
        {
            try
            {
                buttonUpdatePedido.Enabled = false;
                buttonVerPedido.Enabled = false;

                pedidos = await PedidoApiClient.GetAllAsync();
                var datosParaGrid = pedidos.Select(p =>
                {
                    return new
                    {
                        p.Id,
                        p.Fecha,
                        p.Modalidad,
                        p.Estado,
                        p.PrecioTotal
                    };
                }).ToList();


                dataGridViewPedidos.DataSource = null;
                dataGridViewPedidos.DataSource = datosParaGrid;

                comboBoxFiltro.DataSource = pedidos.Select(p => p.Modalidad.ToString()).Distinct().ToList();
                comboBoxFiltro.Items.Insert(0, "Todos");
                comboBoxFiltro.SelectedIndex = 0;

                buttonUpdatePedido.Enabled = true;
                buttonVerPedido.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
