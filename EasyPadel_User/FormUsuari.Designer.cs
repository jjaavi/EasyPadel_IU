namespace EasyPadel_User
{
    partial class FormUsuari
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelLogo = new Panel();
            panelReserves = new Panel();
            dataGridViewReservesSoci = new DataGridView();
            btnReservesAnteriors = new Button();
            btnReservesActuals = new Button();
            panelNovaReserva = new Panel();
            btnExecutarNovaReserva = new Button();
            listTorns = new ListBox();
            listPistesDisponibles = new ListBox();
            lblNovaReserva4 = new Label();
            lblNovaReserva3 = new Label();
            monthCalendarSeleccio = new MonthCalendar();
            lblNovaReserva2 = new Label();
            lblNovaReserva1 = new Label();
            panelConfiguracioSoci = new Panel();
            txtTelefon = new TextBox();
            ltbnconf4 = new Label();
            checkBoxUpdatePassword = new CheckBox();
            txtPasswordNou = new TextBox();
            ltbnconf6 = new Label();
            txtCognomSoci = new TextBox();
            txtNomSoci = new TextBox();
            lblconf2 = new Label();
            lblconf1 = new Label();
            btnActualitzarDadesSoci = new Button();
            txtPasswordActual = new TextBox();
            txtEmailSoci = new TextBox();
            lblconf5 = new Label();
            ltbnconf3 = new Label();
            menuStripUsuari = new MenuStrip();
            menuMevesReserves = new ToolStripMenuItem();
            menuNovaReserva = new ToolStripMenuItem();
            menuConfiguracioUsuari = new ToolStripMenuItem();
            menuActualitzarDadesPersonals = new ToolStripMenuItem();
            menuCanviarContrasenyaUsuari = new ToolStripMenuItem();
            btnCancelarReserva = new Button();
            panelReserves.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReservesSoci).BeginInit();
            panelNovaReserva.SuspendLayout();
            panelConfiguracioSoci.SuspendLayout();
            menuStripUsuari.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelarReserva
            // 
            btnCancelarReserva.BackColor = Color.White;
            btnCancelarReserva.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelarReserva.Location = new Point(829, 511);
            btnCancelarReserva.Margin = new Padding(2);
            btnCancelarReserva.Name = "btnCancelarReserva";
            btnCancelarReserva.Size = new Size(188, 34);
            btnCancelarReserva.TabIndex = 10;
            btnCancelarReserva.Text = "Cancelar reserva";
            btnCancelarReserva.UseVisualStyleBackColor = false;
            btnCancelarReserva.Click += btnCancelarReserva_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackgroundImage = Properties.Resources.EasyPadel_logo1;
            panelLogo.BackgroundImageLayout = ImageLayout.Zoom;
            panelLogo.Dock = DockStyle.Bottom;
            panelLogo.Location = new Point(0, 478);
            panelLogo.Margin = new Padding(2);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(1061, 100);
            panelLogo.TabIndex = 2;
            // 
            // panelReserves
            // 
            panelReserves.BackColor = Color.White;
            panelReserves.Controls.Add(dataGridViewReservesSoci);
            panelReserves.Controls.Add(btnReservesAnteriors);
            panelReserves.Controls.Add(btnReservesActuals);
            panelReserves.Controls.Add(btnCancelarReserva);
            panelReserves.Dock = DockStyle.Fill;
            panelReserves.Location = new Point(0, 33);
            panelReserves.Margin = new Padding(2);
            panelReserves.Name = "panelReserves";
            panelReserves.Size = new Size(1061, 545);
            panelReserves.TabIndex = 4;
            // 
            // dataGridViewReservesSoci
            // 
            dataGridViewReservesSoci.BackgroundColor = Color.White;
            dataGridViewReservesSoci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReservesSoci.Location = new Point(19, 44);
            dataGridViewReservesSoci.Margin = new Padding(2);
            dataGridViewReservesSoci.Name = "dataGridViewReservesSoci";
            dataGridViewReservesSoci.RowHeadersWidth = 62;
            dataGridViewReservesSoci.Size = new Size(998, 459);
            dataGridViewReservesSoci.TabIndex = 0;
            dataGridViewReservesSoci.CellContentClick += dataGridViewReservesSoci_CellContentClick;
            // 
            // btnReservesAnteriors
            // 
            btnReservesAnteriors.Location = new Point(829, 5);
            btnReservesAnteriors.Margin = new Padding(2);
            btnReservesAnteriors.Name = "btnReservesAnteriors";
            btnReservesAnteriors.Size = new Size(188, 34);
            btnReservesAnteriors.TabIndex = 9;
            btnReservesAnteriors.Text = "Reserves anteriors";
            btnReservesAnteriors.UseVisualStyleBackColor = true;
            btnReservesAnteriors.Click += btnReservesAnteriors_Click;
            // 
            // btnReservesActuals
            // 
            btnReservesActuals.Location = new Point(614, 6);
            btnReservesActuals.Margin = new Padding(2);
            btnReservesActuals.Name = "btnReservesActuals";
            btnReservesActuals.Size = new Size(210, 34);
            btnReservesActuals.TabIndex = 8;
            btnReservesActuals.Text = "Reserves actuals";
            btnReservesActuals.UseVisualStyleBackColor = true;
            btnReservesActuals.Click += btnReservesActuals_Click;
            // 
            // panelNovaReserva
            // 
            panelNovaReserva.BackColor = Color.White;
            panelNovaReserva.Controls.Add(btnExecutarNovaReserva);
            panelNovaReserva.Controls.Add(listTorns);
            panelNovaReserva.Controls.Add(listPistesDisponibles);
            panelNovaReserva.Controls.Add(lblNovaReserva4);
            panelNovaReserva.Controls.Add(lblNovaReserva3);
            panelNovaReserva.Controls.Add(monthCalendarSeleccio);
            panelNovaReserva.Controls.Add(lblNovaReserva2);
            panelNovaReserva.Controls.Add(lblNovaReserva1);
            panelNovaReserva.Dock = DockStyle.Fill;
            panelNovaReserva.Location = new Point(0, 33);
            panelNovaReserva.Margin = new Padding(4);
            panelNovaReserva.Name = "panelNovaReserva";
            panelNovaReserva.Size = new Size(1061, 545);
            panelNovaReserva.TabIndex = 11;
            // 
            // btnExecutarNovaReserva
            // 
            btnExecutarNovaReserva.Enabled = false;
            btnExecutarNovaReserva.Location = new Point(417, 427);
            btnExecutarNovaReserva.Name = "btnExecutarNovaReserva";
            btnExecutarNovaReserva.Size = new Size(188, 34);
            btnExecutarNovaReserva.TabIndex = 7;
            btnExecutarNovaReserva.Text = "Reservar";
            btnExecutarNovaReserva.UseVisualStyleBackColor = true;
            btnExecutarNovaReserva.Click += btnExecutarNovaReserva_Click;
            // 
            // listTorns
            // 
            listTorns.FormattingEnabled = true;
            listTorns.Location = new Point(728, 78);
            listTorns.Name = "listTorns";
            listTorns.Size = new Size(188, 254);
            listTorns.TabIndex = 6;
            // 
            // listPistesDisponibles
            // 
            listPistesDisponibles.FormattingEnabled = true;
            listPistesDisponibles.Location = new Point(417, 78);
            listPistesDisponibles.Name = "listPistesDisponibles";
            listPistesDisponibles.Size = new Size(188, 254);
            listPistesDisponibles.TabIndex = 5;
            // 
            // lblNovaReserva4
            // 
            lblNovaReserva4.AutoSize = true;
            lblNovaReserva4.Location = new Point(61, 340);
            lblNovaReserva4.Name = "lblNovaReserva4";
            lblNovaReserva4.Size = new Size(252, 50);
            lblNovaReserva4.TabIndex = 4;
            lblNovaReserva4.Text = "*Les reserves nomes es poden\r\nfer amb 10 dies d'antelació.";
            // 
            // lblNovaReserva3
            // 
            lblNovaReserva3.AutoSize = true;
            lblNovaReserva3.Location = new Point(751, 44);
            lblNovaReserva3.Name = "lblNovaReserva3";
            lblNovaReserva3.Size = new Size(146, 25);
            lblNovaReserva3.TabIndex = 3;
            lblNovaReserva3.Text = "Torn disponibles:";
            // 
            // monthCalendarSeleccio
            // 
            monthCalendarSeleccio.Location = new Point(57, 78);
            monthCalendarSeleccio.Name = "monthCalendarSeleccio";
            monthCalendarSeleccio.TabIndex = 2;
            // 
            // lblNovaReserva2
            // 
            lblNovaReserva2.AutoSize = true;
            lblNovaReserva2.Location = new Point(428, 44);
            lblNovaReserva2.Name = "lblNovaReserva2";
            lblNovaReserva2.Size = new Size(147, 25);
            lblNovaReserva2.TabIndex = 1;
            lblNovaReserva2.Text = "Seleccio de pista:";
            // 
            // lblNovaReserva1
            // 
            lblNovaReserva1.AutoSize = true;
            lblNovaReserva1.Location = new Point(109, 44);
            lblNovaReserva1.Name = "lblNovaReserva1";
            lblNovaReserva1.Size = new Size(145, 25);
            lblNovaReserva1.TabIndex = 0;
            lblNovaReserva1.Text = "Selecciona el dia:";
            // 
            // panelConfiguracioSoci
            // 
            panelConfiguracioSoci.BackColor = Color.FromArgb(213, 221, 40);
            panelConfiguracioSoci.Controls.Add(txtTelefon);
            panelConfiguracioSoci.Controls.Add(ltbnconf4);
            panelConfiguracioSoci.Controls.Add(checkBoxUpdatePassword);
            panelConfiguracioSoci.Controls.Add(txtPasswordNou);
            panelConfiguracioSoci.Controls.Add(ltbnconf6);
            panelConfiguracioSoci.Controls.Add(txtCognomSoci);
            panelConfiguracioSoci.Controls.Add(txtNomSoci);
            panelConfiguracioSoci.Controls.Add(lblconf2);
            panelConfiguracioSoci.Controls.Add(lblconf1);
            panelConfiguracioSoci.Controls.Add(btnActualitzarDadesSoci);
            panelConfiguracioSoci.Controls.Add(txtPasswordActual);
            panelConfiguracioSoci.Controls.Add(txtEmailSoci);
            panelConfiguracioSoci.Controls.Add(lblconf5);
            panelConfiguracioSoci.Controls.Add(ltbnconf3);
            panelConfiguracioSoci.Dock = DockStyle.Fill;
            panelConfiguracioSoci.Location = new Point(0, 33);
            panelConfiguracioSoci.Margin = new Padding(4);
            panelConfiguracioSoci.Name = "panelConfiguracioSoci";
            panelConfiguracioSoci.Size = new Size(1061, 545);
            panelConfiguracioSoci.TabIndex = 12;
            // 
            // txtTelefon
            // 
            txtTelefon.BorderStyle = BorderStyle.FixedSingle;
            txtTelefon.Location = new Point(428, 150);
            txtTelefon.MaxLength = 100;
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(208, 31);
            txtTelefon.TabIndex = 13;
            // 
            // ltbnconf4
            // 
            ltbnconf4.AutoSize = true;
            ltbnconf4.Location = new Point(350, 152);
            ltbnconf4.Name = "ltbnconf4";
            ltbnconf4.Size = new Size(72, 25);
            ltbnconf4.TabIndex = 12;
            ltbnconf4.Text = "Telèfon:";
            // 
            // checkBoxUpdatePassword
            // 
            checkBoxUpdatePassword.AutoSize = true;
            checkBoxUpdatePassword.Location = new Point(449, 187);
            checkBoxUpdatePassword.Name = "checkBoxUpdatePassword";
            checkBoxUpdatePassword.Size = new Size(178, 29);
            checkBoxUpdatePassword.TabIndex = 11;
            checkBoxUpdatePassword.Text = "Canviar password";
            checkBoxUpdatePassword.UseVisualStyleBackColor = true;
            // 
            // txtPasswordNou
            // 
            txtPasswordNou.BorderStyle = BorderStyle.FixedSingle;
            txtPasswordNou.Location = new Point(428, 259);
            txtPasswordNou.MaxLength = 14;
            txtPasswordNou.Name = "txtPasswordNou";
            txtPasswordNou.Size = new Size(208, 31);
            txtPasswordNou.TabIndex = 10;
            // 
            // ltbnconf6
            // 
            ltbnconf6.AutoSize = true;
            ltbnconf6.Location = new Point(290, 259);
            ltbnconf6.Name = "ltbnconf6";
            ltbnconf6.Size = new Size(132, 25);
            ltbnconf6.TabIndex = 9;
            ltbnconf6.Text = "Nou password:";
            // 
            // txtCognomSoci
            // 
            txtCognomSoci.AcceptsReturn = true;
            txtCognomSoci.BorderStyle = BorderStyle.FixedSingle;
            txtCognomSoci.Location = new Point(428, 76);
            txtCognomSoci.MaxLength = 20;
            txtCognomSoci.Name = "txtCognomSoci";
            txtCognomSoci.Size = new Size(208, 31);
            txtCognomSoci.TabIndex = 8;
            // 
            // txtNomSoci
            // 
            txtNomSoci.BorderStyle = BorderStyle.FixedSingle;
            txtNomSoci.Location = new Point(428, 41);
            txtNomSoci.MaxLength = 20;
            txtNomSoci.Name = "txtNomSoci";
            txtNomSoci.Size = new Size(208, 31);
            txtNomSoci.TabIndex = 7;
            // 
            // lblconf2
            // 
            lblconf2.AutoSize = true;
            lblconf2.Location = new Point(336, 78);
            lblconf2.Name = "lblconf2";
            lblconf2.Size = new Size(86, 25);
            lblconf2.TabIndex = 6;
            lblconf2.Text = "Cognom:";
            // 
            // lblconf1
            // 
            lblconf1.AutoSize = true;
            lblconf1.Location = new Point(364, 44);
            lblconf1.Name = "lblconf1";
            lblconf1.Size = new Size(56, 25);
            lblconf1.TabIndex = 5;
            lblconf1.Text = "Nom:";
            // 
            // btnActualitzarDadesSoci
            // 
            btnActualitzarDadesSoci.Location = new Point(428, 301);
            btnActualitzarDadesSoci.Name = "btnActualitzarDadesSoci";
            btnActualitzarDadesSoci.Size = new Size(208, 34);
            btnActualitzarDadesSoci.TabIndex = 4;
            btnActualitzarDadesSoci.Text = "Actualitzar dades";
            btnActualitzarDadesSoci.UseVisualStyleBackColor = true;
            btnActualitzarDadesSoci.Click += btnActualitzarDadesSoci_Click;
            // 
            // txtPasswordActual
            // 
            txtPasswordActual.BorderStyle = BorderStyle.FixedSingle;
            txtPasswordActual.Location = new Point(428, 222);
            txtPasswordActual.MaxLength = 14;
            txtPasswordActual.Name = "txtPasswordActual";
            txtPasswordActual.Size = new Size(208, 31);
            txtPasswordActual.TabIndex = 3;
            // 
            // txtEmailSoci
            // 
            txtEmailSoci.BorderStyle = BorderStyle.FixedSingle;
            txtEmailSoci.Location = new Point(428, 113);
            txtEmailSoci.MaxLength = 100;
            txtEmailSoci.Name = "txtEmailSoci";
            txtEmailSoci.Size = new Size(208, 31);
            txtEmailSoci.TabIndex = 2;
            // 
            // lblconf5
            // 
            lblconf5.AutoSize = true;
            lblconf5.Location = new Point(329, 222);
            lblconf5.Name = "lblconf5";
            lblconf5.Size = new Size(91, 25);
            lblconf5.TabIndex = 1;
            lblconf5.Text = "Password:";
            // 
            // ltbnconf3
            // 
            ltbnconf3.AutoSize = true;
            ltbnconf3.Location = new Point(364, 115);
            ltbnconf3.Name = "ltbnconf3";
            ltbnconf3.Size = new Size(58, 25);
            ltbnconf3.TabIndex = 0;
            ltbnconf3.Text = "email:";
            // 
            // menuStripUsuari
            // 
            menuStripUsuari.ImageScalingSize = new Size(24, 24);
            menuStripUsuari.Items.AddRange(new ToolStripItem[] { menuMevesReserves, menuNovaReserva, menuConfiguracioUsuari });
            menuStripUsuari.Location = new Point(0, 0);
            menuStripUsuari.Name = "menuStripUsuari";
            menuStripUsuari.Size = new Size(1061, 33);
            menuStripUsuari.TabIndex = 13;
            menuStripUsuari.Text = "menuStrip1";
            // 
            // menuMevesReserves
            // 
            menuMevesReserves.Name = "menuMevesReserves";
            menuMevesReserves.Size = new Size(178, 29);
            menuMevesReserves.Text = "Les meves reserves";
            // 
            // menuNovaReserva
            // 
            menuNovaReserva.Name = "menuNovaReserva";
            menuNovaReserva.Size = new Size(131, 29);
            menuNovaReserva.Text = "Nova reserva";
            // 
            // menuConfiguracioUsuari
            // 
            menuConfiguracioUsuari.DropDownItems.AddRange(new ToolStripItem[] { menuActualitzarDadesPersonals, menuCanviarContrasenyaUsuari });
            menuConfiguracioUsuari.Name = "menuConfiguracioUsuari";
            menuConfiguracioUsuari.Size = new Size(196, 29);
            menuConfiguracioUsuari.Text = "Configuració d'usuari";
            // 
            // menuActualitzarDadesPersonals
            // 
            menuActualitzarDadesPersonals.Name = "menuActualitzarDadesPersonals";
            menuActualitzarDadesPersonals.Size = new Size(330, 34);
            menuActualitzarDadesPersonals.Text = "Actualitzar dades personals";
            // 
            // menuCanviarContrasenyaUsuari
            // 
            menuCanviarContrasenyaUsuari.Name = "menuCanviarContrasenyaUsuari";
            menuCanviarContrasenyaUsuari.Size = new Size(330, 34);
            menuCanviarContrasenyaUsuari.Text = "Canviar contrasenya";
            // 
            // FormUsuari
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(213, 221, 40);
            ClientSize = new Size(1061, 578);
            Controls.Add(panelLogo);
            Controls.Add(panelConfiguracioSoci);
            Controls.Add(panelNovaReserva);
            Controls.Add(panelReserves);
            Controls.Add(menuStripUsuari);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStripUsuari;
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "FormUsuari";
            Text = "Easy Padel - Panell de soci";
            Load += FormUsuari_Load;
            panelReserves.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewReservesSoci).EndInit();
            panelNovaReserva.ResumeLayout(false);
            panelNovaReserva.PerformLayout();
            panelConfiguracioSoci.ResumeLayout(false);
            panelConfiguracioSoci.PerformLayout();
            menuStripUsuari.ResumeLayout(false);
            menuStripUsuari.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelLogo;
        private Panel panelReserves;
        private DataGridView dataGridViewReservesSoci;

        private void dataGridViewReservesSoci_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private Button btnReservesActuals;
        private Button btnReservesAnteriors;
        private Button btnCancelarReserva;
        private Panel panelNovaReserva;
        private Panel panelConfiguracioSoci;
        private Label lblNovaReserva1;
        private Label lblNovaReserva2;
        private MonthCalendar monthCalendarSeleccio;
        private Label lblNovaReserva3;
        private Label lblNovaReserva4;
        private ListBox listPistesDisponibles;
        private ListBox listTorns;
        private Button btnExecutarNovaReserva;
        private TextBox txtPasswordActual;
        private TextBox txtEmailSoci;
        private Label lblconf5;
        private Label ltbnconf3;
        private Button btnActualitzarDadesSoci;
        private Label lblconf1;
        private TextBox txtCognomSoci;
        private TextBox txtNomSoci;
        private Label lblconf2;
        private TextBox txtPasswordNou;
        private Label ltbnconf6;
        private CheckBox checkBoxUpdatePassword;
        private TextBox txtTelefon;
        private Label ltbnconf4;
        private MenuStrip menuStripUsuari;
        private ToolStripMenuItem menuMevesReserves;
        private ToolStripMenuItem menuNovaReserva;
        private ToolStripMenuItem menuConfiguracioUsuari;
        private ToolStripMenuItem menuActualitzarDadesPersonals;
        private ToolStripMenuItem menuCanviarContrasenyaUsuari;
    }
}