using API.Clients;
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
    public partial class HomeCliente : Form
    {
        public bool LogoutRequested { get; private set; } = false;

        public HomeCliente()
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

        private async void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                perfilToolStripMenuItem.Enabled = false;
                var session = AuthServiceProvider.Current?.CurrentSession;
                if (session == null || session.ClienteId == null)
                {
                    MessageBox.Show("No se pudo obtener la información del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var cliente = await ClienteApiClient.GetAsync(session.ClienteId.Value);
                using var detalle = new ClienteDetalle(FormMode.Update, cliente) { EsRegistro = false };
                if (detalle.ShowDialog(this) == DialogResult.OK)
                {
                    // Aquí podríamos refrescar información del cliente si es necesario.

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                perfilToolStripMenuItem.Enabled = true;
            }
        }

        private async void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("¿Cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes && AuthServiceProvider.Current != null)
                await AuthServiceProvider.Current.LogoutAsync();
        }
    }
}
