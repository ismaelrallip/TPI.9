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
        private ToolStripLabel? _etiquetaCliente;   
        public HomeCliente()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.Load += HomeCliente_Load;

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

        private async void HomeCliente_Load(object sender, EventArgs e)
        {
            var session = AuthServiceProvider.Current?.CurrentSession;
            if (session?.ClienteId == null) return;

            try
            {
                var cliente = await ClienteApiClient.GetAsync(session.ClienteId.Value);

                // La etiqueta se crea y se agrega recién cuando se tiene el nombre
                _etiquetaCliente = new ToolStripLabel($"{cliente.Nombre} {cliente.Apellido}")
                {
                    Alignment = ToolStripItemAlignment.Right,
                    Margin = new Padding(0, 0, 10, 0)
                };
                (MainMenuStrip ?? Controls.OfType<MenuStrip>().FirstOrDefault())?.Items.Add(_etiquetaCliente);
            }
            catch
            {
                // Si no se puede traer el nombre, no se muestra nada.
            }
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

                // Buscar si ya existe una instancia abierta de Perfil
                var existente = this.MdiChildren.OfType<ClienteDetalle>().FirstOrDefault();
                if (existente != null)
                {
                    existente.BringToFront();
                    return;
                }

                var cliente = await ClienteApiClient.GetAsync(session.ClienteId.Value);

                var detalle = new ClienteDetalle(FormMode.Update, cliente) { EsRegistro = false };
                detalle.MdiParent = this;
                detalle.FormBorderStyle = FormBorderStyle.None;
                detalle.Dock = DockStyle.Fill;

                // Escuchar el cierre para refrescar la etiqueta con el nombre si se actualizó
                detalle.FormClosed += (s, ev) =>
                {
                    if (_etiquetaCliente != null && cliente != null)
                        _etiquetaCliente.Text = $"{cliente.Nombre} {cliente.Apellido}";
                };

                detalle.Show();
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

                // Buscar si ya existe una instancia abierta de Crear Pedido
                var existente = this.MdiChildren.OfType<AgregarEditarPedidoForm>().FirstOrDefault();
                if (existente != null)
                {
                    existente.BringToFront();
                    return;
                }

                var form = new AgregarEditarPedidoForm(session.ClienteId.Value);
                form.MdiParent = this;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
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

        private async void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("¿Cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes && AuthServiceProvider.Current != null)
                await AuthServiceProvider.Current.LogoutAsync();
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
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
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
