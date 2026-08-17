using System;
using System.Windows.Forms;
using Application.Services;
using DTOs;

namespace WindowsForms
{
    public class ClienteDetailForm : Form
    {
        private readonly IClienteService clienteService;
        private readonly ClienteDTO? clienteDto;

        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private TextBox txtPassword;
        private Button btnGuardar;
        private Button btnCancelar;

        public ClienteDetailForm(IClienteService clienteService, ClienteDTO? clienteDto)
        {
            this.clienteService = clienteService;
            this.clienteDto = clienteDto;
            InitializeComponent();
            if (clienteDto != null)
            {
                txtNombre.Text = clienteDto.Nombre;
                txtApellido.Text = clienteDto.Apellido;
                txtEmail.Text = clienteDto.Email;
                txtTelefono.Text = clienteDto.Telefono;
                txtPassword.Text = clienteDto.Password;
            }
        }

        private void InitializeComponent()
        {
            this.Text = clienteDto == null ? "Nuevo Cliente" : "Editar Cliente";
            this.Width = 380;
            this.Height = 300;
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
            Controls.Add(new Label() { Text = "Email:", Left = 20, Top = y, Width = 80 });
            txtEmail = new TextBox() { Left = 110, Top = y, Width = 220 };
            Controls.Add(txtEmail);

            y += 40;
            Controls.Add(new Label() { Text = "Teléfono:", Left = 20, Top = y, Width = 80 });
            txtTelefono = new TextBox() { Left = 110, Top = y, Width = 220 };
            Controls.Add(txtTelefono);

            y += 40;
            Controls.Add(new Label() { Text = "Contraseña:", Left = 20, Top = y, Width = 80 });
            txtPassword = new TextBox() { Left = 110, Top = y, Width = 220, PasswordChar = '*' };
            Controls.Add(txtPassword);

            btnGuardar = new Button() { Text = "Guardar", Left = 150, Top = 210, Width = 80 };
            btnCancelar = new Button() { Text = "Cancelar", Left = 240, Top = 210, Width = 80 };

            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteDto == null)
                {
                    var novo = new ClienteDTO
                    {
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Email = txtEmail.Text,
                        Telefono = txtTelefono.Text,
                        Password = txtPassword.Text
                    };
                    await clienteService.AddAsync(novo);
                }
                else
                {
                    clienteDto.Nombre = txtNombre.Text;
                    clienteDto.Apellido = txtApellido.Text;
                    clienteDto.Email = txtEmail.Text;
                    clienteDto.Telefono = txtTelefono.Text;
                    clienteDto.Password = txtPassword.Text;
                    await clienteService.UpdateAsync(clienteDto);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
