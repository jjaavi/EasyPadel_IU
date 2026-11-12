namespace EasyPadel_IU_Server
{
    partial class FormIUServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIUServer));
            label1 = new Label();
            panel1 = new Panel();
            btnArrancarServidor = new Button();
            label2 = new Label();
            btnParar = new Button();
            panelEstatServidorNotOK = new Panel();
            panelEstatServidorOK = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(61, 9);
            label1.Name = "label1";
            label1.Size = new Size(399, 29);
            label1.TabIndex = 0;
            label1.Text = "Control de Servidor de EasyPadel";
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 150);
            panel1.Name = "panel1";
            panel1.Size = new Size(493, 100);
            panel1.TabIndex = 1;
            // 
            // btnArrancarServidor
            // 
            btnArrancarServidor.Location = new Point(35, 59);
            btnArrancarServidor.Name = "btnArrancarServidor";
            btnArrancarServidor.Size = new Size(173, 36);
            btnArrancarServidor.TabIndex = 2;
            btnArrancarServidor.Text = "Arrencar";
            btnArrancarServidor.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(295, 59);
            label2.Name = "label2";
            label2.Size = new Size(133, 18);
            label2.TabIndex = 3;
            label2.Text = "Estat del servidor:";
            // 
            // btnParar
            // 
            btnParar.Enabled = false;
            btnParar.Location = new Point(35, 101);
            btnParar.Name = "btnParar";
            btnParar.Size = new Size(173, 36);
            btnParar.TabIndex = 4;
            btnParar.Text = "Parar";
            btnParar.UseVisualStyleBackColor = true;
            // 
            // panelEstatServidorNotOK
            // 
            panelEstatServidorNotOK.BackgroundImage = (Image)resources.GetObject("panelEstatServidorNotOK.BackgroundImage");
            panelEstatServidorNotOK.BackgroundImageLayout = ImageLayout.Zoom;
            panelEstatServidorNotOK.Location = new Point(329, 87);
            panelEstatServidorNotOK.Name = "panelEstatServidorNotOK";
            panelEstatServidorNotOK.Size = new Size(68, 49);
            panelEstatServidorNotOK.TabIndex = 5;
            // 
            // panelEstatServidorOK
            // 
            panelEstatServidorOK.BackgroundImage = (Image)resources.GetObject("panelEstatServidorOK.BackgroundImage");
            panelEstatServidorOK.BackgroundImageLayout = ImageLayout.Zoom;
            panelEstatServidorOK.Location = new Point(329, 87);
            panelEstatServidorOK.Name = "panelEstatServidorOK";
            panelEstatServidorOK.Size = new Size(68, 49);
            panelEstatServidorOK.TabIndex = 6;
            // 
            // FormIUServer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 221, 40);
            ClientSize = new Size(493, 250);
            Controls.Add(panelEstatServidorOK);
            Controls.Add(panelEstatServidorNotOK);
            Controls.Add(btnParar);
            Controls.Add(label2);
            Controls.Add(btnArrancarServidor);
            Controls.Add(panel1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormIUServer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EasyPadel - Servidor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Button btnArrancarServidor;
        private Label label2;
        private Button btnParar;
        private Panel panelEstatServidorNotOK;
        private Panel panelEstatServidorOK;
    }
}