using EasyPadel_User;
using System.Diagnostics;
using System.Net.Http;
using System.Xml;

namespace EasyPadel_IU_Server
{
    public partial class FormIUServer : Form
    {
        private const string VariablesFilePath = @"Resources\variables.xml";

        private static readonly HttpClient HttpClient = new()
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        private Process? serverProcess;
        private int serverProcessId;

        public FormIUServer()
        {
            InitializeComponent();
            btnArrancarServidor.Click += btnArrancarServidor_Click;
            btnParar.Click += btnParar_Click;
            FormClosing += FormIUServer_FormClosing;
            ActualitzarEstatServidor(false);
        }

        private void btnArrancarServidor_Click(object? sender, EventArgs e)
        {
            bool iniciat = StartServer();
            if (!iniciat)
            {
                MessageBox.Show("No s'ha pogut arrancar el servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActualitzarEstatServidor(false);
                return;
            }
            MessageBox.Show("Servidor arrancat correctament.", "Informació", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ActualitzarEstatServidor(true);
        }

        private void btnParar_Click(object? sender, EventArgs e)
        {
            StopServer();
            ActualitzarEstatServidor(false);
        }

        private void FormIUServer_FormClosing(object? sender, FormClosingEventArgs e)
        {   
            if (serverProcess is not null && !serverProcess.HasExited)
            {
                DialogResult confirmacio = MessageBox.Show(
                "Si tanca l'aplicació, el server es pararà." + Environment.NewLine + 
                "Segur que vol parar-ho?",
                "Confirmació",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
                if (confirmacio == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                StopServer();
            }
        }

        private bool StartServer()
        {
            if (!SetupServer())
            {
                return false;
            }

            return TryStartBackendAndWaitUntilReady();
        }

        private void StopServer()
        {
            try
            {
                if (serverProcess is not null && !serverProcess.HasExited)
                {
                    serverProcess.Kill(true);
                    serverProcess.WaitForExit(3000);
                    MessageBox.Show("Servidor aturat correctament.", "Informació", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("No s'ha aturat el servidor correctament.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                serverProcess?.Dispose();
                serverProcess = null;
            }
        }

        private bool TryStartBackendAndWaitUntilReady()
        {
            using var loadingMessage = CarregantMessageBox();
            loadingMessage.Show();
            loadingMessage.Refresh();

            bool started = Task.Run(StartServerBackendProcess).GetAwaiter().GetResult();
            Thread.Sleep(1000);
            if (!started)
            {
                return false;
            }

            Stopwatch timeout = Stopwatch.StartNew();
            while (timeout.Elapsed < TimeSpan.FromSeconds(45))
            {
                Application.DoEvents();

                if (IsServerReady())
                {
                    return true;
                }

                Thread.Sleep(1000);
            }

            StopServer();
            return false;
        }

        private bool StartServerBackendProcess()
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
            serverProcessId = serverProcess?.Id ?? 0;
            return serverProcess is not null;
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

        private static string? GetServerPathFromXml()
        {
            string configPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, VariablesFilePath));

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

        private static bool SetupServer()
        {
            string applicationPropertiesPath = Path.Combine(AppContext.BaseDirectory, "server", "application.properties");
            string applicationPropertiesContent = File.ReadAllText(applicationPropertiesPath);
            if (!string.IsNullOrWhiteSpace(applicationPropertiesContent))
            {
                return true;
            }

            using var formInicioBd = new FormSetupServer();
            DialogResult result = formInicioBd.ShowDialog();
            return result == DialogResult.OK;
        }

        private void ActualitzarEstatServidor(bool iniciat)
        {
            if (iniciat)
            {
                btnArrancarServidor.Enabled = false;
                btnParar.Enabled = true;
                panelEstatServidorOK.Visible = true;
                panelEstatServidorNotOK.Visible = false;
            }
            else
            {
                btnArrancarServidor.Enabled = true;
                btnParar.Enabled = false;
                panelEstatServidorOK.Visible = false;
                panelEstatServidorNotOK.Visible = true; 
            }
        }

        private static Form CarregantMessageBox()
        {
            Form messageForm = new()
            {
                FormBorderStyle = FormBorderStyle.FixedDialog,
                ControlBox = false,
                StartPosition = FormStartPosition.CenterScreen,
                ShowInTaskbar = false,
                TopMost = true,
                MinimizeBox = false,
                MaximizeBox = false,
                ClientSize = new Size(360, 90),
                BackColor = Color.FromArgb(213, 221, 40),
                Text = "EasyPadel"
            };

            messageForm.FormClosing += (_, e) => e.Cancel = true;

            Label label = new()
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "Arrencant el servidor...",
                ForeColor = Color.Black,
                BackColor = Color.FromArgb(213, 221, 40)
            };

            messageForm.Controls.Add(label);
            return messageForm;
        }
    }
}
