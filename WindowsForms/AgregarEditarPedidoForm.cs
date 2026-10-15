using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;
using Domain.Model;

namespace WindowsForms
{
    public partial class AgregarEditarPedidoForm : Form
    {
        private PedidoDTO _pedidoActual;
        private bool _esEdicion;
        private BindingList<DetallePedidoDTO> _detallesBinding;
        private decimal _precioDeliveryActual = 0;

        //  Constructor para ALTA (Nuevo Pedido)
        public AgregarEditarPedidoForm()
        {
            InitializeComponent();
            ConfigurarColumnasGrilla();

            _esEdicion = false;
            _pedidoActual = new PedidoDTO
            {
                Fecha = DateTime.Now,
                Estado = EstadoPedido.Pendiente
            };

            _detallesBinding = new BindingList<DetallePedidoDTO>();
            this.Text = "Nuevo Pedido";
        }

        // Constructor para MODIFICACIÓN (Editar Pedido existente)
        public AgregarEditarPedidoForm(PedidoDTO pedidoAEditar) : this()
        {
            _esEdicion = true;
            _pedidoActual = pedidoAEditar;

            if (_pedidoActual.DetallesPedido != null)
            {
                foreach (var det in _pedidoActual.DetallesPedido)
                {
                    _detallesBinding.Add(det);
                }
            }
            this.Text = $"Modificar Pedido #{_pedidoActual.Id}";
        }

