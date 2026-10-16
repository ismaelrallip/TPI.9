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

        private void crearPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                crearPedidoToolStripMenuItem.Enabled = false;
                var session = AuthServiceProvider.Current?.CurrentSession;
                if (session == null || session.ClienteId == null)
                {
                    MessageBox.Show("No se pudo obtener la información del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using var form = new AgregarEditarPedidoForm(session.ClienteId.Value);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Pedido creado correctamente.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo crear el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                crearPedidoToolStripMenuItem.Enabled = true;
            }
        }

        private void misPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                misPedidosToolStripMenuItem.Enabled = false;
                var session = AuthServiceProvider.Current?.CurrentSession;
                if (session == null || session.ClienteId == null)
                {
                    MessageBox.Show("No se pudo obtener la información del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int clienteId = session.ClienteId.Value;

                // Buscar una instancia ya abierta específica para este cliente
                var existente = this.MdiChildren.OfType<PedidosForm>().FirstOrDefault(f => f.Tag?.ToString() == $"cliente_{clienteId}");
                if (existente != null)
                {
                    existente.BringToFront();
                    return;
                }

                var form = new PedidosForm(clienteId, true);
                form.MdiParent = this;
                form.Tag = $"cliente_{clienteId}";
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudieron obtener los pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                misPedidosToolStripMenuItem.Enabled = true;
            }
        }
    }
}
