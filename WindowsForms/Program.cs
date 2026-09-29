using System;
using System.Threading;
using System.Windows.Forms;
using API.Auth.WindowsForms;
using API.Clients;

namespace WindowsForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            AuthServiceProvider.Register(new WindowsFormsAuthService());
            System.Windows.Forms.Application.ThreadException += Application_ThreadException;
            System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            MainAsync();
        }

        private static void MainAsync()
        {
            while (true)
            {
                using var loginForm = new LoginForm();
                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    return; // Cancela el login: cierra la app.
                }

                var session = AuthServiceProvider.Current?.CurrentSession;
                if (session == null)
                {
                    MessageBox.Show("No se pudo recuperar la sesión autenticada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (session.Role == "Administrador")
                {
                    try
                    {
                        
                        var home = new HomeAdministrador();
                        System.Windows.Forms.Application.Run(home);

                        
                        if (home.LogoutRequested)
                        {
                            
                            continue;
                        }
                        else
                        {
                            return; // cerrar la app
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error en la aplicacion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    // Todavia no armamos la pantalla del Cliente.
                    MessageBox.Show("La pantalla para Clientes todavia no esta disponible.", "Aviso",
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