        private void ConfigurarColumnasGrilla()
        {
            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HamburguesaNombre", HeaderText = "Hamburguesa", Width = 160 });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PrecioUnitario", HeaderText = "Precio Unit.", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = "Cant.", Width = 60 });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { Name = "SubtotalCol", HeaderText = "Subtotal", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });

            dgvDetalles.CellFormatting += DgvDetalles_CellFormatting;
        }

        private async void AgregarEditarPedidoForm_Load(object sender, EventArgs e)
        {
            try
            {
                btnGuardar.Enabled = false;

                cmbCliente.SelectedIndex = -1;
                cmbModalidad.SelectedIndex = -1; 

                var clientes = await ClienteApiClient.GetAllAsync();
                cmbCliente.DataSource = clientes.Select(c => new
                {
                    Id = c.Id,
                    NombreCompleto = $"{c.Nombre} {c.Apellido}"
                }).ToList();
                cmbCliente.DisplayMember = "NombreCompleto";
                cmbCliente.ValueMember = "Id";

                
                var hamburguesas = await HamburguesaApiClient.GetAllAsync();
                cmbHamburguesa.DataSource = hamburguesas.ToList();
                cmbHamburguesa.DisplayMember = "Nombre";
                cmbHamburguesa.ValueMember = "Id";
                cmbHamburguesa.SelectedIndex = -1;

                
                cmbModalidad.DataSource = Enum.GetValues(typeof(ModalidadPedido));

                
                var preciosDel = await PrecioDeliveryApiClient.GetByCriteriaAsync(null);
                _precioDeliveryActual = preciosDel.OrderByDescending(p => p.FechaDesde).FirstOrDefault()?.Monto ?? 0;

                dgvDetalles.DataSource = _detallesBinding;

                
                if (_esEdicion)
                {
                    
                    lblFechaValor.Text = _pedidoActual.Fecha.ToString("dd/MM/yyyy HH:mm");
                    cmbCliente.SelectedValue = _pedidoActual.ClienteId;
                    cmbModalidad.SelectedItem = _pedidoActual.Modalidad;
                    txtDireccion.Text = _pedidoActual.Modalidad == ModalidadPedido.TakeAway ? "" : _pedidoActual.Direccion;
                    txtComentario.Text = _pedidoActual.Comentario;
                }
                
                if (_esEdicion)
                {
                    lblFechaValor.Text = _pedidoActual.Fecha.ToString("dd/MM/yyyy HH:mm");
                    cmbCliente.SelectedValue = _pedidoActual.ClienteId;
                    cmbModalidad.SelectedItem = _pedidoActual.Modalidad;
                    txtDireccion.Text = _pedidoActual.Modalidad == ModalidadPedido.TakeAway ? "" : _pedidoActual.Direccion;
                    txtComentario.Text = _pedidoActual.Comentario;
                }
                else
                {
                    lblFechaValor.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }

               
                if (!_esEdicion)
                {
                    cmbCliente.SelectedIndex = -1;
                    cmbModalidad.SelectedIndex = -1;
                }

                RecalcularTotal();
                btnGuardar.Enabled = true;
                RecalcularTotal();
                btnGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
       

        private void cmbModalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbModalidad.SelectedItem == null) return;

            ModalidadPedido modalidad = (ModalidadPedido)cmbModalidad.SelectedItem;

            if (modalidad == ModalidadPedido.Delivery)
            {
                txtDireccion.Enabled = true;
            }
            else
            {
                txtDireccion.Enabled = false;
                txtDireccion.Clear();
            }

            RecalcularTotal();
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbModalidad.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar la modalidad del pedido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_detallesBinding.Count == 0)
            {
                MessageBox.Show("El pedido debe tener al menos una hamburguesa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ModalidadPedido modalidad = (ModalidadPedido)cmbModalidad.SelectedItem;
            if (modalidad == ModalidadPedido.Delivery && string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Para pedidos con Delivery, la dirección es obligatoria.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _pedidoActual.ClienteId = (int)cmbCliente.SelectedValue;
            _pedidoActual.Modalidad = modalidad;

            if (modalidad == ModalidadPedido.Delivery)
            {
                _pedidoActual.Direccion = txtDireccion.Text.Trim();
            }
            else
            {
                // Take Away: sin dirección y sin delivery
                _pedidoActual.Direccion = null;
                _pedidoActual.DeliveryId = null;
                _pedidoActual.DeliveryNombre = null;
            }
            _pedidoActual.Comentario = string.IsNullOrWhiteSpace(txtComentario.Text) ? null : txtComentario.Text.Trim();
            _pedidoActual.DetallesPedido = _detallesBinding.ToList();

            try
            {
                btnGuardar.Enabled = false;

                if (_esEdicion)
                {
                    await PedidoApiClient.UpdateAsync(_pedidoActual);
                }
                else
                {
                    await PedidoApiClient.AddAsync(_pedidoActual);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el pedido: {ex.Message}", "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGuardar.Enabled = true;
            }
        }

        private void btnAgregarLinea_Click(object sender, EventArgs e)
        {
            if (cmbHamburguesa.SelectedItem == null) return;

            var hamburguesaSel = (HamburguesaDTO)cmbHamburguesa.SelectedItem;
            int cantidad = (int)numCantidad.Value;

            // Buscamos el precio vigente para la fecha en la que se creó este pedido
            var precioVigente = hamburguesaSel.Precios
                .Where(p => p.FechaDesde <= _pedidoActual.Fecha)
                .OrderByDescending(p => p.FechaDesde)
                .FirstOrDefault();

            if (precioVigente == null)
            {
                MessageBox.Show($"La hamburguesa {hamburguesaSel.Nombre} no tiene un precio vigente configurado para la fecha del pedido.", "Error de Precio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal precioUnitarioActual = precioVigente.Monto;
            

            var lineaExistente = _detallesBinding.FirstOrDefault(d => d.HamburguesaId == hamburguesaSel.Id);

            if (lineaExistente != null)
            {
                lineaExistente.Cantidad += cantidad;
                _detallesBinding.ResetBindings();
            }
            else
            {
                _detallesBinding.Add(new DetallePedidoDTO
                {
                    HamburguesaId = hamburguesaSel.Id,
                    HamburguesaNombre = hamburguesaSel.Nombre,
                    PrecioUnitario = precioUnitarioActual,
                    Cantidad = cantidad
                });
            }

            numCantidad.Value = 1;
            RecalcularTotal();
        }

        private void btnModificarLinea_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una línea de la grilla para modificar su cantidad.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var detalleSel = (DetallePedidoDTO)dgvDetalles.SelectedRows[0].DataBoundItem;

            using var formModificar = new ModificarCantidadForm(detalleSel.HamburguesaNombre, detalleSel.PrecioUnitario, detalleSel.Cantidad);

            if (formModificar.ShowDialog(this) == DialogResult.OK)
            {
                detalleSel.Cantidad = formModificar.CantidadSeleccionada;
                _detallesBinding.ResetBindings();
                RecalcularTotal();
            }
        }

        private void btnEliminarLinea_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.SelectedRows.Count > 0)
            {
                var detalleSel = (DetallePedidoDTO)dgvDetalles.SelectedRows[0].DataBoundItem;
                _detallesBinding.Remove(detalleSel);
                RecalcularTotal();
            }
        }

        private void RecalcularTotal()
        {
            decimal totalLineas = _detallesBinding.Sum(d => d.Cantidad * d.PrecioUnitario);

            if (cmbModalidad.SelectedItem != null && (ModalidadPedido)cmbModalidad.SelectedItem == ModalidadPedido.Delivery)
            {
                totalLineas += _precioDeliveryActual;
            }

            lblTotalValor.Text = totalLineas.ToString("C2");
            _pedidoActual.PrecioTotal = totalLineas;
        }

        private void DgvDetalles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDetalles.Columns[e.ColumnIndex].Name == "SubtotalCol")
            {
                var detalle = (DetallePedidoDTO)dgvDetalles.Rows[e.RowIndex].DataBoundItem;
                if (detalle != null)
                {
                    e.Value = detalle.Cantidad * detalle.PrecioUnitario;
                }
            }
        }

       
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}