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
    public partial class DeliveryDetalle : Form
    {
        private DeliveryDTO delivery;
        private FormMode mode;

        public DeliveryDTO Delivery
        {
            get { return delivery; }
            set
            {
                delivery = value;
                SetDelivery();
            }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }

        public DeliveryDetalle()
        {
            InitializeComponent();
        }

        public DeliveryDetalle(FormMode mode, DeliveryDTO delivery) : this()
        {
            Mode = mode;
            Delivery = delivery;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (ValidateDelivery(out int dni))
            {
                try
                {
                    DeshabilitarControles();

                    Delivery.Nombre = nombreTextBox.Text.Trim();
                    Delivery.Apellido = apellidoTextBox.Text.Trim();
                    Delivery.Telefono = telefonoTextBox.Text.Trim();
                    Delivery.Dni = dni;

                    if (Mode == FormMode.Update)
                    {
                        await DeliveryApiClient.UpdateAsync(Delivery);
                    }
                    else
                    {
                        await DeliveryApiClient.AddAsync(Delivery);
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar delivery: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void SetDelivery()
        {
            idTextBox.Text = Delivery.IdDelivery.ToString();
            nombreTextBox.Text = Delivery.Nombre;
            apellidoTextBox.Text = Delivery.Apellido;
            telefonoTextBox.Text = Delivery.Telefono;
            dniTextBox.Text = Delivery.Dni == 0 ? string.Empty : Delivery.Dni.ToString();
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;
            idLabel.Visible = mode == FormMode.Update;
            idTextBox.Visible = mode == FormMode.Update;
            Text = mode == FormMode.Add ? "Agregar delivery" : "Actualizar delivery";
        }

        private bool ValidateDelivery(out int dni)
        {
            bool isValid = true;
            dni = 0;

            errorProvider.SetError(nombreTextBox, string.Empty);
            errorProvider.SetError(apellidoTextBox, string.Empty);
            errorProvider.SetError(telefonoTextBox, string.Empty);
            errorProvider.SetError(dniTextBox, string.Empty);

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

            var telefono = telefonoTextBox.Text.Trim();
            if (telefono.Length <= 8 || !telefono.All(char.IsDigit))
            {
                isValid = false;
                errorProvider.SetError(telefonoTextBox, "El teléfono debe tener más de 8 dígitos y contener solo números.");
            }

            if (!int.TryParse(dniTextBox.Text.Trim(), out dni) || dni < 1_000_000 || dni > 99_999_999)
            {
                isValid = false;
                errorProvider.SetError(dniTextBox, "El DNI debe ser un número válido entre 7 y 8 dígitos.");
            }

            return isValid;
        }

        private void DeshabilitarControles()
        {
            aceptarButton.Enabled = false;
            cancelarButton.Enabled = false;
            nombreTextBox.Enabled = false;
            apellidoTextBox.Enabled = false;
            telefonoTextBox.Enabled = false;
            dniTextBox.Enabled = false;
        }

        private void HabilitarControles()
        {
            aceptarButton.Enabled = true;
            cancelarButton.Enabled = true;
            nombreTextBox.Enabled = true;
            apellidoTextBox.Enabled = true;
            telefonoTextBox.Enabled = true;
            dniTextBox.Enabled = true;
        }
    }
}