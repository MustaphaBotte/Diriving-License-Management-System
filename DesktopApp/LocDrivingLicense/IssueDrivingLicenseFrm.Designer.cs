namespace DesktopApp.IssueLocalDrivingLicense
{
    partial class IssueDrivingLicenseFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssueDrivingLicenseFrm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            applicationInfoControl1 = new DesktopApp.VisionTest.ApplicationInfoControl();
            SaveButton = new Guna.UI2.WinForms.Guna2Button();
            NotesTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
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
            CloseButton.Location = new Point(561, 471);
            CloseButton.Name = "CloseButton";
            CloseButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            CloseButton.Size = new Size(108, 36);
            CloseButton.TabIndex = 34;
            CloseButton.Text = "Close";
            CloseButton.Click += CloseButton_Click;
            CloseButton.MouseEnter += CloseButton_MouseEnter;
            CloseButton.MouseLeave += CloseButton_MouseLeave;
            // 
            // applicationInfoControl1
            // 
            applicationInfoControl1.Location = new Point(12, 12);
            applicationInfoControl1.Name = "applicationInfoControl1";
            applicationInfoControl1.Size = new Size(794, 319);
            applicationInfoControl1.TabIndex = 0;
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.Transparent;
            SaveButton.BorderRadius = 15;
            SaveButton.BorderThickness = 1;
            SaveButton.CustomizableEdges = customizableEdges3;
            SaveButton.DisabledState.BorderColor = Color.DarkGray;
            SaveButton.DisabledState.CustomBorderColor = Color.DarkGray;
            SaveButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            SaveButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            SaveButton.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SaveButton.ForeColor = SystemColors.ActiveCaptionText;
            SaveButton.Image = (Image)resources.GetObject("SaveButton.Image");
            SaveButton.ImageAlign = HorizontalAlignment.Left;
            SaveButton.Location = new Point(675, 471);
            SaveButton.Name = "SaveButton";
            SaveButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            SaveButton.Size = new Size(108, 36);
            SaveButton.TabIndex = 33;
            SaveButton.Text = "Save";
            SaveButton.TextAlign = HorizontalAlignment.Left;
            SaveButton.Click += SaveButton_Click;
            SaveButton.MouseEnter += CloseButton_MouseEnter;
            SaveButton.MouseLeave += CloseButton_MouseLeave;
            // 
            // NotesTextBox
            // 
            NotesTextBox.BorderColor = Color.Black;
            NotesTextBox.BorderRadius = 15;
            NotesTextBox.CustomizableEdges = customizableEdges5;
            NotesTextBox.DefaultText = "";
            NotesTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            NotesTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            NotesTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            NotesTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            NotesTextBox.FillColor = Color.Silver;
            NotesTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            NotesTextBox.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NotesTextBox.ForeColor = Color.Black;
            NotesTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            NotesTextBox.Location = new Point(97, 347);
            NotesTextBox.Multiline = true;
            NotesTextBox.Name = "NotesTextBox";
            NotesTextBox.PlaceholderText = "";
            NotesTextBox.ScrollBars = ScrollBars.Horizontal;
            NotesTextBox.SelectedText = "";
            NotesTextBox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            NotesTextBox.Size = new Size(700, 118);
            NotesTextBox.TabIndex = 35;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Sitka Display", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(30, 337);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(61, 30);
            guna2HtmlLabel1.TabIndex = 36;
            guna2HtmlLabel1.Text = "Notes :";
            // 
            // IssueDrivingLicenseFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 519);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(NotesTextBox);
            Controls.Add(CloseButton);
            Controls.Add(SaveButton);
            Controls.Add(applicationInfoControl1);
            Name = "IssueDrivingLicenseFrm";
            Text = "Issue Driving License First Time";
            Load += IssueDrivingLicenseFrm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VisionTest.ApplicationInfoControl applicationInfoControl1;
        private Guna.UI2.WinForms.Guna2Button SaveButton;
        private Guna.UI2.WinForms.Guna2TextBox NotesTextBox;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}