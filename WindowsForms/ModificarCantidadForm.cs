using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class ModificarCantidadForm : Form
    {
        // Propiedad que leerá el formulario principal cuando este se cierre
        public int CantidadSeleccionada { get; private set; }

        public ModificarCantidadForm(string nombreHamburguesa, decimal precioUnitario, int cantidadActual)
        {
            InitializeComponent();

            // Configuraciones de la ventana
            this.Text = "Modificar Cantidad";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Mostramos los datos en los Labels
            lblHamburguesa.Text = $"Hamburguesa: {nombreHamburguesa}";
            lblPrecio.Text = $"Precio Unitario: {precioUnitario:C2}";

            // Precargamos la cantidad en el NumericUpDown
            numNuevaCantidad.Value = cantidadActual > 0 ? cantidadActual : 1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Como el NumericUpDown ya tiene un Mínimo de 1, es imposible que envíen letras o ceros
            CantidadSeleccionada = (int)numNuevaCantidad.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}