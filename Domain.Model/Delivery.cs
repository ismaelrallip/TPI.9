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
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
        }

        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede ser nulo o vacío.", nameof(apellido));
            Apellido = apellido;
        }

        public void SetTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El teléfono no puede ser nulo o vacío.", nameof(telefono));
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
