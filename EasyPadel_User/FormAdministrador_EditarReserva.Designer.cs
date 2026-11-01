namespace EasyPadel_User
{
    partial class FormAdministrador_EditarReserva
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtIdUsuari = new TextBox();
            listBoxPistas = new ListBox();
            txtData = new TextBox();
            comboBoxTorns = new ComboBox();
            btnModificarReserva = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 16);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 0;
            label1.Text = "ID Usuari:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 50);
            label2.Name = "label2";
            label2.Size = new Size(53, 25);
            label2.TabIndex = 1;
            label2.Text = "Pista:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(61, 185);
            label3.Name = "label3";
            label3.Size = new Size(53, 25);
            label3.TabIndex = 2;
            label3.Text = "Data:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(64, 224);
            label4.Name = "label4";
            label4.Size = new Size(50, 25);
            label4.TabIndex = 3;
            label4.Text = "Torn:";
            // 
            // txtIdUsuari
            // 
            txtIdUsuari.BorderStyle = BorderStyle.FixedSingle;
            txtIdUsuari.Location = new Point(120, 13);
            txtIdUsuari.Name = "txtIdUsuari";
            txtIdUsuari.Size = new Size(188, 31);
            txtIdUsuari.TabIndex = 4;
            // 
            // listBoxPistas
            // 
            listBoxPistas.BorderStyle = BorderStyle.FixedSingle;
            listBoxPistas.FormattingEnabled = true;
            listBoxPistas.Location = new Point(120, 50);
            listBoxPistas.Name = "listBoxPistas";
            listBoxPistas.Size = new Size(188, 127);
            listBoxPistas.TabIndex = 5;
            // 
            // txtData
            // 
            txtData.BorderStyle = BorderStyle.FixedSingle;
            txtData.Location = new Point(120, 183);
            txtData.Name = "txtData";
            txtData.Size = new Size(188, 31);
            txtData.TabIndex = 6;
            // 
            // comboBoxTorns
            // 
            comboBoxTorns.FormattingEnabled = true;
            comboBoxTorns.Location = new Point(120, 221);
            comboBoxTorns.Name = "comboBoxTorns";
            comboBoxTorns.Size = new Size(188, 33);
            comboBoxTorns.TabIndex = 7;
            // 
            // btnModificarReserva
            // 
            btnModificarReserva.Location = new Point(15, 276);
            btnModificarReserva.Name = "btnModificarReserva";
            btnModificarReserva.Size = new Size(167, 34);
            btnModificarReserva.TabIndex = 8;
            btnModificarReserva.Text = "Modificar";
            btnModificarReserva.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(188, 276);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(167, 34);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormAdministrador_EditarReserva
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(367, 322);
            ControlBox = false;
            Controls.Add(btnCancelar);
            Controls.Add(btnModificarReserva);
            Controls.Add(comboBoxTorns);
            Controls.Add(txtData);
            Controls.Add(listBoxPistas);
            Controls.Add(txtIdUsuari);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FormAdministrador_EditarReserva";
            Text = "Editar reserva";
            Load += FormAdministrador_EditarReserva_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtIdUsuari;
        private ListBox listBoxPistas;
        private TextBox txtData;
        private ComboBox comboBoxTorns;
        private Button btnModificarReserva;
        private Button btnCancelar;
    }
}