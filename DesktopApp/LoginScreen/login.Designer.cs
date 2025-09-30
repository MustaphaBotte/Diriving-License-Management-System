namespace DesktopApp.LoginScreen
{
    partial class LoginFrm
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrm));
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            usernameTextbox = new Guna.UI2.WinForms.Guna2TextBox();
            passwordTextbox = new Guna.UI2.WinForms.Guna2TextBox();
            RememberMeCheck = new Guna.UI2.WinForms.Guna2CheckBox();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            ShowPassword = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            SignInButton = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            errorProvider1 = new ErrorProvider(components);
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Sylfaen", 14.25F, FontStyle.Bold);
            guna2HtmlLabel1.ForeColor = Color.White;
            guna2HtmlLabel1.Location = new Point(31, 169);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(86, 27);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Password";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Sylfaen", 14.25F, FontStyle.Bold);
            guna2HtmlLabel2.ForeColor = Color.White;
            guna2HtmlLabel2.Location = new Point(25, 103);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(92, 27);
            guna2HtmlLabel2.TabIndex = 1;
            guna2HtmlLabel2.Text = "Username";
            // 
            // usernameTextbox
            // 
            usernameTextbox.BorderColor = Color.Transparent;
            usernameTextbox.BorderRadius = 10;
            usernameTextbox.CustomizableEdges = customizableEdges1;
            usernameTextbox.DefaultText = "";
            usernameTextbox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            usernameTextbox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            usernameTextbox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            usernameTextbox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            usernameTextbox.FillColor = Color.DimGray;
            usernameTextbox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            usernameTextbox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            usernameTextbox.ForeColor = Color.White;
            usernameTextbox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            usernameTextbox.Location = new Point(145, 94);
            usernameTextbox.Name = "usernameTextbox";
            usernameTextbox.PlaceholderText = "username";
            usernameTextbox.SelectedText = "";
            usernameTextbox.ShadowDecoration.CustomizableEdges = customizableEdges2;
            usernameTextbox.Size = new Size(200, 36);
            usernameTextbox.TabIndex = 2;
            usernameTextbox.Leave += usernameTextbox_Leave;
            // 
            // passwordTextbox
            // 
            passwordTextbox.BorderColor = Color.Transparent;
            passwordTextbox.BorderRadius = 10;
            passwordTextbox.CustomizableEdges = customizableEdges3;
            passwordTextbox.DefaultText = "";
            passwordTextbox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            passwordTextbox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            passwordTextbox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            passwordTextbox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            passwordTextbox.FillColor = Color.DimGray;
            passwordTextbox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            passwordTextbox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            passwordTextbox.ForeColor = Color.White;
            passwordTextbox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            passwordTextbox.Location = new Point(145, 160);
            passwordTextbox.Name = "passwordTextbox";
            passwordTextbox.PasswordChar = '*';
            passwordTextbox.PlaceholderText = "password";
            passwordTextbox.SelectedText = "";
            passwordTextbox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            passwordTextbox.Size = new Size(200, 36);
            passwordTextbox.TabIndex = 3;
            passwordTextbox.Leave += usernameTextbox_Leave;
            // 
            // RememberMeCheck
            // 
            RememberMeCheck.AutoSize = true;
            RememberMeCheck.Checked = true;
            RememberMeCheck.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            RememberMeCheck.CheckedState.BorderRadius = 0;
            RememberMeCheck.CheckedState.BorderThickness = 0;
            RememberMeCheck.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            RememberMeCheck.CheckState = CheckState.Checked;
            RememberMeCheck.ForeColor = Color.White;
            RememberMeCheck.Location = new Point(145, 216);
            RememberMeCheck.Name = "RememberMeCheck";
            RememberMeCheck.Size = new Size(104, 19);
            RememberMeCheck.TabIndex = 4;
            RememberMeCheck.Text = "Remember me";
            RememberMeCheck.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            RememberMeCheck.UncheckedState.BorderRadius = 0;
            RememberMeCheck.UncheckedState.BorderThickness = 0;
            RememberMeCheck.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.BorderColor = Color.FromArgb(64, 64, 64);
            guna2Panel1.BorderRadius = 20;
            guna2Panel1.BorderThickness = 1;
            guna2Panel1.Controls.Add(ShowPassword);
            guna2Panel1.Controls.Add(SignInButton);
            guna2Panel1.Controls.Add(guna2HtmlLabel3);
            guna2Panel1.Controls.Add(usernameTextbox);
            guna2Panel1.Controls.Add(RememberMeCheck);
            guna2Panel1.Controls.Add(guna2HtmlLabel1);
            guna2Panel1.Controls.Add(passwordTextbox);
            guna2Panel1.Controls.Add(guna2HtmlLabel2);
            guna2Panel1.CustomizableEdges = customizableEdges9;
            guna2Panel1.Location = new Point(178, 42);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Panel1.Size = new Size(381, 346);
            guna2Panel1.TabIndex = 5;
            // 
            // ShowPassword
            // 
            ShowPassword.BackColor = Color.DimGray;
            ShowPassword.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            ShowPassword.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            ShowPassword.CheckedState.BorderRadius = 2;
            ShowPassword.CheckedState.BorderThickness = 0;
            ShowPassword.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            ShowPassword.CheckMarkColor = Color.Black;
            ShowPassword.CustomizableEdges = customizableEdges5;
            ShowPassword.ForeColor = SystemColors.ControlLightLight;
            ShowPassword.Location = new Point(306, 166);
            ShowPassword.Name = "ShowPassword";
            ShowPassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            ShowPassword.Size = new Size(27, 23);
            ShowPassword.TabIndex = 7;
            ShowPassword.Text = "guna2CustomCheckBox1";
            ShowPassword.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            ShowPassword.UncheckedState.BorderRadius = 2;
            ShowPassword.UncheckedState.BorderThickness = 0;
            ShowPassword.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            ShowPassword.CheckedChanged += ShowPassword_CheckedChanged;
            // 
            // SignInButton
            // 
            SignInButton.BorderColor = Color.DimGray;
            SignInButton.BorderRadius = 15;
            SignInButton.BorderThickness = 1;
            SignInButton.CustomizableEdges = customizableEdges7;
            SignInButton.DisabledState.BorderColor = Color.DarkGray;
            SignInButton.DisabledState.CustomBorderColor = Color.DarkGray;
            SignInButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            SignInButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            SignInButton.FillColor = Color.Black;
            SignInButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SignInButton.ForeColor = Color.White;
            SignInButton.Location = new Point(122, 251);
            SignInButton.Name = "SignInButton";
            SignInButton.ShadowDecoration.CustomizableEdges = customizableEdges8;
            SignInButton.Size = new Size(180, 45);
            SignInButton.TabIndex = 6;
            SignInButton.Text = "Sign in";
            SignInButton.Click += SignInButton_Click;
            SignInButton.MouseEnter += SignInButton_MouseEnter;
            SignInButton.MouseLeave += SignInButton_MouseLeave;
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Sylfaen", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.ForeColor = Color.White;
            guna2HtmlLabel3.Location = new Point(158, 37);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(63, 33);
            guna2HtmlLabel3.TabIndex = 5;
            guna2HtmlLabel3.Text = "Login";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // LoginFrm
            // 
            AcceptButton = SignInButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.login;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(742, 489);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginFrm";
            Text = "Login";
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2TextBox usernameTextbox;
        private Guna.UI2.WinForms.Guna2TextBox passwordTextbox;
        private Guna.UI2.WinForms.Guna2CheckBox RememberMeCheck;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button SignInButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2CustomCheckBox ShowPassword;
    }
}