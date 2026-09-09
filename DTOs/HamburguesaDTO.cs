using Domain.Model;

namespace DTOs
{
    public class HamburguesaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public List<Precio>? Precios { get; set; }

        public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();
    }
}
