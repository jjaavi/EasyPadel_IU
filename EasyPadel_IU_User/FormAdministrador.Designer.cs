namespace EasyPadel_User
{
    partial class FormAdministrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdministrador));
            panelLogo = new Panel();
            panelReserves = new Panel();
            comboBoxFiltreTorn = new ComboBox();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtFiltreData = new TextBox();
            txtFiltrePista = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtFiltreIDUsuari = new TextBox();
            txtFiltreIDreserva = new TextBox();
            btnCercarReserva = new Button();
            dataGridReserves = new DataGridView();
            btnModificarReserva = new Button();
            btnEliminarReserva = new Button();
            panelUsuaris = new Panel();
            checkBoxEstat = new CheckBox();
            btnModificarUsuari = new Button();
            btnAltaUsuari = new Button();
            btnBaixaUsuari = new Button();
            comboBoxRol = new ComboBox();
            label11 = new Label();
            txtFiltreCognom = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtFiltreTelefon = new TextBox();
            txtFiltreNom = new TextBox();
            label9 = new Label();
            label10 = new Label();
            txtFiltreMail = new TextBox();
            txtFiltreUsuariUsuari = new TextBox();
            btnCercarUsuari = new Button();
            dataGridViewUsuaris = new DataGridView();
            panelMantenimentDePistes = new Panel();
            panelNovaPista = new Panel();
            btnNovaPista = new Button();
            label13 = new Label();
            btnMotrarNovaPista = new Button();
            txtNomPistaNova = new TextBox();
            panelModificarPista = new Panel();
            checkBoxPistaActiva = new CheckBox();
            btnModificarPista = new Button();
            label14 = new Label();
            txtNomPista = new TextBox();
            btnMostrarModificarPista = new Button();
            label12 = new Label();
            listBoxPistes = new ListBox();
            btnReserves = new Button();
            btnUsuaris = new Button();
            btnMantenimentDePistes = new Button();
            btnAltresConfiguracions = new Button();
            menuStripAdmin = new MenuStrip();
            menuReserves = new ToolStripMenuItem();
            menuUsuaris = new ToolStripMenuItem();
            manuMantenimentPistes = new ToolStripMenuItem();
            manuAltresConfiguracions = new ToolStripMenuItem();
            canviarPasswordDeAdminToolStripMenuItem = new ToolStripMenuItem();
            panelReserves.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridReserves).BeginInit();
            panelUsuaris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuaris).BeginInit();
            panelMantenimentDePistes.SuspendLayout();
            panelNovaPista.SuspendLayout();
            panelModificarPista.SuspendLayout();
            menuStripAdmin.SuspendLayout();
            SuspendLayout();
            // 
            // panelLogo
            // 
            panelLogo.BackgroundImage = EasyPadel_IU_User.Properties.Resources.EasyPadel_logo1;
            panelLogo.BackgroundImageLayout = ImageLayout.Zoom;
            panelLogo.Location = new Point(970, 475);
            panelLogo.Margin = new Padding(2);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(80, 75);
            panelLogo.TabIndex = 2;
            // 
            // panelReserves
            // 
            panelReserves.BackColor = Color.FromArgb(224, 224, 224);
            panelReserves.Controls.Add(comboBoxFiltreTorn);
            panelReserves.Controls.Add(label5);
            panelReserves.Controls.Add(label3);
            panelReserves.Controls.Add(label4);
            panelReserves.Controls.Add(txtFiltreData);
            panelReserves.Controls.Add(txtFiltrePista);
            panelReserves.Controls.Add(label2);
            panelReserves.Controls.Add(label1);
            panelReserves.Controls.Add(txtFiltreIDUsuari);
            panelReserves.Controls.Add(txtFiltreIDreserva);
            panelReserves.Controls.Add(btnCercarReserva);
            panelReserves.Controls.Add(dataGridReserves);
            panelReserves.Controls.Add(btnModificarReserva);
            panelReserves.Controls.Add(btnEliminarReserva);
            panelReserves.Dock = DockStyle.Fill;
            panelReserves.Location = new Point(0, 33);
            panelReserves.Margin = new Padding(2);
            panelReserves.Name = "panelReserves";
            panelReserves.Size = new Size(1061, 561);
            panelReserves.TabIndex = 4;
            // 
            // comboBoxFiltreTorn
            // 
            comboBoxFiltreTorn.FormattingEnabled = true;
            comboBoxFiltreTorn.Location = new Point(583, 12);
            comboBoxFiltreTorn.Name = "comboBoxFiltreTorn";
            comboBoxFiltreTorn.Size = new Size(150, 33);
            comboBoxFiltreTorn.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(527, 15);
            label5.Name = "label5";
            label5.Size = new Size(50, 25);
            label5.TabIndex = 13;
            label5.Text = "Torn:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(305, 52);
            label3.Name = "label3";
            label3.Size = new Size(53, 25);
            label3.TabIndex = 11;
            label3.Text = "Data:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(305, 15);
            label4.Name = "label4";
            label4.Size = new Size(53, 25);
            label4.TabIndex = 10;
            label4.Text = "Pista:";
            // 
            // txtFiltreData
            // 
            txtFiltreData.BorderStyle = BorderStyle.FixedSingle;
            txtFiltreData.Location = new Point(364, 52);
            txtFiltreData.Name = "txtFiltreData";
            txtFiltreData.Size = new Size(150, 31);
            txtFiltreData.TabIndex = 9;
            // 
            // txtFiltrePista
            // 
            txtFiltrePista.BorderStyle = BorderStyle.FixedSingle;
            txtFiltrePista.Location = new Point(364, 11);
            txtFiltrePista.Name = "txtFiltrePista";
            txtFiltrePista.Size = new Size(150, 31);
            txtFiltrePista.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 54);
            label2.Name = "label2";
            label2.Size = new Size(99, 25);
            label2.TabIndex = 7;
            label2.Text = "Id d'usuari:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 13);
            label1.Name = "label1";
            label1.Size = new Size(118, 25);
            label1.TabIndex = 6;
            label1.Text = "Id de reserva:";
            // 
            // txtFiltreIDUsuari
            // 
            txtFiltreIDUsuari.BorderStyle = BorderStyle.FixedSingle;
            txtFiltreIDUsuari.Location = new Point(145, 52);
            txtFiltreIDUsuari.Name = "txtFiltreIDUsuari";
            txtFiltreIDUsuari.Size = new Size(150, 31);
            txtFiltreIDUsuari.TabIndex = 5;
            // 
            // txtFiltreIDreserva
            // 
            txtFiltreIDreserva.BorderStyle = BorderStyle.FixedSingle;
            txtFiltreIDreserva.Location = new Point(145, 11);
            txtFiltreIDreserva.Name = "txtFiltreIDreserva";
            txtFiltreIDreserva.Size = new Size(150, 31);
            txtFiltreIDreserva.TabIndex = 4;
            // 
            // btnCercarReserva
            // 
            btnCercarReserva.Location = new Point(866, 12);
            btnCercarReserva.Name = "btnCercarReserva";
            btnCercarReserva.Size = new Size(155, 34);
            btnCercarReserva.TabIndex = 3;
            btnCercarReserva.Text = "Cercar";
            btnCercarReserva.UseVisualStyleBackColor = true;
            btnCercarReserva.Click += btnCercarReserva_Click;
            // 
            // dataGridReserves
            // 
            dataGridReserves.AllowUserToAddRows = false;
            dataGridReserves.AllowUserToDeleteRows = false;
            dataGridReserves.AllowUserToOrderColumns = true;
            dataGridReserves.BackgroundColor = SystemColors.Control;
            dataGridReserves.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridReserves.Location = new Point(14, 89);
            dataGridReserves.MultiSelect = false;
            dataGridReserves.Name = "dataGridReserves";
            dataGridReserves.ReadOnly = true;
            dataGridReserves.RowHeadersWidth = 62;
            dataGridReserves.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridReserves.Size = new Size(1007, 411);
            dataGridReserves.TabIndex = 2;
            // 
            // btnModificarReserva
            // 
            btnModificarReserva.Location = new Point(705, 506);
            btnModificarReserva.Name = "btnModificarReserva";
            btnModificarReserva.Size = new Size(155, 34);
            btnModificarReserva.TabIndex = 1;
            btnModificarReserva.Text = "Modificar";
            btnModificarReserva.UseVisualStyleBackColor = true;
            btnModificarReserva.Click += btnModificarReserva_Click;
            // 
            // btnEliminarReserva
            // 
            btnEliminarReserva.Location = new Point(866, 506);
            btnEliminarReserva.Name = "btnEliminarReserva";
            btnEliminarReserva.Size = new Size(155, 34);
            btnEliminarReserva.TabIndex = 0;
            btnEliminarReserva.Text = "Eliminar";
            btnEliminarReserva.UseVisualStyleBackColor = true;
            // 
            // panelUsuaris
            // 
            panelUsuaris.BackColor = Color.FromArgb(224, 224, 224);
            panelUsuaris.Controls.Add(checkBoxEstat);
            panelUsuaris.Controls.Add(btnModificarUsuari);
            panelUsuaris.Controls.Add(btnAltaUsuari);
            panelUsuaris.Controls.Add(btnBaixaUsuari);
            panelUsuaris.Controls.Add(comboBoxRol);
            panelUsuaris.Controls.Add(label11);
            panelUsuaris.Controls.Add(txtFiltreCognom);
            panelUsuaris.Controls.Add(label6);
            panelUsuaris.Controls.Add(label7);
            panelUsuaris.Controls.Add(label8);
            panelUsuaris.Controls.Add(txtFiltreTelefon);
            panelUsuaris.Controls.Add(txtFiltreNom);
            panelUsuaris.Controls.Add(label9);
            panelUsuaris.Controls.Add(label10);
            panelUsuaris.Controls.Add(txtFiltreMail);
            panelUsuaris.Controls.Add(txtFiltreUsuariUsuari);
            panelUsuaris.Controls.Add(btnCercarUsuari);
            panelUsuaris.Controls.Add(dataGridViewUsuaris);
            panelUsuaris.Dock = DockStyle.Fill;
            panelUsuaris.Location = new Point(0, 33);
            panelUsuaris.Name = "panelUsuaris";
            panelUsuaris.Size = new Size(1061, 561);
            panelUsuaris.TabIndex = 4;
            // 
            // checkBoxEstat
            // 
            checkBoxEstat.AutoSize = true;
            checkBoxEstat.Location = new Point(705, 12);
            checkBoxEstat.Name = "checkBoxEstat";
            checkBoxEstat.Size = new Size(78, 29);
            checkBoxEstat.TabIndex = 31;
            checkBoxEstat.Text = "Actiu";
            checkBoxEstat.UseVisualStyleBackColor = true;
            // 
            // btnModificarUsuari
            // 
            btnModificarUsuari.Location = new Point(705, 494);
            btnModificarUsuari.Name = "btnModificarUsuari";
            btnModificarUsuari.Size = new Size(155, 34);
            btnModificarUsuari.TabIndex = 30;
            btnModificarUsuari.Text = "Modificar";
            btnModificarUsuari.UseVisualStyleBackColor = true;
            // 
            // btnAltaUsuari
            // 
            btnAltaUsuari.Location = new Point(373, 494);
            btnAltaUsuari.Name = "btnAltaUsuari";
            btnAltaUsuari.Size = new Size(288, 46);
            btnAltaUsuari.TabIndex = 29;
            btnAltaUsuari.Text = "ALTA D'USUARI";
            btnAltaUsuari.UseVisualStyleBackColor = true;
            // 
            // btnBaixaUsuari
            // 
            btnBaixaUsuari.Location = new Point(868, 494);
            btnBaixaUsuari.Name = "btnBaixaUsuari";
            btnBaixaUsuari.Size = new Size(155, 34);
            btnBaixaUsuari.TabIndex = 28;
            btnBaixaUsuari.Text = "Baixa d'usuari";
            btnBaixaUsuari.UseVisualStyleBackColor = true;
            // 
            // comboBoxRol
            // 
            comboBoxRol.FormattingEnabled = true;
            comboBoxRol.Location = new Point(567, 46);
            comboBoxRol.Name = "comboBoxRol";
            comboBoxRol.Size = new Size(124, 33);
            comboBoxRol.TabIndex = 27;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(520, 51);
            label11.Name = "label11";
            label11.Size = new Size(41, 25);
            label11.TabIndex = 26;
            label11.Text = "Rol:";
            // 
            // txtFiltreCognom
            // 
            txtFiltreCognom.BorderStyle = BorderStyle.FixedSingle;
            txtFiltreCognom.Location = new Point(567, 10);
            txtFiltreCognom.Name = "txtFiltreCognom";
            txtFiltreCognom.Size = new Size(124, 31);
            txtFiltreCognom.TabIndex = 25;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(475, 12);
            label6.Name = "label6";
            label6.Size = new Size(86, 25);
            label6.TabIndex = 24;
            label6.Text = "Cognom:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(278, 51);
            label7.Name = "label7";
            label7.Size = new Size(53, 25);
            label7.TabIndex = 23;
            label7.Text = "Data:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(278, 14);
            label8.Name = "label8";
            label8.Size = new Size(56, 25);
            label8.TabIndex = 22;
            label8.Text = "Nom:";
            // 
            // txtFiltreTelefon
            // 
            txtFiltreTelefon.BorderStyle = BorderStyle.FixedSingle;
            txtFiltreTelefon.Location = new Point(337, 51);
            txtFiltreTelefon.Name = "txtFiltreTelefon";
            txtFiltreTelefon.Size = new Size(124, 31);
            txtFiltreTelefon.TabIndex = 21;
            // 
            // txtFiltreNom
            // 
            txtFiltreNom.BorderStyle = BorderStyle.FixedSingle;
            txtFiltreNom.Location = new Point(337, 10);
            txtFiltreNom.Name = "txtFiltreNom";
            txtFiltreNom.Size = new Size(124, 31);
            txtFiltreNom.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(81, 52);
            label9.Name = "label9";
            label9.Size = new Size(58, 25);
            label9.TabIndex = 19;
            label9.Text = "Email:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(40, 11);
            label10.Name = "label10";
            label10.Size = new Size(99, 25);
            label10.TabIndex = 18;
            label10.Text = "Id d'usuari:";
            // 
            // txtFiltreMail
            // 
            txtFiltreMail.BorderStyle = BorderStyle.FixedSingle;
            txtFiltreMail.Location = new Point(145, 50);
            txtFiltreMail.Name = "txtFiltreMail";
            txtFiltreMail.Size = new Size(124, 31);
            txtFiltreMail.TabIndex = 17;
            // 
            // txtFiltreUsuariUsuari
            // 
            txtFiltreUsuariUsuari.BorderStyle = BorderStyle.FixedSingle;
            txtFiltreUsuariUsuari.Location = new Point(145, 9);
            txtFiltreUsuariUsuari.Name = "txtFiltreUsuariUsuari";
            txtFiltreUsuariUsuari.Size = new Size(124, 31);
            txtFiltreUsuariUsuari.TabIndex = 16;
            // 
            // btnCercarUsuari
            // 
            btnCercarUsuari.Location = new Point(866, 10);
            btnCercarUsuari.Name = "btnCercarUsuari";
            btnCercarUsuari.Size = new Size(155, 34);
            btnCercarUsuari.TabIndex = 15;
            btnCercarUsuari.Text = "Cercar";
            btnCercarUsuari.UseVisualStyleBackColor = true;
            // 
            // dataGridViewUsuaris
            // 
            dataGridViewUsuaris.AllowUserToAddRows = false;
            dataGridViewUsuaris.AllowUserToDeleteRows = false;
            dataGridViewUsuaris.AllowUserToOrderColumns = true;
            dataGridViewUsuaris.BackgroundColor = SystemColors.Control;
            dataGridViewUsuaris.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsuaris.Location = new Point(16, 89);
            dataGridViewUsuaris.MultiSelect = false;
            dataGridViewUsuaris.Name = "dataGridViewUsuaris";
            dataGridViewUsuaris.ReadOnly = true;
            dataGridViewUsuaris.RowHeadersWidth = 62;
            dataGridViewUsuaris.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsuaris.Size = new Size(1007, 399);
            dataGridViewUsuaris.TabIndex = 3;
            // 
            // panelMantenimentDePistes
            // 
            panelMantenimentDePistes.BackColor = Color.FromArgb(224, 224, 224);
            panelMantenimentDePistes.Controls.Add(panelLogo);
            panelMantenimentDePistes.Controls.Add(panelNovaPista);
            panelMantenimentDePistes.Controls.Add(panelModificarPista);
            panelMantenimentDePistes.Controls.Add(label12);
            panelMantenimentDePistes.Controls.Add(listBoxPistes);
            panelMantenimentDePistes.Dock = DockStyle.Fill;
            panelMantenimentDePistes.Location = new Point(0, 33);
            panelMantenimentDePistes.Name = "panelMantenimentDePistes";
            panelMantenimentDePistes.Size = new Size(1061, 561);
            panelMantenimentDePistes.TabIndex = 5;
            // 
            // panelNovaPista
            // 
            panelNovaPista.BackColor = Color.WhiteSmoke;
            panelNovaPista.Controls.Add(btnNovaPista);
            panelNovaPista.Controls.Add(label13);
            panelNovaPista.Controls.Add(btnMotrarNovaPista);
            panelNovaPista.Controls.Add(txtNomPistaNova);
            panelNovaPista.Location = new Point(686, 92);
            panelNovaPista.Name = "panelNovaPista";
            panelNovaPista.Size = new Size(264, 379);
            panelNovaPista.TabIndex = 6;
            // 
            // btnNovaPista
            // 
            btnNovaPista.Location = new Point(75, 103);
            btnNovaPista.Name = "btnNovaPista";
            btnNovaPista.Size = new Size(178, 34);
            btnNovaPista.TabIndex = 5;
            btnNovaPista.Text = "Guardar";
            btnNovaPista.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(12, 68);
            label13.Name = "label13";
            label13.Size = new Size(56, 25);
            label13.TabIndex = 4;
            label13.Text = "Nom:";
            // 
            // btnMotrarNovaPista
            // 
            btnMotrarNovaPista.Location = new Point(9, 9);
            btnMotrarNovaPista.Name = "btnMotrarNovaPista";
            btnMotrarNovaPista.Size = new Size(243, 34);
            btnMotrarNovaPista.TabIndex = 2;
            btnMotrarNovaPista.Text = "Nova Pista";
            btnMotrarNovaPista.UseVisualStyleBackColor = true;
            // 
            // txtNomPistaNova
            // 
            txtNomPistaNova.BorderStyle = BorderStyle.FixedSingle;
            txtNomPistaNova.Location = new Point(74, 66);
            txtNomPistaNova.Name = "txtNomPistaNova";
            txtNomPistaNova.Size = new Size(178, 31);
            txtNomPistaNova.TabIndex = 3;
            // 
            // panelModificarPista
            // 
            panelModificarPista.BackColor = Color.WhiteSmoke;
            panelModificarPista.Controls.Add(checkBoxPistaActiva);
            panelModificarPista.Controls.Add(btnModificarPista);
            panelModificarPista.Controls.Add(label14);
            panelModificarPista.Controls.Add(txtNomPista);
            panelModificarPista.Controls.Add(btnMostrarModificarPista);
            panelModificarPista.Location = new Point(398, 92);
            panelModificarPista.Name = "panelModificarPista";
            panelModificarPista.Size = new Size(264, 379);
            panelModificarPista.TabIndex = 5;
            // 
            // checkBoxPistaActiva
            // 
            checkBoxPistaActiva.AutoSize = true;
            checkBoxPistaActiva.Location = new Point(74, 101);
            checkBoxPistaActiva.Name = "checkBoxPistaActiva";
            checkBoxPistaActiva.Size = new Size(167, 29);
            checkBoxPistaActiva.TabIndex = 7;
            checkBoxPistaActiva.Text = "En manteniment";
            checkBoxPistaActiva.UseVisualStyleBackColor = true;
            // 
            // btnModificarPista
            // 
            btnModificarPista.Location = new Point(74, 136);
            btnModificarPista.Name = "btnModificarPista";
            btnModificarPista.Size = new Size(178, 34);
            btnModificarPista.TabIndex = 6;
            btnModificarPista.Text = "Modificar";
            btnModificarPista.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(12, 66);
            label14.Name = "label14";
            label14.Size = new Size(56, 25);
            label14.TabIndex = 6;
            label14.Text = "Nom:";
            // 
            // txtNomPista
            // 
            txtNomPista.BorderStyle = BorderStyle.FixedSingle;
            txtNomPista.Location = new Point(74, 64);
            txtNomPista.Name = "txtNomPista";
            txtNomPista.Size = new Size(178, 31);
            txtNomPista.TabIndex = 5;
            // 
            // btnMostrarModificarPista
            // 
            btnMostrarModificarPista.Location = new Point(9, 9);
            btnMostrarModificarPista.Name = "btnMostrarModificarPista";
            btnMostrarModificarPista.Size = new Size(243, 34);
            btnMostrarModificarPista.TabIndex = 2;
            btnMostrarModificarPista.Text = "Modificar pista";
            btnMostrarModificarPista.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(102, 61);
            label12.Name = "label12";
            label12.Size = new Size(120, 25);
            label12.TabIndex = 4;
            label12.Text = "Pistes actuals:";
            // 
            // listBoxPistes
            // 
            listBoxPistes.BackColor = Color.White;
            listBoxPistes.FormattingEnabled = true;
            listBoxPistes.Location = new Point(102, 92);
            listBoxPistes.Name = "listBoxPistes";
            listBoxPistes.Size = new Size(264, 379);
            listBoxPistes.TabIndex = 0;
            // 
            // btnReserves
            // 
            btnReserves.Location = new Point(14, 79);
            btnReserves.Margin = new Padding(2);
            btnReserves.Name = "btnReserves";
            btnReserves.Size = new Size(220, 34);
            btnReserves.TabIndex = 5;
            btnReserves.Text = "Reserves";
            btnReserves.UseVisualStyleBackColor = true;
            // 
            // btnUsuaris
            // 
            btnUsuaris.Location = new Point(238, 79);
            btnUsuaris.Margin = new Padding(2);
            btnUsuaris.Name = "btnUsuaris";
            btnUsuaris.Size = new Size(220, 34);
            btnUsuaris.TabIndex = 6;
            btnUsuaris.Text = "Usuaris";
            btnUsuaris.UseVisualStyleBackColor = true;
            // 
            // btnMantenimentDePistes
            // 
            btnMantenimentDePistes.Location = new Point(462, 79);
            btnMantenimentDePistes.Margin = new Padding(2);
            btnMantenimentDePistes.Name = "btnMantenimentDePistes";
            btnMantenimentDePistes.Size = new Size(220, 34);
            btnMantenimentDePistes.TabIndex = 7;
            btnMantenimentDePistes.Text = "Manteniment de pistes";
            btnMantenimentDePistes.UseVisualStyleBackColor = true;
            // 
            // btnAltresConfiguracions
            // 
            btnAltresConfiguracions.Location = new Point(687, 79);
            btnAltresConfiguracions.Name = "btnAltresConfiguracions";
            btnAltresConfiguracions.Size = new Size(220, 34);
            btnAltresConfiguracions.TabIndex = 8;
            btnAltresConfiguracions.Text = "Altres configuracions";
            btnAltresConfiguracions.UseVisualStyleBackColor = true;
            // 
            // menuStripAdmin
            // 
            menuStripAdmin.ImageScalingSize = new Size(24, 24);
            menuStripAdmin.Items.AddRange(new ToolStripItem[] { menuReserves, menuUsuaris, manuMantenimentPistes, manuAltresConfiguracions });
            menuStripAdmin.Location = new Point(0, 0);
            menuStripAdmin.Name = "menuStripAdmin";
            menuStripAdmin.Size = new Size(1061, 33);
            menuStripAdmin.TabIndex = 9;
            menuStripAdmin.Text = "menuStrip1";
            // 
            // menuReserves
            // 
            menuReserves.Name = "menuReserves";
            menuReserves.Size = new Size(96, 29);
            menuReserves.Text = "Reserves";
            // 
            // menuUsuaris
            // 
            menuUsuaris.Name = "menuUsuaris";
            menuUsuaris.Size = new Size(85, 29);
            menuUsuaris.Text = "Usuaris";
            // 
            // manuMantenimentPistes
            // 
            manuMantenimentPistes.Name = "manuMantenimentPistes";
            manuMantenimentPistes.Size = new Size(209, 29);
            manuMantenimentPistes.Text = "Manteniment de pistes";
            // 
            // manuAltresConfiguracions
            // 
            manuAltresConfiguracions.DropDownItems.AddRange(new ToolStripItem[] { canviarPasswordDeAdminToolStripMenuItem });
            manuAltresConfiguracions.Name = "manuAltresConfiguracions";
            manuAltresConfiguracions.Size = new Size(194, 29);
            manuAltresConfiguracions.Text = "Altres configuracions";
            // 
            // canviarPasswordDeAdminToolStripMenuItem
            // 
            canviarPasswordDeAdminToolStripMenuItem.Name = "canviarPasswordDeAdminToolStripMenuItem";
            canviarPasswordDeAdminToolStripMenuItem.Size = new Size(334, 34);
            canviarPasswordDeAdminToolStripMenuItem.Text = "Canviar password de admin";
            canviarPasswordDeAdminToolStripMenuItem.Click += canviarPasswordDeAdminToolStripMenuItem_Click;
            // 
            // FormAdministrador
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Silver;
            ClientSize = new Size(1061, 594);
            Controls.Add(panelMantenimentDePistes);
            Controls.Add(panelUsuaris);
            Controls.Add(panelReserves);
            Controls.Add(menuStripAdmin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStripAdmin;
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "FormAdministrador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Easy Padel - Panell d'administrador";
            Load += FormAdministrador_Load;
            panelReserves.ResumeLayout(false);
            panelReserves.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridReserves).EndInit();
            panelUsuaris.ResumeLayout(false);
            panelUsuaris.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuaris).EndInit();
            panelMantenimentDePistes.ResumeLayout(false);
            panelMantenimentDePistes.PerformLayout();
            panelNovaPista.ResumeLayout(false);
            panelNovaPista.PerformLayout();
            panelModificarPista.ResumeLayout(false);
            panelModificarPista.PerformLayout();
            menuStripAdmin.ResumeLayout(false);
            menuStripAdmin.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelLogo;
        private Panel panelReserves;
        private Button btnReserves;
        private Button btnUsuaris;
        private Button btnMantenimentDePistes;
        private Button btnModificarReserva;
        private Button btnEliminarReserva;
        private DataGridView dataGridReserves;
        private Panel panelUsuaris;
        private Panel panelMantenimentDePistes;
        private Button btnCercarReserva;
        private Label label2;
        private Label label1;
        private TextBox txtFiltreIDUsuari;
        private TextBox txtFiltreIDreserva;
        private Label label5;
        private Label label3;
        private Label label4;
        private TextBox txtFiltreData;
        private TextBox txtFiltrePista;
        private ComboBox comboBoxFiltreTorn;
        private DataGridView dataGridViewUsuaris;
        private Label label11;
        private TextBox txtFiltreCognom;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtFiltreTelefon;
        private TextBox txtFiltreNom;
        private Label label9;
        private Label label10;
        private TextBox txtFiltreMail;
        private TextBox txtFiltreUsuariUsuari;
        private Button btnCercarUsuari;
        private Button btnBaixaUsuari;
        private ComboBox comboBoxRol;
        private Button btnAltaUsuari;
        private Button btnModificarUsuari;
        private CheckBox checkBoxEstat;
        private Button btnAltresConfiguracions;
        private ListBox listBoxPistes;
        private Button btnMostrarModificarPista;
        private Label label12;
        private Panel panelNovaPista;
        private Button btnMotrarNovaPista;
        private TextBox txtNomPistaNova;
        private Panel panelModificarPista;
        private Button btnNovaPista;
        private Label label13;
        private CheckBox checkBoxPistaActiva;
        private Button btnModificarPista;
        private Label label14;
        private TextBox txtNomPista;
        private MenuStrip menuStripAdmin;
        private ToolStripMenuItem menuReserves;
        private ToolStripMenuItem menuUsuaris;
        private ToolStripMenuItem manuMantenimentPistes;
        private ToolStripMenuItem manuAltresConfiguracions;
        private ToolStripMenuItem canviarPasswordDeAdminToolStripMenuItem;
    }
}