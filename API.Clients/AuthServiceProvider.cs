
namespace API.Clients
{
    public static class AuthServiceProvider
    {
        private static IAuthService? instance;
        private static Func<IAuthService?>? resolver;

       
        public static IAuthService? Current => resolver?.Invoke() ?? instance;

        public static void Register(IAuthService authService)
        {
            instance = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        public static void RegisterResolver(Func<IAuthService?> authServiceResolver)
        {
            resolver = authServiceResolver ?? throw new ArgumentNullException(nameof(authServiceResolver));
        }

        public static void Clear()
        {
            instance = null;
            resolver = null;
        }
    }
}