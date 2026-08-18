using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }

        public Ingrediente(int id, string nombre, string descripcion, int stock)
        {
            SetId(id);
            SetNombre(nombre);
            SetDescripcion(descripcion);
            SetStock(stock);
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

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion) || descripcion.Length < 2 || descripcion.Length > 200)
                throw new ArgumentException("La descripción es obligatoria y debe tener entre 2 y 200 caracteres.", nameof(descripcion));
            Descripcion = descripcion;
        }

        public void SetStock(int stock)
        {
            if (stock < 0)
                throw new ArgumentException("El stock debe ser mayor o igual a 0.", nameof(stock));
            Stock = stock;
        }
    }
}
