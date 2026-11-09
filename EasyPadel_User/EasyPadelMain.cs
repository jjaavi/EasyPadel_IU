using EasyPadel_User;
using System.Diagnostics;
using System.Net.Http;
using System.Xml;

namespace EasyPadel
{
    internal static class EasyPadelMain
    {
        private const string variablesFilePath = @"Resources\variables.xml";

        private static readonly HttpClient HttpClient = new()
        {
            Timeout = TimeSpan.FromSeconds(2)
        };

        private static Process? serverProcess;
        private static int serverProcessId;
        private static string BaseApiUrl = string.Empty;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.ApplicationExit += (_, _) => StopServerProcess();

            if (!PrimerIniciCreacioDB())
            {
                return;
            }

            String host = string.Empty;
            String port = string.Empty;
            (host, port) = GetHostAndPortFromVariablesXml();
            BaseApiUrl = $"http://{host}:{port}";

            if (!TryStartBackendAndWaitUntilReady())
            {
                MessageBox.Show("No s'ha pogut conectar amb la base de dades. Si us plau, reinicii la aplicació.");
                StopServerProcess();
                return;
            }

            Application.Run(new FormLogin(BaseApiUrl));
        }

        private static bool TryStartBackendAndWaitUntilReady()
        {
            using var loadingDialog = new LoadingDialogForm("Conectant a la base de dades...");
            loadingDialog.Show();
            loadingDialog.Refresh();

            bool started = Task.Run(StartServerBackendProcess).GetAwaiter().GetResult();
            if (!started)
            {
                return false;
            }

            Stopwatch timeout = Stopwatch.StartNew();
            while (timeout.Elapsed < TimeSpan.FromSeconds(30))
            {
                Application.DoEvents();

                if (IsServerReady())
                {
                    return true;
                }

                Thread.Sleep(500);
            }

            return false;
        }

        private static bool StartServerBackendProcess()
        {
            string? path = GetServerPathFromXml();
            if (string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            string jarPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, path));
            if (!File.Exists(jarPath))
            {
                return false;
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = "java",
                Arguments = $"-jar \"{jarPath}\" --spring.config.additional-location=file:application.properties",
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = Path.GetDirectoryName(jarPath) ?? string.Empty
            };

            serverProcess = Process.Start(startInfo);
            if (serverProcess is null)
            {
                return false;
            }

            serverProcessId = serverProcess.Id;
            return serverProcessId > 0;
        }

        private static bool IsServerReady()
        {
            using HttpResponseMessage response = HttpClient.GetAsync($"http://localhost:8080/status").GetAwaiter().GetResult();
            return response.IsSuccessStatusCode;
        }

        private static (string host, string port) GetHostAndPortFromVariablesXml()
        {
            string host = string.Empty;
            string port = string.Empty;

            string configPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, variablesFilePath));
            if (!File.Exists(configPath))
            {
                return (host, port);
            }

            XmlDocument doc = new();
            doc.Load(configPath);

            XmlNode? hostNode = doc.SelectSingleNode("/variables/host");
            XmlNode? portNode = doc.SelectSingleNode("/variables/port");

            if (hostNode is not null)
            {
                host = hostNode.InnerText.Trim();
            }

            if (portNode is not null)
            {
                port = portNode.InnerText.Trim();
            }

            return (host, port);
        }

        private static string? GetServerPathFromXml()
        {
            string configPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, variablesFilePath));

            using XmlReader reader = XmlReader.Create(configPath, new XmlReaderSettings { IgnoreComments = true, IgnoreWhitespace = true });
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "serverJarPath")
                {
                    string? value = reader.ReadElementContentAsString();
                    return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
                }
            }

            return null;
        }

        private static bool PrimerIniciCreacioDB()
        {
            string applicationPropertiesPath = Path.Combine(AppContext.BaseDirectory, "server", "application.properties");
            if (File.Exists(applicationPropertiesPath))
            {
                return true;
            }

            using var formInicioBd = new FormInicioBD();
            DialogResult result = formInicioBd.ShowDialog();
            return result == DialogResult.OK;
        }

        private static void StopServerProcess()
        {
            try
            {
                if (serverProcess is not null && !serverProcess.HasExited)
                {
                    serverProcess.Kill(true);
                    serverProcess.WaitForExit(3000);
                }
            }
            catch
            {
            }
        }

        private sealed class LoadingDialogForm : Form
        {
            public LoadingDialogForm(string message)
            {
                FormBorderStyle = FormBorderStyle.FixedDialog;
                ControlBox = false;
                StartPosition = FormStartPosition.CenterScreen;
                ShowInTaskbar = false;
                TopMost = true;
                MinimizeBox = false;
                MaximizeBox = false;
                ClientSize = new Size(360, 90);
                BackColor = Color.FromArgb(213, 221, 40);

                var label = new Label
                {
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = message,
                    ForeColor = Color.Black,
                    BackColor = Color.FromArgb(213, 221, 40)
                };

                Controls.Add(label);
            }
        }
    }
}
