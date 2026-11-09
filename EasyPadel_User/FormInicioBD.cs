using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

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

                if (!saveHostIPortVariables(host, port))
                {
                    MessageBox.Show("No s'ha pogut guardar host i port a Resources/variables.xml.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(
                        "Error executant bd.sql." + Environment.NewLine + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Base de dades creades correctament.", "Informació", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
                MessageBox.Show("No s'ha pogut preparar la configuració inicial de base de dades.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool saveHostIPortVariables(string host, string port)
        {
            try
            {
                string xmlPath = Path.Combine(AppContext.BaseDirectory, "Resources", "variables.xml");

                var doc = new XmlDocument();
                doc.Load(xmlPath);

                XmlNode? root = doc.SelectSingleNode("/variables");
                if (root is null)
                {
                    return false;
                }

                XmlNode? hostNode = root.SelectSingleNode("host");
                hostNode.InnerText = host;

                XmlNode? portNode = root.SelectSingleNode("port");
                portNode.InnerText = port;

                doc.Save(xmlPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void label1_Click(object? sender, EventArgs e)
        {
        }
    }
}
