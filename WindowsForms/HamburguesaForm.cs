using Application.Services;
using Domain.Model;
using Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class HamburguesaForm : Form
    {
        private readonly HamburguesaService _hamburguesaService;

        private IEnumerable<Hamburguesa> _hamburguesas;
        public HamburguesaForm(HamburguesaService hamburguesaService)
        {
            _hamburguesaService = hamburguesaService;
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
                var hamburguesas = await _hamburguesaService.GetAllAsync();
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
            using (var formModal = new AgregarHamburguesaForm(_hamburguesaService))
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
