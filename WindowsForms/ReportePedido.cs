using API.Clients;
using Domain.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsForms
{
    public partial class ReportePedido : Form
    {
        private bool inicializando;
        private bool cargandoPedidos;

        public ReportePedido()
        {
            InitializeComponent();
            Load += ReportePedido_Load;
        }

        private async void ReportePedido_Load(object sender, EventArgs e)
        {
            inicializando = true;

            ConfigurarFechas();
            ConfigurarCombos();
            ConfigurarGrilla();

            inicializando = false;

            await CargarPedidosAsync();
        }

        private void ConfigurarFechas()
        {
            foreach (DateTimePicker picker in new[]
            {
                desdeDatePicker,
                hastaDatePicker
            })
            {
                picker.Format = DateTimePickerFormat.Custom;
                picker.CustomFormat = "dd/MM/yyyy";
                picker.ShowCheckBox = true;
                picker.Checked = false;
            }
        }

        private void ConfigurarCombos()
        {
            modalidadComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            estadoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            modalidadComboBox.Items.Clear();
            estadoComboBox.Items.Clear();

            modalidadComboBox.Items.Add("Todos");
            foreach (ModalidadPedido modalidad in
                     Enum.GetValues(typeof(ModalidadPedido)))
            {
                modalidadComboBox.Items.Add(modalidad);
            }

            estadoComboBox.Items.Add("Todos");
            foreach (EstadoPedido estado in
                     Enum.GetValues(typeof(EstadoPedido)))
            {
                estadoComboBox.Items.Add(estado);
            }

            modalidadComboBox.SelectedIndex = 0;
            estadoComboBox.SelectedIndex = 0;
        }

        private void ConfigurarGrilla()
        {
            dataGridViewPedidos.AutoGenerateColumns = true;
            dataGridViewPedidos.ReadOnly = true;
            dataGridViewPedidos.AllowUserToAddRows = false;
            dataGridViewPedidos.AllowUserToDeleteRows = false;
            dataGridViewPedidos.MultiSelect = false;
            dataGridViewPedidos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPedidos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async Task CargarPedidosAsync()
        {
            if (inicializando || cargandoPedidos)
                return;

            DateTime? desde = desdeDatePicker.Checked
                ? desdeDatePicker.Value.Date
                : null;

            DateTime? hasta = hastaDatePicker.Checked
                ? hastaDatePicker.Value.Date
                : null;

            if (desde.HasValue && hasta.HasValue &&
                desde.Value > hasta.Value)
            {
                MessageBox.Show(
                    "La fecha desde no puede ser posterior a la fecha hasta.",
                    "Fechas inválidas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            ModalidadPedido? modalidad =
                modalidadComboBox.SelectedItem is ModalidadPedido m
                    ? m
                    : null;

            EstadoPedido? estado =
                estadoComboBox.SelectedItem is EstadoPedido e
                    ? e
                    : null;

            try
            {
                cargandoPedidos = true;
                ConfigurarControles(false);

                var pedidos = await PedidoApiClient.GetByFiltroAsync(
                    desde, hasta, modalidad, estado);

                // El backend aplica los filtros.
                // En el formulario solo se ordenan los resultados.
                dataGridViewPedidos.DataSource = pedidos
                    .OrderByDescending(p => p.Fecha)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los pedidos: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                cargandoPedidos = false;
                ConfigurarControles(true);
            }
        }

        private void ConfigurarControles(bool habilitados)
        {
            desdeDatePicker.Enabled = habilitados;
            hastaDatePicker.Enabled = habilitados;
            modalidadComboBox.Enabled = habilitados;
            estadoComboBox.Enabled = habilitados;
            traerTodosButton.Enabled = habilitados;
            DownloadButton.Enabled = habilitados;
        }

        private async void desdeDatePicker_ValueChanged(
            object sender, EventArgs e)
        {
            await CargarPedidosAsync();
        }

        private async void hastaDatePicker_ValueChanged(
            object sender, EventArgs e)
        {
            await CargarPedidosAsync();
        }

        private async void modalidadComboBox_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            await CargarPedidosAsync();
        }

        private async void estadoComboBox_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            await CargarPedidosAsync();
        }

        private async void traerTodosButton_Click(
            object sender, EventArgs e)
        {
            inicializando = true;

            desdeDatePicker.Checked = false;
            hastaDatePicker.Checked = false;
            modalidadComboBox.SelectedIndex = 0;
            estadoComboBox.SelectedIndex = 0;

            inicializando = false;

            await CargarPedidosAsync();
        }

        private async void DownloadButton_Click(
            object sender, EventArgs e)
        {
            DateTime? desde = desdeDatePicker.Checked
                ? desdeDatePicker.Value.Date
                : null;

            DateTime? hasta = hastaDatePicker.Checked
                ? hastaDatePicker.Value.Date
                : null;

            if (desde.HasValue && hasta.HasValue &&
                desde.Value > hasta.Value)
            {
                MessageBox.Show(
                    "La fecha desde no puede ser posterior a la fecha hasta.",
                    "Fechas inválidas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            ModalidadPedido? modalidad =
                modalidadComboBox.SelectedItem is ModalidadPedido m
                    ? m
                    : null;

            EstadoPedido? estado =
                estadoComboBox.SelectedItem is EstadoPedido ep
                    ? ep
                    : null;

            using var dialog = new SaveFileDialog
            {
                Title = "Guardar reporte de pedidos",
                Filter = "Archivo PDF (*.pdf)|*.pdf",
                DefaultExt = "pdf",
                AddExtension = true,
                OverwritePrompt = true,
                FileName = $"reporte-pedidos-{DateTime.Now:yyyyMMdd-HHmm}.pdf"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                DownloadButton.Enabled = false;
                Cursor = Cursors.WaitCursor;

                byte[] pdf = await PedidoApiClient.DescargarReportePdfAsync(
                    desde, hasta, modalidad, estado);

                if (pdf.Length == 0)
                    throw new InvalidOperationException(
                        "La API devolvió un PDF vacío.");

                await File.WriteAllBytesAsync(dialog.FileName, pdf);

                MessageBox.Show(
                    $"El reporte se guardó correctamente en:\n{dialog.FileName}",
                    "Reporte generado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo generar el reporte.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                DownloadButton.Enabled = true;
                Cursor = Cursors.Default;
            }
        }
    }
}