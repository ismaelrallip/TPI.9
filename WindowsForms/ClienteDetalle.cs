using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using DTOs;
using API.Clients;

using System.Text.RegularExpressions;
using DTOs;
using API.Clients;

namespace WindowsForms
{
    // FormMode se define una sola vez acá y la reutiliza también DeliveryDetalle.
    public enum FormMode
    {
        Add,
        Update
    }

    public partial class ClienteDetalle : Form
    {
        private const string PasswordPlaceholder = "12345678"; // valor "de mentira", nunca se manda al backend
        private bool passwordPlaceholderActive;

        private ClienteDTO cliente;
        private FormMode mode;

        public ClienteDTO Cliente
        {
            get { return cliente; }
            set
            {
                cliente = value;
                SetCliente();
            }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }

        public ClienteDetalle()
        {
            InitializeComponent();
        }

        public ClienteDetalle(FormMode mode, ClienteDTO cliente) : this()
        {
            Mode = mode;
            Cliente = cliente;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (ValidateCliente())
            {
                try
                {
                    DeshabilitarControles();

                    Cliente.Nombre = nombreTextBox.Text.Trim();
                    Cliente.Apellido = apellidoTextBox.Text.Trim();
                    Cliente.Email = emailTextBox.Text.Trim();
                    Cliente.Telefono = telefonoTextBox.Text.Trim();

                    if (Mode == FormMode.Add || !passwordPlaceholderActive)
                    {
                        Cliente.Password = passwordTextBox.Text;
                    }
                    // Si es Update y quedó el relleno sin tocar, Cliente.Password conserva
                    // el valor original que trajo el GetAsync() — no se pisa la contraseña.

                    if (Mode == FormMode.Update)
                    {
                        await ClienteApiClient.UpdateAsync(Cliente);
                    }
                    else
                    {
                        await ClienteApiClient.AddAsync(Cliente);
                    }

                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    HabilitarControles();
                }
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SetCliente()
        {
            idTextBox.Text = Cliente.Id.ToString();
            nombreTextBox.Text = Cliente.Nombre;
            apellidoTextBox.Text = Cliente.Apellido;
            emailTextBox.Text = Cliente.Email;
            telefonoTextBox.Text = Cliente.Telefono;

            if (mode == FormMode.Update)
            {
                passwordTextBox.Text = PasswordPlaceholder;
                passwordPlaceholderActive = true;
            }
            else
            {
                passwordTextBox.Text = string.Empty;
                passwordPlaceholderActive = false;
            }
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;
            idLabel.Visible = mode == FormMode.Update;
            idTextBox.Visible = mode == FormMode.Update;
            Text = mode == FormMode.Add ? "Agregar cliente" : "Actualizar cliente";
            // En alta: texto plano, para que vea lo que está tipeando.
            // En edición: enmascarado, porque lo que se ve es el relleno falso, no algo que esté escribiendo activamente.
            passwordTextBox.UseSystemPasswordChar = mode == FormMode.Update;
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            //  borra el relleno y desenmascara para que vea lo que escribe.
            if (passwordPlaceholderActive)
            {
                passwordTextBox.Clear();
                passwordTextBox.UseSystemPasswordChar = false;
            }
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            // Si se va sin escribir nada, vuelve a mostrar el relleno enmascarado.
            if (mode == FormMode.Update && passwordTextBox.Text.Length == 0)
            {
                passwordTextBox.Text = PasswordPlaceholder;
                passwordPlaceholderActive = true;
                passwordTextBox.UseSystemPasswordChar = true;
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (passwordTextBox.Text != PasswordPlaceholder)
            {
                passwordPlaceholderActive = false;
            }
        }

        private bool ValidateCliente()
        {
            bool isValid = true;

            errorProvider.SetError(nombreTextBox, string.Empty);
            errorProvider.SetError(apellidoTextBox, string.Empty);
            errorProvider.SetError(emailTextBox, string.Empty);
            errorProvider.SetError(telefonoTextBox, string.Empty);
            errorProvider.SetError(passwordTextBox, string.Empty);

            if (nombreTextBox.Text.Trim().Length < 2 || nombreTextBox.Text.Trim().Length > 50)
            {
                isValid = false;
                errorProvider.SetError(nombreTextBox, "El nombre debe tener entre 2 y 50 caracteres.");
            }

            if (apellidoTextBox.Text.Trim().Length < 2 || apellidoTextBox.Text.Trim().Length > 50)
            {
                isValid = false;
                errorProvider.SetError(apellidoTextBox, "El apellido debe tener entre 2 y 50 caracteres.");
            }

            if (emailTextBox.Text.Trim() == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(emailTextBox, "El email es requerido.");
            }
            else if (!EsEmailValido(emailTextBox.Text.Trim()))
            {
                isValid = false;
                errorProvider.SetError(emailTextBox, "El formato del email no es válido.");
            }

            var telefono = telefonoTextBox.Text.Trim();
            if (telefono.Length <= 8 || !telefono.All(char.IsDigit))
            {
                isValid = false;
                errorProvider.SetError(telefonoTextBox, "El teléfono debe tener más de 8 dígitos y contener solo números.");
            }

            if (mode == FormMode.Add && passwordTextBox.Text.Length < 6)
            {
                isValid = false;
                errorProvider.SetError(passwordTextBox, "La contraseña es obligatoria y debe tener al menos 6 caracteres.");
            }
            else if (mode == FormMode.Update && !passwordPlaceholderActive && passwordTextBox.Text.Length < 6)
            {
                isValid = false;
                errorProvider.SetError(passwordTextBox, "Si va a cambiar la contraseña, debe tener al menos 6 caracteres.");
            }

            return isValid;
        }

        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void DeshabilitarControles()
        {
            aceptarButton.Enabled = false;
            cancelarButton.Enabled = false;
            nombreTextBox.Enabled = false;
            apellidoTextBox.Enabled = false;
            emailTextBox.Enabled = false;
            telefonoTextBox.Enabled = false;
            passwordTextBox.Enabled = false;
        }

        private void HabilitarControles()
        {
            aceptarButton.Enabled = true;
            cancelarButton.Enabled = true;
            nombreTextBox.Enabled = true;
            apellidoTextBox.Enabled = true;
            emailTextBox.Enabled = true;
            telefonoTextBox.Enabled = true;
            passwordTextBox.Enabled = true;
        }
    }
}