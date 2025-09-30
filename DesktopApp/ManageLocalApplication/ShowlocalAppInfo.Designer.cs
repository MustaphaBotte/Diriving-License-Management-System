namespace DesktopApp.ManageLocalApplication
{
    partial class ShowlocalAppInfo
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
            applicationInfoControl1 = new DesktopApp.VisionTest.ApplicationInfoControl();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // applicationInfoControl1
            // 
            applicationInfoControl1.Location = new Point(12, 36);
            applicationInfoControl1.Name = "applicationInfoControl1";
            applicationInfoControl1.Size = new Size(794, 376);
            applicationInfoControl1.TabIndex = 0;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.Red;
            guna2HtmlLabel1.Location = new Point(190, -3);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(406, 33);
            guna2HtmlLabel1.TabIndex = 1;
            guna2HtmlLabel1.Text = "Local Driving License App Details";
            // 
            // ShowlocalAppInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 415);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(applicationInfoControl1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ShowlocalAppInfo";
            Text = "Show local App Info";
            Load += ShowlocalAppInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VisionTest.ApplicationInfoControl applicationInfoControl1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}