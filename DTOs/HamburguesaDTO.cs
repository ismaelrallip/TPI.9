namespace DTOs
{
    public class HamburguesaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;

        public List<PrecioDTO> Precios { get; set; } = new List<PrecioDTO>();

        public List<IngredienteDTO> Ingredientes { get; set; } = new List<IngredienteDTO>();
    }
}
