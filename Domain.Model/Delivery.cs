using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Delivery
    {
        public int IdDelivery { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Telefono { get; private set; }
        public int Dni { get; private set; }

        public Delivery(int idDelivery, string nombre, string apellido, string telefono, int dni)
        {
            SetIdDelivery(idDelivery);
            SetNombre(nombre);
            SetApellido(apellido);
            SetTelefono(telefono);
            SetDni(dni);
        }

        public void SetIdDelivery(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            IdDelivery = id;
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

        public void SetTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono) || telefono.Length <= 8 || !telefono.All(char.IsDigit))
                throw new ArgumentException("El teléfono es obligatorio, debe tener más de 8 dígitos y contener solo números.", nameof(telefono));
            Telefono = telefono;
        }

        public void SetDni(int dni)
        {
            if (dni < 1_000_000 || dni > 99_999_999)
                throw new ArgumentException("El DNI debe ser un número válido entre 7 y 8 dígitos.", nameof(dni));

            Dni = dni;
        }
    }
}
