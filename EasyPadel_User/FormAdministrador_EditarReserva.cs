using System;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace EasyPadel_User
{
    public partial class FormAdministrador_EditarReserva : Form
    {
        private static readonly HttpClient HttpClient = new();
        private readonly int reservaId;
        private readonly int usuariIdReserva;
        private readonly int pistaIdReserva;
        private readonly string dataReserva;
        private readonly int tornReserva;

        public FormAdministrador_EditarReserva(int reservaId, int usuariId, int pistaId, string data, int torn)
        {
            InitializeComponent();
            this.reservaId = reservaId;
            usuariIdReserva = usuariId;
            pistaIdReserva = pistaId;
            dataReserva = data;
            tornReserva = torn;

            Load += FormAdministrador_EditarReserva_Load;
            btnCancelar.Click += btnCancelar_Click;
            btnModificarReserva.Click += btnModificarReserva_Click;
        }

        private async void FormAdministrador_EditarReserva_Load(object? sender, EventArgs e)
        {
            txtIdUsuari.Text = usuariIdReserva.ToString();
            txtData.Text = dataReserva;

            loadTornsComboBox();
            await loadPistesList();
        }

        private async Task loadPistesList()
        {
            try
            {
                List<PistaDto> pistes = await HttpClient.GetFromJsonAsync<List<PistaDto>>("http://localhost:8080/api/pistes")
                    ?? [];

                listBoxPistas.DataSource = pistes;
                listBoxPistas.DisplayMember = nameof(PistaDto.Nom);
                listBoxPistas.ValueMember = nameof(PistaDto.Id);

                PistaDto? pistaSeleccionada = pistes.FirstOrDefault(p => p.Id == pistaIdReserva);
                if (pistaSeleccionada is not null)
                {
                    listBoxPistas.SelectedItem = pistaSeleccionada;
                }
                else if (pistes.Count > 0)
                {
                    listBoxPistas.SelectedIndex = 0;
                }
            }
            catch
            {
                MessageBox.Show("No s'han pogut carregar les pistes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadTornsComboBox()
        {
            comboBoxTorns.Items.Clear();
            comboBoxTorns.Items.AddRange(
            [
                "08h-10h",
                "10h-12h",
                "12h-14h",
                "14h-16h",
                "16h-18h",
                "18h-20h",
                "20h-22h"
            ]);

            if (tornReserva >= 1 && tornReserva <= 7)
            {
                comboBoxTorns.SelectedIndex = tornReserva - 1;
            }
            else
            {
                comboBoxTorns.SelectedIndex = 0;
            }
        }

        private async void btnModificarReserva_Click(object? sender, EventArgs e)
        {
            DialogResult okdialog = MessageBox.Show(
                "Segur que vols modificar aquesta reserva?",
                "Modificar reserva",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (okdialog != DialogResult.Yes)
            {
                return;
            }


            int usuariId = int.Parse(txtIdUsuari.Text.Trim());

            if (!validarData(txtData.Text, out string? data))
            {
                MessageBox.Show("El format de data no és vàlid. Ha de ser yyyy-MM-dd.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PistaDto pistaSeleccionada = (PistaDto)listBoxPistas.SelectedItem!;

            string tornText = comboBoxTorns.SelectedItem!.ToString()!;
            int torn = getTornComboBoxIndex(tornText);

            var request = new ReservaUpdateRequestDto(
                usuariId,
                pistaSeleccionada.Id,
                data,
                torn);

            try
            {
                using HttpResponseMessage response = await HttpClient.PutAsJsonAsync($"http://localhost:8080/api/reserves/{reservaId}", request);
                if (response.IsSuccessStatusCode)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("No s'ha pogut modificar la reserva. És possible que ja existeixi una reserva per aquesta pista en aquest torn.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("No s'ha pogut modificar la reserva. És possible que ja existeixi una reserva per aquesta pista en aquest torn.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private static bool validarData(string text, out string? data)
        {
            string formatdataok = text.Trim();
            if (string.IsNullOrWhiteSpace(formatdataok))
            {
                data = null;
                return true;
            }

            if (DateTime.TryParse(formatdataok, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dataParsed))
            {
                data = dataParsed.ToString("yyyy-MM-dd");
                return true;
            }

            data = null;
            return false;
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private sealed record ReservaUpdateRequestDto(
            [property: JsonPropertyName("usuariId")] int UsuariId,
            [property: JsonPropertyName("pistaId")] int PistaId,
            [property: JsonPropertyName("data")] string Data,
            [property: JsonPropertyName("torn")] int Torn);

        private sealed record PistaDto(
            [property: JsonPropertyName("id")] int Id,
            [property: JsonPropertyName("nom")] string Nom);
    }
}
