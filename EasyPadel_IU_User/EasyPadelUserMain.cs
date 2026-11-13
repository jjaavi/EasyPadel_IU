using EasyPadel_IU_User;
using EasyPadel_User;
using System.Diagnostics;
using System.Net.Http;
using System.Xml;

namespace EasyPadel
{
    internal static class EasyPadelUserMain
    {
        private const string VariablesFilePath = @"Resources\variables.xml";

        private static readonly HttpClient HttpClient = new()
        {
            Timeout = TimeSpan.FromSeconds(2)
        };

        internal static string BaseApiUrl = String.Empty;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            BaseApiUrl = GetVariablesXml();

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
                using HttpResponseMessage response = HttpClient.GetAsync($"{BaseApiUrl}/status").GetAwaiter().GetResult();
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        private static string GetVariablesXml()
        {
            try
            {
                string configPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, VariablesFilePath));
                if (!File.Exists(configPath))
                {
                    return "http://localhost:8080";
                }

                XmlDocument doc = new();
                doc.Load(configPath);
                string? value = doc.SelectSingleNode("/variables/baseApiUrl")?.InnerText?.Trim();

                return string.IsNullOrWhiteSpace(value) ? "http://localhost:8080" : value;
            }
            catch
            {
                return "http://localhost:8080";
            }
        }

    }
}
