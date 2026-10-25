using API.Clients;
using System.Data;
using DTOs;

namespace WindowsForms
{
    public partial class IngredientesForm : Form
    {

        private IEnumerable<IngredienteDTO> _ingredientes;

        // Espera a que el usuario deje de escribir antes de buscar en el servidor
        private readonly System.Windows.Forms.Timer _timerBusqueda = new() { Interval = 350 };

        public IngredientesForm()
        {
            InitializeComponent();

            ConfigurarColumnas();

            dataGridViewIngredientes.AutoGenerateColumns = false;

            _timerBusqueda.Tick += async (s, e) =>
            {
                _timerBusqueda.Stop();
                await LoadIngredientes(textBoxBuscarIngredientes.Text);
            };
            FormClosed += (s, e) => _timerBusqueda.Dispose();
        }

        private async void IngredientesForm_Load(object sender, EventArgs e)
        {
            await LoadIngredientes();
        }
        // Cada cambio del texto reinicia la espera; la búsqueda se hace al dejar de escribir
        private void textBoxBuscarIngredientes_TextChanged(object sender, EventArgs e)
        {
            _timerBusqueda.Stop();
            _timerBusqueda.Start();
        }

        // Vacía el texto de búsqueda sin disparar una búsqueda extra (la recarga la hace quien llama)
        private void LimpiarBusqueda()
        {
            textBoxBuscarIngredientes.Text = string.Empty;
            _timerBusqueda.Stop();
        }

        private void buttonAddIngrediente_Click(object sender, EventArgs e)
        {
            AgregarIngrediente();
        }

       
        // El filtro lo resuelve la API, ya no se filtra en memoria.
        private async Task LoadIngredientes(string texto = "")
        {
            try
            {
                buttonUpdateIngrediente.Enabled = false;
                

                var ingredientes = string.IsNullOrWhiteSpace(texto)
                    ? await IngredienteApiClient.GetAllAsync()
                    : await IngredienteApiClient.GetByCriteriaAsync(texto.Trim());
                _ingredientes = ingredientes;
                dataGridViewIngredientes.DataSource = ingredientes.ToList();

                buttonUpdateIngrediente.Enabled = true;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ingredientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdateHamburguesa_Click(object sender, EventArgs e)
        {
            // 1. Validar que exista al menos una fila seleccionada o una celda activa
            if (dataGridViewIngredientes.CurrentRow != null && dataGridViewIngredientes.CurrentRow.Index >= 0)
            {
                // 2. Obtener la celda "Id" (o el índice de columna correspondiente)
                var celdaId = dataGridViewIngredientes.CurrentRow.Cells["Id"].Value;

                // 3. Validar que la celda no esté vacía o nula
                if (celdaId != null && int.TryParse(celdaId.ToString(), out int idSeleccionado))
                {
                    ActualizarIngrediente(idSeleccionado);
                }
                else
                {
                    MessageBox.Show("La fila seleccionada no contiene un ID válido.");
                }
            }
        }

        private async void AgregarIngrediente()
        {
            using (var formModal = new AgregarIngredienteForm())
            {
                // ShowDialog() lo abre como popup modal
                if (formModal.ShowDialog(this) == DialogResult.OK)
                {
                    // Si guardó con éxito, recarga el gridView
                    LimpiarBusqueda();
                    await LoadIngredientes();
                }
            }
        }
        private async void ActualizarIngrediente(int id)
        {
            using (var formModal = new ActualizarIngredienteForm(id))
            {
                // ShowDialog() lo abre como popup modal
                if (formModal.ShowDialog(this) == DialogResult.OK)
                {
                    // Si guardó con éxito, recarga el gridView
                    LimpiarBusqueda();
                    await LoadIngredientes();
                }
            }

        }

        private void ConfigurarColumnas()
        {
            dataGridViewIngredientes.AutoGenerateColumns = false;
            dataGridViewIngredientes.Columns.Clear(); 

            dataGridViewIngredientes.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id", Width = 50 });
            dataGridViewIngredientes.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Nombre", DataPropertyName = "Nombre", Width = 150 });
            dataGridViewIngredientes.Columns.Add(new DataGridViewTextBoxColumn { Name = "Descripcion", HeaderText = "Descripción", DataPropertyName = "Descripcion", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dataGridViewIngredientes.Columns.Add(new DataGridViewTextBoxColumn { Name = "Stock", HeaderText = "Stock", DataPropertyName = "Stock", Width = 80 });
        }
    }
}