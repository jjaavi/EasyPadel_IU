using System;
using System.Drawing;
using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyPadel_User
{
    public partial class FormAdministrador : Form
    {
        private const string BaseApiUrl = "http://localhost:8080";
        private static readonly HttpClient HttpClient = new();

        public FormAdministrador()
        {
            InitializeComponent();
            menuReserves.Click += menuReserves_Click;
            menuUsuaris.Click += menuUsuaris_Click;
            manuMantenimentPistes.Click += manuMantenimentPistes_Click;
            btnCercarReserva.Click += btnCercarReserva_Click;
            btnCercarUsuari.Click += btnCercarUsuari_Click;
            btnModificarReserva.Click += btnModificarReserva_Click;
            btnEliminarReserva.Click += btnEliminarReserva_Click;
            btnBaixaUsuari.Click += btnBaixaUsuari_Click;
            btnAltaUsuari.Click += btnAltaUsuari_Click;
            btnModificarUsuari.Click += btnModificarUsuari_Click;
            btnMostrarModificarPista.Click += btnMostrarModificarPista_Click;
            btnMotrarNovaPista.Click += btnMotrarNovaPista_Click;
            btnNovaPista.Click += btnNovaPista_Click;
            btnModificarPista.Click += btnModificarPista_Click;
            listBoxPistes.SelectedIndexChanged += listBoxPistes_SelectedIndexChanged;
            dataGridReserves.SelectionChanged += dataGridReserves_SelectionChanged;
            dataGridViewUsuaris.SelectionChanged += dataGridViewUsuaris_SelectionChanged;
            dataGridReserves.CellContentDoubleClick += btnModificarReserva_Click;
            dataGridViewUsuaris.CellContentDoubleClick += btnModificarUsuari_Click;
        }

        private async Task MostrarPanelActiu(Panel panelVisible)
        {
            panelReserves.Visible = panelVisible == panelReserves;
            panelUsuaris.Visible = panelVisible == panelUsuaris;
            panelMantenimentDePistes.Visible = panelVisible == panelMantenimentDePistes;

            if (panelReserves.Visible)
            {
                await InicialitzarPanellReservesAsync();
            }
            if (panelUsuaris.Visible)
            {
                await InicialitzarPanellUsuarisAsync();
            }
            if (panelMantenimentDePistes.Visible)
            {
                await InicialitzarPanellMantenimentDePistesAsync();
            }
        }

        private async void menuReserves_Click(object? sender, EventArgs e)
        {
            await MostrarPanelActiu(panelReserves);
        }

        private async void menuUsuaris_Click(object? sender, EventArgs e)
        {
            await MostrarPanelActiu(panelUsuaris);
        }

        private async void manuMantenimentPistes_Click(object? sender, EventArgs e)
        {
            await MostrarPanelActiu(panelMantenimentDePistes);
        }

        private async Task InicialitzarPanellReservesAsync()
        {
            btnModificarReserva.Enabled = false;
            btnEliminarReserva.Enabled = false;

            if (comboBoxFiltreTorn.Items.Count == 0)
            {
                comboBoxFiltreTorn.Items.AddRange(
                [
                    string.Empty,
                    "08h-10h",
                    "10h-12h",
                    "12h-14h",
                    "14h-16h",
                    "16h-18h",
                    "18h-20h",
                    "20h-22h"
                ]);

                comboBoxFiltreTorn.SelectedIndex = 0;
            }

            await CarregarProperes20ReservesAsync();
            ActualitzarEstatBotonsReserves();
        }

        private async Task InicialitzarPanellUsuarisAsync()
        {
            btnBaixaUsuari.Enabled = false;
            btnModificarUsuari.Enabled = false;
            checkBoxEstat.Checked = true;
            dataGridViewUsuaris.DataSource = null;

            if (comboBoxRol.Items.Count == 0)
            {
                comboBoxRol.Items.AddRange(
                [
                    string.Empty,
                    "USER",
                    "ADMIN"
                ]);

                comboBoxRol.SelectedIndex = 0;
            }

            await Task.CompletedTask;
        }

        private async Task InicialitzarPanellMantenimentDePistesAsync()
        {
            foreach (Control control in panelModificarPista.Controls)
            {
                control.Visible = control == btnMostrarModificarPista;
            }

            foreach (Control control in panelNovaPista.Controls)
            {
                control.Visible = control == btnMotrarNovaPista;
            }

            await CarregarPistesMantenimentAsync();
        }

        private async Task CarregarPistesMantenimentAsync(int? selectedPistaId = null)
        {
            try
            {
                List<PistaMantenimentDto> pistes = await HttpClient.GetFromJsonAsync<List<PistaMantenimentDto>>($"{BaseApiUrl}/api/pistes")
                    ?? [];

                List<PistaListItem> pistesListBox = pistes
                    .Select(p => new PistaListItem(p.Id, p.Nom ?? string.Empty, p.Activa ?? true))
                    .ToList();

                listBoxPistes.DataSource = pistesListBox;

                if (pistesListBox.Count == 0)
                {
                    txtNomPista.Text = string.Empty;
                    checkBoxPistaActiva.Checked = false;
                    return;
                }

                if (selectedPistaId.HasValue)
                {
                    int selectedIndex = pistesListBox.FindIndex(p => p.Id == selectedPistaId.Value);
                    listBoxPistes.SelectedIndex = selectedIndex >= 0 ? selectedIndex : 0;
                }
                else
                {
                    listBoxPistes.SelectedIndex = 0;
                }
            }
            catch
            {
                listBoxPistes.DataSource = null;
                txtNomPista.Text = string.Empty;
                checkBoxPistaActiva.Checked = false;
                MessageBox.Show("No s'han pogut carregar les pistes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxPistes_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listBoxPistes.SelectedItem is not PistaListItem pistaSeleccionada)
            {
                txtNomPista.Text = string.Empty;
                checkBoxPistaActiva.Checked = false;
                return;
            }

            txtNomPista.Text = pistaSeleccionada.Nom;
            checkBoxPistaActiva.Checked = !pistaSeleccionada.Activa;
        }

        private void btnMostrarModificarPista_Click(object? sender, EventArgs e)
        {
            foreach (Control control in panelModificarPista.Controls)
            {
                control.Visible = true;
            }
        }

        private void btnMotrarNovaPista_Click(object? sender, EventArgs e)
        {
            foreach (Control control in panelNovaPista.Controls)
            {
                control.Visible = true;
            }
        }

        private async void btnModificarPista_Click(object? sender, EventArgs e)
        {
            PistaListItem? pistaSeleccionada = listBoxPistes.SelectedItem as PistaListItem;

            string? nomPista = NullIfWhiteSpace(txtNomPista.Text);
            if (nomPista is null)
            {
                MessageBox.Show("El nom de la pista és obligatori.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool enManteniment = checkBoxPistaActiva.Checked;
            string missatgeConfirmacio = "Segur que vols modificar aquesta pista?";
            if (enManteniment)
            {
                missatgeConfirmacio += "\nVols posar aquesta pista en manteniment?";
            }

            DialogResult confirmacio = MessageBox.Show(
                missatgeConfirmacio,
                "Confirmació",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacio != DialogResult.Yes)
            {
                return;
            }

            if (enManteniment)
            {
                List<ReservaPistaResponseDto> reservesPerPista;
                try
                {
                    reservesPerPista = await HttpClient.GetFromJsonAsync<List<ReservaPistaResponseDto>>(
                        $"{BaseApiUrl}/api/reserves/pista/{pistaSeleccionada.Id}") ?? [];
                }
                catch
                {
                    MessageBox.Show("Error recuperant les reserves de la pista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (reservesPerPista.Count > 0)
                {
                    string llistaReserves = string.Join(
                        Environment.NewLine,
                        reservesPerPista.Select(r => $"{r.Id} - {r.Data}"));

                    DialogResult confirmacioEliminacio = MessageBox.Show(
                        $"Aquesta pista esta asociada a les seguents reserves:\n{llistaReserves}\n\nS'han d'eliminar les següents reserver per a poder posar la pista en manteniment, segur que vols fer-ho?",
                        "Confirmació",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmacioEliminacio != DialogResult.Yes)
                    {
                        return;
                    }

                    foreach (ReservaPistaResponseDto reserva in reservesPerPista)
                    {
                        try
                        {
                            using HttpResponseMessage responseDelete = await HttpClient.DeleteAsync($"{BaseApiUrl}/api/reserves/{reserva.Id}");
                            if (!responseDelete.IsSuccessStatusCode)
                            {
                                MessageBox.Show($"No s'ha pogut eliminar la reserva {reserva.Id} correctament.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error eliminant les reserves associades a la pista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }

            PistaUpdateRequestDto request = new(nomPista, !enManteniment);

            try
            {
                using HttpResponseMessage response = await HttpClient.PutAsJsonAsync(
                    $"{BaseApiUrl}/api/pistes/{pistaSeleccionada.Id}",
                    request);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Pista modificada correctament.", "Informació", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CarregarPistesMantenimentAsync(pistaSeleccionada.Id);
                }
                else
                {
                    MessageBox.Show("No s'ha pogut modificar la pista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("No s'ha pogut modificar la pista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnNovaPista_Click(object? sender, EventArgs e)
        {
            string? nomPista = NullIfWhiteSpace(txtNomPistaNova.Text);
            if (nomPista is null)
            {
                MessageBox.Show("El nom de la pista és obligatori.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PistaCreateRequestDto request = new(nomPista, true);

            try
            {
                using HttpResponseMessage response = await HttpClient.PostAsJsonAsync(
                    $"{BaseApiUrl}/api/pistes",
                    request);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Pista creada correctament.", "Informació", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNomPistaNova.Text = string.Empty;
                    await CarregarPistesMantenimentAsync();
                }
                else
                {
                    MessageBox.Show("No s'ha pogut crear la pista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("No s'ha pogut crear la pista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CarregarProperes20ReservesAsync()
        {
            string dateToday = DateTime.Today.ToString("yyyy-MM-dd");
            string endpoint = $"{BaseApiUrl}/api/reserves/properes?data={Uri.EscapeDataString(dateToday)}";

            try
            {
                List<ReservaResponseDto> reserves = await HttpClient.GetFromJsonAsync<List<ReservaResponseDto>>(endpoint)
                    ?? [];
                ActualitzarGridReserves(reserves);
            }
            catch
            {
                MessageBox.Show("No s'han pogut carregar les reserves.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCercarReserva_Click(object? sender, EventArgs e)
        {
            if (!validarInt(txtFiltreIDreserva.Text, out int? reservaId)
                || !validarInt(txtFiltreIDUsuari.Text, out int? usuariId)
                || !validarInt(txtFiltrePista.Text, out int? pistaId))
            {
                MessageBox.Show("Els camps Id reserva, Id usuari i Pista han de ser numèrics.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!validarData(txtFiltreData.Text, out string? data))
            {
                MessageBox.Show("El format de data no és vàlid. Ha de ser yyyy-MM-dd.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tornText = comboBoxFiltreTorn.SelectedItem?.ToString() ?? string.Empty;
            int tornInt = getTornComboBoxIndex(tornText);
            //Si torn > 0, es posa a int, sino es posa a null
            int? torn = tornInt > 0 ? tornInt : null;

            bool senseFiltres = !reservaId.HasValue
                && !usuariId.HasValue
                && !pistaId.HasValue
                && string.IsNullOrWhiteSpace(data)
                && !torn.HasValue;

            if (senseFiltres)
            {
                await CarregarProperes20ReservesAsync();
                return;
            }

            string endpoint = GenerateEndpointCercaAdmin(reservaId, usuariId, pistaId, data, torn);

            try
            {
                List<ReservaResponseDto> reserves = await HttpClient.GetFromJsonAsync<List<ReservaResponseDto>>(endpoint)
                    ?? [];
                ActualitzarGridReserves(reserves);
            }
            catch
            {
                MessageBox.Show("No s'han pogut carregar les reserves.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCercarUsuari_Click(object? sender, EventArgs e)
        {
            if (!validarInt(txtFiltreUsuariUsuari.Text, out int? usuariId))
            {
                MessageBox.Show("El camp Id d'usuari ha de ser numèric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!validarData(txtFiltreTelefon.Text, out string? dataAlta))
            {
                MessageBox.Show("El format de data no és vàlid. Ha de ser yyyy-MM-dd.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string? nom = NullIfWhiteSpace(txtFiltreNom.Text);
            string? cognom = NullIfWhiteSpace(txtFiltreCognom.Text);
            string? email = NullIfWhiteSpace(txtFiltreMail.Text);
            string? rol = rolEndpoint(NullIfWhiteSpace(comboBoxRol.Text));
            bool actiu = checkBoxEstat.Checked;

            string endpoint = GenerateEndpointCercaAdminUsuaris(usuariId, nom, cognom, email, rol, actiu, dataAlta);

            try
            {
                List<UsuariResponseDto> usuaris = await HttpClient.GetFromJsonAsync<List<UsuariResponseDto>>(endpoint)
                    ?? [];
                ActualitzarGridUsuaris(usuaris);
            }
            catch
            {
                MessageBox.Show("No s'han pogut carregar els usuaris.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string? NullIfWhiteSpace(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return value.Trim();
        }

        private static string? rolEndpoint(string? rol)
        {
            string? rolseleccionat = NullIfWhiteSpace(rol);
            if (rolseleccionat is null)
            {
                return null;
            }

            return rolseleccionat switch
            {
                "ADMIN" => "ADMIN",
                "USER" => "USER",
                _ => null
            };
        }

        private static bool validarInt(string text, out int? value)
        {
            string net = text.Trim();
            if (string.IsNullOrWhiteSpace(net))
            {
                value = null;
                return true;
            }

            if (int.TryParse(net, out int parsed))
            {
                value = parsed;
                return true;
            }

            value = null;
            return false;
        }

        private static bool validarData(string text, out string? data)
        {
            string formatdataok = text.Trim();
            if (string.IsNullOrWhiteSpace(formatdataok))
            {
                data = null;
                return true;
            }

            if (DateTime.TryParseExact(formatdataok, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataParsed))
            {
                data = dataParsed.ToString("yyyy-MM-dd");
                return true;
            }

            data = null;
            return false;
        }

        private string GenerateEndpointCercaAdmin(int? reservaId, int? usuariId, int? pistaId, string? data, int? torn)
        {
            List<string> stringList = [];

            if (reservaId.HasValue)
            {
                stringList.Add($"reservaId={reservaId.Value}");
            }

            if (usuariId.HasValue)
            {
                stringList.Add($"usuariId={usuariId.Value}");
            }

            if (pistaId.HasValue)
            {
                stringList.Add($"pistaId={pistaId.Value}");
            }

            if (!string.IsNullOrWhiteSpace(data))
            {
                stringList.Add($"data={Uri.EscapeDataString(data)}");
            }

            if (torn.HasValue)
            {
                stringList.Add($"torn={torn.Value}");
            }

            return $"{BaseApiUrl}/api/reserves/cercaAdmin?{string.Join("&", stringList)}";
        }

        private string GenerateEndpointCercaAdminUsuaris(int? usuariId, string? nom, string? cognom, string? email, string? rol, bool actiu, string? dataAlta)
        {
            List<string> stringList = [];

            if (usuariId.HasValue)
            {
                stringList.Add($"usuariId={usuariId.Value}");
            }

            if (!string.IsNullOrWhiteSpace(nom))
            {
                stringList.Add($"nom={Uri.EscapeDataString(nom)}");
            }

            if (!string.IsNullOrWhiteSpace(cognom))
            {
                stringList.Add($"cognom={Uri.EscapeDataString(cognom)}");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                stringList.Add($"email={Uri.EscapeDataString(email)}");
            }

            if (!string.IsNullOrWhiteSpace(rol))
            {
                stringList.Add($"rol={Uri.EscapeDataString(rol)}");
            }

            if (actiu)
            {
                stringList.Add($"actiu=true");
            }
            else
            {
                stringList.Add($"actiu=false");
            }

            if (!string.IsNullOrWhiteSpace(dataAlta))
            {
                stringList.Add($"dataAlta={Uri.EscapeDataString(dataAlta)}");
            }

            return $"{BaseApiUrl}/api/usuaris/cercaAdmin?{string.Join("&", stringList)}";
        }

        private void ActualitzarGridReserves(List<ReservaResponseDto> reserves)
        {
            dataGridReserves.DataSource = reserves
                .Select(r => new
                {
                    Id = r.Id,
                    UsuariId = r.UsuariId,
                    Usuari = $"{r.UsuariNom} {r.UsuariCognom}",
                    PistaId = r.PistaId,
                    Pista = r.PistaNom,
                    Data = r.Data,
                    Torn = GetHoresTornString(r.Torn)
                })
                .ToList();

            ActualitzarEstatBotonsReserves();
        }

        private void ActualitzarGridUsuaris(List<UsuariResponseDto> usuaris)
        {
            dataGridViewUsuaris.DataSource = usuaris
                .Select(u => new
                {
                    Id = u.Id,
                    Nom = u.Nom,
                    Cognom = u.Cognom,
                    Email = u.Email,
                    Telefon = u.Telefon,
                    Rol = u.Rol,
                    DataAlta = u.DataAlta,
                    Actiu = u.Actiu
                })
                .ToList();
        }

        private void dataGridReserves_SelectionChanged(object? sender, EventArgs e)
        {
            ActualitzarEstatBotonsReserves();
        }

        private void dataGridViewUsuaris_SelectionChanged(object? sender, EventArgs e)
        {
            ActualitzarEstatBotonsUsuaris();
        }

        private void btnAltaUsuari_Click(object? sender, EventArgs e)
        {
            MostrarFormEditaOAltaUsuari(modificar: false);
        }

        private void btnModificarUsuari_Click(object? sender, EventArgs e)
        {
            if (dataGridViewUsuaris.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow fila = dataGridViewUsuaris.SelectedRows[0];
            int usuariId = Convert.ToInt32(fila.Cells["Id"].Value);
            string nom = Convert.ToString(fila.Cells["Nom"].Value)!;
            string cognom = Convert.ToString(fila.Cells["Cognom"].Value)!;
            string telefon = Convert.ToString(fila.Cells["Telefon"].Value)!;
            string email = Convert.ToString(fila.Cells["Email"].Value)!;
            bool admin = false;
            if (Convert.ToString(fila.Cells["Rol"].Value) == "ADMIN")
            {
                admin = true;
            }
            bool actiu = true;
            if (Convert.ToBoolean(fila.Cells["Actiu"].Value) == false)
            {
                actiu = false;
            }

            MostrarFormEditaOAltaUsuari(true, usuariId, nom, cognom, telefon, email, admin, actiu);
        }

        private async void MostrarFormEditaOAltaUsuari(bool modificar, int? usuariId = null, string nom = "", string cognom = "", string telefon = "", string email = "", bool admin = false, bool actiu = true)
        {
            using FormAdministrdor_EditaOAltaUsuari formulariUsuari = new(modificar, usuariId, nom, cognom, telefon, email, admin, actiu);
            formulariUsuari.StartPosition = FormStartPosition.Manual;
            formulariUsuari.Location = Location;
            formulariUsuari.Size = new Size(366, 397);
            formulariUsuari.MinimumSize = new Size(366, 397);
            if (formulariUsuari.ShowDialog(this) == DialogResult.OK)
            {
                await InicialitzarPanellUsuarisAsync();
            }
        }

        private async void btnModificarReserva_Click(object? sender, EventArgs e)
        {
            if (dataGridReserves.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow fila = dataGridReserves.SelectedRows[0];
            int reservaId = Convert.ToInt32(fila.Cells["Id"].Value);
            int usuariId = Convert.ToInt32(fila.Cells["UsuariId"].Value);
            int pistaId = Convert.ToInt32(fila.Cells["PistaId"].Value);
            string data = Convert.ToString(fila.Cells["Data"].Value) ?? string.Empty;
            string tornText = Convert.ToString(fila.Cells["Torn"].Value) ?? string.Empty;
            int torn = getTornComboBoxIndex(tornText);

            using FormAdministrador_EditarReserva formulariEditarReserva = new(reservaId, usuariId, pistaId, data, torn);
            formulariEditarReserva.StartPosition = FormStartPosition.Manual;
            formulariEditarReserva.Location = this.Location;
            formulariEditarReserva.Size = new Size(389, 378);
            formulariEditarReserva.MinimumSize = new Size(389, 378);

            if (formulariEditarReserva.ShowDialog(this) == DialogResult.OK)
            {
                await CarregarProperes20ReservesAsync();
            }
        }

        private async void btnEliminarReserva_Click(object? sender, EventArgs e)
        {
            if (dataGridReserves.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow fila = dataGridReserves.SelectedRows[0];
            int reservaId = Convert.ToInt32(fila.Cells["Id"].Value);

            DialogResult okdialog = MessageBox.Show(
                $"Segur que vols eliminar la reserva amb id {reservaId}?",
                "Confirmació d'eliminació",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (okdialog != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using HttpResponseMessage response = await HttpClient.DeleteAsync($"{BaseApiUrl}/api/reserves/{reservaId}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Reserva eliminada correctament", "Reserva eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CarregarProperes20ReservesAsync();
                }
                else
                {
                    MessageBox.Show("Error eliminant la reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Error eliminant la reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnBaixaUsuari_Click(object? sender, EventArgs e)
        {
            if (dataGridViewUsuaris.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow fila = dataGridViewUsuaris.SelectedRows[0];
            int usuariId = Convert.ToInt32(fila.Cells["Id"].Value);
            string nom = Convert.ToString(fila.Cells["Nom"].Value) ?? string.Empty;
            string cognom = Convert.ToString(fila.Cells["Cognom"].Value) ?? string.Empty;

            DialogResult confirmacio = MessageBox.Show(
                $"Vols donar de baixa l'usuari amb id {usuariId} ({nom} {cognom}) ? El seu estat es posar a NO ACTIU",
                "Confirmació",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacio != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using HttpResponseMessage response = await HttpClient.PutAsync($"{BaseApiUrl}/api/usuaris/{usuariId}/baixa", null);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Usuari {usuariId} - {nom} {cognom}  donat de baixa correctament.", "Informació", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await InicialitzarPanellUsuarisAsync();
                }
                else
                {
                    MessageBox.Show("Error donant de baixa l'usuari.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Error donant de baixa l'usuari.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualitzarEstatBotonsReserves()
        {
            if (dataGridReserves.SelectedRows.Count > 0)
            {
                btnModificarReserva.Enabled = true;
                btnEliminarReserva.Enabled = true;
            }
            else
            {
                btnModificarReserva.Enabled = false;
                btnEliminarReserva.Enabled = false;
            }
        }

        private void ActualitzarEstatBotonsUsuaris()
        {
            bool filaSeleccionada = dataGridViewUsuaris.SelectedRows.Count > 0;
            btnBaixaUsuari.Enabled = filaSeleccionada;
            btnModificarUsuari.Enabled = filaSeleccionada;
        }

        private string GetHoresTornString(int torn)
        {
            return torn switch
            {
                1 => "08h-10h",
                2 => "10h-12h",
                3 => "12h-14h",
                4 => "14h-16h",
                5 => "16h-18h",
                6 => "18h-20h",
                7 => "20h-22h",
                _ => "Sense torn"
            };
        }

        private int getTornComboBoxIndex(string torn)
        {
            switch (torn)
            {
                case "08h-10h":
                    return 1;
                case "10h-12h":
                    return 2;
                case "12h-14h":
                    return 3;
                case "14h-16h":
                    return 4;
                case "16h-18h":
                    return 5;
                case "18h-20h":
                    return 6;
                case "20h-22h":
                    return 7;
                case "":
                    return 0;
                default:
                    return -1;
            }
        }

        private async void FormAdministrador_Load(object sender, EventArgs e)
        {
            await MostrarPanelActiu(panelReserves);
        }

        private void canviarPasswordDeAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using Form_CanviarContrasenya formulariCanvi = new();
            formulariCanvi.StartPosition = FormStartPosition.Manual;
            formulariCanvi.Location = this.Location;
            formulariCanvi.Size = new Size(426, 195);
            formulariCanvi.MinimumSize = new Size(426, 195);
            formulariCanvi.ShowDialog(this);
        }

        private sealed record ReservaResponseDto(
            [property: JsonPropertyName("id")] int Id,
            [property: JsonPropertyName("usuariId")] int UsuariId,
            [property: JsonPropertyName("usuariNom")] string UsuariNom,
            [property: JsonPropertyName("usuariCognom")] string UsuariCognom,
            [property: JsonPropertyName("pistaId")] int PistaId,
            [property: JsonPropertyName("pistaNom")] string PistaNom,
            [property: JsonPropertyName("data")] string Data,
            [property: JsonPropertyName("torn")] int Torn);

        private sealed record UsuariResponseDto(
            [property: JsonPropertyName("id")] int Id,
            [property: JsonPropertyName("nom")] string? Nom,
            [property: JsonPropertyName("cognom")] string? Cognom,
            [property: JsonPropertyName("email")] string? Email,
            [property: JsonPropertyName("telefon")] string? Telefon,
            [property: JsonPropertyName("rol")] string? Rol,
            [property: JsonPropertyName("actiu")] bool? Actiu,
            [property: JsonPropertyName("dataAlta")] string? DataAlta);

        private sealed record UsuariUpdateRequestDto(
            [property: JsonPropertyName("nom")] string Nom,
            [property: JsonPropertyName("cognom")] string Cognom,
            [property: JsonPropertyName("email")] string Email,
            [property: JsonPropertyName("password")] string? Password,
            [property: JsonPropertyName("telefon")] string? Telefon,
            [property: JsonPropertyName("rol")] string? Rol,
            [property: JsonPropertyName("actiu")] bool? Actiu);

        private sealed record PistaMantenimentDto(
            [property: JsonPropertyName("id")] int Id,
            [property: JsonPropertyName("nom")] string? Nom,
            [property: JsonPropertyName("activa")] bool? Activa);

        private sealed record PistaListItem(int Id, string Nom, bool Activa)
        {
            public override string ToString()
            {
                if (Activa)
                {
                    return Nom;
                }

                return $"{Nom} - En manteniment";
            }
        }

        private sealed record PistaUpdateRequestDto(
            [property: JsonPropertyName("nom")] string Nom,
            [property: JsonPropertyName("activa")] bool Activa);

        private sealed record PistaCreateRequestDto(
            [property: JsonPropertyName("nom")] string Nom,
            [property: JsonPropertyName("activa")] bool Activa);

        private sealed record ReservaPistaResponseDto(
            [property: JsonPropertyName("id")] int Id,
            [property: JsonPropertyName("data")] string? Data,
            [property: JsonPropertyName("usuari")] string? Usuari,
            [property: JsonPropertyName("usuariId")] int? UsuariId,
            [property: JsonPropertyName("usuariNom")] string? UsuariNom,
            [property: JsonPropertyName("usuariCognom")] string? UsuariCognom);
    }
}

