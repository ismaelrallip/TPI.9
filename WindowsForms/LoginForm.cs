using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using API.Clients;

namespace WindowsForms
{
    public partial class LoginForm : Form
    {
        // Datos de la sesión iniciada. Válido solo si DialogResult == OK.
        public LoginResponse? Sesion { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            var username = usernameTextBox.Text.Trim();
            var password = passwordTextBox.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Debe completar usuario y contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SetLoading(true);
            try
            {
                var sesion = await AuthApiClient.LoginAsync(username, password);
                if (sesion == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    passwordTextBox.Clear();
                    passwordTextBox.Focus();
                    return;
                }

                Sesion = sesion;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo iniciar sesión.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoading(false);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                loginButton_Click(sender, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void SetLoading(bool loading)
        {
            loginButton.Enabled = !loading;
            cancelButton.Enabled = !loading;
            usernameTextBox.Enabled = !loading;
            passwordTextBox.Enabled = !loading;
            loginButton.Text = loading ? "Verificando..." : "Iniciar sesión";
        }
    }
}