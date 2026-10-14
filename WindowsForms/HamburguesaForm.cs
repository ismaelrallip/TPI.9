using API.Clients;
using DTOs;
using System.Data;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class HamburguesaForm : Form
    {

        private IEnumerable<HamburguesaDTO> burgas;

        // Espera a que el usuario deje de escribir antes de buscar en el servidor
        private readonly System.Windows.Forms.Timer _timerBusqueda = new() { Interval = 350 };

        public HamburguesaForm()
        {
            InitializeComponent();

            ConfigurarColumnas();

            dataGridViewHamburguesas.AutoGenerateColumns = false;

            _timerBusqueda.Tick += async (s, e) =>
            {
                _timerBusqueda.Stop();
                await LoadHamburguesas(textBoxBuscarHamburguesa.Text);
            };
            FormClosed += (s, e) => _timerBusqueda.Dispose();
        }

        private void HamburguesaForm_Load(object sender, EventArgs e)
        {
            buttonUpdateHamburguesa.Enabled = false;
            LoadHamburguesas();
        }

       
        // El filtro lo resuelve la API (base de datos): ya no se filtra en memoria.
        private async Task LoadHamburguesas(string texto = "")
        {
            try
            {
                buttonUpdateHamburguesa.Enabled = false;
                buttonVerResumen.Enabled = false;

                burgas = string.IsNullOrWhiteSpace(texto)
                    ? await HamburguesaApiClient.GetAllAsync()
                    : await HamburguesaApiClient.GetByCriteriaAsync(texto.Trim());

                var datosParaGrid = burgas.Select(h =>
                {
                    // Buscamos el precio con la fecha más reciente
                    var ultimoPrecio = h.Precios?
                        .OrderByDescending(p => p.FechaDesde)
                        .FirstOrDefault();

                    return new
                    {
                        h.Id,
                        h.Nombre,
                        h.Descripcion,
                        // Si no hay precios o la lista es null
                        Precio = ultimoPrecio?.Monto ?? 0m,
                        FechaPrecio = ultimoPrecio?.FechaDesde.ToString("dd/MM/yyyy") ?? "Sin registrar"
                    };
                }).ToList();

                dataGridViewHamburguesas.DataSource = null;
                dataGridViewHamburguesas.DataSource = datosParaGrid;

                buttonUpdateHamburguesa.Enabled = true;
                buttonVerResumen.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar hamburguesas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cada cambio del texto reinicia la espera,la búsqueda se hace al dejar de escribir
        private void textBoxBuscarHamburguesa_TextChanged(object sender, EventArgs e)
        {
            _timerBusqueda.Stop();
            _timerBusqueda.Start();
        }

        // Vacía el texto de búsqueda sin disparar una búsqueda extra (la recarga la hace quien llama)
        private void LimpiarBusqueda()
        {
            textBoxBuscarHamburguesa.Text = string.Empty;
            _timerBusqueda.Stop();
        }

        private void buttonAddHamburguesa_Click(object sender, EventArgs e)
        {
            CrearHamburguesa();
        }

        private async void CrearHamburguesa()
        {
            using (var formModal = new AgregarHamburguesaForm())
            {
                
                if (formModal.ShowDialog(this) == DialogResult.OK)
                {
                    // Si guardó con éxito, recarga el gridView
                    LimpiarBusqueda();
                    await LoadHamburguesas();
                }
            }
        }

        private void buttonUpdateHamburguesa_Click(object sender, EventArgs e)
        {
            // 1. Validar que exista al menos una fila seleccionada o una celda activa
            if (dataGridViewHamburguesas.CurrentRow != null && dataGridViewHamburguesas.CurrentRow.Index >= 0)
            {
                // 2. Obtener la celda "Id" (o el índice de columna correspondiente)
                var celdaId = dataGridViewHamburguesas.CurrentRow.Cells["Id"].Value;

                // 3. Validar que la celda no esté vacía o nula
                if (celdaId != null && int.TryParse(celdaId.ToString(), out int idSeleccionado))
                {
                    ActualizarHamburguesa(idSeleccionado);
                }
                else
                {
                    MessageBox.Show("La fila seleccionada no contiene un ID válido.");
                }
            }
        }

        private async void ActualizarHamburguesa(int id)
        {
            using (var formModal = new ActualizarHamburguesaForm(id))
            {
                if (formModal.ShowDialog(this) == DialogResult.OK)
                {
                    // Si guardó con éxito, recarga el gridView
                    LimpiarBusqueda();
                    await LoadHamburguesas();
                }
            }
        }

        private void buttonVerResumen_Click(object sender, EventArgs e)
        {
            if (dataGridViewHamburguesas.CurrentRow != null && dataGridViewHamburguesas.CurrentRow.Index >= 0)
            {
                // 2. Obtener la celda "Id" (o el índice de columna correspondiente)
                var celdaId = dataGridViewHamburguesas.CurrentRow.Cells["Id"].Value;

                // 3. Validar que la celda no esté vacía o nula
                if (celdaId != null && int.TryParse(celdaId.ToString(), out int idSeleccionado))
                {
                    VerResumen(idSeleccionado);
                }
                else
                {
                    MessageBox.Show("La fila seleccionada no contiene un ID válido.");
                }
            }
        }

        private async void VerResumen(int id)
        {
            using (var formModal = new ResumenHamburguesaForm(id))
            {
                // ShowDialog() lo abre como popup modal
                if (formModal.ShowDialog(this) == DialogResult.OK)
                {
                    // Si guardó con éxito, recarga el gridView
                    LimpiarBusqueda();
                    await LoadHamburguesas();
                }
            }
        }
        private void ConfigurarColumnas()
        {
            dataGridViewHamburguesas.AutoGenerateColumns = false;
            dataGridViewHamburguesas.Columns.Clear(); 

            dataGridViewHamburguesas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id", Width = 50 });
            dataGridViewHamburguesas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Nombre", DataPropertyName = "Nombre", Width = 150 });
            dataGridViewHamburguesas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Descripcion", HeaderText = "Descripción", DataPropertyName = "Descripcion", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dataGridViewHamburguesas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Precio", HeaderText = "Precio Actual", DataPropertyName = "Precio", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dataGridViewHamburguesas.Columns.Add(new DataGridViewTextBoxColumn { Name = "FechaPrecio", HeaderText = "Fecha del Precio", DataPropertyName = "FechaPrecio", Width = 120 });
        }
    }
}
