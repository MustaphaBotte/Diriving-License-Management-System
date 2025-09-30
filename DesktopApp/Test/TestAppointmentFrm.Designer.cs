namespace DesktopApp.ScheduleTest
{
    partial class TestAppointmentFrm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestAppointmentFrm));
            TestTypeTitleLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            DataGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            AppointmentID = new DataGridViewTextBoxColumn();
            AppointmentDate = new DataGridViewTextBoxColumn();
            PaidFees = new DataGridViewTextBoxColumn();
            CreatedByUserID = new DataGridViewTextBoxColumn();
            IsLocked = new DataGridViewCheckBoxColumn();
            AddAppointment = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            RowsCountLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            applicationInfoControl1 = new DesktopApp.VisionTest.ApplicationInfoControl();
            TestOptionsMenuStrip = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            TakeTestMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            TestOptionsMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // TestTypeTitleLabel
            // 
            TestTypeTitleLabel.BackColor = Color.Transparent;
            TestTypeTitleLabel.Font = new Font("Times New Roman", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TestTypeTitleLabel.ForeColor = Color.Red;
            TestTypeTitleLabel.Location = new Point(257, 12);
            TestTypeTitleLabel.Name = "TestTypeTitleLabel";
            TestTypeTitleLabel.Size = new Size(225, 34);
            TestTypeTitleLabel.TabIndex = 0;
            TestTypeTitleLabel.Text = " Test Appointment";
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackColor = Color.Transparent;
            guna2PictureBox1.BackgroundImage = Properties.Resources.icons8_vision_100;
            guna2PictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            guna2PictureBox1.BorderRadius = 20;
            guna2PictureBox1.CustomizableEdges = customizableEdges5;
            guna2PictureBox1.FillColor = Color.Transparent;
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(155, -5);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2PictureBox1.Size = new Size(96, 84);
            guna2PictureBox1.TabIndex = 1;
            guna2PictureBox1.TabStop = false;
            // 
            // DataGrid
            // 
            DataGrid.AllowUserToAddRows = false;
            dataGridViewCellStyle6.BackColor = Color.White;
            DataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            DataGrid.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.Silver;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = Color.Silver;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            DataGrid.ColumnHeadersHeight = 20;
            DataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            DataGrid.Columns.AddRange(new DataGridViewColumn[] { AppointmentID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle8.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            DataGrid.DefaultCellStyle = dataGridViewCellStyle8;
            DataGrid.GridColor = Color.White;
            DataGrid.Location = new Point(12, 434);
            DataGrid.MultiSelect = false;
            DataGrid.Name = "DataGrid";
            DataGrid.ReadOnly = true;
            DataGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = Color.Aquamarine;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            DataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            DataGrid.RowHeadersVisible = false;
            dataGridViewCellStyle10.SelectionBackColor = Color.WhiteSmoke;
            DataGrid.RowsDefaultCellStyle = dataGridViewCellStyle10;
            DataGrid.Size = new Size(782, 160);
            DataGrid.TabIndex = 3;
            DataGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            DataGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            DataGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            DataGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            DataGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            DataGrid.ThemeStyle.BackColor = Color.White;
            DataGrid.ThemeStyle.GridColor = Color.White;
            DataGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            DataGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            DataGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            DataGrid.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            DataGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            DataGrid.ThemeStyle.HeaderStyle.Height = 20;
            DataGrid.ThemeStyle.ReadOnly = true;
            DataGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            DataGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DataGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            DataGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            DataGrid.ThemeStyle.RowsStyle.Height = 25;
            DataGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            DataGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            DataGrid.CellMouseClick += DataGrid_CellMouseClick;
            DataGrid.SelectionChanged += DataGrid_SelectionChanged;
            // 
            // AppointmentID
            // 
            AppointmentID.HeaderText = "AppointmentID";
            AppointmentID.Name = "AppointmentID";
            AppointmentID.ReadOnly = true;
            // 
            // AppointmentDate
            // 
            AppointmentDate.HeaderText = "AppointmentDate";
            AppointmentDate.Name = "AppointmentDate";
            AppointmentDate.ReadOnly = true;
            // 
            // PaidFees
            // 
            PaidFees.HeaderText = "PaidFees";
            PaidFees.Name = "PaidFees";
            PaidFees.ReadOnly = true;
            // 
            // CreatedByUserID
            // 
            CreatedByUserID.HeaderText = "CreatedByUserID";
            CreatedByUserID.Name = "CreatedByUserID";
            CreatedByUserID.ReadOnly = true;
            // 
            // IsLocked
            // 
            IsLocked.HeaderText = "IsLocked";
            IsLocked.Name = "IsLocked";
            IsLocked.ReadOnly = true;
            IsLocked.Resizable = DataGridViewTriState.True;
            IsLocked.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // AddAppointment
            // 
            AddAppointment.BorderRadius = 15;
            AddAppointment.CustomizableEdges = customizableEdges7;
            AddAppointment.DisabledState.BorderColor = Color.DarkGray;
            AddAppointment.DisabledState.CustomBorderColor = Color.DarkGray;
            AddAppointment.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            AddAppointment.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            AddAppointment.FillColor = Color.ForestGreen;
            AddAppointment.Font = new Font("Segoe UI", 9F);
            AddAppointment.ForeColor = Color.White;
            AddAppointment.Image = Properties.Resources.Add1;
            AddAppointment.Location = new Point(712, 396);
            AddAppointment.Name = "AddAppointment";
            AddAppointment.ShadowDecoration.CustomizableEdges = customizableEdges8;
            AddAppointment.Size = new Size(82, 32);
            AddAppointment.TabIndex = 4;
            AddAppointment.Text = "Add";
            AddAppointment.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            AddAppointment.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.LowerCase;
            AddAppointment.Click += AddAppointment_Click;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(15, 396);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(108, 21);
            guna2HtmlLabel2.TabIndex = 5;
            guna2HtmlLabel2.Text = "Appointments";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.Location = new Point(12, 600);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(91, 21);
            guna2HtmlLabel3.TabIndex = 6;
            guna2HtmlLabel3.Text = "Rows Count";
            // 
            // RowsCountLabel
            // 
            RowsCountLabel.BackColor = Color.Transparent;
            RowsCountLabel.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RowsCountLabel.ForeColor = Color.IndianRed;
            RowsCountLabel.Location = new Point(122, 600);
            RowsCountLabel.Name = "RowsCountLabel";
            RowsCountLabel.Size = new Size(24, 21);
            RowsCountLabel.TabIndex = 7;
            RowsCountLabel.Text = "???";
            // 
            // applicationInfoControl1
            // 
            applicationInfoControl1.Location = new Point(0, 75);
            applicationInfoControl1.Name = "applicationInfoControl1";
            applicationInfoControl1.Size = new Size(794, 315);
            applicationInfoControl1.TabIndex = 8;
            // 
            // TestOptionsMenuStrip
            // 
            TestOptionsMenuStrip.Items.AddRange(new ToolStripItem[] { TakeTestMenuItem, editToolStripMenuItem });
            TestOptionsMenuStrip.Name = "TestOptionsMenuStrip";
            TestOptionsMenuStrip.RenderStyle.ArrowColor = Color.FromArgb(151, 143, 255);
            TestOptionsMenuStrip.RenderStyle.BorderColor = Color.Gainsboro;
            TestOptionsMenuStrip.RenderStyle.ColorTable = null;
            TestOptionsMenuStrip.RenderStyle.RoundedEdges = true;
            TestOptionsMenuStrip.RenderStyle.SelectionArrowColor = Color.White;
            TestOptionsMenuStrip.RenderStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
            TestOptionsMenuStrip.RenderStyle.SelectionForeColor = Color.White;
            TestOptionsMenuStrip.RenderStyle.SeparatorColor = Color.Gainsboro;
            TestOptionsMenuStrip.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            TestOptionsMenuStrip.Size = new Size(149, 56);
            // 
            // TakeTestMenuItem
            // 
            TakeTestMenuItem.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TakeTestMenuItem.Image = Properties.Resources.icons8_vision_1001;
            TakeTestMenuItem.Name = "TakeTestMenuItem";
            TakeTestMenuItem.Size = new Size(148, 26);
            TakeTestMenuItem.Text = "Take Test";
            TakeTestMenuItem.Click += TakeTestMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Font = new Font("Ebrima", 12F, FontStyle.Bold);
            editToolStripMenuItem.Image = (Image)resources.GetObject("editToolStripMenuItem.Image");
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(148, 26);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // TestAppointmentFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 624);
            Controls.Add(applicationInfoControl1);
            Controls.Add(RowsCountLabel);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(AddAppointment);
            Controls.Add(DataGrid);
            Controls.Add(guna2PictureBox1);
            Controls.Add(TestTypeTitleLabel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "TestAppointmentFrm";
            Text = "Vsion Test Appointment";
            Load += VsionTestAppointmentFrm_Load;
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            TestOptionsMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel TestTypeTitleLabel;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2DataGridView DataGrid;
        private Guna.UI2.WinForms.Guna2Button AddAppointment;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel RowsCountLabel;
        private DataGridViewTextBoxColumn AppointmentID;
        private DataGridViewTextBoxColumn AppointmentDate;
        private DataGridViewTextBoxColumn PaidFees;
        private DataGridViewTextBoxColumn CreatedByUserID;
        private DataGridViewCheckBoxColumn IsLocked;
        private VisionTest.ApplicationInfoControl applicationInfoControl1;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip TestOptionsMenuStrip;
        private ToolStripMenuItem TakeTestMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
    }
}