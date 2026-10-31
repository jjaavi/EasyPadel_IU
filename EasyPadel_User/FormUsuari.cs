using System.Dynamic;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace EasyPadel_User
{
    public partial class FormUsuari : Form
    {
        private static readonly HttpClient HttpClient = new();
        private static int panelActiuReserves = 1;
        private bool carregantPistes;
        private bool carregantDadesSoci;
        private string nomSociOriginal = string.Empty;
        private string cognomSociOriginal = string.Empty;
        private string emailSociOriginal = string.Empty;
        private string telefonSociOriginal = string.Empty;
        private UsuariConfiguracioDto? usuariConfiguracioActual;

        private async void FormUsuari_Load(object sender, EventArgs e)
        {
            MostrarPanelActiu(panelReserves);
            panelActiuReserves = 1;
            await CarregarReservesActualsAsync();

            //Panel de nova reserva
            monthCalendarSeleccio.MinDate = DateTime.Today;
            monthCalendarSeleccio.MaxDate = DateTime.Today.AddDays(10);
            monthCalendarSeleccio.MaxSelectionCount = 1; // opcional, para seleccionar solo un día
        }

        public FormUsuari()
        {
            InitializeComponent();
            InicialitzarGridReserves();
            menuMevesReserves.Click += menuMevesReserves_Click;
            menuNovaReserva.Click += menuNovaReserva_Click;
            menuActualitzarDadesPersonals.Click += menuActualitzarDadesPersonals_Click;
            menuCanviarContrasenyaUsuari.Click += menuCanviarContrasenyaUsuari_Click;
            dataGridViewReservesSoci.SelectionChanged += dataGridViewReservesSoci_SelectionChanged;
            listPistesDisponibles.SelectedIndexChanged += listPistesDisponibles_SelectedIndexChanged;
            listTorns.SelectedIndexChanged += listTorns_SelectedIndexChanged;
            monthCalendarSeleccio.DateSelected += monthCalendarSeleccio_DateSelected;
            txtNomSoci.TextChanged += txtDadesSoci_TextChanged;
            txtCognomSoci.TextChanged += txtDadesSoci_TextChanged;
            txtEmailSoci.TextChanged += txtDadesSoci_TextChanged;
            txtTelefon.TextChanged += txtDadesSoci_TextChanged;
            MostrarPanelActiu(panelReserves);
            ActualitzarEstatBotoCancelarReserva();
            ActualitzarEstatBotoExecutarNovaReserva();
        }

        private void InicialitzarGridReserves()
        {
            dataGridViewReservesSoci.Dock = DockStyle.None;
            dataGridViewReservesSoci.ReadOnly = true;
            dataGridViewReservesSoci.AllowUserToAddRows = false;
            dataGridViewReservesSoci.AllowUserToDeleteRows = false;
            dataGridViewReservesSoci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewReservesSoci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReservesSoci.MultiSelect = false;
        }

        private void MostrarPanelActiu(Panel panelVisible)
        {
            panelReserves.Visible = panelVisible == panelReserves;
            panelNovaReserva.Visible = panelVisible == panelNovaReserva;
            panelConfiguracioSoci.Visible = panelVisible == panelConfiguracioSoci;

            ActualitzarEstatBotoCancelarReserva();
            ActualitzarEstatBotoExecutarNovaReserva();
            ActualitzarEstatBotoActualitzarDadesSoci();
        }

        private async void menuMevesReserves_Click(object? sender, EventArgs e)
        {
            MostrarPanelActiu(panelReserves);
            panelActiuReserves = 1;
            await CarregarReservesActualsAsync();
        }

        private async void btnReservesActuals_Click(object? sender, EventArgs e)
        {
            panelActiuReserves = 1;
            await CarregarReservesActualsAsync();
        }

        private async void btnReservesAnteriors_Click(object? sender, EventArgs e)
        {
            panelActiuReserves = 2;
            await CarregarReservesAnteriorsAsync();
        }

        private async Task CarregarReservesActualsAsync()
        {
            await CarregarReservesDataGrid($"http://localhost:8080/api/reserves/usuari/{SessionContext.UsuariId}/posteriors");
        }

        private async Task CarregarReservesAnteriorsAsync()
        {
            string dataActual = DateTime.Today.ToString("yyyy-MM-dd");
            await CarregarReservesDataGrid($"http://localhost:8080/api/reserves/usuari/{SessionContext.UsuariId}/anteriors?data={dataActual}");
        }

        private async Task CarregarReservesDataGrid(string endpoint)
        {
            if (SessionContext.UsuariId <= 0)
            {
                MessageBox.Show("No s'ha pogut identificar l'usuari.");
                return;
            }

            try
            {
                List<ReservaResponseDto> reserves = await HttpClient.GetFromJsonAsync<List<ReservaResponseDto>>(endpoint)
                    ?? new List<ReservaResponseDto>();

                dataGridViewReservesSoci.DataSource = reserves
                    .Select(r => new
                    {
                        Id = r.Id,
                        Data = r.Data,
                        Torn = getHoresTornString(r.Torn),
                        Pista = r.PistaNom
                    })
                    .ToList();

                ActualitzarEstatBotoCancelarReserva();
            }
            catch
            {
                MessageBox.Show("No s'han pogut carregar les reserves de l'usuari.");
            }
        }

        private string getHoresTornString(int torn)
        {
            return torn switch
            {
                1 => "8h-10h",
                2 => "10h-12h",
                3 => "12h-14h",
                4 => "14h-16h",
                5 => "16h-18h",
                6 => "18h-20h",
                7 => "20h-22h",
                _ => "Sense torn"
            };
        }

        private int ObtenirHoraIniciTorn(int torn)
        {
            return torn switch
            {
                1 => 8,
                2 => 10,
                3 => 12,
                4 => 14,
                5 => 16,
                6 => 18,
                7 => 20,
                _ => 0
            };
        }

        private async void menuNovaReserva_Click(object? sender, EventArgs e)
        {
            MostrarPanelActiu(panelNovaReserva);
            await CarregarPistesDisponiblesAsync();
        }

        private async void menuActualitzarDadesPersonals_Click(object? sender, EventArgs e)
        {
            MostrarPanelActiu(panelConfiguracioSoci);
            ReiniciarPanellConfiguracioSoci();
            await CarregarDadesConfiguracioSociAsync();
        }

        private async void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            DialogResult okdialog = MessageBox.Show(
                "Segur que vols cancelar aquesta reserva?",
                "Cancelar reserva",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (okdialog == DialogResult.Yes)
            {
                int reservaId = (int)dataGridViewReservesSoci.SelectedRows[0].Cells["Id"].Value;

                try
                {
                    using HttpResponseMessage response = await HttpClient.DeleteAsync($"http://localhost:8080/api/reserves/{reservaId}");
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("No s'ha pogut cancelar la reserva.");
                    }
                }
                catch
                {
                    MessageBox.Show("No s'ha pogut cancelar la reserva.");
                }
            }

            MostrarPanelActiu(panelReserves);
            panelActiuReserves = 1;
            await CarregarReservesActualsAsync();
        }

        private async void listPistesDisponibles_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ActualitzarEstatBotoExecutarNovaReserva();

            if (carregantPistes || listPistesDisponibles.SelectedItem is not PistaDisponibleDto pistaSeleccionada)
            {
                listTorns.DataSource = null;
                listTorns.Items.Clear();
                ActualitzarEstatBotoExecutarNovaReserva();
                return;
            }

            await CarregarDisponibilitatTornsAsync(pistaSeleccionada.Id);
        }

        private void listTorns_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listTorns.SelectedItem is TornListItem torn && !torn.Disponible)
            {
                listTorns.ClearSelected();
            }

            ActualitzarEstatBotoExecutarNovaReserva();
        }

        private void monthCalendarSeleccio_DateSelected(object? sender, DateRangeEventArgs e)
        {
            ReiniciarSeleccioNovaReserva();
            ActualitzarEstatBotoExecutarNovaReserva();
        }

        private async Task CarregarPistesDisponiblesAsync()
        {
            try
            {
                carregantPistes = true;

                List<PistaDisponibleDto> pistes = await HttpClient.GetFromJsonAsync<List<PistaDisponibleDto>>("http://localhost:8080/api/pistes/actives")
                    ?? new List<PistaDisponibleDto>();

                listPistesDisponibles.DataSource = pistes;
                listPistesDisponibles.DisplayMember = nameof(PistaDisponibleDto.Nom);
                listPistesDisponibles.ValueMember = nameof(PistaDisponibleDto.Id);
                listPistesDisponibles.ClearSelected();

                listTorns.DataSource = null;
                listTorns.Items.Clear();
                listTorns.ClearSelected();
                ActualitzarEstatBotoExecutarNovaReserva();
            }
            catch
            {
                MessageBox.Show("No s'han pogut carregar les pistes disponibles.");
            }
            finally
            {
                carregantPistes = false;
            }
        }

        private async Task CarregarDisponibilitatTornsAsync(int pistaId)
        {
            try
            {
                string dataSeleccionada = monthCalendarSeleccio.SelectionStart.ToString("yyyy-MM-dd");
                DisponibilitatPistaResponseDto? resposta = await HttpClient.GetFromJsonAsync<DisponibilitatPistaResponseDto>(
                    $"http://localhost:8080/api/reserves/disponibilitat/{pistaId}?data={dataSeleccionada}");

                DateTime dataSeleccionadaDate = monthCalendarSeleccio.SelectionStart.Date;
                DateTime now = DateTime.Now;

                List<TornListItem> torns = resposta?.Torns
                    .Where(t => dataSeleccionadaDate != DateTime.Today || ObtenirHoraIniciTorn(t.Torn) > now.Hour)
                    .Select(t => new TornListItem(t.Torn, t.Disponible, t.Disponible
                        ? getHoresTornString(t.Torn)
                        : $"{getHoresTornString(t.Torn)} - No disponible"))
                    .ToList() ?? new List<TornListItem>();

                listTorns.DataSource = torns;
                listTorns.DisplayMember = nameof(TornListItem.Text);
                listTorns.ValueMember = nameof(TornListItem.Torn);
                listTorns.ClearSelected();
                ActualitzarEstatBotoExecutarNovaReserva();
            }
            catch
            {
                MessageBox.Show("No s'han pogut carregar els torns disponibles.");
            }
        }

        private void ReiniciarSeleccioNovaReserva()
        {
            listPistesDisponibles.ClearSelected();
            listTorns.DataSource = null;
            listTorns.Items.Clear();
            listTorns.ClearSelected();
            ActualitzarEstatBotoExecutarNovaReserva();
        }

        private async Task CarregarDadesConfiguracioSociAsync()
        {
            if (SessionContext.UsuariId <= 0)
            {
                MessageBox.Show("No s'ha pogut carregar l'usuari.");
                return;
            }

            try
            {
                UsuariConfiguracioDto? usuari = await HttpClient.GetFromJsonAsync<UsuariConfiguracioDto>($"http://localhost:8080/api/usuaris/{SessionContext.UsuariId}");

                if (usuari is null)
                {
                    MessageBox.Show("No s'han pogut carregar les dades del soci.");
                    return;
                }

                carregantDadesSoci = true;
                usuariConfiguracioActual = usuari;

                txtNomSoci.Text = usuari.Nom ?? string.Empty;
                txtCognomSoci.Text = usuari.Cognom ?? string.Empty;
                txtEmailSoci.Text = usuari.Email ?? string.Empty;
                txtTelefon.Text = usuari.Telefon ?? string.Empty;

                nomSociOriginal = txtNomSoci.Text;
                cognomSociOriginal = txtCognomSoci.Text;
                emailSociOriginal = txtEmailSoci.Text;
                telefonSociOriginal = txtTelefon.Text;
            }
            catch
            {
                MessageBox.Show("No s'han pogut carregar les dades del soci.");
            }
            finally
            {
                carregantDadesSoci = false;
                ActualitzarEstatBotoActualitzarDadesSoci();
            }
        }

        private void dataGridViewReservesSoci_SelectionChanged(object? sender, EventArgs e)
        {
            ActualitzarEstatBotoCancelarReserva();
        }

        private void ReiniciarPanellConfiguracioSoci()
        {
            btnActualitzarDadesSoci.Enabled = false;
            btnActualitzarDadesSoci.BackColor = Color.DarkGray;
        }

        private void txtDadesSoci_TextChanged(object? sender, EventArgs e)
        {
            if (carregantDadesSoci)
            {
                return;
            }

            ActualitzarEstatBotoActualitzarDadesSoci();
        }

        private void ActualitzarEstatBotoActualitzarDadesSoci()
        {
            bool controlTxtsChanged = txtNomSoci.Text != nomSociOriginal
                || txtCognomSoci.Text != cognomSociOriginal
                || txtEmailSoci.Text != emailSociOriginal
                || txtTelefon.Text != telefonSociOriginal;

            bool controlTxtsNullOrWhiteSpace = !string.IsNullOrWhiteSpace(txtNomSoci.Text)
                && !string.IsNullOrWhiteSpace(txtCognomSoci.Text)
                && !string.IsNullOrWhiteSpace(txtEmailSoci.Text)
                && !string.IsNullOrWhiteSpace(txtTelefon.Text);

            bool habilitar = panelConfiguracioSoci.Visible && controlTxtsChanged && controlTxtsNullOrWhiteSpace;

            btnActualitzarDadesSoci.Enabled = habilitar;
            if (habilitar)
            {
                btnActualitzarDadesSoci.BackColor = Color.White;
            }
            else
            {
                btnActualitzarDadesSoci.BackColor = Color.DarkGray;
            }
        }

        private void ActualitzarEstatBotoCancelarReserva()
        {
            btnCancelarReserva.Enabled = panelReserves.Visible
                && dataGridViewReservesSoci.SelectedRows.Count > 0
                && panelActiuReserves == 1;
        }

        private void ActualitzarEstatBotoExecutarNovaReserva()
        {
            bool dataSeleccionada = monthCalendarSeleccio.SelectionStart >= monthCalendarSeleccio.MinDate
                && monthCalendarSeleccio.SelectionStart <= monthCalendarSeleccio.MaxDate;
            bool pistaSeleccionada = listPistesDisponibles.SelectedItem is PistaDisponibleDto;
            bool tornDisponibleSeleccionat = listTorns.SelectedItem is TornListItem torn && torn.Disponible;

            btnExecutarNovaReserva.Enabled = panelNovaReserva.Visible
                && dataSeleccionada
                && pistaSeleccionada
                && tornDisponibleSeleccionat;
        }

        private async void btnExecutarNovaReserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (listTorns.SelectedItem is not TornListItem tornSeleccionat ||
                    listPistesDisponibles.SelectedItem is not PistaDisponibleDto pistaSeleccionada)
                {
                    return;
                }

                DateTime dataSeleccio = monthCalendarSeleccio.SelectionStart.Date;
                string missatgeConfirmacio = $"Vols reservar el torn {tornSeleccionat.Text} per la pista {pistaSeleccionada.Nom} el dia {dataSeleccio:yyyy-MM-dd}?";

                DialogResult okdialog = MessageBox.Show(
                    missatgeConfirmacio,
                    "Confirmació reserva",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (okdialog != DialogResult.Yes)
                {
                    return;
                }

                var reservaRequest = new ReservaCreateRequestDto(
                    SessionContext.UsuariId,
                    pistaSeleccionada.Id,
                    dataSeleccio.ToString("yyyy-MM-dd"),
                    tornSeleccionat.Torn);

                using HttpResponseMessage response = await HttpClient.PostAsJsonAsync("http://localhost:8080/api/reserves", reservaRequest);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Reserva feta correctament.", "Informació", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CarregarDisponibilitatTornsAsync(pistaSeleccionada.Id);
                    ActualitzarEstatBotoExecutarNovaReserva();
                }
                else
                {
                    MessageBox.Show("Reserva no realitzada. Si us plau, torna a intentar-ho.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Reserva no realitzada. Si us plau, torna a intentar-ho.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnActualitzarDadesSoci_Click(object sender, EventArgs e)
        {
            if (SessionContext.UsuariId <= 0 || usuariConfiguracioActual is null)
            {
                MessageBox.Show("No s'ha pogut carregar l'usuari.");
                return;
            }

            var request = new UsuariUpdateRequestDto(
                txtNomSoci.Text.Trim(),
                txtCognomSoci.Text.Trim(),
                txtEmailSoci.Text.Trim(),
                null,
                txtTelefon.Text.Trim(),
                usuariConfiguracioActual.Rol,
                usuariConfiguracioActual.Actiu);

            try
            {
                using HttpResponseMessage response = await HttpClient.PutAsJsonAsync(
                    $"http://localhost:8080/api/usuaris/{SessionContext.UsuariId}",
                    request);

                if (response.IsSuccessStatusCode)
                {
                    ReiniciarPanellConfiguracioSoci();
                    await CarregarDadesConfiguracioSociAsync();
                    MessageBox.Show("Dades actualitzades correctament", "Informació", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No s'han pogut actualitzar les dades del soci.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("No s'han pogut actualitzar les dades del soci.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void menuCanviarContrasenyaUsuari_Click(object? sender, EventArgs e)
        {
            using Form_CanviarContrasenya formulariCanvi = new();
            formulariCanvi.StartPosition = FormStartPosition.Manual;
            formulariCanvi.Location = this.Location;
            formulariCanvi.Size = new Size(426, 195);
            formulariCanvi.MinimumSize = new Size(426, 195);
            formulariCanvi.ShowDialog(this);
        }

        private sealed record ReservaResponseDto(int Id, int UsuariId, string UsuariNom, string UsuariCognom, int PistaId, string PistaNom, string Data, int Torn);

        private sealed record PistaDisponibleDto(int Id, string Nom);

        private sealed record DisponibilitatPistaResponseDto(int PistaId, string PistaNom, string Data, List<TornDisponibilitatDto> Torns);

        private sealed record TornDisponibilitatDto(int Torn, bool Disponible);

        private sealed record ReservaCreateRequestDto(
            [property: JsonPropertyName("usuariId")] int UsuariId,
            [property: JsonPropertyName("pistaId")] int PistaId,
            [property: JsonPropertyName("data")] string Data,
            [property: JsonPropertyName("torn")] int Torn);

        private sealed record TornListItem(int Torn, bool Disponible, string Text)
        {
            public override string ToString() => Text;
        }

        private sealed record LoginRequestDto(
            [property: JsonPropertyName("email")] string Email,
            [property: JsonPropertyName("password")] string Password);

        private sealed record UsuariUpdateRequestDto(
            [property: JsonPropertyName("nom")] string Nom,
            [property: JsonPropertyName("cognom")] string Cognom,
            [property: JsonPropertyName("email")] string Email,
            [property: JsonPropertyName("password")] string? Password,
            [property: JsonPropertyName("telefon")] string? Telefon,
            [property: JsonPropertyName("rol")] string? Rol,
            [property: JsonPropertyName("actiu")] bool? Actiu);

        private sealed record UsuariConfiguracioDto(
            [property: JsonPropertyName("id")] int? Id,
            [property: JsonPropertyName("nom")] string? Nom,
            [property: JsonPropertyName("cognom")] string? Cognom,
            [property: JsonPropertyName("email")] string? Email,
            [property: JsonPropertyName("telefon")] string? Telefon,
            [property: JsonPropertyName("rol")] string? Rol,
            [property: JsonPropertyName("actiu")] bool? Actiu,
            [property: JsonPropertyName("password")] string? Password);
    }
}
