namespace API.Clients
{
  public interface IAuthService
  {
    event Action<bool>? AuthenticationStateChanged;
    DTOs.LoginResponse? CurrentSession { get; }
    Task<bool> IsAuthenticatedAsync();
    Task<string?> GetTokenAsync();
    Task<bool> LoginAsync(string username, string password);
    Task LogoutAsync();
    Task CheckTokenExpirationAsync();
  }
}