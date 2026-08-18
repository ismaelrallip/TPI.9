using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Hamburguesa
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public decimal Precio { get; private set; }
        public List<Ingrediente> Ingredientes { get; private set; }
        public Hamburguesa(int id, string nombre, string descripcion, decimal precio, List<Ingrediente> ingredientes)
        {
            SetId(id);
            SetNombre(nombre);
            SetDescripcion(descripcion);
            SetPrecio(precio);
            SetIngredientes(ingredientes);
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
        public void SetPrecio(decimal precio)
        {
            if (precio < 0)
                throw new ArgumentException("El precio debe ser mayor o igual a 0.", nameof(precio));
            Precio = precio;
        }
        public void SetIngredientes(List<Ingrediente> ingredientes)
        {
            if (ingredientes == null || ingredientes.Count == 0)
                throw new ArgumentException("La hamburguesa debe tener al menos un ingrediente.", nameof(ingredientes));
            Ingredientes = ingredientes;
        }
    }
}
