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
        private int? _clienteIdFilter = null;
        private bool _esVistaCliente = false;

        public PedidosForm()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        // Constructor para vista enfocada en un cliente (clienteId) y para desactivar opciones de admin
        public PedidosForm(int? clienteId = null, bool esVistaCliente = false) : this()
        {
            _clienteIdFilter = clienteId;
            _esVistaCliente = esVistaCliente;
        }

        private async void PedidosForm_Load(object sender, EventArgs e)
        {
            ConfigurarControlesFiltro();
            btnAvanzarEstado.Visible = !_esVistaCliente;
            btnAsignarDelivery.Visible = !_esVistaCliente;

            if (_esVistaCliente)
            {
                dataGridViewPedidos.Columns["Id"].Visible = false;
                dataGridViewPedidos.Columns["Cliente"].Visible = false;
            }

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

            // Al arrancar destildado (requiere la propiedad ShowCheckBox = true desde el diseñador visual),
            // indicamos que queremos traer absolutamente todos los pedidos históricos sin importar la fecha.
            dateTimePickerFiltro.Checked = false;

            var opcionesModalidad = new List<string> { "Todos", "TakeAway", "Delivery" };
            comboBoxFiltro.DataSource = opcionesModalidad;
            comboBoxFiltro.SelectedIndex = 0;

            // El filtro completo lo resuelve la API. 
            // Cualquier acción del usuario (tildar/destildar el checkbox, cambiar el día o elegir otra modalidad)
            // volverá a consultar automáticamente al servidor.
            dateTimePickerFiltro.ValueChanged += async (s, ev) => { if (!_estaCargando) await LoadPedidos(); };
            comboBoxFiltro.SelectedIndexChanged += async (s, ev) => { if (!_estaCargando) await LoadPedidos(); };

            _estaCargando = false;
        }

        private async Task LoadPedidos()
        {
            try
            {
                // Leemos los filtros antes de bloquear la interfaz.
                // Si el control está tildado, mandamos la fecha específica. Si está destildado, mandamos null.
                DateTime? fechaSeleccionada = dateTimePickerFiltro.Checked ? dateTimePickerFiltro.Value.Date : null;

                // Si la modalidad es "Todos", mandamos null para que la API no filtre por este campo.
                string modalidadSeleccionada = comboBoxFiltro.SelectedItem?.ToString() ?? "Todos";
                ModalidadPedido? modalidad = modalidadSeleccionada == "Todos"
                    ? null
                    : Enum.Parse<ModalidadPedido>(modalidadSeleccionada);

                _estaCargando = true;

                // Bloqueamos los controles temporalmente para evitar que el usuario haga múltiples cambios 
                // rápidos y sature la API de peticiones simultáneas.
                dateTimePickerFiltro.Enabled = false;
                comboBoxFiltro.Enabled = false;

                // Consultamos al servidor. Si tenemos un cliente específico, pedimos sólo sus pedidos.
                if (_clienteIdFilter.HasValue)
                {
                    var resultado = await PedidoApiClient.GetByClienteIdAsync(_clienteIdFilter.Value);
                    _pedidosCache = resultado?.ToList() ?? new List<PedidoDTO>();
                }
                else
                {
                    // Ya no filtramos en memoria con .Where(); la API nos devuelve la lista exacta y lista para mostrar.
                    var resultado = await PedidoApiClient.GetByFiltroAsync(fechaSeleccionada, modalidad);
                    _pedidosCache = resultado?.ToList() ?? new List<PedidoDTO>();
                }

                _estaCargando = false;
                MostrarPedidos(); // Solo mapea y proyecta los datos ya filtrados en la grilla
            }
            catch (Exception ex)
            {
                _estaCargando = false;
                MessageBox.Show($"Error al cargar los pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Volvemos a habilitar la botonera de filtros, haya salido bien o mal la consulta
                dateTimePickerFiltro.Enabled = true;
                comboBoxFiltro.Enabled = true;
            }
        }

        // Muestra en el grid los pedidos que devolvió el servidor (el filtro lo hace la API)
        private void MostrarPedidos()
        {
            var datosParaGrid = _pedidosCache.Select(p => new
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
            btnModificarPedido.Enabled = false;
            // Si esta vista es para cliente, ocultamos botones administrativos
            if (_esVistaCliente)
            {
                btnAvanzarEstado.Visible = false;
                btnAsignarDelivery.Visible = false;
            }
            else
            {
                btnAvanzarEstado.Visible = true;
                btnAsignarDelivery.Visible = true;
            }
        }

        private void ActualizarBotonera(PedidoDTO pedido)
        {
            DesactivarBotonera();

            if (pedido.Estado == EstadoPedido.Cancelado || pedido.Estado == EstadoPedido.Entregado)
                return;

            if (pedido.Estado == EstadoPedido.Pendiente)
            {
                btnCancelarPedido.Enabled = true;
                btnModificarPedido.Enabled = true;

                if (_esVistaCliente)
                {
                    // Clientes pueden cancelar/modificar solo si está pendiente, pero no otras acciones
                    btnAsignarDelivery.Enabled = false;
                    btnAvanzarEstado.Enabled = false;
                }

                if (pedido.Modalidad == ModalidadPedido.Delivery)
                {
                    btnAsignarDelivery.Enabled = true;
                    btnAsignarDelivery.Text = "Asignar Delivery"; // Lo forzamos por si había cambiado
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

                   
                    btnAsignarDelivery.Enabled = true;
                    btnAsignarDelivery.Text = "Cambiar Delivery";
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
            if (_esVistaCliente) return; // no permitir en vista cliente
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

            if (_esVistaCliente && pedido.Estado != EstadoPedido.Pendiente)
            {
                MessageBox.Show("Solo se pueden cancelar pedidos en estado Pendiente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            if (_esVistaCliente) return; // no permitir asignar delivery en vista cliente
            if (dataGridViewPedidos.SelectedRows.Count == 0) return;
            int idPedido = (int)dataGridViewPedidos.SelectedRows[0].Cells["Id"].Value;
            var pedido = _pedidosCache.First(p => p.Id == idPedido);

            using var formAsignar = new AsignarDeliveryForm(pedido);
            if (formAsignar.ShowDialog(this) == DialogResult.OK)
            {
                await LoadPedidos();
            }
        }
        private async void btnNuevoPedido_Click(object sender, EventArgs e)
        {
            // Si estamos en vista de cliente, preseleccionamos y bloqueamos el cliente
            using var form = _clienteIdFilter.HasValue ? new AgregarEditarPedidoForm(_clienteIdFilter.Value) : new AgregarEditarPedidoForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadPedidos();
            }
        }

        private async void btnModificarPedido_Click(object sender, EventArgs e)
        {
            if (dataGridViewPedidos.SelectedRows.Count == 0) return;

            int idPedido = (int)dataGridViewPedidos.SelectedRows[0].Cells["Id"].Value;

            var pedidoSeleccionado = _pedidosCache.FirstOrDefault(p => p.Id == idPedido);

            if (pedidoSeleccionado == null) return;

            if (pedidoSeleccionado.Estado != EstadoPedido.Pendiente)
            {
                MessageBox.Show("Solo se pueden modificar pedidos en estado Pendiente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si es vista cliente, abrimos el formulario en modo cliente para bloquear cambios de cliente y opciones admin
            if (_esVistaCliente)
            {
                using var form = new AgregarEditarPedidoForm(pedidoSeleccionado, true);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadPedidos();
                }
            }
            else
            {
                using var form = new AgregarEditarPedidoForm(pedidoSeleccionado);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadPedidos();
                }
            }
        }
    }
}