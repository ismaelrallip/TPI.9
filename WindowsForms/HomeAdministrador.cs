using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;

namespace WindowsForms
{
    public partial class HomeAdministrador : Form
    {
        public bool LogoutRequested { get; private set; } = false;

        public HomeAdministrador()
        {
            InitializeComponent();
            this.IsMdiContainer = true;

            if (AuthServiceProvider.Current != null)
                AuthServiceProvider.Current.AuthenticationStateChanged += AuthenticationStateChanged;
        }

        private void AuthenticationStateChanged(bool isAuthenticated)
        {
            if (!isAuthenticated && !IsDisposed)
                BeginInvoke(RequestLogout);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (AuthServiceProvider.Current != null)
                AuthServiceProvider.Current.AuthenticationStateChanged -= AuthenticationStateChanged;

            base.OnFormClosed(e);
        }


        public void RequestLogout()
        {
            LogoutRequested = true;
            this.Close();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarFormulario<ClienteLista>();
        }

        private void deliveriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarFormulario<DeliveryLista>();
        }

        private void hamburguesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarFormulario<HamburguesaForm>();
        }

        private void ingredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarFormulario<IngredientesForm>();
        }

        private void precioDeliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarFormulario<PrecioDeliveryHistorico>();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarFormulario<PedidosForm>();
        }

        private async void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("¿Cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes && AuthServiceProvider.Current != null)
                await AuthServiceProvider.Current.LogoutAsync();
        }
        private void MostrarFormulario<T>() where T : Form, new()
        {
            var formularioExistente = this.MdiChildren.OfType<T>().FirstOrDefault();

            if (formularioExistente != null)
            {
                formularioExistente.BringToFront();
            }
            else
            {
                var form = new T();
                form.MdiParent = this;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
        }
    }
}