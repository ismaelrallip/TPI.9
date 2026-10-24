
using API.Clients;
using DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class ReporteDelivery : Form
    {
        private DeliveryDTO? _deliverySeleccionado;

        private bool _cargandoDeliveries;
        private bool _operacionEnCurso;
        private bool _historialCargado;

        // Elemento que se muestra en el ComboBox.
        private sealed class DeliveryComboItem
        {
            public DeliveryDTO Delivery { get; }

            public string NombreCompleto =>
                $"{Delivery.Nombre} {Delivery.Apellido} (ID: {Delivery.IdDelivery})";

            public DeliveryComboItem(DeliveryDTO delivery)
            {
                Delivery = delivery;
            }
        }

        public ReporteDelivery()
        {
            InitializeComponent();

            deliveriesDataGridView.AutoGenerateColumns = false;
            deliveriesDataGridView.ReadOnly = true;
            deliveriesDataGridView.AllowUserToAddRows = false;
            deliveriesDataGridView.AllowUserToDeleteRows = false;
            deliveriesDataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            deliveriesDataGridView.MultiSelect = false;

            deliveryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            ConfigurarColumnas();

            // Evitar registrar dos veces los mismos eventos.
            desdeDatePicker.ValueChanged -= desdeDatePicker_ValueChanged;
            desdeDatePicker.ValueChanged += desdeDatePicker_ValueChanged;

            hastaDatePicker.ValueChanged -= hastaDatePicker_ValueChanged;
            hastaDatePicker.ValueChanged += hastaDatePicker_ValueChanged;

            deliveryComboBox.SelectedIndexChanged -=
                deliveryComboBox_SelectedIndexChanged;
            deliveryComboBox.SelectedIndexChanged +=
                deliveryComboBox_SelectedIndexChanged;

            Load += ReporteDelivery_Load;

            downloadButton.Enabled = false;
        }

        // ------------------------------------------------------------
        // Configuración del DataGridView
        // ------------------------------------------------------------

        private void ConfigurarColumnas()
        {
            deliveriesDataGridView.Columns.Clear();

            deliveriesDataGridView.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "PedidoId",
                    HeaderText = "PedidoId",
                    DataPropertyName = "PedidoId",
                    Width = 85
                });

            deliveriesDataGridView.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Fecha",
                    HeaderText = "Fecha",
                    DataPropertyName = "Fecha",
                    Width = 140,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "dd/MM/yyyy HH:mm"
                    }
                });

            deliveriesDataGridView.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Cliente",
                    HeaderText = "Cliente",
                    DataPropertyName = "Cliente",
                    Width = 180
                });

            deliveriesDataGridView.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Direccion",
                    HeaderText = "Dirección",
                    DataPropertyName = "Direccion",
                    Width = 200
                });

            deliveriesDataGridView.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Estado",
                    HeaderText = "Estado",
                    DataPropertyName = "Estado",
                    Width = 110
                });

            deliveriesDataGridView.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "CalificacionDelivery",
                    HeaderText = "Calificación",
                    DataPropertyName = "CalificacionDelivery",
                    Width = 100
                });

            deliveriesDataGridView.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "PrecioTotal",
                    HeaderText = "Total",
                    DataPropertyName = "PrecioTotal",
                    Width = 110,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2"
                    }
                });
        }

        // ------------------------------------------------------------
        // Carga inicial de deliveries
        // ------------------------------------------------------------

        private async void ReporteDelivery_Load(object? sender, EventArgs e)
        {
            await CargarDeliveriesAsync();
        }

        private async Task CargarDeliveriesAsync()
        {
            try
            {
                _cargandoDeliveries = true;
                _operacionEnCurso = true;

                SetControlesHabilitados(false);

                deliveryComboBox.DataSource = null;
                deliveryComboBox.Items.Clear();

                var deliveries = (await DeliveryApiClient.GetAllAsync())
                    .OrderBy(d => d.Apellido)
                    .ThenBy(d => d.Nombre)
                    .Select(d => new DeliveryComboItem(d))
                    .ToList();

                deliveryComboBox.DisplayMember =
                    nameof(DeliveryComboItem.NombreCompleto);

                deliveryComboBox.DataSource = deliveries;
                deliveryComboBox.SelectedIndex = -1;

                _deliverySeleccionado = null;
                _historialCargado = false;
                deliveriesDataGridView.DataSource = null;

                if (deliveries.Count == 0)
                {
                    MessageBox.Show(
                        "No hay deliveries registrados.",
                        "Deliveries",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los deliveries: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _cargandoDeliveries = false;
                _operacionEnCurso = false;

                SetControlesHabilitados(true);
            }
        }

        // ------------------------------------------------------------
        // Selección del delivery
        // ------------------------------------------------------------

        private async void deliveryComboBox_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (_cargandoDeliveries || _operacionEnCurso)
                return;

            if (deliveryComboBox.SelectedItem is not DeliveryComboItem item)
            {
                LimpiarResultados();
                return;
            }

            _deliverySeleccionado = item.Delivery;
            _historialCargado = false;
            deliveriesDataGridView.DataSource = null;

            await RecargarSiCorrespondeAsync();
        }

        // ------------------------------------------------------------
        // Consulta del historial desde el backend
        // ------------------------------------------------------------

        private async Task CargarPedidosAsync()
        {
            if (_deliverySeleccionado == null)
                return;

            DateTime desde = desdeDatePicker.Value.Date;
            DateTime hasta = hastaDatePicker.Value.Date;

            if (desde > hasta)
            {
                _historialCargado = false;
                deliveriesDataGridView.DataSource = null;
                return;
            }

            var historial = await DeliveryApiClient.ObtenerHistorialAsync(
                _deliverySeleccionado.IdDelivery,
                desde,
                hasta);

            deliveriesDataGridView.DataSource = null;
            deliveriesDataGridView.DataSource = historial.Pedidos;

            _historialCargado = true;
        }

        // ------------------------------------------------------------
        // Cambios de fechas
        // ------------------------------------------------------------

        private async void desdeDatePicker_ValueChanged(
            object sender, EventArgs e)
        {
            await RecargarSiCorrespondeAsync();
        }

        private async void hastaDatePicker_ValueChanged(
            object sender, EventArgs e)
        {
            await RecargarSiCorrespondeAsync();
        }

        private async Task RecargarSiCorrespondeAsync()
        {
            if (_deliverySeleccionado == null || _operacionEnCurso)
                return;

            if (desdeDatePicker.Value.Date > hastaDatePicker.Value.Date)
            {
                _historialCargado = false;
                deliveriesDataGridView.DataSource = null;

                SetControlesHabilitados(true);
                return;
            }

            try
            {
                _operacionEnCurso = true;
                _historialCargado = false;

                SetControlesHabilitados(false);

                await CargarPedidosAsync();
            }
            catch (Exception ex)
            {
                _historialCargado = false;
                deliveriesDataGridView.DataSource = null;

                MessageBox.Show(
                    $"Error al actualizar los pedidos: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _operacionEnCurso = false;
                SetControlesHabilitados(true);
            }
        }

        // ------------------------------------------------------------
        // Descarga del reporte PDF
        // ------------------------------------------------------------

        private async void downloadButton_Click(object sender, EventArgs e)
        {
            if (_deliverySeleccionado == null || !_historialCargado)
            {
                MessageBox.Show(
                    "Seleccioná un delivery y esperá a que se cargue su historial.",
                    "Reporte",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            DateTime desde = desdeDatePicker.Value.Date;
            DateTime hasta = hastaDatePicker.Value.Date;

            if (desde > hasta)
            {
                MessageBox.Show(
                    "La fecha desde no puede ser posterior a la fecha hasta.",
                    "Fechas inválidas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using var dialog = new SaveFileDialog
            {
                Title = "Guardar reporte de delivery",
                Filter = "Archivo PDF (*.pdf)|*.pdf",
                FileName =
                    $"reporte-delivery-{_deliverySeleccionado.IdDelivery}-" +
                    $"{DateTime.Now:yyyyMMdd-HHmm}.pdf",
                DefaultExt = "pdf",
                AddExtension = true
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                _operacionEnCurso = true;
                SetControlesHabilitados(false);

                byte[] pdf =
                    await DeliveryApiClient.DescargarReporteDeliveryPdfAsync(
                        _deliverySeleccionado.IdDelivery,
                        desde,
                        hasta);

                await File.WriteAllBytesAsync(
                    dialog.FileName, pdf);

                MessageBox.Show(
                    "El reporte se descargó correctamente.",
                    "Reporte generado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al descargar el reporte: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _operacionEnCurso = false;
                SetControlesHabilitados(true);
            }
        }

        // ------------------------------------------------------------
        // Limpieza y habilitación de controles
        // ------------------------------------------------------------

        private void LimpiarResultados()
        {
            _deliverySeleccionado = null;
            _historialCargado = false;

            deliveriesDataGridView.DataSource = null;

            SetControlesHabilitados(true);
        }

        private void SetControlesHabilitados(bool habilitado)
        {
            deliveryComboBox.Enabled = habilitado;
            desdeDatePicker.Enabled = habilitado;
            hastaDatePicker.Enabled = habilitado;

            downloadButton.Enabled =
                habilitado &&
                _deliverySeleccionado != null &&
                _historialCargado &&
                desdeDatePicker.Value.Date <= hastaDatePicker.Value.Date;
        }
    }
}
