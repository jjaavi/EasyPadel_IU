using System;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace EasyPadel_User
{
    public partial class FormAdministrdor_EditaOAltaUsuari : Form
    {
        private static readonly HttpClient HttpClient = new();
        private static readonly char[] PasswordSpecialChars = "!@#$%^&*()-_=+[]{}".ToCharArray();

        private readonly bool modificar;
        private readonly int? usuariId;
        private readonly bool actiuDataGrid;
        private bool missatgePasswordMostrat;

        public FormAdministrdor_EditaOAltaUsuari(bool modificar, int? usuariId = null, string nom = "", string cognom = "", string telefon = "", string email = "", bool admin = false, bool actiu = true)
        {
            InitializeComponent();
            this.modificar = modificar;
            this.usuariId = usuariId;
            actiuDataGrid = actiu;

            txtNom.Text = nom;
            txtCognom.Text = cognom;
            txtTelefon.Text = telefon;
            txtEmail.Text = email;

            if (modificar)
            {
                txtPassword.Enabled = true;
                txtPassword.Click += txtPassword_Click;
                checkBoxAdmin.Checked = admin;
            }
            else
            {
                txtPassword.Text = "Generada automaticament";
                txtPassword.Enabled = false;
            }

            btnCancelar.Click += btnCancelar_Click;
            btnGuardar.Click += btnGuardar_Click;
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtPassword_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "S'esta forçant la modificació del password de l'usuari per restaurar la contraseña. Deixa en blanc el password per a NO modificar el password. Escriu qualsevol cosa per generar un password temporal nou.",
                "Informació",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            string nom = txtNom.Text.Trim();
            string cognom = txtCognom.Text.Trim();
            string email = txtEmail.Text.Trim();
            string? telefon = string.IsNullOrWhiteSpace(txtTelefon.Text) ? null : txtTelefon.Text.Trim();
            string rol;
            if (checkBoxAdmin.Checked){
                rol = "ADMIN";
            }else{
                rol = "USER";
            }

            if (string.IsNullOrWhiteSpace(nom)
                || string.IsNullOrWhiteSpace(cognom)
                || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Els camps nom, cognom i email són obligatoris.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string? passwordTemporal = null;

            //MODIFICACIÓ de l'usuari
            if (modificar)
            {
                bool restarurPassword = !string.IsNullOrWhiteSpace(txtPassword.Text);
                Object request;
                if (restarurPassword)
                {
                    passwordTemporal = GenerarPasswordTemporal(8, 20);
                    request = new UsuariUpdateRequestDtoWithPass (
                        nom,
                        cognom,
                        email,
                        passwordTemporal,
                        telefon,
                        rol,
                    actiuDataGrid);
                }
                else
                {
                    request = new UsuariUpdateRequestDtoNoPass(
                        nom,
                        cognom,
                        email,
                        telefon,
                        rol,
                    actiuDataGrid);
                }

                try
                {
                    using HttpResponseMessage response = await HttpClient.PutAsJsonAsync(
                        $"http://localhost:8080/api/usuaris/{usuariId.Value}",
                        request);

                    if (response.IsSuccessStatusCode)
                    {
                        if (restarurPassword)
                        {
                            MessageBox.Show(
                                $"Usuari amb email {email} modificat correctament. El password temporal nou es {passwordTemporal}.",
                                "Modificació d'usuari.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Usuari modificat correctament.", "Usuari modificat.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No s'ha pogut modificar l'usuari.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("No s'ha pogut modificar l'usuari.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //ALTA d'un usuari
            else
            {
                passwordTemporal = GenerarPasswordTemporal(8, 20);
                UsuariCreateRequestDto createRequest = new(
                    nom,
                    cognom,
                    email,
                    passwordTemporal,
                    telefon,
                    rol,
                    true);
                try
                {
                    using HttpResponseMessage response = await HttpClient.PostAsJsonAsync(
                        "http://localhost:8080/api/usuaris",
                        createRequest);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(
                            $"Usuari amb email {email} creat correctament. El password temporal es {passwordTemporal}.",
                            "Informació",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No s'ha pogut crear l'usuari. Es posible que el email ja existeixi. Revisa els camps.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("No s'ha pogut crear l'usuari.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string GenerarPasswordTemporal(int minimLongitud, int maximLongitud)
        {
            int longitud = Random.Shared.Next(minimLongitud, maximLongitud + 1);
            const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            char digit = digits[Random.Shared.Next(digits.Length)];
            char special = PasswordSpecialChars[Random.Shared.Next(PasswordSpecialChars.Length)];

            char[] password = new char[longitud];
            password[0] = digit;
            password[1] = special;

            string alfabet = letters + digits + new string(PasswordSpecialChars);
            for (int i = 2; i < longitud; i++)
            {
                password[i] = alfabet[Random.Shared.Next(alfabet.Length)];
            }

            for (int i = password.Length - 1; i > 0; i--)
            {
                int j = Random.Shared.Next(i + 1);
                (password[i], password[j]) = (password[j], password[i]);
            }

            return new string(password);
        }

        private sealed record UsuariCreateRequestDto(
            [property: JsonPropertyName("nom")] string Nom,
            [property: JsonPropertyName("cognom")] string Cognom,
            [property: JsonPropertyName("email")] string Email,
            [property: JsonPropertyName("password")] string Password,
            [property: JsonPropertyName("telefon")] string? Telefon,
            [property: JsonPropertyName("rol")] string Rol,
            [property: JsonPropertyName("actiu")] bool Actiu);

        private sealed record UsuariUpdateRequestDtoWithPass(
            [property: JsonPropertyName("nom")] string Nom,
            [property: JsonPropertyName("cognom")] string Cognom,
            [property: JsonPropertyName("email")] string Email,
            [property: JsonPropertyName("password")] string? Password,
            [property: JsonPropertyName("telefon")] string? Telefon,
            [property: JsonPropertyName("rol")] string Rol,
            [property: JsonPropertyName("actiu")] bool Actiu);

        private sealed record UsuariUpdateRequestDtoNoPass(
            [property: JsonPropertyName("nom")] string Nom,
            [property: JsonPropertyName("cognom")] string Cognom,
            [property: JsonPropertyName("email")] string Email,
            [property: JsonPropertyName("telefon")] string? Telefon,
            [property: JsonPropertyName("rol")] string Rol,
            [property: JsonPropertyName("actiu")] bool Actiu);
    }
}
