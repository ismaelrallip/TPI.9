using System;
using System.Windows.Forms;
using Application.Services;
using DTOs;

namespace WindowsForms
{
    public class DeliveryDetailForm : Form
    {
        private readonly IDeliveryService deliveryService;
        private readonly DeliveryDTO? deliveryDto;

        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private TextBox txtDni;
        private Button btnGuardar;
        private Button btnCancelar;

        public DeliveryDetailForm(IDeliveryService deliveryService, DeliveryDTO? deliveryDto)
        {
            this.deliveryService = deliveryService;
            this.deliveryDto = deliveryDto;
            InitializeComponent();
            if (deliveryDto != null)
            {
                txtNombre.Text = deliveryDto.Nombre;
                txtApellido.Text = deliveryDto.Apellido;
                txtTelefono.Text = deliveryDto.Telefono;
                txtDni.Text = deliveryDto.Dni.ToString();
            }
        }

        private void InitializeComponent()
        {
            this.Text = deliveryDto == null ? "Nuevo Delivery" : "Editar Delivery";
            this.Width = 380;
            this.Height = 260;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            int y = 20;
            Controls.Add(new Label() { Text = "Nombre:", Left = 20, Top = y, Width = 80 });
            txtNombre = new TextBox() { Left = 110, Top = y, Width = 220 };
            Controls.Add(txtNombre);

            y += 40;
            Controls.Add(new Label() { Text = "Apellido:", Left = 20, Top = y, Width = 80 });
            txtApellido = new TextBox() { Left = 110, Top = y, Width = 220 };
            Controls.Add(txtApellido);

            y += 40;
            Controls.Add(new Label() { Text = "Teléfono:", Left = 20, Top = y, Width = 80 });
            txtTelefono = new TextBox() { Left = 110, Top = y, Width = 220 };
            Controls.Add(txtTelefono);

            y += 40;
            Controls.Add(new Label() { Text = "DNI:", Left = 20, Top = y, Width = 80 });
            txtDni = new TextBox() { Left = 110, Top = y, Width = 220 };
            Controls.Add(txtDni);

            btnGuardar = new Button() { Text = "Guardar", Left = 150, Top = 170, Width = 80 };
            btnCancelar = new Button() { Text = "Cancelar", Left = 240, Top = 170, Width = 80 };

            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtDni.Text, out int dni))
                {
                    if (deliveryDto == null)
                    {
                        var dto = new DeliveryDTO
                        {
                            Nombre = txtNombre.Text,
                            Apellido = txtApellido.Text,
                            Telefono = txtTelefono.Text,
                            Dni = dni
                        };
                        await deliveryService.AddAsync(dto);
                    }
                    else
                    {
                        deliveryDto.Nombre = txtNombre.Text;
                        deliveryDto.Apellido = txtApellido.Text;
                        deliveryDto.Telefono = txtTelefono.Text;
                        deliveryDto.Dni = dni;
                        await deliveryService.UpdateAsync(deliveryDto);
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El DNI debe ser numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
