namespace EasyPadel_User
{
    partial class FormSetupServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetupServer));
            TextBox txtHost;
            label1 = new Label();
            btnInstalarBD = new Button();
            label2 = new Label();
            label3 = new Label();
            txtPort = new TextBox();
            label4 = new Label();
            txtUserAdmin = new TextBox();
            label5 = new Label();
            txtPassworAdmin = new TextBox();
            txtHost = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 19);
            label1.Name = "label1";
            label1.Size = new Size(550, 200);
            label1.TabIndex = 0;
            label1.Text = resources.GetString("label1.Text");
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // btnInstalarBD
            // 
            btnInstalarBD.Location = new Point(143, 387);
            btnInstalarBD.Name = "btnInstalarBD";
            btnInstalarBD.Size = new Size(302, 34);
            btnInstalarBD.TabIndex = 1;
            btnInstalarBD.Text = "Instalar base de dades";
            btnInstalarBD.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(241, 220);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 2;
            label2.Text = "Host:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(247, 257);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 4;
            label3.Text = "Port:";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(295, 254);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(150, 31);
            txtPort.TabIndex = 5;
            txtPort.Text = "3306";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(127, 294);
            label4.Name = "label4";
            label4.Size = new Size(168, 25);
            label4.TabIndex = 6;
            label4.Text = "User admin MySQL:";
            // 
            // txtUserAdmin
            // 
            txtUserAdmin.Location = new Point(295, 291);
            txtUserAdmin.Name = "txtUserAdmin";
            txtUserAdmin.Size = new Size(150, 31);
            txtUserAdmin.TabIndex = 7;
            txtUserAdmin.Text = "admin";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(143, 331);
            label5.Name = "label5";
            label5.Size = new Size(146, 25);
            label5.TabIndex = 8;
            label5.Text = "Password admin:";
            // 
            // txtPassworAdmin
            // 
            txtPassworAdmin.Location = new Point(295, 328);
            txtPassworAdmin.Name = "txtPassworAdmin";
            txtPassworAdmin.PasswordChar = '*';
            txtPassworAdmin.Size = new Size(150, 31);
            txtPassworAdmin.TabIndex = 9;
            txtPassworAdmin.Text = "1234";
            // 
            // txtHost
            // 
            txtHost.Location = new Point(295, 217);
            txtHost.Name = "txtHost";
            txtHost.Size = new Size(150, 31);
            txtHost.TabIndex = 3;
            txtHost.Text = "localhost";
            // 
            // FormSetupServer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(599, 445);
            Controls.Add(txtPassworAdmin);
            Controls.Add(label5);
            Controls.Add(txtUserAdmin);
            Controls.Add(label4);
            Controls.Add(txtPort);
            Controls.Add(label3);
            Controls.Add(txtHost);
            Controls.Add(label2);
            Controls.Add(btnInstalarBD);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormSetupServer";
            Text = "EasyPadel - Primera execucció";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnInstalarBD;
        private Label label2;
        private Label label3;
        private TextBox txtHost;
        private TextBox txtPort;
        private Label label4;
        private TextBox txtUserAdmin;
        private Label label5;
        private TextBox txtPassworAdmin;
    }
}