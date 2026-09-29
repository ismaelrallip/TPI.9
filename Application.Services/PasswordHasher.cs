using System.Security.Cryptography;

namespace Application.Services
{
  internal static class PasswordHasher
  {
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 100_000;
    private const string Prefix = "PBKDF2-SHA256";

    public static string Hash(string password)
    {
      var salt = RandomNumberGenerator.GetBytes(SaltSize);
      var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, HashSize);
      return $"{Prefix}${Iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
    }

    public static bool Verify(string password, string storedValue)
    {
      var parts = storedValue.Split('$');
      if (parts.Length != 4 || parts[0] != Prefix || !int.TryParse(parts[1], out var iterations))
        return false;

      try
      {
        var salt = Convert.FromBase64String(parts[2]);
        var expectedHash = Convert.FromBase64String(parts[3]);
        var actualHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, expectedHash.Length);
        return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
      }
      catch (FormatException)
      {
        return false;
      }
    }
  }
}