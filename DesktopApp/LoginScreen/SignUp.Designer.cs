namespace DesktopApp.LoginScreen
{
    partial class SignUpFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpFrm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ConfpasswordTextbox = new Guna.UI2.WinForms.Guna2TextBox();
            SignUpButton = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            usernameTextbox = new Guna.UI2.WinForms.Guna2TextBox();
            RememberMeCheck = new Guna.UI2.WinForms.Guna2CheckBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            passwordTextbox = new Guna.UI2.WinForms.Guna2TextBox();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            errorProvider1 = new ErrorProvider(components);
            Warning = new Guna.UI2.WinForms.Guna2HtmlLabel();
            TimeLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ShowPassword = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            ShowConfPass = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            CloseButton = new Guna.UI2.WinForms.Guna2ImageRadioButton();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            resources.ApplyResources(guna2HtmlLabel4, "guna2HtmlLabel4");
            guna2HtmlLabel4.ForeColor = Color.White;
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            // 
            // ConfpasswordTextbox
            // 
            ConfpasswordTextbox.BorderColor = Color.Transparent;
            ConfpasswordTextbox.BorderRadius = 10;
            ConfpasswordTextbox.CustomizableEdges = customizableEdges1;
            ConfpasswordTextbox.DefaultText = "";
            ConfpasswordTextbox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            ConfpasswordTextbox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            ConfpasswordTextbox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            ConfpasswordTextbox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            ConfpasswordTextbox.FillColor = Color.DimGray;
            ConfpasswordTextbox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            resources.ApplyResources(ConfpasswordTextbox, "ConfpasswordTextbox");
            ConfpasswordTextbox.ForeColor = Color.White;
            ConfpasswordTextbox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            ConfpasswordTextbox.Name = "ConfpasswordTextbox";
            ConfpasswordTextbox.PasswordChar = '*';
            ConfpasswordTextbox.PlaceholderText = "password";
            ConfpasswordTextbox.SelectedText = "";
            ConfpasswordTextbox.ShadowDecoration.CustomizableEdges = customizableEdges2;
            ConfpasswordTextbox.Validating += ConfpasswordTextbox_Validating;
            // 
            // SignUpButton
            // 
            SignUpButton.BorderColor = Color.DimGray;
            SignUpButton.BorderRadius = 15;
            SignUpButton.BorderThickness = 1;
            SignUpButton.CustomizableEdges = customizableEdges3;
            SignUpButton.DisabledState.BorderColor = Color.DarkGray;
            SignUpButton.DisabledState.CustomBorderColor = Color.DarkGray;
            SignUpButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            SignUpButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            SignUpButton.FillColor = Color.Black;
            resources.ApplyResources(SignUpButton, "SignUpButton");
            SignUpButton.ForeColor = Color.White;
            SignUpButton.Name = "SignUpButton";
            SignUpButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            SignUpButton.Click += SignUpButton_Click;
            SignUpButton.MouseEnter += SignUp_Load;
            SignUpButton.MouseLeave += CloseButton_MouseLeave;
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            resources.ApplyResources(guna2HtmlLabel3, "guna2HtmlLabel3");
            guna2HtmlLabel3.ForeColor = Color.White;
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            // 
            // usernameTextbox
            // 
            usernameTextbox.BorderColor = Color.Transparent;
            usernameTextbox.BorderRadius = 10;
            usernameTextbox.CustomizableEdges = customizableEdges5;
            usernameTextbox.DefaultText = "";
            usernameTextbox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            usernameTextbox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            usernameTextbox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            usernameTextbox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            usernameTextbox.FillColor = Color.DimGray;
            usernameTextbox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            resources.ApplyResources(usernameTextbox, "usernameTextbox");
            usernameTextbox.ForeColor = Color.White;
            usernameTextbox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            usernameTextbox.Name = "usernameTextbox";
            usernameTextbox.PlaceholderText = "username";
            usernameTextbox.SelectedText = "";
            usernameTextbox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            usernameTextbox.Validating += usernameTextbox_Validating;
            // 
            // RememberMeCheck
            // 
            resources.ApplyResources(RememberMeCheck, "RememberMeCheck");
            RememberMeCheck.Checked = true;
            RememberMeCheck.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            RememberMeCheck.CheckedState.BorderRadius = 0;
            RememberMeCheck.CheckedState.BorderThickness = 0;
            RememberMeCheck.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            RememberMeCheck.CheckState = CheckState.Checked;
            RememberMeCheck.ForeColor = Color.White;
            RememberMeCheck.Name = "RememberMeCheck";
            RememberMeCheck.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            RememberMeCheck.UncheckedState.BorderRadius = 0;
            RememberMeCheck.UncheckedState.BorderThickness = 0;
            RememberMeCheck.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            resources.ApplyResources(guna2HtmlLabel1, "guna2HtmlLabel1");
            guna2HtmlLabel1.ForeColor = Color.White;
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            // 
            // passwordTextbox
            // 
            passwordTextbox.BorderColor = Color.Transparent;
            passwordTextbox.BorderRadius = 10;
            passwordTextbox.CustomizableEdges = customizableEdges7;
            passwordTextbox.DefaultText = "";
            passwordTextbox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            passwordTextbox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            passwordTextbox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            passwordTextbox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            passwordTextbox.FillColor = Color.DimGray;
            passwordTextbox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            resources.ApplyResources(passwordTextbox, "passwordTextbox");
            passwordTextbox.ForeColor = Color.White;
            passwordTextbox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            passwordTextbox.Name = "passwordTextbox";
            passwordTextbox.PasswordChar = '*';
            passwordTextbox.PlaceholderText = "password";
            passwordTextbox.SelectedText = "";
            passwordTextbox.ShadowDecoration.CustomizableEdges = customizableEdges8;
            passwordTextbox.Validating += passwordTextbox_Validating;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            resources.ApplyResources(guna2HtmlLabel2, "guna2HtmlLabel2");
            guna2HtmlLabel2.ForeColor = Color.White;
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Warning
            // 
            Warning.BackColor = Color.Transparent;
            resources.ApplyResources(Warning, "Warning");
            Warning.ForeColor = Color.Red;
            Warning.Name = "Warning";
            // 
            // TimeLabel
            // 
            TimeLabel.BackColor = Color.Transparent;
            resources.ApplyResources(TimeLabel, "TimeLabel");
            TimeLabel.ForeColor = Color.Lime;
            TimeLabel.Name = "TimeLabel";
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
            ShowPassword.CustomizableEdges = customizableEdges12;
            ShowPassword.ForeColor = SystemColors.ControlLightLight;
            resources.ApplyResources(ShowPassword, "ShowPassword");
            ShowPassword.Name = "ShowPassword";
            ShowPassword.ShadowDecoration.CustomizableEdges = customizableEdges13;
            ShowPassword.Tag = "Pass";
            ShowPassword.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            ShowPassword.UncheckedState.BorderRadius = 2;
            ShowPassword.UncheckedState.BorderThickness = 0;
            ShowPassword.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            ShowPassword.CheckedChanged += ShowPassword_CheckedChanged;
            // 
            // ShowConfPass
            // 
            ShowConfPass.BackColor = Color.DimGray;
            ShowConfPass.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            ShowConfPass.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            ShowConfPass.CheckedState.BorderRadius = 2;
            ShowConfPass.CheckedState.BorderThickness = 0;
            ShowConfPass.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            ShowConfPass.CheckMarkColor = Color.Black;
            ShowConfPass.CustomizableEdges = customizableEdges10;
            ShowConfPass.ForeColor = SystemColors.ControlLightLight;
            resources.ApplyResources(ShowConfPass, "ShowConfPass");
            ShowConfPass.Name = "ShowConfPass";
            ShowConfPass.ShadowDecoration.CustomizableEdges = customizableEdges11;
            ShowConfPass.Tag = "ConfPass";
            ShowConfPass.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            ShowConfPass.UncheckedState.BorderRadius = 2;
            ShowConfPass.UncheckedState.BorderThickness = 0;
            ShowConfPass.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            ShowConfPass.CheckedChanged += ShowPassword_CheckedChanged;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.BorderColor = Color.FromArgb(64, 64, 64);
            guna2Panel1.BorderRadius = 20;
            guna2Panel1.BorderThickness = 1;
            guna2Panel1.Controls.Add(ShowConfPass);
            guna2Panel1.Controls.Add(guna2HtmlLabel4);
            guna2Panel1.Controls.Add(ConfpasswordTextbox);
            guna2Panel1.Controls.Add(ShowPassword);
            guna2Panel1.Controls.Add(SignUpButton);
            guna2Panel1.Controls.Add(guna2HtmlLabel3);
            guna2Panel1.Controls.Add(usernameTextbox);
            guna2Panel1.Controls.Add(RememberMeCheck);
            guna2Panel1.Controls.Add(guna2HtmlLabel1);
            guna2Panel1.Controls.Add(passwordTextbox);
            guna2Panel1.Controls.Add(guna2HtmlLabel2);
            guna2Panel1.CustomizableEdges = customizableEdges14;
            resources.ApplyResources(guna2Panel1, "guna2Panel1");
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges15;
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.DarkGray;
            CloseButton.CheckedState.Image = (Image)resources.GetObject("resource.Image");
            CloseButton.Image = (Image)resources.GetObject("CloseButton.Image");
            CloseButton.ImageOffset = new Point(0, 0);
            CloseButton.ImageRotate = 0F;
            resources.ApplyResources(CloseButton, "CloseButton");
            CloseButton.Name = "CloseButton";
            CloseButton.ShadowDecoration.CustomizableEdges = customizableEdges9;
            CloseButton.Click += CloseButton_Click;
            CloseButton.MouseEnter += CloseButton_MouseEnter;
            CloseButton.MouseLeave += CloseButton_MouseLeave;
            // 
            // SignUpFrm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.login3;
            Controls.Add(CloseButton);
            Controls.Add(TimeLabel);
            Controls.Add(Warning);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SignUpFrm";
            Load += SignUp_Load;
            Shown += SignUpFrm_Shown;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2TextBox ConfpasswordTextbox;
        private Guna.UI2.WinForms.Guna2Button SignUpButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2TextBox usernameTextbox;
        private Guna.UI2.WinForms.Guna2CheckBox RememberMeCheck;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox passwordTextbox;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2HtmlLabel Warning;
        private Guna.UI2.WinForms.Guna2HtmlLabel TimeLabel;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2CustomCheckBox ShowConfPass;
        private Guna.UI2.WinForms.Guna2CustomCheckBox ShowPassword;
        private Guna.UI2.WinForms.Guna2ImageRadioButton CloseButton;
    }
}