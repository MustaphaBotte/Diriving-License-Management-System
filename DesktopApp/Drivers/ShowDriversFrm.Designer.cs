namespace DesktopApp.Drivers
{
    partial class ShowDriversFrm
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
            Guna.UI2.WinForms.Guna2Button CloseButton;
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowDriversFrm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DateTimePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            FilterValueTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            FilterChoices = new Guna.UI2.WinForms.Guna2ComboBox();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            RowsCountlabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            RefreshButton = new Guna.UI2.WinForms.Guna2Button();
            DataGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            DriverID = new DataGridViewTextBoxColumn();
            PersonID = new DataGridViewTextBoxColumn();
            FullName = new DataGridViewTextBoxColumn();
            NationalNo = new DataGridViewTextBoxColumn();
            CreatedDate = new DataGridViewTextBoxColumn();
            Active_Licenses = new DataGridViewTextBoxColumn();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            DriversMenuStrip = new ContextMenuStrip(components);
            IssueInternationalLicenseBtn = new ToolStripMenuItem();
            ShowLicensesHistoryBtn = new ToolStripMenuItem();
            ShowInfoButton = new ToolStripMenuItem();
            CloseButton = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            DriversMenuStrip.SuspendLayout();
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
            CloseButton.Location = new Point(748, 561);
            CloseButton.Name = "CloseButton";
            CloseButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            CloseButton.Size = new Size(123, 36);
            CloseButton.TabIndex = 44;
            CloseButton.Text = "Close";
            CloseButton.Click += CloseButton_Click;
            CloseButton.MouseEnter += RefreshButton_MouseEnter;
            CloseButton.MouseLeave += RefreshButton_MouseLeave;
            // 
            // DateTimePicker
            // 
            DateTimePicker.BackColor = Color.Transparent;
            DateTimePicker.BorderColor = Color.DarkCyan;
            DateTimePicker.BorderRadius = 15;
            DateTimePicker.BorderThickness = 1;
            DateTimePicker.Checked = true;
            DateTimePicker.CustomizableEdges = customizableEdges3;
            DateTimePicker.FillColor = Color.FromArgb(64, 64, 64);
            DateTimePicker.Font = new Font("Segoe UI", 9F);
            DateTimePicker.Format = DateTimePickerFormat.Long;
            DateTimePicker.Location = new Point(303, 192);
            DateTimePicker.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            DateTimePicker.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            DateTimePicker.Name = "DateTimePicker";
            DateTimePicker.ShadowDecoration.CustomizableEdges = customizableEdges4;
            DateTimePicker.Size = new Size(200, 36);
            DateTimePicker.TabIndex = 49;
            DateTimePicker.Value = new DateTime(2025, 6, 3, 15, 35, 13, 326);
            DateTimePicker.Visible = false;
            DateTimePicker.ValueChanged += DateTimePicker_ValueChanged;
            // 
            // FilterValueTextBox
            // 
            FilterValueTextBox.BackColor = Color.Transparent;
            FilterValueTextBox.BorderColor = Color.DarkCyan;
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
            FilterValueTextBox.Location = new Point(286, 192);
            FilterValueTextBox.Margin = new Padding(4);
            FilterValueTextBox.Name = "FilterValueTextBox";
            FilterValueTextBox.PlaceholderText = "";
            FilterValueTextBox.SelectedText = "";
            FilterValueTextBox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            FilterValueTextBox.Size = new Size(234, 36);
            FilterValueTextBox.TabIndex = 48;
            FilterValueTextBox.TextChanged += FilterValueTextBox_TextChanged;
            FilterValueTextBox.KeyPress += FilterValueTextBox_KeyPress;
            // 
            // FilterChoices
            // 
            FilterChoices.BackColor = Color.Transparent;
            FilterChoices.BorderColor = Color.DarkCyan;
            FilterChoices.BorderRadius = 15;
            FilterChoices.CustomizableEdges = customizableEdges7;
            FilterChoices.DrawMode = DrawMode.OwnerDrawFixed;
            FilterChoices.DropDownStyle = ComboBoxStyle.DropDownList;
            FilterChoices.FillColor = Color.DimGray;
            FilterChoices.FocusedColor = Color.FromArgb(94, 148, 255);
            FilterChoices.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            FilterChoices.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FilterChoices.ForeColor = Color.Black;
            FilterChoices.ItemHeight = 30;
            FilterChoices.Location = new Point(101, 193);
            FilterChoices.Name = "FilterChoices";
            FilterChoices.ShadowDecoration.CustomizableEdges = customizableEdges8;
            FilterChoices.Size = new Size(178, 36);
            FilterChoices.TabIndex = 47;
            FilterChoices.SelectedIndexChanged += FilterChoices_SelectedIndexChanged;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = Color.OrangeRed;
            guna2HtmlLabel2.Location = new Point(22, 203);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(67, 20);
            guna2HtmlLabel2.TabIndex = 46;
            guna2HtmlLabel2.Text = "Filter By";
            // 
            // RowsCountlabel
            // 
            RowsCountlabel.BackColor = Color.Transparent;
            RowsCountlabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RowsCountlabel.ForeColor = Color.DarkRed;
            RowsCountlabel.Location = new Point(149, 561);
            RowsCountlabel.Name = "RowsCountlabel";
            RowsCountlabel.Size = new Size(19, 27);
            RowsCountlabel.TabIndex = 43;
            RowsCountlabel.Text = "??";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.ForeColor = Color.Black;
            guna2HtmlLabel3.Location = new Point(22, 561);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(110, 27);
            guna2HtmlLabel3.TabIndex = 42;
            guna2HtmlLabel3.Text = "Rows Count";
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
            RefreshButton.Location = new Point(620, 561);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.ShadowDecoration.CustomizableEdges = customizableEdges10;
            RefreshButton.Size = new Size(122, 36);
            RefreshButton.TabIndex = 41;
            RefreshButton.Text = "Refresh";
            RefreshButton.TextAlign = HorizontalAlignment.Left;
            RefreshButton.Click += RefreshButton_Click;
            RefreshButton.MouseEnter += RefreshButton_MouseEnter;
            RefreshButton.MouseLeave += RefreshButton_MouseLeave;
            // 
            // DataGrid
            // 
            DataGrid.AllowUserToAddRows = false;
            DataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = Color.LightSkyBlue;
            DataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DataGrid.BackgroundColor = Color.LightGray;
            DataGrid.BorderStyle = BorderStyle.FixedSingle;
            DataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
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
            DataGrid.Columns.AddRange(new DataGridViewColumn[] { DriverID, PersonID, FullName, NationalNo, CreatedDate, Active_Licenses });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.DimGray;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            DataGrid.GridColor = Color.FromArgb(231, 229, 255);
            DataGrid.Location = new Point(24, 235);
            DataGrid.Name = "DataGrid";
            DataGrid.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.ActiveBorder;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.DimGray;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            DataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            DataGrid.RowHeadersVisible = false;
            DataGrid.Size = new Size(847, 321);
            DataGrid.TabIndex = 40;
            DataGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            DataGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            DataGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            DataGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            DataGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            DataGrid.ThemeStyle.BackColor = Color.LightGray;
            DataGrid.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            DataGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            DataGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.Single;
            DataGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            DataGrid.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            DataGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            DataGrid.ThemeStyle.HeaderStyle.Height = 25;
            DataGrid.ThemeStyle.ReadOnly = true;
            DataGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            DataGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DataGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            DataGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            DataGrid.ThemeStyle.RowsStyle.Height = 25;
            DataGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            DataGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            DataGrid.CellDoubleClick += DataGrid_CellDoubleClick;
            DataGrid.CellMouseClick += DataGrid_CellMouseClick;
            // 
            // DriverID
            // 
            DriverID.HeaderText = "DriverID";
            DriverID.Name = "DriverID";
            DriverID.ReadOnly = true;
            // 
            // PersonID
            // 
            PersonID.HeaderText = "PersonID";
            PersonID.Name = "PersonID";
            PersonID.ReadOnly = true;
            // 
            // FullName
            // 
            FullName.HeaderText = "FullName";
            FullName.Name = "FullName";
            FullName.ReadOnly = true;
            // 
            // NationalNo
            // 
            NationalNo.HeaderText = "NationalNo";
            NationalNo.Name = "NationalNo";
            NationalNo.ReadOnly = true;
            // 
            // CreatedDate
            // 
            CreatedDate.HeaderText = "CreatedDate";
            CreatedDate.Name = "CreatedDate";
            CreatedDate.ReadOnly = true;
            // 
            // Active_Licenses
            // 
            Active_Licenses.HeaderText = "Active_Licenses";
            Active_Licenses.Name = "Active_Licenses";
            Active_Licenses.ReadOnly = true;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Cambria", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(392, 1);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(156, 59);
            guna2HtmlLabel1.TabIndex = 39;
            guna2HtmlLabel1.Text = "Drivers";
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackColor = Color.Transparent;
            guna2PictureBox1.BackgroundImage = Properties.Resources.icons8_au_volant_100__1_2;
            guna2PictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            guna2PictureBox1.CustomizableEdges = customizableEdges11;
            guna2PictureBox1.FillColor = Color.Transparent;
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(405, 64);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2PictureBox1.Size = new Size(131, 121);
            guna2PictureBox1.TabIndex = 50;
            guna2PictureBox1.TabStop = false;
            // 
            // DriversMenuStrip
            // 
            DriversMenuStrip.Items.AddRange(new ToolStripItem[] { IssueInternationalLicenseBtn, ShowLicensesHistoryBtn, ShowInfoButton });
            DriversMenuStrip.Name = "PeopleMenuStrip";
            DriversMenuStrip.ShowCheckMargin = true;
            DriversMenuStrip.Size = new Size(347, 110);
            // 
            // IssueInternationalLicenseBtn
            // 
            IssueInternationalLicenseBtn.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IssueInternationalLicenseBtn.Image = (Image)resources.GetObject("IssueInternationalLicenseBtn.Image");
            IssueInternationalLicenseBtn.Name = "IssueInternationalLicenseBtn";
            IssueInternationalLicenseBtn.Size = new Size(346, 28);
            IssueInternationalLicenseBtn.Text = "Issue International License'";
            // 
            // ShowLicensesHistoryBtn
            // 
            ShowLicensesHistoryBtn.Font = new Font("Arial Black", 12F, FontStyle.Bold);
            ShowLicensesHistoryBtn.Image = (Image)resources.GetObject("ShowLicensesHistoryBtn.Image");
            ShowLicensesHistoryBtn.Name = "ShowLicensesHistoryBtn";
            ShowLicensesHistoryBtn.Size = new Size(346, 28);
            ShowLicensesHistoryBtn.Text = "Show Licenses History";
            ShowLicensesHistoryBtn.TextImageRelation = TextImageRelation.Overlay;
            ShowLicensesHistoryBtn.Click += ShowLicensesHistoryBtn_Click;
            // 
            // ShowInfoButton
            // 
            ShowInfoButton.Font = new Font("Arial Black", 12F, FontStyle.Bold);
            ShowInfoButton.Image = Properties.Resources.show1;
            ShowInfoButton.Name = "ShowInfoButton";
            ShowInfoButton.Size = new Size(346, 28);
            ShowInfoButton.Text = "Show Person Info";
            ShowInfoButton.Click += ShowInfoButton_Click;
            // 
            // ShowDriversFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(903, 603);
            Controls.Add(guna2PictureBox1);
            Controls.Add(DateTimePicker);
            Controls.Add(FilterValueTextBox);
            Controls.Add(FilterChoices);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(CloseButton);
            Controls.Add(RowsCountlabel);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(RefreshButton);
            Controls.Add(DataGrid);
            Controls.Add(guna2HtmlLabel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ShowDriversFrm";
            Text = "Drivers";
            Load += ShowDriversFrm_Load;
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            DriversMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker DateTimePicker;
        private Guna.UI2.WinForms.Guna2TextBox FilterValueTextBox;
        private Guna.UI2.WinForms.Guna2ComboBox FilterChoices;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel RowsCountlabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2Button RefreshButton;
        private Guna.UI2.WinForms.Guna2DataGridView DataGrid;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private DataGridViewTextBoxColumn DriverID;
        private DataGridViewTextBoxColumn PersonID;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn NationalNo;
        private DataGridViewTextBoxColumn CreatedDate;
        private DataGridViewTextBoxColumn Active_Licenses;
        private ContextMenuStrip DriversMenuStrip;
        private ToolStripMenuItem IssueInternationalLicenseBtn;
        private ToolStripMenuItem ShowLicensesHistoryBtn;
        private ToolStripMenuItem ShowInfoButton;
    }
}