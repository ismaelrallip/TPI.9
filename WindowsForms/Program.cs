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
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            MainAsync();
        }

        private static void MainAsync()
        {
            while (true)
            {
                using var loginForm = new LoginForm();
                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    // Cancela o cierra el login: cierra la app por completo
                    CerrarAplicacion();
                    return;
                }

                var session = AuthServiceProvider.Current?.CurrentSession;
                if (session == null)
                {
                    MessageBox.Show("No se pudo recuperar la sesión autenticada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CerrarAplicacion();
                    return;
                }

                if (session.Role == "Administrador")
                {
                    try
                    {
                        var home = new HomeAdministrador();
                        Application.Run(home);

                        if (home.LogoutRequested)
                        {
                            continue; // Vuelve al login
                        }
                        else
                        {
                            CerrarAplicacion();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error en la aplicación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CerrarAplicacion();
                        return;
                    }
                }
                else
                {
                    try
                    {
                        var home = new HomeCliente();
                        Application.Run(home);

                        if (home.LogoutRequested)
                        {
                            continue; // Vuelve al login
                        }
                        else
                        {
                            CerrarAplicacion();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error en la aplicación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CerrarAplicacion();
                        return;
                    }
                }
            }
        }

        private static void CerrarAplicacion()
        {
            Application.Exit();
            Environment.Exit(0); // Mata todo hilo residual de la WebAPI o conexiones activas
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"Error inesperado: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}