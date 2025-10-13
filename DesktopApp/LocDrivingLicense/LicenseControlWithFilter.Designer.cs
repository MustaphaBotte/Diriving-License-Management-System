namespace DesktopApp.LocDrivingLicense
{
    partial class LicenseControlWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseControlWithFilter));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            FilterChoices = new Guna.UI2.WinForms.Guna2ComboBox();
            FindButton = new Guna.UI2.WinForms.Guna2Button();
            FilterValueTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            licenseControl1 = new LicenseControl();
            guna2GroupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // guna2GroupBox2
            // 
            guna2GroupBox2.BorderColor = Color.DimGray;
            guna2GroupBox2.BorderRadius = 30;
            guna2GroupBox2.Controls.Add(FilterChoices);
            guna2GroupBox2.Controls.Add(FindButton);
            guna2GroupBox2.Controls.Add(FilterValueTextBox);
            guna2GroupBox2.Controls.Add(guna2HtmlLabel2);
            guna2GroupBox2.CustomBorderColor = Color.DimGray;
            guna2GroupBox2.CustomizableEdges = customizableEdges7;
            guna2GroupBox2.FillColor = Color.Transparent;
            guna2GroupBox2.Font = new Font("Candara", 11.25F, FontStyle.Bold);
            guna2GroupBox2.ForeColor = Color.Black;
            guna2GroupBox2.Location = new Point(3, 3);
            guna2GroupBox2.Name = "guna2GroupBox2";
            guna2GroupBox2.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2GroupBox2.Size = new Size(753, 88);
            guna2GroupBox2.TabIndex = 35;
            guna2GroupBox2.Text = "Filter";
            // 
            // FilterChoices
            // 
            FilterChoices.BackColor = Color.Transparent;
            FilterChoices.BorderColor = Color.Black;
            FilterChoices.BorderRadius = 15;
            FilterChoices.CustomizableEdges = customizableEdges1;
            FilterChoices.DrawMode = DrawMode.OwnerDrawFixed;
            FilterChoices.DropDownStyle = ComboBoxStyle.DropDownList;
            FilterChoices.FillColor = Color.DimGray;
            FilterChoices.FocusedColor = Color.FromArgb(94, 148, 255);
            FilterChoices.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            FilterChoices.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FilterChoices.ForeColor = Color.Black;
            FilterChoices.ItemHeight = 30;
            FilterChoices.Items.AddRange(new object[] { "LicenseID", "Loc_DLA_ID" });
            FilterChoices.Location = new Point(139, 44);
            FilterChoices.Name = "FilterChoices";
            FilterChoices.ShadowDecoration.CustomizableEdges = customizableEdges2;
            FilterChoices.Size = new Size(178, 36);
            FilterChoices.TabIndex = 23;
            // 
            // FindButton
            // 
            FindButton.BackColor = Color.Transparent;
            FindButton.BorderRadius = 15;
            FindButton.BorderThickness = 1;
            FindButton.CustomizableEdges = customizableEdges3;
            FindButton.DisabledState.BorderColor = Color.DarkGray;
            FindButton.DisabledState.CustomBorderColor = Color.DarkGray;
            FindButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            FindButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            FindButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FindButton.ForeColor = Color.Black;
            FindButton.Image = (Image)resources.GetObject("FindButton.Image");
            FindButton.ImageAlign = HorizontalAlignment.Left;
            FindButton.Location = new Point(529, 43);
            FindButton.Name = "FindButton";
            FindButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            FindButton.Size = new Size(114, 36);
            FindButton.TabIndex = 22;
            FindButton.Text = "Find";
            FindButton.Click += FindButton_Click;
            FindButton.MouseEnter += FindButton_MouseEnter;
            FindButton.MouseLeave += FindButton_MouseLeave;
            // 
            // FilterValueTextBox
            // 
            FilterValueTextBox.BackColor = Color.Transparent;
            FilterValueTextBox.BorderColor = Color.Black;
            FilterValueTextBox.BorderRadius = 15;
            FilterValueTextBox.CustomizableEdges = customizableEdges5;
            FilterValueTextBox.DefaultText = "";
            FilterValueTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            FilterValueTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            FilterValueTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            FilterValueTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            FilterValueTextBox.FillColor = Color.DimGray;
            FilterValueTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            FilterValueTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            FilterValueTextBox.ForeColor = Color.Black;
            FilterValueTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            FilterValueTextBox.Location = new Point(324, 43);
            FilterValueTextBox.Margin = new Padding(4);
            FilterValueTextBox.Name = "FilterValueTextBox";
            FilterValueTextBox.PlaceholderText = "";
            FilterValueTextBox.SelectedText = "";
            FilterValueTextBox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            FilterValueTextBox.Size = new Size(198, 36);
            FilterValueTextBox.TabIndex = 21;
            FilterValueTextBox.KeyPress += FilterValueTextBox_KeyPress;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = Color.Firebrick;
            guna2HtmlLabel2.Location = new Point(27, 50);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(78, 20);
            guna2HtmlLabel2.TabIndex = 19;
            guna2HtmlLabel2.Text = "Search By";
            // 
            // licenseControl1
            // 
            licenseControl1.Location = new Point(3, 97);
            licenseControl1.Name = "licenseControl1";
            licenseControl1.Size = new Size(760, 277);
            licenseControl1.TabIndex = 36;
            // 
            // LicenseControlWithFilter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(licenseControl1);
            Controls.Add(guna2GroupBox2);
            Name = "LicenseControlWithFilter";
            Size = new Size(764, 375);
            guna2GroupBox2.ResumeLayout(false);
            guna2GroupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Guna.UI2.WinForms.Guna2ComboBox FilterChoices;
        private Guna.UI2.WinForms.Guna2Button FindButton;
        private Guna.UI2.WinForms.Guna2TextBox FilterValueTextBox;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private LicenseControl licenseControl1;
    }
}
