namespace DesktopApp.PeopleManagement
{
    partial class PeopleManagementFrm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PeopleManagementFrm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            PeopleMenuStrip = new ContextMenuStrip(components);
            EditPersonButton = new ToolStripMenuItem();
            ButtonDeletePerson = new ToolStripMenuItem();
            ShowInfoButton = new ToolStripMenuItem();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            FilterChoices = new Guna.UI2.WinForms.Guna2ComboBox();
            FilterValueTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            DateTimePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            AddNewButton = new Guna.UI2.WinForms.Guna2Button();
            RefreshButton = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            RowsCountlabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            PeopleMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // DataGrid
            // 
            DataGrid.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = Color.LightSkyBlue;
            DataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DataGrid.BackgroundColor = Color.DimGray;
            DataGrid.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DataGrid.ColumnHeadersHeight = 25;
            DataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.DimGray;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            DataGrid.GridColor = Color.FromArgb(231, 229, 255);
            DataGrid.Location = new Point(12, 92);
            DataGrid.Name = "DataGrid";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.ActiveBorder;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.DimGray;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            DataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            DataGrid.RowHeadersVisible = false;
            DataGrid.Size = new Size(1246, 494);
            DataGrid.TabIndex = 0;
            DataGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            DataGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            DataGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            DataGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            DataGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            DataGrid.ThemeStyle.BackColor = Color.DimGray;
            DataGrid.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            DataGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            DataGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            DataGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            DataGrid.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            DataGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            DataGrid.ThemeStyle.HeaderStyle.Height = 25;
            DataGrid.ThemeStyle.ReadOnly = false;
            DataGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            DataGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DataGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            DataGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            DataGrid.ThemeStyle.RowsStyle.Height = 25;
            DataGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            DataGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            DataGrid.CellMouseClick += DataGrid_CellMouseClick;
            DataGrid.CellMouseDoubleClick += DataGrid_CellMouseDoubleClick;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Sitka Small", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = SystemColors.ButtonHighlight;
            guna2HtmlLabel1.Location = new Point(434, -6);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(347, 50);
            guna2HtmlLabel1.TabIndex = 1;
            guna2HtmlLabel1.Text = "People Management";
            // 
            // PeopleMenuStrip
            // 
            PeopleMenuStrip.Items.AddRange(new ToolStripItem[] { EditPersonButton, ButtonDeletePerson, ShowInfoButton });
            PeopleMenuStrip.Name = "PeopleMenuStrip";
            PeopleMenuStrip.ShowCheckMargin = true;
            PeopleMenuStrip.Size = new Size(157, 88);
            // 
            // EditPersonButton
            // 
            EditPersonButton.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EditPersonButton.Image = (Image)resources.GetObject("EditPersonButton.Image");
            EditPersonButton.Name = "EditPersonButton";
            EditPersonButton.Size = new Size(156, 28);
            EditPersonButton.Text = "Edit";
            EditPersonButton.Click += EditPersonButton_Click;
            // 
            // ButtonDeletePerson
            // 
            ButtonDeletePerson.Font = new Font("Arial Black", 12F, FontStyle.Bold);
            ButtonDeletePerson.Image = (Image)resources.GetObject("ButtonDeletePerson.Image");
            ButtonDeletePerson.Name = "ButtonDeletePerson";
            ButtonDeletePerson.Size = new Size(156, 28);
            ButtonDeletePerson.Text = "Delete";
            ButtonDeletePerson.TextImageRelation = TextImageRelation.Overlay;
            ButtonDeletePerson.Click += ButtonDeletePerson_Click;
            // 
            // ShowInfoButton
            // 
            ShowInfoButton.Font = new Font("Arial Black", 12F, FontStyle.Bold);
            ShowInfoButton.Image = Properties.Resources.show1;
            ShowInfoButton.Name = "ShowInfoButton";
            ShowInfoButton.Size = new Size(156, 28);
            ShowInfoButton.Text = "Show";
            ShowInfoButton.Click += ShowInfoButton_Click;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = Color.OrangeRed;
            guna2HtmlLabel2.Location = new Point(50, 55);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(67, 20);
            guna2HtmlLabel2.TabIndex = 2;
            guna2HtmlLabel2.Text = "Filter By";
            // 
            // FilterChoices
            // 
            FilterChoices.BackColor = Color.Transparent;
            FilterChoices.BorderColor = Color.DarkCyan;
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
            FilterChoices.Location = new Point(129, 50);
            FilterChoices.Name = "FilterChoices";
            FilterChoices.ShadowDecoration.CustomizableEdges = customizableEdges2;
            FilterChoices.Size = new Size(178, 36);
            FilterChoices.TabIndex = 3;
            FilterChoices.SelectedIndexChanged += FilterChoices_SelectedIndexChanged;
            // 
            // FilterValueTextBox
            // 
            FilterValueTextBox.BackColor = Color.Transparent;
            FilterValueTextBox.BorderColor = Color.DarkCyan;
            FilterValueTextBox.BorderRadius = 15;
            FilterValueTextBox.CustomizableEdges = customizableEdges3;
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
            FilterValueTextBox.Location = new Point(314, 50);
            FilterValueTextBox.Margin = new Padding(4);
            FilterValueTextBox.Name = "FilterValueTextBox";
            FilterValueTextBox.PlaceholderText = "";
            FilterValueTextBox.SelectedText = "";
            FilterValueTextBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            FilterValueTextBox.Size = new Size(234, 36);
            FilterValueTextBox.TabIndex = 4;
            FilterValueTextBox.TextChanged += FilterValueTextBox_TextChanged;
            FilterValueTextBox.KeyPress += FilterValueTextBox_KeyPress;
            // 
            // DateTimePicker
            // 
            DateTimePicker.BackColor = Color.Transparent;
            DateTimePicker.BorderColor = Color.DarkCyan;
            DateTimePicker.BorderRadius = 15;
            DateTimePicker.BorderThickness = 1;
            DateTimePicker.Checked = true;
            DateTimePicker.CustomizableEdges = customizableEdges5;
            DateTimePicker.FillColor = Color.FromArgb(64, 64, 64);
            DateTimePicker.Font = new Font("Segoe UI", 9F);
            DateTimePicker.Format = DateTimePickerFormat.Long;
            DateTimePicker.Location = new Point(328, 50);
            DateTimePicker.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            DateTimePicker.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            DateTimePicker.Name = "DateTimePicker";
            DateTimePicker.ShadowDecoration.CustomizableEdges = customizableEdges6;
            DateTimePicker.Size = new Size(200, 36);
            DateTimePicker.TabIndex = 5;
            DateTimePicker.Value = new DateTime(2025, 6, 3, 15, 35, 13, 326);
            DateTimePicker.Visible = false;
            DateTimePicker.ValueChanged += DateTimePicker_ValueChanged;
            // 
            // AddNewButton
            // 
            AddNewButton.BackColor = Color.Transparent;
            AddNewButton.BorderRadius = 15;
            AddNewButton.BorderThickness = 1;
            AddNewButton.CustomizableEdges = customizableEdges7;
            AddNewButton.DisabledState.BorderColor = Color.DarkGray;
            AddNewButton.DisabledState.CustomBorderColor = Color.DarkGray;
            AddNewButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            AddNewButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            AddNewButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddNewButton.ForeColor = Color.Black;
            AddNewButton.Image = Properties.Resources.Add;
            AddNewButton.ImageAlign = HorizontalAlignment.Left;
            AddNewButton.Location = new Point(1102, 50);
            AddNewButton.Name = "AddNewButton";
            AddNewButton.ShadowDecoration.CustomizableEdges = customizableEdges8;
            AddNewButton.Size = new Size(144, 36);
            AddNewButton.TabIndex = 6;
            AddNewButton.Text = "Add New";
            AddNewButton.Click += AddNewButton_Click;
            AddNewButton.MouseEnter += Button_MouseEnter;
            AddNewButton.MouseLeave += Button_MouseLeave;
            // 
            // RefreshButton
            // 
            RefreshButton.BackColor = Color.Transparent;
            RefreshButton.BorderRadius = 20;
            RefreshButton.BorderThickness = 1;
            RefreshButton.CustomizableEdges = customizableEdges9;
            RefreshButton.DisabledState.BorderColor = Color.DarkGray;
            RefreshButton.DisabledState.CustomBorderColor = Color.DarkGray;
            RefreshButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            RefreshButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            RefreshButton.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RefreshButton.ForeColor = SystemColors.ActiveCaptionText;
            RefreshButton.Image = (Image)resources.GetObject("RefreshButton.Image");
            RefreshButton.ImageAlign = HorizontalAlignment.Left;
            RefreshButton.Location = new Point(971, 50);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.ShadowDecoration.CustomizableEdges = customizableEdges10;
            RefreshButton.Size = new Size(125, 36);
            RefreshButton.TabIndex = 7;
            RefreshButton.Text = "Refresh";
            RefreshButton.TextAlign = HorizontalAlignment.Left;
            RefreshButton.Click += RefreshButton_Click;
            RefreshButton.MouseEnter += Button_MouseEnter;
            RefreshButton.MouseLeave += Button_MouseLeave;
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.ForeColor = Color.White;
            guna2HtmlLabel3.Location = new Point(11, 592);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(110, 27);
            guna2HtmlLabel3.TabIndex = 8;
            guna2HtmlLabel3.Text = "Rows Count";
            // 
            // RowsCountlabel
            // 
            RowsCountlabel.BackColor = Color.Transparent;
            RowsCountlabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RowsCountlabel.ForeColor = Color.IndianRed;
            RowsCountlabel.Location = new Point(138, 592);
            RowsCountlabel.Name = "RowsCountlabel";
            RowsCountlabel.Size = new Size(19, 27);
            RowsCountlabel.TabIndex = 9;
            RowsCountlabel.Text = "??";
            // 
            // PeopleManagementFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources.wallpaperflare_com_wallpaper__3_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1270, 631);
            Controls.Add(RowsCountlabel);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(RefreshButton);
            Controls.Add(AddNewButton);
            Controls.Add(DateTimePicker);
            Controls.Add(FilterValueTextBox);
            Controls.Add(FilterChoices);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(DataGrid);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PeopleManagementFrm";
            Text = "People MAnagement";
            FormClosing += PeopleManagementFrm_FormClosing;
            Load += FrmLoad;
            SizeChanged += PeopleManagementFrm_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            PeopleMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView DataGrid;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private ContextMenuStrip PeopleMenuStrip;
        private ToolStripMenuItem EditPersonButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2ComboBox FilterChoices;
        private Guna.UI2.WinForms.Guna2TextBox FilterValueTextBox;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateTimePicker;
        private ToolStripMenuItem ButtonDeletePerson;
        private Guna.UI2.WinForms.Guna2Button AddNewButton;
        private ToolStripMenuItem ShowInfoButton;
        private Guna.UI2.WinForms.Guna2Button RefreshButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel RowsCountlabel;
    }
}