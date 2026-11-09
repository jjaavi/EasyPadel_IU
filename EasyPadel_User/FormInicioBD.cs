using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace EasyPadel_User
{
    public partial class FormInicioBD : Form
    {
        public FormInicioBD()
        {
            InitializeComponent();
            btnInstalarBD.Click += btnInstalarBD_Click;
        }

        private void btnInstalarBD_Click(object? sender, EventArgs e)
        {
            string host = txtHost.Text.Trim();
            string port = txtPort.Text.Trim();
            string adminUser = txtUserAdmin.Text.Trim();
            string adminPassword = txtPassworAdmin.Text;

            if (string.IsNullOrWhiteSpace(host) ||
                string.IsNullOrWhiteSpace(port) ||
                string.IsNullOrWhiteSpace(adminUser) ||
                string.IsNullOrWhiteSpace(adminPassword))
            {
                MessageBox.Show("Cal indicar les dades per conectar a la bd de MySQL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string serverDirectory = Path.Combine(AppContext.BaseDirectory, "server");
                string bdDirectory = Path.Combine(AppContext.BaseDirectory, "bd");
                Directory.CreateDirectory(serverDirectory);

                string appPropertiesPath = Path.Combine(serverDirectory, "application.properties");
                string dbUrl = $"jdbc:mysql://{host}:{port}/easy_padel";

                string content =
                    "spring.application.name=easypadel-backend" + Environment.NewLine + Environment.NewLine +
                    "# Base de dades" + Environment.NewLine +
                    $"spring.datasource.url=${{DB_URL:{dbUrl}}}" + Environment.NewLine +
                    $"spring.datasource.username=${{DB_USER:{adminUser}}}" + Environment.NewLine +
                    $"spring.datasource.password=${{DB_PASSWORD:{adminPassword}}}" + Environment.NewLine + Environment.NewLine +
                    "# L'esquema el gestiona bd/bd.sql" + Environment.NewLine +
                    "spring.jpa.hibernate.ddl-auto=none" + Environment.NewLine +
                    "spring.jpa.open-in-view=false" + Environment.NewLine;

                File.WriteAllText(appPropertiesPath, content, new UTF8Encoding(false));

                string bdScriptPath = Path.Combine(bdDirectory, "bd.sql");

                string sqlScript = File.ReadAllText(bdScriptPath, Encoding.UTF8);
                string connectionString = $"Server={host};Port={port};User ID={adminUser};Password={adminPassword};SslMode=None;AllowPublicKeyRetrieval=True;Allow User Variables=True;";

                try
                {
                    using var connection = new MySqlConnection(connectionString);
                    connection.Open();

                    var script = new MySqlScript(connection, sqlScript);
                    script.Execute();

                    MessageBox.Show("Base de dades creades correctament.", "Informació", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult messageBoxDadesProva = MessageBox.Show(
                        "Vols inserir dades de prova? Es recomana per una primera execució.",
                        "Dades de prova",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (messageBoxDadesProva == DialogResult.Yes)
                    {
                        string dadesProvaScriptPath = Path.Combine(bdDirectory, "dades_prova.sql");
                        string dadesProvaScript = File.ReadAllText(dadesProvaScriptPath, Encoding.UTF8);

                        var dadesScript = new MySqlScript(connection, dadesProvaScript);
                        dadesScript.Execute();

                        MessageBox.Show(
                            "S'han inserit dades de prova a la bd." + Environment.NewLine +
                            "S'ha inserit els seguents socis:" + Environment.NewLine +
                            "marc.garcia@gmail.com" + Environment.NewLine +
                            "laura.pons@gmail.com" + Environment.NewLine +
                            "Y l'usuari admin:" + Environment.NewLine +
                            "jjaavi@gmail.com" + Environment.NewLine +
                            "Tots tenen el password: 12345678." + Environment.NewLine + Environment.NewLine +
                            "Recorda'l per poder fer un primer login.",
                            "Informació",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    connection.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(
                        "Error connectant a MySQL Server. " + Environment.NewLine + 
                        "Repasa les credencials." + Environment.NewLine + 
                        "Assegura't que el daemon de MySQL Server està iniciat.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                
                DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("No s'ha pogut preparar la configuració inicial de base de dades.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object? sender, EventArgs e)
        {
        }
    }
}
