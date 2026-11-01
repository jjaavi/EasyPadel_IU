namespace EasyPadel_User
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            Login = new Button();
            textBoxPassword = new TextBox();
            textBoxUsuari = new TextBox();
            panel2 = new Panel();
            printDialog1 = new PrintDialog();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(Login);
            panel1.Controls.Add(textBoxPassword);
            panel1.Controls.Add(textBoxUsuari);
            panel1.Location = new Point(51, 275);
            panel1.Name = "panel1";
            panel1.Size = new Size(410, 282);
            panel1.TabIndex = 0;
            // 
            // Login
            // 
            Login.Location = new Point(148, 162);
            Login.Name = "Login";
            Login.Size = new Size(112, 34);
            Login.TabIndex = 2;
            Login.Text = "Login";
            Login.UseVisualStyleBackColor = true;
            Login.Click += Login_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxPassword.Location = new Point(112, 109);
            textBoxPassword.MaxLength = 100;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(182, 31);
            textBoxPassword.TabIndex = 1;
            // 
            // textBoxUsuari
            // 
            textBoxUsuari.BorderStyle = BorderStyle.FixedSingle;
            textBoxUsuari.Location = new Point(112, 56);
            textBoxUsuari.MaxLength = 100;
            textBoxUsuari.Name = "textBoxUsuari";
            textBoxUsuari.Size = new Size(182, 31);
            textBoxUsuari.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackgroundImage = Properties.Resources.EasyPadel_logo1;
            panel2.BackgroundImageLayout = ImageLayout.Zoom;
            panel2.Location = new Point(51, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(410, 238);
            panel2.TabIndex = 1;
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 221, 40);
            ClientSize = new Size(513, 594);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormLogin";
            Text = "EasyPadel";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBoxPassword;
        private TextBox textBoxUsuari;
        private Button Login;
        private Panel panel2;
        private PrintDialog printDialog1;
    }
}
