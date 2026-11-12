using System;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace EasyPadel_User
{
    public partial class Form_CanviarContrasenya : Form
    {
        private static string BaseApiUrl => EasyPadel.EasyPadelUserMain.BaseApiUrl;
        private static readonly HttpClient HttpClient = new();

        public Form_CanviarContrasenya()
        {
            InitializeComponent();

            btnCanviarContrasenya.Click += btnCanviarContrasenya_Click;
            btnCancelar.Click += btnCancelar_Click;

            MessageBox.Show(
                "La contrasenya ha de tenir:\r\n" +
                "- Mínim de 8 caràcters i màxim de 20.\r\n" +
                "- Un caràcter especial (+*-,.$, ...).\r\n" +
                "- Un número (1,2,3,...).\r\n" +
                "Recorda confirmar la password actual per poder fer el canvi.",
                "Canviar password",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private async void btnCanviarContrasenya_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswordActual.Text) || string.IsNullOrWhiteSpace(txtPasswordNou.Text))
            {
                MessageBox.Show("Has d'indicar la contrasenya actual i la nova.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult okdialog = MessageBox.Show(
                "Segur que vols fer el canvi de contrasenya?",
                "Confirmació",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (okdialog != DialogResult.Yes)
            {
                return;
            }

            string nouPassword = txtPasswordNou.Text.Trim();
            if (!validarFormatPassword(nouPassword))
            {
                MessageBox.Show("La nova contrasenya ha de tenir entre 8 i 20 caràcters, contenir almenys un número i un caràcter especial, i no superar 72 bytes UTF-8.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                PasswordRequestDto request = new(
                    txtPasswordActual.Text,
                    nouPassword);

                using HttpResponseMessage response = await HttpClient.PutAsJsonAsync(
                    $"{BaseApiUrl}/api/usuaris/{SessionContext.UsuariId}/password",
                    request);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Contrasenya actualitzada correctament.", "Informació", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("No s'ha pogut canviar la contrasenya. Revisa que la contrasenya actual sigui correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("No s'ha pogut canviar la contrasenya.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private static bool validarFormatPassword(string nouPassword)
        {
            if (nouPassword.Length < 8 || nouPassword.Length > 20)
            {
                return false;
            }

            if (!nouPassword.Any(char.IsDigit) || !nouPassword.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                return false;
            }

            if (Encoding.UTF8.GetByteCount(nouPassword) > 72)
            {
                return false;
            }

            return true;
        }

        private sealed record PasswordRequestDto(
            [property: JsonPropertyName("passwordActual")] string PasswordActual,
            [property: JsonPropertyName("novaPassword")] string NovaPassword);
    }
}
