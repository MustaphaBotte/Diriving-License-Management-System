namespace DesktopApp.AppTypesManagement
{
    partial class AppTypesManagementFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppTypesManagementFrm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            RowsCountlabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            RefreshButton = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            DataGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            ApplicationTypesMenuStrip = new ContextMenuStrip(components);
            EditAppTypeMenuItem = new ToolStripMenuItem();
            CloseButton = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            ApplicationTypesMenuStrip.SuspendLayout();
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
            CloseButton.Location = new Point(658, 380);
            CloseButton.Name = "CloseButton";
            CloseButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            CloseButton.Size = new Size(123, 36);
            CloseButton.TabIndex = 28;
            CloseButton.Text = "Close";
            CloseButton.Click += CloseButton_Click;
            CloseButton.MouseEnter += RefreshButton_MouseEnter;
            CloseButton.MouseLeave += RefreshButton_MouseLeave;
            // 
            // RowsCountlabel
            // 
            RowsCountlabel.BackColor = Color.Transparent;
            RowsCountlabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RowsCountlabel.ForeColor = Color.DarkRed;
            RowsCountlabel.Location = new Point(152, 380);
            RowsCountlabel.Name = "RowsCountlabel";
            RowsCountlabel.Size = new Size(19, 27);
            RowsCountlabel.TabIndex = 27;
            RowsCountlabel.Text = "??";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.ForeColor = Color.Black;
            guna2HtmlLabel3.Location = new Point(25, 380);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(110, 27);
            guna2HtmlLabel3.TabIndex = 26;
            guna2HtmlLabel3.Text = "Rows Count";
            // 
            // RefreshButton
            // 
            RefreshButton.BackColor = Color.Transparent;
            RefreshButton.BorderRadius = 20;
            RefreshButton.BorderThickness = 1;
            RefreshButton.CustomizableEdges = customizableEdges3;
            RefreshButton.DisabledState.BorderColor = Color.DarkGray;
            RefreshButton.DisabledState.CustomBorderColor = Color.DarkGray;
            RefreshButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            RefreshButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            RefreshButton.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RefreshButton.ForeColor = SystemColors.ActiveCaptionText;
            RefreshButton.Image = (Image)resources.GetObject("RefreshButton.Image");
            RefreshButton.ImageAlign = HorizontalAlignment.Left;
            RefreshButton.Location = new Point(522, 380);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            RefreshButton.Size = new Size(122, 36);
            RefreshButton.TabIndex = 20;
            RefreshButton.Text = "Refresh";
            RefreshButton.TextAlign = HorizontalAlignment.Left;
            RefreshButton.Click += RefreshButton_Click;
            RefreshButton.MouseEnter += RefreshButton_MouseEnter;
            RefreshButton.MouseLeave += RefreshButton_MouseLeave;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Sitka Small", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.Black;
            guna2HtmlLabel1.Location = new Point(257, 0);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(309, 50);
            guna2HtmlLabel1.TabIndex = 18;
            guna2HtmlLabel1.Text = "Application Types";
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
            DataGrid.Location = new Point(24, 147);
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
            DataGrid.Size = new Size(757, 201);
            DataGrid.TabIndex = 21;
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
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackColor = Color.Transparent;
            guna2PictureBox1.BackgroundImage = (Image)resources.GetObject("guna2PictureBox1.BackgroundImage");
            guna2PictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            guna2PictureBox1.CustomizableEdges = customizableEdges5;
            guna2PictureBox1.FillColor = Color.Transparent;
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(340, 46);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2PictureBox1.Size = new Size(142, 95);
            guna2PictureBox1.TabIndex = 29;
            guna2PictureBox1.TabStop = false;
            // 
            // ApplicationTypesMenuStrip
            // 
            ApplicationTypesMenuStrip.Items.AddRange(new ToolStripItem[] { EditAppTypeMenuItem });
            ApplicationTypesMenuStrip.Name = "contextMenuStrip1";
            ApplicationTypesMenuStrip.Size = new Size(244, 30);
            // 
            // EditAppTypeMenuItem
            // 
            EditAppTypeMenuItem.Font = new Font("Sylfaen", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EditAppTypeMenuItem.Image = Properties.Resources.edit;
            EditAppTypeMenuItem.Name = "EditAppTypeMenuItem";
            EditAppTypeMenuItem.Size = new Size(243, 26);
            EditAppTypeMenuItem.Text = "Edit Application Type";
            EditAppTypeMenuItem.Click += EditAppTypeMenuItem_Click;
            // 
            // AppTypesManagementFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(812, 425);
            Controls.Add(guna2PictureBox1);
            Controls.Add(CloseButton);
            Controls.Add(RowsCountlabel);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(RefreshButton);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(DataGrid);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AppTypesManagementFrm";
            Text = "AppTypesManagementFrm";
            Load += AppTypesManagementFrm_Load;
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ApplicationTypesMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel RowsCountlabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2Button RefreshButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2DataGridView DataGrid;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private ContextMenuStrip ApplicationTypesMenuStrip;
        private ToolStripMenuItem EditAppTypeMenuItem;
    }
}