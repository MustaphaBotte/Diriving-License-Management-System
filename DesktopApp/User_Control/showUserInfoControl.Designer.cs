namespace DesktopApp.User_Control
{
    partial class showUserInfoControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(showUserInfoControl));
            PersonControl = new DesktopApp.PersonControl.ShowInfoInControl();
            ActiveStatusLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            UsernameLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            UseridLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            Guna2GenderLbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // PersonControl
            // 
            PersonControl.BackColor = Color.Transparent;
            PersonControl.BackgroundImage = (Image)resources.GetObject("PersonControl.BackgroundImage");
            PersonControl.Location = new Point(0, -1);
            PersonControl.Name = "PersonControl";
            PersonControl.Size = new Size(773, 296);
            PersonControl.TabIndex = 41;
            // 
            // ActiveStatusLabel
            // 
            ActiveStatusLabel.BackColor = Color.Transparent;
            ActiveStatusLabel.Font = new Font("Microsoft Sans Serif", 9.75F);
            ActiveStatusLabel.ForeColor = SystemColors.ControlText;
            ActiveStatusLabel.Location = new Point(615, 268);
            ActiveStatusLabel.Name = "ActiveStatusLabel";
            ActiveStatusLabel.Size = new Size(24, 18);
            ActiveStatusLabel.TabIndex = 47;
            ActiveStatusLabel.Text = "???";
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Cambria", 12F, FontStyle.Bold);
            guna2HtmlLabel4.ForeColor = Color.DodgerBlue;
            guna2HtmlLabel4.Location = new Point(502, 265);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(65, 21);
            guna2HtmlLabel4.TabIndex = 46;
            guna2HtmlLabel4.Text = "Is Active";
            // 
            // UsernameLabel
            // 
            UsernameLabel.BackColor = Color.Transparent;
            UsernameLabel.Font = new Font("Microsoft Sans Serif", 9.75F);
            UsernameLabel.ForeColor = SystemColors.ControlText;
            UsernameLabel.Location = new Point(420, 268);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(24, 18);
            UsernameLabel.TabIndex = 45;
            UsernameLabel.Text = "???";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Cambria", 12F, FontStyle.Bold);
            guna2HtmlLabel2.ForeColor = Color.DodgerBlue;
            guna2HtmlLabel2.Location = new Point(282, 265);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(77, 21);
            guna2HtmlLabel2.TabIndex = 44;
            guna2HtmlLabel2.Text = "Username";
            // 
            // UseridLabel
            // 
            UseridLabel.BackColor = Color.Transparent;
            UseridLabel.Font = new Font("Microsoft Sans Serif", 9.75F);
            UseridLabel.ForeColor = SystemColors.ControlText;
            UseridLabel.Location = new Point(130, 268);
            UseridLabel.Name = "UseridLabel";
            UseridLabel.Size = new Size(24, 18);
            UseridLabel.TabIndex = 43;
            UseridLabel.Text = "???";
            // 
            // Guna2GenderLbl
            // 
            Guna2GenderLbl.BackColor = Color.Transparent;
            Guna2GenderLbl.Font = new Font("Cambria", 12F, FontStyle.Bold);
            Guna2GenderLbl.ForeColor = Color.DodgerBlue;
            Guna2GenderLbl.Location = new Point(16, 265);
            Guna2GenderLbl.Name = "Guna2GenderLbl";
            Guna2GenderLbl.Size = new Size(56, 21);
            Guna2GenderLbl.TabIndex = 42;
            Guna2GenderLbl.Text = "User Id";
            // 
            // showUserInfoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.ZA_1903;
            Controls.Add(ActiveStatusLabel);
            Controls.Add(guna2HtmlLabel4);
            Controls.Add(UsernameLabel);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(UseridLabel);
            Controls.Add(Guna2GenderLbl);
            Controls.Add(PersonControl);
            Name = "showUserInfoControl";
            Size = new Size(776, 293);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PersonControl.ShowInfoInControl PersonControl;
        private Guna.UI2.WinForms.Guna2HtmlLabel ActiveStatusLabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel UsernameLabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel UseridLabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel Guna2GenderLbl;
    }
}
