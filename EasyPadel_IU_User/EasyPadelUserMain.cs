using EasyPadel_IU_User;
using EasyPadel_User;
using System.Diagnostics;
using System.Net.Http;

namespace EasyPadel
{
    internal static class EasyPadelUserMain
    {
        private static readonly HttpClient HttpClient = new()
        {
            Timeout = TimeSpan.FromSeconds(2)
        };

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            if (!TryStartBackendAndWaitUntilReady())
            {
                return;
            }

            Application.Run(new FormLogin());
        }

        private static bool TryStartBackendAndWaitUntilReady()
        {
            using var loadingDialog = new FormLoading{};

            loadingDialog.Show();
            loadingDialog.Refresh();

            Stopwatch timeout = Stopwatch.StartNew();
            while (timeout.Elapsed < TimeSpan.FromSeconds(10))
            {
                Application.DoEvents();

                if (IsServerReady())
                {
                    return true;
                }

                Thread.Sleep(500);
            }

            MessageBox.Show("No s'ha pogut conectar a la base de dades. Intenta-ho més tard");
            return false;
        }

        private static bool IsServerReady()
        {
            try
            {
                using HttpResponseMessage response = HttpClient.GetAsync("http://localhost:8080/status").GetAwaiter().GetResult();
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

    }
}
