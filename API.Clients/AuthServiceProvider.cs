namespace API.Clients
{
  public static class AuthServiceProvider
  {
    private static IAuthService? instance;

    public static IAuthService? Current => instance;

    public static void Register(IAuthService authService)
    {
      instance = authService ?? throw new ArgumentNullException(nameof(authService));
    }

    public static void Clear()
    {
      instance = null;
    }
  }
}