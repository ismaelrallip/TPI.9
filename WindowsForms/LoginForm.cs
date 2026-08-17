using System;
using System.Windows.Forms;
using Application.Services;

namespace WindowsForms
{
    public partial class LoginForm : Form
    {
        private readonly IClienteService clienteService;
        private TextBox txtUser;
        private TextBox txtPass;
        private Button btnLogin;
        private Button btnCancel;
        private Label lblUser;
        private Label lblPass;

        public LoginForm(IClienteService clienteService)
        {
            this.clienteService = clienteService;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Login - Sistema Hamburguesería";
            this.Width = 350;
            this.Height = 220;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            lblUser = new Label() { Text = "Usuario / Email:", Left = 20, Top = 20, Width = 90 };
            txtUser = new TextBox() { Left = 120, Top = 20, Width = 170 };

            lblPass = new Label() { Text = "Contraseña:", Left = 20, Top = 60, Width = 90 };
            txtPass = new TextBox() { Left = 120, Top = 60, Width = 170, PasswordChar = '*' };

            btnLogin = new Button() { Text = "Ingresar", Left = 120, Top = 110, Width = 80 };
            btnCancel = new Button() { Text = "Cancelar", Left = 210, Top = 110, Width = 80 };

            btnLogin.Click += BtnLogin_Click;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.Add(lblUser);
            this.Controls.Add(txtUser);
            this.Controls.Add(lblPass);
            this.Controls.Add(txtPass);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnCancel);
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Credenciales por defecto para acceso rápido en Entrega 2
            if (txtUser.Text.Trim().Equals("admin", StringComparison.OrdinalIgnoreCase) && txtPass.Text == "admin")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            try
            {
                var clientes = await clienteService.GetAllAsync();
                var cliente = clientes.FirstOrDefault(c => c.Email.Equals(txtUser.Text.Trim(), StringComparison.OrdinalIgnoreCase) && c.Password == txtPass.Text);

                if (cliente != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
