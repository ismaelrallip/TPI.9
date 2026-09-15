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

namespace WindowsForms
{
    public enum FormMode
    {
        Add,
        Update
    }

    public partial class ClienteDetalle : Form
    {
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
                    Cliente.Password = passwordTextBox.Text; 

                    if (Mode == FormMode.Update)
                    {
                        await ClienteApiClient.UpdateAsync(Cliente);
                    }
                    else
                    {
                        await ClienteApiClient.AddAsync(Cliente);
                    }

                    DialogResult = DialogResult.OK;
                    Close();
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
            Close();
        }

        private void SetCliente()
        {
            idTextBox.Text = Cliente.Id.ToString();
            nombreTextBox.Text = Cliente.Nombre;
            apellidoTextBox.Text = Cliente.Apellido;
            emailTextBox.Text = Cliente.Email;
            telefonoTextBox.Text = Cliente.Telefono;
            passwordTextBox.Text = Cliente.Password ?? string.Empty;
            confirmarPasswordTextBox.Text = Cliente.Password ?? string.Empty;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;
            idLabel.Visible = mode == FormMode.Update;
            idTextBox.Visible = mode == FormMode.Update;
            Text = mode == FormMode.Add ? "Agregar cliente" : "Actualizar cliente";
            passwordTextBox.UseSystemPasswordChar = false;
            confirmarPasswordTextBox.UseSystemPasswordChar = false;
        }

        private bool ValidateCliente()
        {
            bool isValid = true;

            errorProvider.SetError(nombreTextBox, string.Empty);
            errorProvider.SetError(apellidoTextBox, string.Empty);
            errorProvider.SetError(emailTextBox, string.Empty);
            errorProvider.SetError(telefonoTextBox, string.Empty);
            errorProvider.SetError(passwordTextBox, string.Empty);
            errorProvider.SetError(confirmarPasswordTextBox, string.Empty); // Limpia error del nuevo campo

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

            if (passwordTextBox.Text.Length < 6)
            {
                isValid = false;
                errorProvider.SetError(passwordTextBox, "La contraseña debe tener al menos 6 caracteres.");
            }
            else if (passwordTextBox.Text != confirmarPasswordTextBox.Text) 
            {
                isValid = false;
                errorProvider.SetError(confirmarPasswordTextBox, "Las contraseñas no coinciden.");
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
            confirmarPasswordTextBox.Enabled = false; 
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
            confirmarPasswordTextBox.Enabled = true;
        }
    }
}