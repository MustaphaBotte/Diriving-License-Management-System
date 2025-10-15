namespace DesktopApp.InternationalDrivingLicense
{
    partial class InternationlLicensesManagement
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
            Guna.UI2.WinForms.Guna2Button IssueNewLicensebtn;
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InternationlLicensesManagement));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            DateTimePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            FilterValueTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            FilterChoices = new Guna.UI2.WinForms.Guna2ComboBox();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            RowsCountlabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            RefreshButton = new Guna.UI2.WinForms.Guna2Button();
            DataGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            InternationalLicenseID = new DataGridViewTextBoxColumn();
            ApplicationID = new DataGridViewTextBoxColumn();
            DriverID = new DataGridViewTextBoxColumn();
            IssuedUsingLocalLicenseID = new DataGridViewTextBoxColumn();
            IssueDate = new DataGridViewTextBoxColumn();
            ExpirationDate = new DataGridViewTextBoxColumn();
            IsActive = new DataGridViewTextBoxColumn();
            CreatedByUserID = new DataGridViewTextBoxColumn();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            licenseMenuStrip = new ContextMenuStrip(components);
            ShowLicensebtn = new ToolStripMenuItem();
            ShowLicensesHistoryBtn = new ToolStripMenuItem();
            ShowInfoButton = new ToolStripMenuItem();
            CloseButton = new Guna.UI2.WinForms.Guna2Button();
            IssueNewLicensebtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            licenseMenuStrip.SuspendLayout();
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
            CloseButton.Location = new Point(857, 553);
            CloseButton.Name = "CloseButton";
            CloseButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            CloseButton.Size = new Size(123, 36);
            CloseButton.TabIndex = 56;
            CloseButton.Text = "Close";
            CloseButton.Click += CloseButton_Click;
            CloseButton.MouseEnter += IssueNewLicensebtn_MouseEnter;
            CloseButton.MouseLeave += IssueNewLicensebtn_MouseLeave;
            // 
            // IssueNewLicensebtn
            // 
            IssueNewLicensebtn.BackColor = Color.Transparent;
            IssueNewLicensebtn.BorderRadius = 15;
            IssueNewLicensebtn.BorderThickness = 1;
            IssueNewLicensebtn.CustomizableEdges = customizableEdges3;
            IssueNewLicensebtn.DisabledState.BorderColor = Color.DarkGray;
            IssueNewLicensebtn.DisabledState.CustomBorderColor = Color.DarkGray;
            IssueNewLicensebtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            IssueNewLicensebtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            IssueNewLicensebtn.FillColor = Color.SeaGreen;
            IssueNewLicensebtn.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IssueNewLicensebtn.ForeColor = Color.White;
            IssueNewLicensebtn.Image = (Image)resources.GetObject("IssueNewLicensebtn.Image");
            IssueNewLicensebtn.ImageAlign = HorizontalAlignment.Left;
            IssueNewLicensebtn.Location = new Point(757, 184);
            IssueNewLicensebtn.Name = "IssueNewLicensebtn";
            IssueNewLicensebtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            IssueNewLicensebtn.Size = new Size(221, 36);
            IssueNewLicensebtn.TabIndex = 63;
            IssueNewLicensebtn.Text = "Issue New License";
            IssueNewLicensebtn.Click += IssueNewLicensebtn_Click;
            IssueNewLicensebtn.MouseEnter += IssueNewLicensebtn_MouseEnter;
            IssueNewLicensebtn.MouseLeave += IssueNewLicensebtn_MouseLeave;
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackColor = Color.Transparent;
            guna2PictureBox1.BackgroundImage = (Image)resources.GetObject("guna2PictureBox1.BackgroundImage");
            guna2PictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            guna2PictureBox1.CustomizableEdges = customizableEdges5;
            guna2PictureBox1.FillColor = Color.Transparent;
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(439, 46);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2PictureBox1.Size = new Size(131, 121);
            guna2PictureBox1.TabIndex = 61;
            guna2PictureBox1.TabStop = false;
            // 
            // DateTimePicker
            // 
            DateTimePicker.BackColor = Color.Transparent;
            DateTimePicker.BorderColor = Color.DarkCyan;
            DateTimePicker.BorderRadius = 15;
            DateTimePicker.BorderThickness = 1;
            DateTimePicker.Checked = true;
            DateTimePicker.CustomizableEdges = customizableEdges7;
            DateTimePicker.FillColor = Color.FromArgb(64, 64, 64);
            DateTimePicker.Font = new Font("Segoe UI", 9F);
            DateTimePicker.Format = DateTimePickerFormat.Long;
            DateTimePicker.Location = new Point(353, 184);
            DateTimePicker.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            DateTimePicker.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            DateTimePicker.Name = "DateTimePicker";
            DateTimePicker.ShadowDecoration.CustomizableEdges = customizableEdges8;
            DateTimePicker.Size = new Size(200, 36);
            DateTimePicker.TabIndex = 60;
            DateTimePicker.Value = new DateTime(2025, 6, 3, 15, 35, 13, 326);
            DateTimePicker.Visible = false;
            DateTimePicker.ValueChanged += DateTimePicker_ValueChanged;
            // 
            // FilterValueTextBox
            // 
            FilterValueTextBox.BackColor = Color.Transparent;
            FilterValueTextBox.BorderColor = Color.DarkCyan;
            FilterValueTextBox.BorderRadius = 15;
            FilterValueTextBox.CustomizableEdges = customizableEdges9;
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
            FilterValueTextBox.Location = new Point(336, 184);
            FilterValueTextBox.Margin = new Padding(4);
            FilterValueTextBox.Name = "FilterValueTextBox";
            FilterValueTextBox.PlaceholderText = "";
            FilterValueTextBox.SelectedText = "";
            FilterValueTextBox.ShadowDecoration.CustomizableEdges = customizableEdges10;
            FilterValueTextBox.Size = new Size(234, 36);
            FilterValueTextBox.TabIndex = 59;
            FilterValueTextBox.TextChanged += FilterValueTextBox_TextChanged;
            FilterValueTextBox.KeyPress += FilterValueTextBox_KeyPress;
            // 
            // FilterChoices
            // 
            FilterChoices.BackColor = Color.Transparent;
            FilterChoices.BorderColor = Color.DarkCyan;
            FilterChoices.BorderRadius = 15;
            FilterChoices.CustomizableEdges = customizableEdges11;
            FilterChoices.DrawMode = DrawMode.OwnerDrawFixed;
            FilterChoices.DropDownStyle = ComboBoxStyle.DropDownList;
            FilterChoices.FillColor = Color.DimGray;
            FilterChoices.FocusedColor = Color.FromArgb(94, 148, 255);
            FilterChoices.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            FilterChoices.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FilterChoices.ForeColor = Color.Black;
            FilterChoices.ItemHeight = 30;
            FilterChoices.Location = new Point(94, 184);
            FilterChoices.Name = "FilterChoices";
            FilterChoices.ShadowDecoration.CustomizableEdges = customizableEdges12;
            FilterChoices.Size = new Size(235, 36);
            FilterChoices.TabIndex = 58;
            FilterChoices.SelectedIndexChanged += FilterChoices_SelectedIndexChanged;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = Color.OrangeRed;
            guna2HtmlLabel2.Location = new Point(15, 194);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(67, 20);
            guna2HtmlLabel2.TabIndex = 57;
            guna2HtmlLabel2.Text = "Filter By";
            // 
            // RowsCountlabel
            // 
            RowsCountlabel.BackColor = Color.Transparent;
            RowsCountlabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RowsCountlabel.ForeColor = Color.DarkRed;
            RowsCountlabel.Location = new Point(142, 552);
            RowsCountlabel.Name = "RowsCountlabel";
            RowsCountlabel.Size = new Size(19, 27);
            RowsCountlabel.TabIndex = 55;
            RowsCountlabel.Text = "??";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.ForeColor = Color.Black;
            guna2HtmlLabel3.Location = new Point(15, 552);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(110, 27);
            guna2HtmlLabel3.TabIndex = 54;
            guna2HtmlLabel3.Text = "Rows Count";
            // 
            // RefreshButton
            // 
            RefreshButton.BackColor = Color.Transparent;
            RefreshButton.BorderRadius = 20;
            RefreshButton.BorderThickness = 1;
            RefreshButton.CustomizableEdges = customizableEdges13;
            RefreshButton.DisabledState.BorderColor = Color.DarkGray;
            RefreshButton.DisabledState.CustomBorderColor = Color.DarkGray;
            RefreshButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            RefreshButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            RefreshButton.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RefreshButton.ForeColor = SystemColors.ActiveCaptionText;
            RefreshButton.Image = (Image)resources.GetObject("RefreshButton.Image");
            RefreshButton.ImageAlign = HorizontalAlignment.Left;
            RefreshButton.Location = new Point(729, 553);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.ShadowDecoration.CustomizableEdges = customizableEdges14;
            RefreshButton.Size = new Size(122, 36);
            RefreshButton.TabIndex = 53;
            RefreshButton.Text = "Refresh";
            RefreshButton.TextAlign = HorizontalAlignment.Left;
            RefreshButton.Click += RefreshButton_Click;
            RefreshButton.MouseEnter += IssueNewLicensebtn_MouseEnter;
            RefreshButton.MouseLeave += IssueNewLicensebtn_MouseLeave;
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
            DataGrid.Columns.AddRange(new DataGridViewColumn[] { InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.DimGray;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            DataGrid.GridColor = Color.FromArgb(231, 229, 255);
            DataGrid.Location = new Point(17, 226);
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
            DataGrid.Size = new Size(963, 321);
            DataGrid.TabIndex = 52;
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
            DataGrid.CellMouseClick += DataGrid_CellMouseClick;
            // 
            // InternationalLicenseID
            // 
            InternationalLicenseID.HeaderText = "ID";
            InternationalLicenseID.Name = "InternationalLicenseID";
            InternationalLicenseID.ReadOnly = true;
            // 
            // ApplicationID
            // 
            ApplicationID.HeaderText = "AppID";
            ApplicationID.Name = "ApplicationID";
            ApplicationID.ReadOnly = true;
            // 
            // DriverID
            // 
            DriverID.HeaderText = "Driver";
            DriverID.Name = "DriverID";
            DriverID.ReadOnly = true;
            // 
            // IssuedUsingLocalLicenseID
            // 
            IssuedUsingLocalLicenseID.HeaderText = "LocalLic";
            IssuedUsingLocalLicenseID.Name = "IssuedUsingLocalLicenseID";
            IssuedUsingLocalLicenseID.ReadOnly = true;
            // 
            // IssueDate
            // 
            IssueDate.HeaderText = "Issued";
            IssueDate.Name = "IssueDate";
            IssueDate.ReadOnly = true;
            // 
            // ExpirationDate
            // 
            ExpirationDate.HeaderText = "Expires";
            ExpirationDate.Name = "ExpirationDate";
            ExpirationDate.ReadOnly = true;
            // 
            // IsActive
            // 
            IsActive.HeaderText = "Active";
            IsActive.Name = "IsActive";
            IsActive.ReadOnly = true;
            // 
            // CreatedByUserID
            // 
            CreatedByUserID.HeaderText = "User";
            CreatedByUserID.Name = "CreatedByUserID";
            CreatedByUserID.ReadOnly = true;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Cambria", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(358, -74);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(156, 59);
            guna2HtmlLabel1.TabIndex = 51;
            guna2HtmlLabel1.Text = "Drivers";
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Cambria", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel4.Location = new Point(265, -10);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(435, 59);
            guna2HtmlLabel4.TabIndex = 62;
            guna2HtmlLabel4.Text = "Internationl Licenses";
            // 
            // licenseMenuStrip
            // 
            licenseMenuStrip.Items.AddRange(new ToolStripItem[] { ShowLicensebtn, ShowLicensesHistoryBtn, ShowInfoButton });
            licenseMenuStrip.Name = "PeopleMenuStrip";
            licenseMenuStrip.ShowCheckMargin = true;
            licenseMenuStrip.Size = new Size(303, 88);
            // 
            // ShowLicensebtn
            // 
            ShowLicensebtn.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShowLicensebtn.Image = (Image)resources.GetObject("ShowLicensebtn.Image");
            ShowLicensebtn.Name = "ShowLicensebtn";
            ShowLicensebtn.Size = new Size(302, 28);
            ShowLicensebtn.Text = "Show License ";
            ShowLicensebtn.Click += ShowLicensebtn_Click;
            // 
            // ShowLicensesHistoryBtn
            // 
            ShowLicensesHistoryBtn.Font = new Font("Arial Black", 12F, FontStyle.Bold);
            ShowLicensesHistoryBtn.Image = (Image)resources.GetObject("ShowLicensesHistoryBtn.Image");
            ShowLicensesHistoryBtn.Name = "ShowLicensesHistoryBtn";
            ShowLicensesHistoryBtn.Size = new Size(302, 28);
            ShowLicensesHistoryBtn.Text = "Show Licenses History";
            ShowLicensesHistoryBtn.TextImageRelation = TextImageRelation.Overlay;
            ShowLicensesHistoryBtn.Click += ShowLicensesHistoryBtn_Click;
            // 
            // ShowInfoButton
            // 
            ShowInfoButton.Font = new Font("Arial Black", 12F, FontStyle.Bold);
            ShowInfoButton.Image = Properties.Resources.show1;
            ShowInfoButton.Name = "ShowInfoButton";
            ShowInfoButton.Size = new Size(302, 28);
            ShowInfoButton.Text = "Show Person Info";
            ShowInfoButton.Click += ShowInfoButton_Click;
            // 
            // InternationlLicensesManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 598);
            Controls.Add(IssueNewLicensebtn);
            Controls.Add(guna2HtmlLabel4);
            Controls.Add(guna2PictureBox1);
            Controls.Add(DateTimePicker);
            Controls.Add(FilterValueTextBox);
            Controls.Add(FilterChoices);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(CloseButton);
            Controls.Add(RowsCountlabel);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(RefreshButton);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(DataGrid);
            Name = "InternationlLicensesManagement";
            Text = "InternationlLicensesManagement";
            Load += InternationlLicensesManagement_Load;
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            licenseMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateTimePicker;
        private Guna.UI2.WinForms.Guna2TextBox FilterValueTextBox;
        private Guna.UI2.WinForms.Guna2ComboBox FilterChoices;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel RowsCountlabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2Button RefreshButton;
        private Guna.UI2.WinForms.Guna2DataGridView DataGrid;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private DataGridViewTextBoxColumn InternationalLicenseID;
        private DataGridViewTextBoxColumn ApplicationID;
        private DataGridViewTextBoxColumn DriverID;
        private DataGridViewTextBoxColumn IssuedUsingLocalLicenseID;
        private DataGridViewTextBoxColumn IssueDate;
        private DataGridViewTextBoxColumn ExpirationDate;
        private DataGridViewTextBoxColumn IsActive;
        private DataGridViewTextBoxColumn CreatedByUserID;
        private ContextMenuStrip licenseMenuStrip;
        private ToolStripMenuItem ShowLicensebtn;
        private ToolStripMenuItem ShowLicensesHistoryBtn;
        private ToolStripMenuItem ShowInfoButton;
    }
}