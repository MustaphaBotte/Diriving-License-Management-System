namespace DesktopApp.AllLicensesHistory
{
    partial class ShowAllLicensesHistoryFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowAllLicensesHistoryFrm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            showInfoInControl1 = new DesktopApp.PersonControl.ShowInfoInControl();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            Pages = new Guna.UI2.WinForms.Guna2TabControl();
            LocalLicensesPage = new TabPage();
            LocalRowCountLBL = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            LocalLicencesGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            Lic_ID = new DataGridViewTextBoxColumn();
            AppID = new DataGridViewTextBoxColumn();
            ClassName = new DataGridViewTextBoxColumn();
            IssueDate = new DataGridViewTextBoxColumn();
            ExpirationDate = new DataGridViewTextBoxColumn();
            IsActive = new DataGridViewCheckBoxColumn();
            InternationalLicensesPage = new TabPage();
            InterRowCountLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            InternatiolLicensesGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            IL_LicID = new DataGridViewTextBoxColumn();
            InterGridAppID = new DataGridViewTextBoxColumn();
            LocalLicenseID = new DataGridViewTextBoxColumn();
            InterGridIssueDate = new DataGridViewTextBoxColumn();
            InterGridExpDate = new DataGridViewTextBoxColumn();
            InterGridIsActive = new DataGridViewCheckBoxColumn();
            panel1 = new Panel();
            ShowLicenseMenuStrip = new ContextMenuStrip(components);
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSeparator2 = new ToolStripSeparator();
            showLicenseInfoToolStripMenuItem = new ToolStripMenuItem();
            Pages.SuspendLayout();
            LocalLicensesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LocalLicencesGrid).BeginInit();
            InternationalLicensesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)InternatiolLicensesGrid).BeginInit();
            panel1.SuspendLayout();
            ShowLicenseMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // showInfoInControl1
            // 
            showInfoInControl1.BackColor = Color.Transparent;
            showInfoInControl1.BackgroundImage = (Image)resources.GetObject("showInfoInControl1.BackgroundImage");
            showInfoInControl1.BorderStyle = BorderStyle.FixedSingle;
            showInfoInControl1.Location = new Point(29, 55);
            showInfoInControl1.Name = "showInfoInControl1";
            showInfoInControl1.Size = new Size(772, 273);
            showInfoInControl1.TabIndex = 1;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Constantia", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.Black;
            guna2HtmlLabel1.Location = new Point(265, 2);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(292, 47);
            guna2HtmlLabel1.TabIndex = 2;
            guna2HtmlLabel1.Text = "Licenses History";
            // 
            // Pages
            // 
            Pages.Controls.Add(LocalLicensesPage);
            Pages.Controls.Add(InternationalLicensesPage);
            Pages.ItemSize = new Size(180, 40);
            Pages.Location = new Point(7, 4);
            Pages.Name = "Pages";
            Pages.SelectedIndex = 0;
            Pages.Size = new Size(764, 253);
            Pages.TabButtonHoverState.BorderColor = Color.Empty;
            Pages.TabButtonHoverState.FillColor = Color.FromArgb(40, 52, 70);
            Pages.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F);
            Pages.TabButtonHoverState.ForeColor = Color.White;
            Pages.TabButtonHoverState.InnerColor = Color.FromArgb(40, 52, 70);
            Pages.TabButtonIdleState.BorderColor = Color.Empty;
            Pages.TabButtonIdleState.FillColor = Color.FromArgb(33, 42, 57);
            Pages.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F);
            Pages.TabButtonIdleState.ForeColor = Color.FromArgb(156, 160, 167);
            Pages.TabButtonIdleState.InnerColor = Color.FromArgb(33, 42, 57);
            Pages.TabButtonSelectedState.BorderColor = Color.Empty;
            Pages.TabButtonSelectedState.FillColor = Color.FromArgb(29, 37, 49);
            Pages.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F);
            Pages.TabButtonSelectedState.ForeColor = Color.White;
            Pages.TabButtonSelectedState.InnerColor = Color.FromArgb(76, 132, 255);
            Pages.TabButtonSize = new Size(180, 40);
            Pages.TabButtonTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            Pages.TabIndex = 3;
            Pages.TabMenuBackColor = Color.Gainsboro;
            Pages.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            Pages.SelectedIndexChanged += Pages_SelectedIndexChanged;
            // 
            // LocalLicensesPage
            // 
            LocalLicensesPage.BackColor = Color.Gainsboro;
            LocalLicensesPage.BorderStyle = BorderStyle.FixedSingle;
            LocalLicensesPage.Controls.Add(LocalRowCountLBL);
            LocalLicensesPage.Controls.Add(guna2HtmlLabel2);
            LocalLicensesPage.Controls.Add(LocalLicencesGrid);
            LocalLicensesPage.Location = new Point(4, 44);
            LocalLicensesPage.Name = "LocalLicensesPage";
            LocalLicensesPage.Padding = new Padding(3);
            LocalLicensesPage.Size = new Size(756, 205);
            LocalLicensesPage.TabIndex = 0;
            LocalLicensesPage.Text = "Local Licenses";
            // 
            // LocalRowCountLBL
            // 
            LocalRowCountLBL.BackColor = Color.Transparent;
            LocalRowCountLBL.Font = new Font("Times New Roman", 14.25F);
            LocalRowCountLBL.ForeColor = Color.Red;
            LocalRowCountLBL.Location = new Point(98, 176);
            LocalRowCountLBL.Name = "LocalRowCountLBL";
            LocalRowCountLBL.Size = new Size(95, 23);
            LocalRowCountLBL.TabIndex = 2;
            LocalRowCountLBL.Text = "No Records";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(6, 176);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(86, 23);
            guna2HtmlLabel2.TabIndex = 1;
            guna2HtmlLabel2.Text = "#Records : ";
            // 
            // LocalLicencesGrid
            // 
            LocalLicencesGrid.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            LocalLicencesGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            LocalLicencesGrid.BackgroundColor = Color.Gray;
            LocalLicencesGrid.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            LocalLicencesGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            LocalLicencesGrid.ColumnHeadersHeight = 17;
            LocalLicencesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            LocalLicencesGrid.Columns.AddRange(new DataGridViewColumn[] { Lic_ID, AppID, ClassName, IssueDate, ExpirationDate, IsActive });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            LocalLicencesGrid.DefaultCellStyle = dataGridViewCellStyle3;
            LocalLicencesGrid.GridColor = Color.FromArgb(231, 229, 255);
            LocalLicencesGrid.Location = new Point(6, 6);
            LocalLicencesGrid.Name = "LocalLicencesGrid";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.ButtonFace;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            LocalLicencesGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            LocalLicencesGrid.RowHeadersVisible = false;
            LocalLicencesGrid.Size = new Size(742, 164);
            LocalLicencesGrid.TabIndex = 0;
            LocalLicencesGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            LocalLicencesGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            LocalLicencesGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            LocalLicencesGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            LocalLicencesGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            LocalLicencesGrid.ThemeStyle.BackColor = Color.Gray;
            LocalLicencesGrid.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            LocalLicencesGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            LocalLicencesGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            LocalLicencesGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            LocalLicencesGrid.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            LocalLicencesGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            LocalLicencesGrid.ThemeStyle.HeaderStyle.Height = 17;
            LocalLicencesGrid.ThemeStyle.ReadOnly = false;
            LocalLicencesGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            LocalLicencesGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            LocalLicencesGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            LocalLicencesGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            LocalLicencesGrid.ThemeStyle.RowsStyle.Height = 25;
            LocalLicencesGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            LocalLicencesGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            LocalLicencesGrid.CellMouseClick += LocalLicencesGrid_CellMouseClick;
            // 
            // Lic_ID
            // 
            Lic_ID.HeaderText = "Lic_ID";
            Lic_ID.Name = "Lic_ID";
            // 
            // AppID
            // 
            AppID.HeaderText = "AppID";
            AppID.Name = "AppID";
            // 
            // ClassName
            // 
            ClassName.HeaderText = "ClassName";
            ClassName.Name = "ClassName";
            // 
            // IssueDate
            // 
            IssueDate.HeaderText = "IssueDate";
            IssueDate.Name = "IssueDate";
            // 
            // ExpirationDate
            // 
            ExpirationDate.HeaderText = "ExpirationDate";
            ExpirationDate.Name = "ExpirationDate";
            // 
            // IsActive
            // 
            IsActive.HeaderText = "IsActive";
            IsActive.Name = "IsActive";
            // 
            // InternationalLicensesPage
            // 
            InternationalLicensesPage.BackColor = Color.Gainsboro;
            InternationalLicensesPage.BorderStyle = BorderStyle.FixedSingle;
            InternationalLicensesPage.Controls.Add(InterRowCountLabel);
            InternationalLicensesPage.Controls.Add(guna2HtmlLabel4);
            InternationalLicensesPage.Controls.Add(InternatiolLicensesGrid);
            InternationalLicensesPage.Location = new Point(4, 44);
            InternationalLicensesPage.Name = "InternationalLicensesPage";
            InternationalLicensesPage.Padding = new Padding(3);
            InternationalLicensesPage.Size = new Size(756, 205);
            InternationalLicensesPage.TabIndex = 1;
            InternationalLicensesPage.Text = "International Licenses";
            // 
            // InterRowCountLabel
            // 
            InterRowCountLabel.BackColor = Color.Transparent;
            InterRowCountLabel.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InterRowCountLabel.ForeColor = Color.Red;
            InterRowCountLabel.Location = new Point(101, 176);
            InterRowCountLabel.Name = "InterRowCountLabel";
            InterRowCountLabel.Size = new Size(95, 23);
            InterRowCountLabel.TabIndex = 4;
            InterRowCountLabel.Text = "No Records";
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel4.Location = new Point(9, 176);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(86, 23);
            guna2HtmlLabel4.TabIndex = 3;
            guna2HtmlLabel4.Text = "#Records : ";
            // 
            // InternatiolLicensesGrid
            // 
            InternatiolLicensesGrid.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = Color.White;
            InternatiolLicensesGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            InternatiolLicensesGrid.BackgroundColor = Color.Gray;
            InternatiolLicensesGrid.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            InternatiolLicensesGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            InternatiolLicensesGrid.ColumnHeadersHeight = 17;
            InternatiolLicensesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            InternatiolLicensesGrid.Columns.AddRange(new DataGridViewColumn[] { IL_LicID, InterGridAppID, LocalLicenseID, InterGridIssueDate, InterGridExpDate, InterGridIsActive });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            InternatiolLicensesGrid.DefaultCellStyle = dataGridViewCellStyle7;
            InternatiolLicensesGrid.GridColor = Color.FromArgb(231, 229, 255);
            InternatiolLicensesGrid.Location = new Point(6, 6);
            InternatiolLicensesGrid.Name = "InternatiolLicensesGrid";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.ButtonFace;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            InternatiolLicensesGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            InternatiolLicensesGrid.RowHeadersVisible = false;
            InternatiolLicensesGrid.Size = new Size(742, 164);
            InternatiolLicensesGrid.TabIndex = 1;
            InternatiolLicensesGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            InternatiolLicensesGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            InternatiolLicensesGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            InternatiolLicensesGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            InternatiolLicensesGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            InternatiolLicensesGrid.ThemeStyle.BackColor = Color.Gray;
            InternatiolLicensesGrid.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            InternatiolLicensesGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            InternatiolLicensesGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            InternatiolLicensesGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            InternatiolLicensesGrid.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            InternatiolLicensesGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            InternatiolLicensesGrid.ThemeStyle.HeaderStyle.Height = 17;
            InternatiolLicensesGrid.ThemeStyle.ReadOnly = false;
            InternatiolLicensesGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            InternatiolLicensesGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            InternatiolLicensesGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            InternatiolLicensesGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            InternatiolLicensesGrid.ThemeStyle.RowsStyle.Height = 25;
            InternatiolLicensesGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            InternatiolLicensesGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            InternatiolLicensesGrid.CellMouseClick += InternatiolLicensesGrid_CellMouseClick;
            // 
            // IL_LicID
            // 
            IL_LicID.HeaderText = "IL_LicID";
            IL_LicID.Name = "IL_LicID";
            // 
            // InterGridAppID
            // 
            InterGridAppID.HeaderText = "AppID";
            InterGridAppID.Name = "InterGridAppID";
            // 
            // LocalLicenseID
            // 
            LocalLicenseID.HeaderText = "LocalLicenseID";
            LocalLicenseID.Name = "LocalLicenseID";
            // 
            // InterGridIssueDate
            // 
            InterGridIssueDate.HeaderText = "IssueDate";
            InterGridIssueDate.Name = "InterGridIssueDate";
            // 
            // InterGridExpDate
            // 
            InterGridExpDate.HeaderText = "ExpirationDate";
            InterGridExpDate.Name = "InterGridExpDate";
            // 
            // InterGridIsActive
            // 
            InterGridIsActive.HeaderText = "IsActive";
            InterGridIsActive.Name = "InterGridIsActive";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(Pages);
            panel1.Location = new Point(29, 334);
            panel1.Name = "panel1";
            panel1.Size = new Size(772, 262);
            panel1.TabIndex = 4;
            // 
            // ShowLicenseMenuStrip
            // 
            ShowLicenseMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripSeparator1, toolStripSeparator2, showLicenseInfoToolStripMenuItem });
            ShowLicenseMenuStrip.Name = "PeopleMenuStrip";
            ShowLicenseMenuStrip.ShowCheckMargin = true;
            ShowLicenseMenuStrip.Size = new Size(263, 44);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(259, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(259, 6);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            showLicenseInfoToolStripMenuItem.Font = new Font("Arial Black", 12F, FontStyle.Bold);
            showLicenseInfoToolStripMenuItem.Image = Properties.Resources.show4;
            showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            showLicenseInfoToolStripMenuItem.Size = new Size(262, 28);
            showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            showLicenseInfoToolStripMenuItem.Click += showLicenseInfoToolStripMenuItem_Click;
            // 
            // ShowAllLicensesHistoryFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(826, 601);
            Controls.Add(panel1);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(showInfoInControl1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ShowAllLicensesHistoryFrm";
            Text = "License History";
            Load += ShowAllLicensesHistoryFrm_Load;
            Pages.ResumeLayout(false);
            LocalLicensesPage.ResumeLayout(false);
            LocalLicensesPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LocalLicencesGrid).EndInit();
            InternationalLicensesPage.ResumeLayout(false);
            InternationalLicensesPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)InternatiolLicensesGrid).EndInit();
            panel1.ResumeLayout(false);
            ShowLicenseMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PersonControl.ShowInfoInControl showInfoInControl1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TabControl Pages;
        private TabPage LocalLicensesPage;
        private TabPage InternationalLicensesPage;
        private Guna.UI2.WinForms.Guna2HtmlLabel LocalRowCountLBL;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2DataGridView LocalLicencesGrid;
        private Guna.UI2.WinForms.Guna2HtmlLabel InterRowCountLabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2DataGridView InternatiolLicensesGrid;
        private DataGridViewTextBoxColumn Lic_ID;
        private DataGridViewTextBoxColumn AppID;
        private DataGridViewTextBoxColumn ClassName;
        private DataGridViewTextBoxColumn IssueDate;
        private DataGridViewTextBoxColumn ExpirationDate;
        private DataGridViewCheckBoxColumn IsActive;
        private Panel panel1;
        private ContextMenuStrip ShowLicenseMenuStrip;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private DataGridViewTextBoxColumn IL_LicID;
        private DataGridViewTextBoxColumn InterGridAppID;
        private DataGridViewTextBoxColumn LocalLicenseID;
        private DataGridViewTextBoxColumn InterGridIssueDate;
        private DataGridViewTextBoxColumn InterGridExpDate;
        private DataGridViewCheckBoxColumn InterGridIsActive;
    }
}