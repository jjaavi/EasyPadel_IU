using System.Net.Http.Json;

namespace EasyPadel_User
{
    public partial class FormLogin : Form
    {
        private const string PlaceholderUsuari = "Correu electrònic";
        private const string PlaceholderPassword = "Contrasenya";
        private static readonly HttpClient HttpClient = new();
        private readonly string baseApiUrl;

        public FormLogin(string baseApiUrl)
        {
            InitializeComponent();
            this.baseApiUrl = baseApiUrl;
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

            LoginResponseDto? loginResponse = await ejecutarLogin(baseApiUrl, textBoxUsuari.Text.Trim(), textBoxPassword.Text);
            if (loginResponse is null ||
                !loginResponse.Correcte ||
                loginResponse.IdUsuari is null ||
                string.IsNullOrWhiteSpace(loginResponse.Rol))
            {
                MessageBox.Show("No s'ha pogut iniciar sessió. Si us plau, revisa els camps.");
                return;
            }

            SessionContext.UsuariId = loginResponse.IdUsuari.Value;
            SessionContext.Rol = loginResponse.Rol;
            SessionContext.EmailUsuari = textBoxUsuari.Text.Trim();

            Form newForm;
            if (string.Equals(loginResponse.Rol, "ADMIN", StringComparison.OrdinalIgnoreCase))
            {
                newForm = new FormAdministrador(baseApiUrl);
            }
            else
            {
                newForm = new FormUsuari(baseApiUrl);
            }

            Hide();
            newForm.FormClosed += (_, _) => Close();
            newForm.Show();
        }

        private static async Task<LoginResponseDto?> ejecutarLogin(string baseApiUrl, string email, string password)
        {
            var loginRequest = new LoginRequestDto(email, password);

            try
            {
                using HttpResponseMessage response = await HttpClient.PostAsJsonAsync($"{baseApiUrl}/api/usuaris/login", loginRequest);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<LoginResponseDto>();
            }
            catch
            {
                return null;
            }
        }

        private sealed record LoginRequestDto(string Email, string Password);

        private sealed record LoginResponseDto(bool Correcte, int? IdUsuari, string? Rol, string? Missatge);
    }

    public static class SessionContext
    {
        public static int UsuariId { get; set; }

        public static string Rol { get; set; } = string.Empty;

        public static string EmailUsuari { get; set; } = string.Empty;
    }
}
