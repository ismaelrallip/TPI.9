using System;
using System.Threading;
using System.Windows.Forms;

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
                        // Crear instancia y mantener referencia para leer la bandera después
                        var home = new HomeAdministrador();
                        System.Windows.Forms.Application.Run(home);

                        // Si el home pidió logout, continuamos el while para volver al login;
                        // si no (usuario cerró la ventana para salir), terminamos la app.
                        if (home.LogoutRequested)
                        {
                            // continuar el bucle: volver al login
                            continue;
                        }
                        else
                        {
                            return; // cerrar la app
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error en la aplicación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
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