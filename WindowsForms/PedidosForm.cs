using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;
using Domain.Model;

namespace WindowsForms
{
    public partial class PedidosForm : Form
    {
        private List<PedidoDTO> _pedidosCache = new();

        private bool _estaCargando = false;

        public PedidosForm()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private async void PedidosForm_Load(object sender, EventArgs e)
        {
            ConfigurarControlesFiltro();
            await LoadPedidos();
        }

        private void ConfigurarColumnas()
        {
            dataGridViewPedidos.AutoGenerateColumns = false;
            AgregarColumna(dataGridViewPedidos, "Id", "Id", 50);
            AgregarColumna(dataGridViewPedidos, "Fecha", "Fecha", 120);
            AgregarColumna(dataGridViewPedidos, "Cliente", "Cliente", 130);
            AgregarColumna(dataGridViewPedidos, "Modalidad", "Modalidad", 90);
            AgregarColumna(dataGridViewPedidos, "Estado", "Estado", 90);
            AgregarColumna(dataGridViewPedidos, "Direccion", "Dirección", 140);
            AgregarColumna(dataGridViewPedidos, "Delivery", "Delivery", 130);
            AgregarColumna(dataGridViewPedidos, "PrecioTotal", "Total", 90);
            AgregarColumna(dataGridViewPedidos, "CalifPedido", "Calif. pedido", 80);
            AgregarColumna(dataGridViewPedidos, "CalifDelivery", "Calif. delivery", 80);
            AgregarColumna(dataGridViewPedidos, "Comentario", "Comentario", 150);
            AgregarColumna(dataGridViewPedidos, "ComentarioFinal", "Comentario final", 150);

            dataGridViewDetalle.AutoGenerateColumns = false;
            AgregarColumna(dataGridViewDetalle, "Hamburguesa", "Hamburguesa", 150);
            AgregarColumna(dataGridViewDetalle, "Cantidad", "Cantidad", 70);
            AgregarColumna(dataGridViewDetalle, "PrecioUnitario", "Precio unitario", 100, "C2");
            AgregarColumna(dataGridViewDetalle, "Subtotal", "Subtotal", 100, "C2");
        }

        private static void AgregarColumna(DataGridView grid, string propiedad, string titulo, int minimo, string? formato = null)
        {
            var columna = new DataGridViewTextBoxColumn
            {
                Name = propiedad,
                HeaderText = titulo,
                DataPropertyName = propiedad,
                MinimumWidth = minimo
            };
            if (formato != null)
                columna.DefaultCellStyle = new DataGridViewCellStyle { Format = formato };
            grid.Columns.Add(columna);
        }

        private void ConfigurarControlesFiltro()
        {
            _estaCargando = true;

            dateTimePickerFiltro.Value = DateTime.Today;

            var opcionesModalidad = new List<string> { "Todos", "TakeAway", "Delivery" };
            comboBoxFiltro.DataSource = opcionesModalidad;
            comboBoxFiltro.SelectedIndex = 0;

            dateTimePickerFiltro.ValueChanged += (s, ev) => AplicarFiltros();
            comboBoxFiltro.SelectedIndexChanged += (s, ev) => AplicarFiltros();

            _estaCargando = false;
        }

        private async Task LoadPedidos()
        {
            try
            {
                _estaCargando = true;

                dateTimePickerFiltro.Enabled = false;
                comboBoxFiltro.Enabled = false;

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
                dateTimePickerFiltro.Enabled = true;
                comboBoxFiltro.Enabled = true;
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
                Id = p.Id,
                Fecha = p.Fecha.ToString("dd/MM/yyyy HH:mm"),
                Cliente = p.ClienteNombre ?? "-",
                Modalidad = p.Modalidad.ToString(),
                Estado = p.Estado.ToString(),
                Direccion = p.Direccion ?? "-",
                Delivery = p.DeliveryNombre ?? "-",
                PrecioTotal = p.PrecioTotal,
                CalifPedido = p.CalificacionPedido,
                CalifDelivery = p.CalificacionDelivery,
                Comentario = p.Comentario ?? "-",
                ComentarioFinal = p.ComentarioFinal ?? "-"
            }).ToList();

            dataGridViewPedidos.DataSource = null;
            dataGridViewPedidos.DataSource = datosParaGrid;
        }

