using System.Text.RegularExpressions;

namespace Domain.Model
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Email { get; private set; }
        public string Telefono { get; private set; }
        public string Password { get; private set; }

        public Cliente(int id, string nombre, string apellido, string email, string telefono, string password)
        {
            SetId(id);
            SetNombre(nombre);
            SetApellido(apellido);
            SetEmail(email);
            SetTelefono(telefono);
            SetPassword(password);
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre) || nombre.Length < 2 || nombre.Length > 50)
                throw new ArgumentException("El nombre es obligatorio y debe tener entre 2 y 50 caracteres.", nameof(nombre));
            Nombre = nombre;
        }

        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido) || apellido.Length < 2 || apellido.Length > 50)
                throw new ArgumentException("El apellido es obligatorio y debe tener entre 2 y 50 caracteres.", nameof(apellido));
            Apellido = apellido;
        }

        public void SetEmail(string email)
        {
            if (!EsEmailValido(email))
                throw new ArgumentException("El email no tiene un formato válido.", nameof(email));
            Email = email;
        }

        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public void SetTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono) || telefono.Length <= 8 || !telefono.All(char.IsDigit))
                throw new ArgumentException("El teléfono es obligatorio, debe tener más de 8 dígitos y contener solo números.", nameof(telefono));
            Telefono = telefono;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                throw new ArgumentException("La contraseña es obligatoria y debe tener al menos 6 caracteres.", nameof(password));
            Password = password;
        }
    }
}
