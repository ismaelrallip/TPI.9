using Domain.Model;
using API.Clients;
using System.Data;

namespace WindowsForms
{
    public partial class HamburguesaForm : Form
    {

        private IEnumerable<Hamburguesa> _hamburguesas;

        public HamburguesaForm()
        {
            InitializeComponent();
        }

        private void HamburguesaForm_Load(object sender, EventArgs e)
        {
            LoadHamburguesas();
        }

        // FUNCIONES
        private async Task LoadHamburguesas()
        {
            try
            {
                var hamburguesas = await HamburguesaApiClient.GetAllAsync();
                _hamburguesas = (IEnumerable<Hamburguesa>)hamburguesas;
                dataGridViewHamburguesas.DataSource = hamburguesas.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar hamburguesas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxBuscarHamburguesa_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBoxBuscarHamburguesa.Text;
            if (_hamburguesas != null)
            {
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    _hamburguesas = _hamburguesas.Where(i => i.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                                                          i.Descripcion.Contains(filtro, StringComparison.OrdinalIgnoreCase));
                }
                dataGridViewHamburguesas.DataSource = _hamburguesas.ToList();
            }
        }

        private void buttonAddHamburguesa_Click(object sender, EventArgs e)
        {
            using (var formModal = new AgregarHamburguesaForm())
            {
                // ShowDialog() lo abre como popup modal
                if (formModal.ShowDialog() == DialogResult.OK)
                {
                    // Si guardó con éxito, recarga el gridView
                    textBoxBuscarHamburguesa.Text = string.Empty;
                    LoadHamburguesas();
                }
            }
        }

        private void ActualizarHamburguesa(Hamburguesa hamburguesaSeleccionada)
        {
            using (var formModal = new ActualizarHamburguesaForm(hamburguesaSeleccionada))
            {
                // ShowDialog() lo abre como popup modal
                if (formModal.ShowDialog() == DialogResult.OK)
                {
                    // Si guardó con éxito, recarga el gridView
                    textBoxBuscarHamburguesa.Text = string.Empty;
                    LoadHamburguesas();
                }
            }
        }
    }
}
