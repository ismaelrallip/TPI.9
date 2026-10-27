using DTOs;
using API.Clients;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace API.Auth.Blazor.Server
{
    public class BlazorServerAuthService : IAuthService
    {
        private LoginResponse? _currentSession;
        private readonly ProtectedLocalStorage _localStorage;

        public event Action<bool>? AuthenticationStateChanged;

        public LoginResponse? CurrentSession => _currentSession;

        // Inyectamos ProtectedLocalStorage
        public BlazorServerAuthService(ProtectedLocalStorage localStorage)
        {
            _localStorage = localStorage;
        }

        public Task<bool> IsAuthenticatedAsync()
        {
            try
            {
                if (_currentSession != null)
                {
                    return Task.FromResult(!string.IsNullOrEmpty(_currentSession.Token) && DateTime.UtcNow < _currentSession.ExpiresAt);
                }
                return Task.FromResult(false);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public Task<string?> GetTokenAsync()
        {
            try
            {
                return Task.FromResult(_currentSession?.Token);
            }
            catch
            {
                return Task.FromResult<string?>(null);
            }
        }

        public Task<string?> GetUsernameAsync()
        {
            try
            {
                return Task.FromResult(_currentSession?.Username);
            }
            catch
            {
                return Task.FromResult<string?>(null);
            }
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var response = await AuthApiClient.LoginAsync(username, password);

            if (response != null && !string.IsNullOrWhiteSpace(response.Token))
            {
                _currentSession = response;

                // Guardamos la sesión cifrada en el navegador
                await _localStorage.SetAsync("sesion_usuario", response);

                AuthenticationStateChanged?.Invoke(true);
                return true;
            }

            return false;
        }

        public async Task LogoutAsync()
        {
            _currentSession = null;

            // Borramos la sesión del navegador
            await _localStorage.DeleteAsync("sesion_usuario");

            AuthenticationStateChanged?.Invoke(false);
        }

        public async Task CheckTokenExpirationAsync()
        {
            if (!await IsAuthenticatedAsync())
            {
                await LogoutAsync();
            }
        }

        public Task<bool> HasPermissionAsync(string permission)
        {
            try
            {
                var token = _currentSession?.Token;
                if (string.IsNullOrEmpty(token))
                    return Task.FromResult(false);

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadJwtToken(token);

                var permissionClaims = jsonToken.Claims
                    .Where(c => c.Type == "permission")
                    .Select(c => c.Value);

                return Task.FromResult(permissionClaims.Contains(permission));
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

       
        public async Task CargarSesionGuardadaAsync()
        {
            try
            {
                var result = await _localStorage.GetAsync<LoginResponse>("sesion_usuario");

                if (result.Success && result.Value != null)
                {
                    // Verificamos que no esté expirada antes de restaurarla
                    if (DateTime.UtcNow < result.Value.ExpiresAt)
                    {
                        _currentSession = result.Value;
                        AuthenticationStateChanged?.Invoke(true);
                    }
                    else
                    {
                        await LogoutAsync();
                    }
                }
            }
            catch
            {
                // Si ocurre un error leyendo el LocalStorage (ej. datos corruptos), se ignora y queda deslogueado
            }
        }
    }
}