namespace DesktopApp.PersonControl
{
    partial class ShowPersonWithFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowPersonWithFilter));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            FilterGroupBox = new Guna.UI2.WinForms.Guna2GroupBox();
            FilterChoices = new Guna.UI2.WinForms.Guna2ComboBox();
            FindButton = new Guna.UI2.WinForms.Guna2Button();
            FilterValueTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            showInfoInControl1 = new ShowInfoInControl();
            FilterGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // FilterGroupBox
            // 
            FilterGroupBox.BorderColor = Color.DimGray;
            FilterGroupBox.BorderRadius = 30;
            FilterGroupBox.Controls.Add(FilterChoices);
            FilterGroupBox.Controls.Add(FindButton);
            FilterGroupBox.Controls.Add(FilterValueTextBox);
            FilterGroupBox.Controls.Add(guna2HtmlLabel2);
            FilterGroupBox.CustomBorderColor = Color.DimGray;
            FilterGroupBox.CustomizableEdges = customizableEdges7;
            FilterGroupBox.FillColor = Color.Transparent;
            FilterGroupBox.Font = new Font("Candara", 11.25F, FontStyle.Bold);
            FilterGroupBox.ForeColor = Color.Black;
            FilterGroupBox.Location = new Point(13, 3);
            FilterGroupBox.Name = "FilterGroupBox";
            FilterGroupBox.ShadowDecoration.CustomizableEdges = customizableEdges8;
            FilterGroupBox.Size = new Size(772, 88);
            FilterGroupBox.TabIndex = 36;
            FilterGroupBox.Text = "Filter";
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
            FilterChoices.Items.AddRange(new object[] { "PersonID", "Nationa_No" });
            FilterChoices.Location = new Point(138, 43);
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
            FindButton.Location = new Point(594, 43);
            FindButton.Name = "FindButton";
            FindButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            FindButton.Size = new Size(114, 36);
            FindButton.TabIndex = 22;
            FindButton.Text = "Find";
            FindButton.Click += FindButton_Click;
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
            FilterValueTextBox.Location = new Point(323, 43);
            FilterValueTextBox.Margin = new Padding(4);
            FilterValueTextBox.Name = "FilterValueTextBox";
            FilterValueTextBox.PlaceholderText = "";
            FilterValueTextBox.SelectedText = "";
            FilterValueTextBox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            FilterValueTextBox.Size = new Size(198, 36);
            FilterValueTextBox.TabIndex = 21;
            FilterValueTextBox.TextChanged += FilterValueTextBox_TextChanged;
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
            // showInfoInControl1
            // 
            showInfoInControl1.BackColor = SystemColors.Control;
            showInfoInControl1.BackgroundImage = (Image)resources.GetObject("showInfoInControl1.BackgroundImage");
            showInfoInControl1.Location = new Point(13, 97);
            showInfoInControl1.Name = "showInfoInControl1";
            showInfoInControl1.Size = new Size(772, 273);
            showInfoInControl1.TabIndex = 37;
            // 
            // ShowPersonWithFilter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(showInfoInControl1);
            Controls.Add(FilterGroupBox);
            Name = "ShowPersonWithFilter";
            Size = new Size(799, 390);
            Load += ShowPersonWithFilter_Load;
            FilterGroupBox.ResumeLayout(false);
            FilterGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox FilterGroupBox;
        private Guna.UI2.WinForms.Guna2ComboBox FilterChoices;
        private Guna.UI2.WinForms.Guna2Button FindButton;
        private Guna.UI2.WinForms.Guna2TextBox FilterValueTextBox;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private ShowInfoInControl showInfoInControl1;
    }
}
