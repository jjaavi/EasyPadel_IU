using System.Net;
using System.Net.Http.Json;

namespace EasyPadel_User
{
    public partial class FormLogin : Form
    {
        private const string PlaceholderUsuari = "Correu electrònic";
        private const string PlaceholderPassword = "Contrasenya";
        private static string BaseApiUrl => EasyPadel.EasyPadelUserMain.BaseApiUrl;
        private static readonly HttpClient HttpClient = new();

        public FormLogin()
        {
            InitializeComponent();
            InicialitzarPlaceholders();
        }

        private void InicialitzarPlaceholders()
        {
            MostrarPlaceholder(textBoxUsuari, PlaceholderUsuari, false);
            MostrarPlaceholder(textBoxPassword, PlaceholderPassword, true);

            textBoxUsuari.Enter += textBoxUsuari_Enter;
            textBoxUsuari.Leave += textBoxUsuari_Leave;
            textBoxPassword.Enter += textBoxPassword_Enter;
            textBoxPassword.Leave += textBoxPassword_Leave;
        }

        private void textBoxUsuari_Enter(object? sender, EventArgs e)
        {
            TreurePlaceholder(textBoxUsuari, PlaceholderUsuari, false);
        }

        private void textBoxUsuari_Leave(object? sender, EventArgs e)
        {
            RestaurarPlaceholder(textBoxUsuari, PlaceholderUsuari, false);
        }

        private void textBoxPassword_Enter(object? sender, EventArgs e)
        {
            TreurePlaceholder(textBoxPassword, PlaceholderPassword, true);
        }

        private void textBoxPassword_Leave(object? sender, EventArgs e)
        {
            RestaurarPlaceholder(textBoxPassword, PlaceholderPassword, true);
        }

        private static void MostrarPlaceholder(TextBox textBox, string placeholder, bool esPassword)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.DarkGray;
            textBox.UseSystemPasswordChar = false;
        }

        private static void TreurePlaceholder(TextBox textBox, string placeholder, bool esPassword)
        {
            if (textBox.ForeColor == Color.DarkGray && textBox.Text == placeholder)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = SystemColors.WindowText;
                textBox.UseSystemPasswordChar = esPassword;
            }
        }

        private static void RestaurarPlaceholder(TextBox textBox, string placeholder, bool esPassword)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MostrarPlaceholder(textBox, placeholder, esPassword);
            }
        }

        private async void Login_Click(object sender, EventArgs e)
        {
            bool mailBuit = string.IsNullOrWhiteSpace(textBoxUsuari.Text) ||
                            (textBoxUsuari.ForeColor == Color.DarkGray && textBoxUsuari.Text == PlaceholderUsuari);

            bool passwordBuit = string.IsNullOrWhiteSpace(textBoxPassword.Text) ||
                                (textBoxPassword.ForeColor == Color.DarkGray && textBoxPassword.Text == PlaceholderPassword);

            if (mailBuit || passwordBuit)
            {
                MessageBox.Show("S'han d'emplenar els camps mail i password.");
                return;
            }

            LoginResult loginResult = await ejecutarLogin(textBoxUsuari.Text.Trim(), textBoxPassword.Text);
            if (loginResult.Response is null ||
                !loginResult.Response.Correcte ||
                loginResult.Response.IdUsuari is null ||
                string.IsNullOrWhiteSpace(loginResult.Response.Rol))
            {
                if (loginResult.StatusCode == HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("L'usuari està desactivat.");
                }
                else if (loginResult.StatusCode == HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Credencials incorrectes.");
                }
                else
                {
                    MessageBox.Show("No s'ha pogut iniciar sessió. Si us plau, revisa els camps.");
                }

                return;
            }

            SessionContext.UsuariId = loginResult.Response.IdUsuari.Value;
            SessionContext.Rol = loginResult.Response.Rol;
            SessionContext.EmailUsuari = textBoxUsuari.Text.Trim();

            Form newForm;
            if (string.Equals(loginResult.Response.Rol, "ADMIN", StringComparison.OrdinalIgnoreCase))
            {
                newForm = new FormAdministrador();
            }
            else
            {
                newForm = new FormUsuari();
            }

            Hide();
            newForm.FormClosed += (_, _) => Close();
            newForm.Show();
        }

        private static async Task<LoginResult> ejecutarLogin(string email, string password)
        {
            var loginRequest = new LoginRequestDto(email, password);

            try
            {
                using HttpResponseMessage response = await HttpClient.PostAsJsonAsync($"{BaseApiUrl}/api/usuaris/login", loginRequest);
                LoginResponseDto? loginResponse = null;

                if (response.IsSuccessStatusCode)
                {
                    loginResponse = await response.Content.ReadFromJsonAsync<LoginResponseDto>();
                }

                return new LoginResult(loginResponse, response.StatusCode);
            }
            catch
            {
                return new LoginResult(null, null);
            }
        }

        private sealed record LoginRequestDto(string Email, string Password);

        private sealed record LoginResponseDto(bool Correcte, int? IdUsuari, string? Rol, string? Missatge);

        private sealed record LoginResult(LoginResponseDto? Response, HttpStatusCode? StatusCode);
    }

    public static class SessionContext
    {
        public static int UsuariId { get; set; }

        public static string Rol { get; set; } = string.Empty;

        public static string EmailUsuari { get; set; } = string.Empty;
    }
}
