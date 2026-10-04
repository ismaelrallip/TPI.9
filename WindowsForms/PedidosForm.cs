using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace WindowsForms
{
    public partial class PedidosForm : Form
    {
        private List<PedidoDTO> _pedidosCache = new();

        // var para bloqueo de controles
        private bool _estaCargando = false;

        public PedidosForm()
        {
            InitializeComponent();
        }

        private async void PedidosForm_Load(object sender, EventArgs e)
        {
            ConfigurarControlesFiltro();
            await LoadPedidos();
        }

        private void ConfigurarControlesFiltro()
        {
            _estaCargando = true;

            dateTimePickerFiltro.Value = DateTime.Today;

            // Valores de modalidad conocidos definidos directamente en el front para no importar el dominio
            var opcionesModalidad = new List<string> { "Todos", "TakeAway", "Delivery" };

            comboBoxFiltro.DataSource = opcionesModalidad;
            comboBoxFiltro.SelectedIndex = 0;

            // Suscripcion a eventos: DISPARA AplicarFiltros() cuando se disparan los eventos ValueChanged o SelectedIndexChanged

            dateTimePickerFiltro.ValueChanged += (s, ev) => AplicarFiltros();
            comboBoxFiltro.SelectedIndexChanged += (s, ev) => AplicarFiltros();

            _estaCargando = false;
        }

        private async Task LoadPedidos()
        {
            try
            {
                //--bloqueo de controles--------------
                _estaCargando = true;

                buttonUpdatePedido.Enabled = false;
                buttonVerPedido.Enabled = false;
                dateTimePickerFiltro.Enabled = false;
                comboBoxFiltro.Enabled = false;
                // ---------------------------------

                var resultado = await PedidoApiClient.GetAllAsync();
                _pedidosCache = resultado?.ToList() ?? new List<PedidoDTO>();

                _estaCargando = false;
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                _estaCargando = false;
                MessageBox.Show($"Error al cargar los pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //--desbloqueo de controles--------------
                dateTimePickerFiltro.Enabled = true;
                comboBoxFiltro.Enabled = true;
                //---------------------------------------
            }
        }

        private void AplicarFiltros()
        {
            if (_estaCargando || _pedidosCache == null) return;

            DateTime fechaSeleccionada = dateTimePickerFiltro.Value.Date;
            string modalidadSeleccionada = comboBoxFiltro.SelectedItem?.ToString() ?? "Todos";

            var pedidosFiltrados = _pedidosCache.Where(p =>
            {
                bool coincideFecha = p.Fecha.Date == fechaSeleccionada;
                bool coincideModalidad = modalidadSeleccionada == "Todos" || p.Modalidad.ToString() == modalidadSeleccionada;

                return coincideFecha && coincideModalidad;
            });

            var datosParaGrid = pedidosFiltrados.Select(p => new
            {
                p.Id,
                Fecha = p.Fecha.ToString("dd/MM/yyyy HH:mm"),
                Modalidad = p.Modalidad.ToString(),
                Estado = p.Estado.ToString(),
                PrecioTotal = p.PrecioTotal.ToString("C2")
            }).ToList();

            dataGridViewPedidos.DataSource = null;
            dataGridViewPedidos.DataSource = datosParaGrid;

            //--desbloqueo de controles VERPEDIDO y MODIFICAR-----
            bool hayFilas = datosParaGrid.Count > 0;
            buttonUpdatePedido.Enabled = hayFilas;
            buttonVerPedido.Enabled = hayFilas;
            //--------------------------------------------
        }
    }
}