        private void dataGridViewPedidos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPedidos.SelectedRows.Count == 0)
            {
                dataGridViewDetalle.DataSource = null;
                DesactivarBotonera();
                return;
            }

            int idPedido = (int)dataGridViewPedidos.SelectedRows[0].Cells["Id"].Value;
            var pedidoSeleccionado = _pedidosCache.FirstOrDefault(p => p.Id == idPedido);

            if (pedidoSeleccionado != null)
            {
                if (pedidoSeleccionado.DetallesPedido != null)
                {
                    var detallesParaGrid = pedidoSeleccionado.DetallesPedido.Select(d => new
                    {
                        Hamburguesa = d.HamburguesaNombre ?? "Desconocida",
                        Cantidad = d.Cantidad,
                        PrecioUnitario = d.PrecioUnitario,
                        Subtotal = d.Cantidad * d.PrecioUnitario
                    }).ToList();

                    dataGridViewDetalle.DataSource = null;
                    dataGridViewDetalle.DataSource = detallesParaGrid;
                }

                ActualizarBotonera(pedidoSeleccionado);
            }
        }

        private void DesactivarBotonera()
        {
            btnAvanzarEstado.Enabled = false;
            btnAsignarDelivery.Enabled = false;
            btnCancelarPedido.Enabled = false;
            btnAvanzarEstado.Text = "Avanzar Estado";
        }

        private void ActualizarBotonera(PedidoDTO pedido)
        {
            DesactivarBotonera();

            if (pedido.Estado == EstadoPedido.Cancelado || pedido.Estado == EstadoPedido.Entregado)
                return;

            if (pedido.Estado == EstadoPedido.Pendiente)
            {
                btnCancelarPedido.Enabled = true;

                if (pedido.Modalidad == ModalidadPedido.Delivery)
                {
                    btnAsignarDelivery.Enabled = true;
                }
                else
                {
                    btnAvanzarEstado.Enabled = true;
                    btnAvanzarEstado.Text = "Avanzar a: En Proceso";
                    btnAvanzarEstado.Tag = EstadoPedido.EnProceso;
                }
            }
            else if (pedido.Modalidad == ModalidadPedido.TakeAway)
            {
                if (pedido.Estado == EstadoPedido.EnProceso)
                {
                    btnAvanzarEstado.Enabled = true;
                    btnAvanzarEstado.Text = "Avanzar a: Listo";
                    btnAvanzarEstado.Tag = EstadoPedido.Listo;
                }
                else if (pedido.Estado == EstadoPedido.Listo)
                {
                    btnAvanzarEstado.Enabled = true;
                    btnAvanzarEstado.Text = "Entregar al Cliente";
                    btnAvanzarEstado.Tag = EstadoPedido.Entregado;
                }
            }
            else if (pedido.Modalidad == ModalidadPedido.Delivery)
            {
                if (pedido.Estado == EstadoPedido.Asignado)
                {
                    btnAvanzarEstado.Enabled = true;
                    btnAvanzarEstado.Text = "Avanzar a: En Camino";
                    btnAvanzarEstado.Tag = EstadoPedido.EnCamino;
                }
                else if (pedido.Estado == EstadoPedido.EnCamino)
                {
                    btnAvanzarEstado.Enabled = true;
                    btnAvanzarEstado.Text = "Marcar como Entregado";
                    btnAvanzarEstado.Tag = EstadoPedido.Entregado;
                }
            }
        }

        private async void btnAvanzarEstado_Click(object sender, EventArgs e)
        {
            if (dataGridViewPedidos.SelectedRows.Count == 0 || btnAvanzarEstado.Tag == null) return;
            int idPedido = (int)dataGridViewPedidos.SelectedRows[0].Cells["Id"].Value;
            var pedido = _pedidosCache.First(p => p.Id == idPedido);

            EstadoPedido nuevoEstado = (EstadoPedido)btnAvanzarEstado.Tag;

            
            var confirmar = MessageBox.Show(
                $"¿Estás seguro que deseas avanzar el pedido #{pedido.Id} a '{nuevoEstado}'?\n\nATENCIÓN: Esta acción NO se puede deshacer y el pedido no podrá volver a un estado anterior.",
                "Confirmar Avance",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmar != DialogResult.Yes) return; 

            try
            {
                _estaCargando = true;
                pedido.Estado = nuevoEstado;

                await PedidoApiClient.UpdateAsync(pedido);
                await LoadPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al avanzar el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _estaCargando = false;
            }
        }

        private async void btnCancelarPedido_Click(object sender, EventArgs e)
        {
            if (dataGridViewPedidos.SelectedRows.Count == 0) return;
            int idPedido = (int)dataGridViewPedidos.SelectedRows[0].Cells["Id"].Value;
            var pedido = _pedidosCache.First(p => p.Id == idPedido);

            var confirmar = MessageBox.Show($"¿Estás seguro que deseas cancelar el pedido #{pedido.Id}?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmar != DialogResult.Yes) return;

            try
            {
                pedido.Estado = EstadoPedido.Cancelado;
                await PedidoApiClient.UpdateAsync(pedido);
                await LoadPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cancelar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAsignarDelivery_Click(object sender, EventArgs e)
        {
            if (dataGridViewPedidos.SelectedRows.Count == 0) return;
            int idPedido = (int)dataGridViewPedidos.SelectedRows[0].Cells["Id"].Value;
            var pedido = _pedidosCache.First(p => p.Id == idPedido);

            using var formAsignar = new AsignarDeliveryForm(pedido);
            if (formAsignar.ShowDialog(this) == DialogResult.OK)
            {
                await LoadPedidos();
            }
        }
    }
}