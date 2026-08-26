
namespace WindowsForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            System.Windows.Forms.Application.ThreadException += Application_ThreadException;
            System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            MainAsync();
        }

        private static void MainAsync()
        {
            while (true)
            {
                using var loginForm = new LoginForm();
                if (loginForm.ShowDialog() != DialogResult.OK || loginForm.Sesion == null)
                {
                    return; // Canceló el login: cierra la app.
                }

                if (loginForm.Sesion.Role == "Administrador")
                {
                    try
                    {
                        System.Windows.Forms.Application.Run(new HomeAdministrador());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error en la aplicación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return; // Por ahora, al cerrar HomeAdministrador se termina la app (sin logout todavía).
                }
                else
                {
                    // Todavía no armamos la pantalla del Cliente.
                    MessageBox.Show("La pantalla para Clientes todavía no está disponible.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"Error inesperado: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}