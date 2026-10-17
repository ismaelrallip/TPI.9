using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;

namespace WindowsForms
{
    public partial class PerfilCliente : Form
    {
        private int? _clienteId;
        private enum Mode { None, ChangePassword, DeleteAccount, EditProfile }
        private Mode _mode = Mode.None;



        private async Task<bool> LoadClienteAsync()
        {
            var session = AuthServiceProvider.Current?.CurrentSession;
            if (session == null || session.ClienteId == null)
                return false;

            _clienteId = session.ClienteId.Value;

            var cliente = await ClienteApiClient.GetAsync(_clienteId.Value);
            nombreTextBox.Text = cliente.Nombre;
            ApellidoTextBox.Text = cliente.Apellido;
            emailTextBox.Text = cliente.Email;
            telefonoTextBox.Text = cliente.Telefono;

            // Inicialmente ocultamos campos y botones relacionados a contraseña
            SetPasswordControlsVisible(false);

            SetProfileFieldsEditable(false);
            SetPasswordControlsVisible(false);

            return true;
        }
        private void SetProfileFieldsEditable(bool editable)
        {
            
            nombreTextBox.Enabled = editable;
            nombreTextBox.ReadOnly = !editable;

            ApellidoTextBox.Enabled = editable;
            ApellidoTextBox.ReadOnly = !editable;

            emailTextBox.Enabled = editable;
            emailTextBox.ReadOnly = !editable;

            telefonoTextBox.Enabled = editable;
            telefonoTextBox.ReadOnly = !editable;
        }
        private void SetPasswordControlsVisible(bool visible)
        {
            contraseñaActualLabel.Visible = visible;
            label1.Visible = visible;
            ConfirmarContraseñaLabel.Visible = visible;
            textBox1.Visible = visible; // current
            textBox2.Visible = visible; // new
            textBox3.Visible = visible; // confirm
            aceptarButton.Visible = visible;
            cancelButton.Visible = visible;
        }
        public PerfilCliente()
        {
            InitializeComponent();
        }

        private void cambiarContraseñaButton_Click(object sender, EventArgs e)
        {
            _mode = Mode.ChangePassword;
            SetPasswordControlsVisible(true);
            // Limpiar campos
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            _mode = Mode.DeleteAccount;
            // Mostrar solo el campo de contraseña actual y botones aceptar/cancelar
            SetPasswordControlsVisible(false);
            contraseñaActualLabel.Visible = true;
            textBox1.Visible = true;
            aceptarButton.Visible = true;
            cancelButton.Visible = true;
            // Limpiar
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            _ = HandleAceptarAsync();
        }

        private async Task HandleAceptarAsync()
        {
            if (_clienteId == null)
            {
                MessageBox.Show("No se pudo obtener la sesión de cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_mode == Mode.ChangePassword)
            {
                var current = textBox1.Text;
                var nw = textBox2.Text;
                var confirm = textBox3.Text;

                if (string.IsNullOrWhiteSpace(current) || string.IsNullOrWhiteSpace(nw) || string.IsNullOrWhiteSpace(confirm))
                {
                    MessageBox.Show("Complete todos los campos de contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nw != confirm)
                {
                    MessageBox.Show("La nueva contraseña y la confirmación no coinciden.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var confirmarPass = MessageBox.Show("¿Está seguro que desea cambiar su contraseña?", "Confirmar cambio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmarPass != DialogResult.Yes) return;
                try
                {
                    var req = new DTOs.ChangePasswordRequest { CurrentPassword = current, NewPassword = nw };
                    await API.Clients.ClienteApiClient.ChangePasswordAsync(_clienteId.Value, req);
                    MessageBox.Show("Contraseña cambiada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo cambiar la contraseña: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // ocultar controles y resetear modo
                SetPasswordControlsVisible(false);
                _mode = Mode.None;
            }
            else if (_mode == Mode.DeleteAccount)
            {
                var current = textBox1.Text;
                if (string.IsNullOrWhiteSpace(current))
                {
                    MessageBox.Show("Ingrese la contraseña actual para confirmar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmar = MessageBox.Show("Eliminar su cuenta es permanente. ¿Está seguro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmar != DialogResult.Yes) return;

                try
                {
                    var req = new DTOs.DeleteAccountRequest { CurrentPassword = current };
                    await API.Clients.ClienteApiClient.DeleteWithPasswordAsync(_clienteId.Value, req);

                    MessageBox.Show("Su cuenta fue eliminada. Serás desconectado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (API.Clients.AuthServiceProvider.Current != null)
                        await API.Clients.AuthServiceProvider.Current.LogoutAsync();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo eliminar la cuenta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // no cerrar
                }

                SetPasswordControlsVisible(false);
                _mode = Mode.None;
            }
            else if (_mode == Mode.EditProfile)
            {
                var confirmarEdicion = MessageBox.Show("¿Está seguro que desea guardar los cambios en su perfil?", "Confirmar edición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmarEdicion != DialogResult.Yes) return;
                try
                {
                    var clienteDto = new DTOs.ClienteDTO
                    {
                        Id = _clienteId.Value,
                        Nombre = nombreTextBox.Text.Trim(),
                        Apellido = ApellidoTextBox.Text.Trim(),
                        Email = emailTextBox.Text.Trim(),
                        Telefono = telefonoTextBox.Text.Trim()
                    };

                    // Reutiliza el endpoint de actualización existente
                    await API.Clients.ClienteApiClient.UpdateAsync(clienteDto);

                    MessageBox.Show("Perfil actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SetProfileFieldsEditable(false);
                    aceptarButton.Visible = false;
                    cancelButton.Visible = false;
                    _mode = Mode.None;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        private async void PerfilCliente_Load(object sender, EventArgs e)
        {
            await LoadClienteAsync();
        }
        private void editarPerfilButton_Click(object sender, EventArgs e)
        {
            _mode = Mode.EditProfile;
            SetPasswordControlsVisible(false); // Ocultar inputs de contraseña
            SetProfileFieldsEditable(true);    // Permitir escribir
            aceptarButton.Visible = true;
            cancelButton.Visible = true;
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            SetPasswordControlsVisible(false);
            SetProfileFieldsEditable(false);
            _mode = Mode.None;
        }
    }
}
