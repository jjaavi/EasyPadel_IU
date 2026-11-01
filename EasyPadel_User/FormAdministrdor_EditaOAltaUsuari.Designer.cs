namespace EasyPadel_User
{
    partial class FormAdministrdor_EditaOAltaUsuari
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
            lblNom = new Label();
            txtNom = new TextBox();
            lblCognom = new Label();
            txtCognom = new TextBox();
            lblTelefon = new Label();
            txtTelefon = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            checkBoxAdmin = new CheckBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.Location = new Point(60, 26);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(56, 25);
            lblNom.TabIndex = 0;
            lblNom.Text = "Nom:";
            // 
            // txtNom
            // 
            txtNom.BorderStyle = BorderStyle.FixedSingle;
            txtNom.Location = new Point(122, 23);
            txtNom.MaxLength = 20;
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(194, 31);
            txtNom.TabIndex = 1;
            // 
            // lblCognom
            // 
            lblCognom.AutoSize = true;
            lblCognom.Location = new Point(30, 63);
            lblCognom.Name = "lblCognom";
            lblCognom.Size = new Size(86, 25);
            lblCognom.TabIndex = 2;
            lblCognom.Text = "Cognom:";
            // 
            // txtCognom
            // 
            txtCognom.BorderStyle = BorderStyle.FixedSingle;
            txtCognom.Location = new Point(122, 60);
            txtCognom.MaxLength = 20;
            txtCognom.Name = "txtCognom";
            txtCognom.Size = new Size(194, 31);
            txtCognom.TabIndex = 3;
            // 
            // lblTelefon
            // 
            lblTelefon.AutoSize = true;
            lblTelefon.Location = new Point(44, 103);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new Size(72, 25);
            lblTelefon.TabIndex = 4;
            lblTelefon.Text = "Telèfon:";
            // 
            // txtTelefon
            // 
            txtTelefon.BorderStyle = BorderStyle.FixedSingle;
            txtTelefon.Location = new Point(122, 97);
            txtTelefon.MaxLength = 15;
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(194, 31);
            txtTelefon.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(58, 161);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(122, 158);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(194, 31);
            txtEmail.TabIndex = 7;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(25, 198);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(91, 25);
            lblPassword.TabIndex = 8;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(122, 195);
            txtPassword.MaxLength = 200;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(194, 31);
            txtPassword.TabIndex = 9;
            // 
            // checkBoxAdmin
            // 
            checkBoxAdmin.AutoSize = true;
            checkBoxAdmin.Location = new Point(122, 246);
            checkBoxAdmin.Name = "checkBoxAdmin";
            checkBoxAdmin.Size = new Size(152, 29);
            checkBoxAdmin.TabIndex = 10;
            checkBoxAdmin.Text = "Administrador";
            checkBoxAdmin.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(12, 295);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(159, 34);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(177, 295);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(155, 34);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormAdministrdor_EditaOAltaUsuari
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 341);
            ControlBox = false;
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(checkBoxAdmin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtTelefon);
            Controls.Add(lblTelefon);
            Controls.Add(txtCognom);
            Controls.Add(lblCognom);
            Controls.Add(txtNom);
            Controls.Add(lblNom);
            Name = "FormAdministrdor_EditaOAltaUsuari";
            Text = "Usuari";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNom;
        private Label lblCognom;
        private Label lblTelefon;
        private Label lblEmail;
        private Label lblPassword;
        private Button btnGuardar;
        private Button btnCancelar;
        internal TextBox txtNom;
        internal TextBox txtCognom;
        internal TextBox txtTelefon;
        internal TextBox txtEmail;
        internal TextBox txtPassword;
        internal CheckBox checkBoxAdmin;
    }
}
