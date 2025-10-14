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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowAllLicensesHistoryFrm));
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            licensesHistoryControl1 = new DesktopApp.LicensesHistory.LicensesHistoryControl();
            showPersonWithFilter1 = new DesktopApp.PersonControl.ShowPersonWithFilter();
            SuspendLayout();
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
            // licensesHistoryControl1
            // 
            licensesHistoryControl1.Location = new Point(29, 421);
            licensesHistoryControl1.Name = "licensesHistoryControl1";
            licensesHistoryControl1.Size = new Size(765, 255);
            licensesHistoryControl1.TabIndex = 3;
            // 
            // showPersonWithFilter1
            // 
            showPersonWithFilter1.BackColor = Color.Transparent;
            showPersonWithFilter1.Location = new Point(12, 41);
            showPersonWithFilter1.Name = "showPersonWithFilter1";
            showPersonWithFilter1.Size = new Size(799, 377);
            showPersonWithFilter1.TabIndex = 4;
            // 
            // ShowAllLicensesHistoryFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(826, 688);
            Controls.Add(showPersonWithFilter1);
            Controls.Add(licensesHistoryControl1);
            Controls.Add(guna2HtmlLabel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ShowAllLicensesHistoryFrm";
            Text = "License History";
            Load += ShowAllLicensesHistoryFrm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private LicensesHistory.LicensesHistoryControl licensesHistoryControl1;
        private PersonControl.ShowPersonWithFilter showPersonWithFilter1;
    }
}