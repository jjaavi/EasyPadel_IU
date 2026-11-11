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
            using var loadingDialog = new LoadingDialogForm("Conectant a la base de dades...");
            loadingDialog.Show();
            loadingDialog.Refresh();

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
