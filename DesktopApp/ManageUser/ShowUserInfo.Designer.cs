namespace DesktopApp.ManageUser
{
    partial class ShowUserInfoFrm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowUserInfoFrm));
            CancelButton = new Guna.UI2.WinForms.Guna2Button();
            showUserInfoControl1 = new DesktopApp.User_Control.showUserInfoControl();
            SuspendLayout();
            // 
            // CancelButton
            // 
            CancelButton.BackColor = Color.Transparent;
            CancelButton.BorderRadius = 10;
            CancelButton.BorderThickness = 1;
            CancelButton.CustomizableEdges = customizableEdges1;
            CancelButton.DisabledState.BorderColor = Color.DarkGray;
            CancelButton.DisabledState.CustomBorderColor = Color.DarkGray;
            CancelButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            CancelButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            CancelButton.FillColor = Color.RosyBrown;
            CancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CancelButton.ForeColor = Color.Black;
            CancelButton.Location = new Point(675, 285);
            CancelButton.Name = "CancelButton";
            CancelButton.PressedColor = Color.DimGray;
            CancelButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            CancelButton.Size = new Size(144, 39);
            CancelButton.TabIndex = 39;
            CancelButton.Text = "Close";
            CancelButton.Click += CancelButton_Click;
            CancelButton.MouseEnter += CancelButton_MouseEnter;
            CancelButton.MouseLeave += CancelButton_MouseLeave;
            // 
            // showUserInfoControl1
            // 
            showUserInfoControl1.BackgroundImage = (Image)resources.GetObject("showUserInfoControl1.BackgroundImage");
            showUserInfoControl1.Location = new Point(0, 0);
            showUserInfoControl1.Name = "showUserInfoControl1";
            showUserInfoControl1.Size = new Size(819, 324);
            showUserInfoControl1.TabIndex = 40;
            // 
            // ShowUserInfoFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 329);
            Controls.Add(CancelButton);
            Controls.Add(showUserInfoControl1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ShowUserInfoFrm";
            Text = "ShowUserInfo";
            Load += ShowUserInfo_Load;
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button CancelButton;
        private User_Control.showUserInfoControl showUserInfoControl1;
    }
}