namespace API.Clients
{
  public sealed class SessionExpiredException : UnauthorizedAccessException
  {
    public SessionExpiredException()
        : base("La sesión expiró o dejó de ser válida. Debe volver a iniciar sesión.")
    {
    }
  }
}