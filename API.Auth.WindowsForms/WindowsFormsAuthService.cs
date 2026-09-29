using API.Clients;
using DTOs;

namespace API.Auth.WindowsForms
{
  public sealed class WindowsFormsAuthService : IAuthService
  {
    private LoginResponse? currentSession;

    public event Action<bool>? AuthenticationStateChanged;

    public LoginResponse? CurrentSession => currentSession;

    public async Task<bool> IsAuthenticatedAsync()
    {
      await CheckTokenExpirationAsync();
      return currentSession != null && !string.IsNullOrWhiteSpace(currentSession.Token);
    }

    public async Task<string?> GetTokenAsync()
    {
      return await IsAuthenticatedAsync() ? currentSession?.Token : null;
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
      var session = await AuthApiClient.LoginAsync(username, password);
      if (session == null || string.IsNullOrWhiteSpace(session.Token))
        return false;

      currentSession = session;
      return true;
    }

    public Task LogoutAsync()
    {
      currentSession = null;
      AuthenticationStateChanged?.Invoke(false);
      return Task.CompletedTask;
    }

    public Task CheckTokenExpirationAsync()
    {
      if (currentSession != null && DateTime.UtcNow >= currentSession.ExpiresAt)
      {
        currentSession = null;
        AuthenticationStateChanged?.Invoke(false);
      }

      return Task.CompletedTask;
    }
  }
}