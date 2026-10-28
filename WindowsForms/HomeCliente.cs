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

            // Si cerró la ventana tocando la X (no por Logout), deslogueamos la sesión
            if (!LogoutRequested && AuthServiceProvider.Current != null)
            {
                _ = AuthServiceProvider.Current.LogoutAsync();
            }
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

                _etiquetaCliente = new ToolStripLabel($"{cliente.Nombre} {cliente.Apellido}")
                {
                    Alignment = ToolStripItemAlignment.Right,
                    Margin = new Padding(0, 0, 10, 0)
                };
                (MainMenuStrip ?? Controls.OfType<MenuStrip>().FirstOrDefault())?.Items.Add(_etiquetaCliente);
            }
            catch
            {
                // Si no se puede obtener el nombre, no se muestra la etiqueta.
            }
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarFormulario<PerfilCliente>();
        }

        private void crearPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var session = AuthServiceProvider.Current?.CurrentSession;
            if (session == null || session.ClienteId == null)
            {
                MessageBox.Show("No se pudo obtener la información del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Usamos la sobrecarga personalizada pasando la fábrica para instanciar con ClienteId
            var form = MostrarFormulario(() => new AgregarEditarPedidoForm(session.ClienteId.Value));

            // Mantenemos la suscripción para recargar "Mis Pedidos" si se creó correctamente
            if (form != null)
            {
                form.FormClosed += async (s, ev) =>
                {
                    if (form.DialogResult == DialogResult.OK)
                    {
                        MessageBox.Show("Pedido creado correctamente.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var pedidosForm = this.MdiChildren.OfType<PedidosForm>().FirstOrDefault(f => f.Tag?.ToString() == $"cliente_{session.ClienteId.Value}");
                        if (pedidosForm != null)
                        {
                            await pedidosForm.LoadPedidos();
                        }
                    }
                };
            }
        }

        private void misPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var session = AuthServiceProvider.Current?.CurrentSession;
            if (session == null || session.ClienteId == null)
            {
                MessageBox.Show("No se pudo obtener la información del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int clienteId = session.ClienteId.Value;

            var form = MostrarFormulario(() => new PedidosForm(clienteId, true));
            if (form != null)
            {
                form.Tag = $"cliente_{clienteId}";
            }
        }

        private async void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("¿Cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes && AuthServiceProvider.Current != null)
                await AuthServiceProvider.Current.LogoutAsync();
        }

        #region Métodos Auxiliares para Navegación MDI

        /// <summary>
        /// Abre un formulario sin parámetros reemplazando el hijo anterior.
        /// </summary>
        private T? MostrarFormulario<T>() where T : Form, new()
        {
            return MostrarFormulario(() => new T());
        }

        /// <summary>
        /// Abre un formulario instanciado con constructor personalizado reemplazando el hijo anterior.
        /// </summary>
        private T? MostrarFormulario<T>(Func<T> factory) where T : Form
        {
            try
            {
                // Verifica si la misma pantalla ya está abierta
                var formularioExistente = this.MdiChildren.OfType<T>().FirstOrDefault();
                if (formularioExistente != null)
                {
                    formularioExistente.BringToFront();
                    return formularioExistente;
                }

                // Cierra los formularios hijos previos para mantener un área limpia
                foreach (var child in this.MdiChildren)
                {
                    child.Close();
                }

                // Crea y configura el nuevo formulario hijo
                var form = factory();
                form.MdiParent = this;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();

                return form;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al abrir la pantalla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion
    }
}