namespace DTOs
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;      // sin uso por ahora (queda listo para Entrega 3)
        public DateTime ExpiresAt { get; set; }                  // ídem
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;         // "Administrador" o "Cliente"
        public int? ClienteId { get; set; }                      // solo si Role == "Cliente"
    }
}