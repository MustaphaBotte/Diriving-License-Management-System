namespace DesktopApp.ManageAppType
{
    partial class EditAppTypeFrm
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
            Guna.UI2.WinForms.Guna2Button CloseButton;
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAppTypeFrm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            AppTypeFeeTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            AppTypeIDLAbel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SaveButton = new Guna.UI2.WinForms.Guna2Button();
            AppTypeTitleTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            CloseButton = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.Transparent;
            CloseButton.BorderRadius = 15;
            CloseButton.BorderThickness = 1;
            CloseButton.CustomizableEdges = customizableEdges1;
            CloseButton.DisabledState.BorderColor = Color.DarkGray;
            CloseButton.DisabledState.CustomBorderColor = Color.DarkGray;
            CloseButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            CloseButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            CloseButton.FillColor = Color.SeaGreen;
            CloseButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CloseButton.ForeColor = Color.White;
            CloseButton.Image = Properties.Resources.sign_out2;
            CloseButton.ImageAlign = HorizontalAlignment.Left;
            CloseButton.Location = new Point(175, 313);
            CloseButton.Name = "CloseButton";
            CloseButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            CloseButton.Size = new Size(108, 36);
            CloseButton.TabIndex = 30;
            CloseButton.Text = "Close";
            CloseButton.Click += CloseButton_Click_1;
            CloseButton.MouseEnter += CloseButton_MouseEnter;
            CloseButton.MouseLeave += CloseButton_MouseLeave;
            // 
            // AppTypeFeeTextBox
            // 
            AppTypeFeeTextBox.BackColor = Color.Transparent;
            AppTypeFeeTextBox.BorderColor = Color.Black;
            AppTypeFeeTextBox.BorderRadius = 15;
            AppTypeFeeTextBox.CausesValidation = false;
            AppTypeFeeTextBox.CustomizableEdges = customizableEdges3;
            AppTypeFeeTextBox.DefaultText = "";
            AppTypeFeeTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            AppTypeFeeTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            AppTypeFeeTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            AppTypeFeeTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            AppTypeFeeTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            AppTypeFeeTextBox.Font = new Font("Arial", 11.25F);
            AppTypeFeeTextBox.ForeColor = Color.Black;
            AppTypeFeeTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            AppTypeFeeTextBox.Location = new Point(175, 240);
            AppTypeFeeTextBox.Margin = new Padding(6);
            AppTypeFeeTextBox.Name = "AppTypeFeeTextBox";
            AppTypeFeeTextBox.PlaceholderForeColor = Color.DimGray;
            AppTypeFeeTextBox.PlaceholderText = "fees";
            AppTypeFeeTextBox.SelectedText = "";
            AppTypeFeeTextBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            AppTypeFeeTextBox.Size = new Size(270, 40);
            AppTypeFeeTextBox.TabIndex = 1;
            AppTypeFeeTextBox.TabStop = false;
            AppTypeFeeTextBox.KeyPress += AppTypeFeeTextBox_KeyPress;
            // 
            // AppTypeIDLAbel
            // 
            AppTypeIDLAbel.BackColor = Color.Transparent;
            AppTypeIDLAbel.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            AppTypeIDLAbel.ForeColor = SystemColors.ActiveCaptionText;
            AppTypeIDLAbel.Location = new Point(175, 103);
            AppTypeIDLAbel.Name = "AppTypeIDLAbel";
            AppTypeIDLAbel.Size = new Size(30, 21);
            AppTypeIDLAbel.TabIndex = 2;
            AppTypeIDLAbel.Text = "???";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Times New Roman", 12F);
            guna2HtmlLabel1.ForeColor = SystemColors.ActiveCaptionText;
            guna2HtmlLabel1.Location = new Point(22, 103);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(127, 21);
            guna2HtmlLabel1.TabIndex = 3;
            guna2HtmlLabel1.Text = "Application Type ID";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Times New Roman", 12F);
            guna2HtmlLabel2.ForeColor = SystemColors.ActiveCaptionText;
            guna2HtmlLabel2.Location = new Point(15, 250);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(140, 21);
            guna2HtmlLabel2.TabIndex = 4;
            guna2HtmlLabel2.Text = "Application Type Fees";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Times New Roman", 12F);
            guna2HtmlLabel3.ForeColor = SystemColors.ActiveCaptionText;
            guna2HtmlLabel3.Location = new Point(12, 172);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(137, 21);
            guna2HtmlLabel3.TabIndex = 5;
            guna2HtmlLabel3.Text = "Application Type Title";
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel4.ForeColor = SystemColors.ActiveCaptionText;
            guna2HtmlLabel4.Location = new Point(124, 32);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(256, 31);
            guna2HtmlLabel4.TabIndex = 6;
            guna2HtmlLabel4.Text = "Edit Application Type ";
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.Transparent;
            SaveButton.BorderRadius = 15;
            SaveButton.BorderThickness = 1;
            SaveButton.CustomizableEdges = customizableEdges5;
            SaveButton.DisabledState.BorderColor = Color.DarkGray;
            SaveButton.DisabledState.CustomBorderColor = Color.DarkGray;
            SaveButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            SaveButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            SaveButton.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SaveButton.ForeColor = SystemColors.ActiveCaptionText;
            SaveButton.Image = (Image)resources.GetObject("SaveButton.Image");
            SaveButton.ImageAlign = HorizontalAlignment.Left;
            SaveButton.Location = new Point(289, 313);
            SaveButton.Name = "SaveButton";
            SaveButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            SaveButton.Size = new Size(108, 36);
            SaveButton.TabIndex = 29;
            SaveButton.Text = "Save";
            SaveButton.TextAlign = HorizontalAlignment.Left;
            SaveButton.Click += SaveButton_Click;
            SaveButton.MouseEnter += CloseButton_MouseEnter;
            SaveButton.MouseLeave += CloseButton_MouseLeave;
            // 
            // AppTypeTitleTextBox
            // 
            AppTypeTitleTextBox.BackColor = Color.Transparent;
            AppTypeTitleTextBox.BorderColor = Color.Black;
            AppTypeTitleTextBox.BorderRadius = 15;
            AppTypeTitleTextBox.CausesValidation = false;
            AppTypeTitleTextBox.CustomizableEdges = customizableEdges7;
            AppTypeTitleTextBox.DefaultText = "";
            AppTypeTitleTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            AppTypeTitleTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            AppTypeTitleTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            AppTypeTitleTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            AppTypeTitleTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            AppTypeTitleTextBox.Font = new Font("Arial", 11.25F);
            AppTypeTitleTextBox.ForeColor = Color.Black;
            AppTypeTitleTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            AppTypeTitleTextBox.Location = new Point(175, 163);
            AppTypeTitleTextBox.Margin = new Padding(6);
            AppTypeTitleTextBox.Name = "AppTypeTitleTextBox";
            AppTypeTitleTextBox.PlaceholderForeColor = Color.DimGray;
            AppTypeTitleTextBox.PlaceholderText = "title";
            AppTypeTitleTextBox.SelectedText = "";
            AppTypeTitleTextBox.ShadowDecoration.CustomizableEdges = customizableEdges8;
            AppTypeTitleTextBox.Size = new Size(270, 40);
            AppTypeTitleTextBox.TabIndex = 31;
            // 
            // EditAppTypeFrm
            // 
            AcceptButton = SaveButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(475, 450);
            Controls.Add(AppTypeTitleTextBox);
            Controls.Add(CloseButton);
            Controls.Add(SaveButton);
            Controls.Add(guna2HtmlLabel4);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(AppTypeIDLAbel);
            Controls.Add(AppTypeFeeTextBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditAppTypeFrm";
            Text = "EditAppType";
            Load += EditAppType_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox AppTypeFeeTextBox;
        private Guna.UI2.WinForms.Guna2HtmlLabel AppTypeIDLAbel;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2Button SaveButton;
        private Guna.UI2.WinForms.Guna2TextBox AppTypeTitleTextBox;
    }
}