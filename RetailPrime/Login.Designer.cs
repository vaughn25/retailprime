namespace RetailPrime
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlLogin = new FlowLayoutPanel();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            mskPassword = new MaskedTextBox();
            btnLogin = new Button();
            lblAppName = new Label();
            pnlLogin.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLogin
            // 
            pnlLogin.Controls.Add(lblUsername);
            pnlLogin.Controls.Add(txtUsername);
            pnlLogin.Controls.Add(lblPassword);
            pnlLogin.Controls.Add(mskPassword);
            pnlLogin.Location = new Point(12, 103);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(322, 64);
            pnlLogin.TabIndex = 0;
            // 
            // lblUsername
            // 
            lblUsername.Location = new Point(3, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(72, 23);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username:";
            lblUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(81, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(234, 23);
            txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(3, 29);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(72, 23);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            lblPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mskPassword
            // 
            mskPassword.Location = new Point(81, 32);
            mskPassword.Name = "mskPassword";
            mskPassword.Size = new Size(234, 23);
            mskPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(12, 173);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(322, 23);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += this.btnLogin_Click;
            // 
            // lblAppName
            // 
            lblAppName.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.Location = new Point(12, 9);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(322, 69);
            lblAppName.TabIndex = 5;
            lblAppName.Text = "Retail Prime";
            lblAppName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 208);
            Controls.Add(lblAppName);
            Controls.Add(pnlLogin);
            Controls.Add(btnLogin);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel pnlLogin;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private MaskedTextBox mskPassword;
        private Button btnLogin;
        private Label lblAppName;
    }
}
