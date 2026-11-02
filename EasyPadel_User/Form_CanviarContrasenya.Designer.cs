namespace EasyPadel_User
{
    partial class Form_CanviarContrasenya
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
            txtPasswordNou = new TextBox();
            ltbnconf6 = new Label();
            btnCanviarContrasenya = new Button();
            txtPasswordActual = new TextBox();
            lblconf5 = new Label();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // txtPasswordNou
            // 
            txtPasswordNou.BorderStyle = BorderStyle.FixedSingle;
            txtPasswordNou.Location = new Point(160, 49);
            txtPasswordNou.MaxLength = 20;
            txtPasswordNou.Name = "txtPasswordNou";
            txtPasswordNou.PasswordChar = '*';
            txtPasswordNou.Size = new Size(228, 31);
            txtPasswordNou.TabIndex = 15;
            // 
            // ltbnconf6
            // 
            ltbnconf6.AutoSize = true;
            ltbnconf6.Location = new Point(22, 51);
            ltbnconf6.Name = "ltbnconf6";
            ltbnconf6.Size = new Size(132, 25);
            ltbnconf6.TabIndex = 14;
            ltbnconf6.Text = "Nou password:";
            // 
            // btnCanviarContrasenya
            // 
            btnCanviarContrasenya.Location = new Point(12, 89);
            btnCanviarContrasenya.Name = "btnCanviarContrasenya";
            btnCanviarContrasenya.Size = new Size(187, 34);
            btnCanviarContrasenya.TabIndex = 13;
            btnCanviarContrasenya.Text = "Canviar contrasenya";
            btnCanviarContrasenya.UseVisualStyleBackColor = true;
            // 
            // txtPasswordActual
            // 
            txtPasswordActual.BorderStyle = BorderStyle.FixedSingle;
            txtPasswordActual.Location = new Point(160, 12);
            txtPasswordActual.MaxLength = 100;
            txtPasswordActual.Name = "txtPasswordActual";
            txtPasswordActual.PasswordChar = '*';
            txtPasswordActual.Size = new Size(228, 31);
            txtPasswordActual.TabIndex = 12;
            // 
            // lblconf5
            // 
            lblconf5.AutoSize = true;
            lblconf5.Location = new Point(12, 14);
            lblconf5.Name = "lblconf5";
            lblconf5.Size = new Size(142, 25);
            lblconf5.TabIndex = 11;
            lblconf5.Text = "Password acutal:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(205, 89);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(187, 34);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // Form_CanviarContrasenya
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(400, 135);
            ControlBox = false;
            Controls.Add(btnCancelar);
            Controls.Add(txtPasswordNou);
            Controls.Add(ltbnconf6);
            Controls.Add(btnCanviarContrasenya);
            Controls.Add(txtPasswordActual);
            Controls.Add(lblconf5);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form_CanviarContrasenya";
            Text = "Canviar contrasenya";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPasswordNou;
        private Label ltbnconf6;
        private Button btnCanviarContrasenya;
        private TextBox txtPasswordActual;
        private Label lblconf5;
        private Button btnCancelar;
    }
}