namespace DesktopApp.ManageUser
{
    partial class ChangeUserPassFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeUserPassFrm));
            CurrentPassTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            ConfirmPasswordTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            PasswordTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            SaveButton = new Guna.UI2.WinForms.Guna2Button();
            CancelButton = new Guna.UI2.WinForms.Guna2Button();
            errorProvider1 = new ErrorProvider(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            showUserInfoControl1 = new DesktopApp.User_Control.showUserInfoControl();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // CurrentPassTextBox
            // 
            CurrentPassTextBox.BackColor = Color.Transparent;
            CurrentPassTextBox.BorderColor = Color.Black;
            CurrentPassTextBox.BorderRadius = 15;
            CurrentPassTextBox.CustomizableEdges = customizableEdges1;
            CurrentPassTextBox.DefaultText = "";
            CurrentPassTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            CurrentPassTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            CurrentPassTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            CurrentPassTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            CurrentPassTextBox.FillColor = Color.Silver;
            CurrentPassTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            CurrentPassTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            CurrentPassTextBox.ForeColor = Color.Black;
            CurrentPassTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            CurrentPassTextBox.Location = new Point(183, 386);
            CurrentPassTextBox.Margin = new Padding(4);
            CurrentPassTextBox.Name = "CurrentPassTextBox";
            CurrentPassTextBox.PlaceholderText = "";
            CurrentPassTextBox.SelectedText = "";
            CurrentPassTextBox.ShadowDecoration.CustomizableEdges = customizableEdges2;
            CurrentPassTextBox.Size = new Size(158, 33);
            CurrentPassTextBox.TabIndex = 29;
            CurrentPassTextBox.Leave += CurrentPassTextBox_Leave;
            //CurrentPassTextBox.Validating += CurrentPassTextBox_Validating;
            // 
            // ConfirmPasswordTextBox
            // 
            ConfirmPasswordTextBox.BackColor = Color.Transparent;
            ConfirmPasswordTextBox.BorderColor = Color.Black;
            ConfirmPasswordTextBox.BorderRadius = 15;
            ConfirmPasswordTextBox.CustomizableEdges = customizableEdges3;
            ConfirmPasswordTextBox.DefaultText = "";
            ConfirmPasswordTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            ConfirmPasswordTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            ConfirmPasswordTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            ConfirmPasswordTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            ConfirmPasswordTextBox.FillColor = Color.Silver;
            ConfirmPasswordTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            ConfirmPasswordTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            ConfirmPasswordTextBox.ForeColor = Color.Black;
            ConfirmPasswordTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            ConfirmPasswordTextBox.Location = new Point(183, 437);
            ConfirmPasswordTextBox.Margin = new Padding(4);
            ConfirmPasswordTextBox.Name = "ConfirmPasswordTextBox";
            ConfirmPasswordTextBox.PasswordChar = '*';
            ConfirmPasswordTextBox.PlaceholderText = "";
            ConfirmPasswordTextBox.SelectedText = "";
            ConfirmPasswordTextBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            ConfirmPasswordTextBox.Size = new Size(158, 33);
            ConfirmPasswordTextBox.TabIndex = 31;
            ConfirmPasswordTextBox.Leave += ConfirmPasswordTextBox_Leave;
           // ConfirmPasswordTextBox.Validating += ConfirmPasswordTextBox_Validating;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.BackColor = Color.Transparent;
            PasswordTextBox.BorderColor = Color.Black;
            PasswordTextBox.BorderRadius = 15;
            PasswordTextBox.CustomizableEdges = customizableEdges5;
            PasswordTextBox.DefaultText = "";
            PasswordTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            PasswordTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            PasswordTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            PasswordTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            PasswordTextBox.FillColor = Color.Silver;
            PasswordTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            PasswordTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            PasswordTextBox.ForeColor = Color.Black;
            PasswordTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            PasswordTextBox.Location = new Point(499, 386);
            PasswordTextBox.Margin = new Padding(4);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.PlaceholderText = "";
            PasswordTextBox.SelectedText = "";
            PasswordTextBox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            PasswordTextBox.Size = new Size(158, 33);
            PasswordTextBox.TabIndex = 36;
            PasswordTextBox.Leave += PasswordTextBox_Leave;
           // PasswordTextBox.Validating += PasswordTextBox_Validating;
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.Snow;
            SaveButton.BorderRadius = 10;
            SaveButton.BorderThickness = 1;
            SaveButton.CustomizableEdges = customizableEdges7;
            SaveButton.DisabledState.BorderColor = Color.DarkGray;
            SaveButton.DisabledState.CustomBorderColor = Color.DarkGray;
            SaveButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            SaveButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            SaveButton.FillColor = Color.Green;
            SaveButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SaveButton.ForeColor = Color.White;
            SaveButton.Location = new Point(635, 470);
            SaveButton.Name = "SaveButton";
            SaveButton.ShadowDecoration.CustomizableEdges = customizableEdges8;
            SaveButton.Size = new Size(144, 39);
            SaveButton.TabIndex = 39;
            SaveButton.Text = "Save";
            SaveButton.Click += SaveButton_Click;
            SaveButton.MouseEnter += CancelButton_MouseEnter;
            SaveButton.MouseLeave += CancelButton_MouseLeave;
            // 
            // CancelButton
            // 
            CancelButton.BackColor = Color.Transparent;
            CancelButton.BorderRadius = 10;
            CancelButton.BorderThickness = 1;
            CancelButton.CustomizableEdges = customizableEdges9;
            CancelButton.DisabledState.BorderColor = Color.DarkGray;
            CancelButton.DisabledState.CustomBorderColor = Color.DarkGray;
            CancelButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            CancelButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            CancelButton.FillColor = Color.Gray;
            CancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CancelButton.ForeColor = Color.White;
            CancelButton.Location = new Point(475, 470);
            CancelButton.Name = "CancelButton";
            CancelButton.ShadowDecoration.CustomizableEdges = customizableEdges10;
            CancelButton.Size = new Size(144, 39);
            CancelButton.TabIndex = 38;
            CancelButton.Text = "Cancel";
            CancelButton.Click += CancelButton_Click;
            CancelButton.MouseEnter += CancelButton_MouseEnter;
            CancelButton.MouseLeave += CancelButton_MouseLeave;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 27.75F);
            label1.Location = new Point(265, 3);
            label1.Name = "label1";
            label1.Size = new Size(309, 43);
            label1.TabIndex = 41;
            label1.Text = "Change Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            label2.Location = new Point(12, 444);
            label2.Name = "label2";
            label2.Size = new Size(144, 18);
            label2.TabIndex = 42;
            label2.Text = "Confirm Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            label3.Location = new Point(373, 392);
            label3.Name = "label3";
            label3.Size = new Size(119, 18);
            label3.TabIndex = 43;
            label3.Text = "New Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            label4.Location = new Point(12, 392);
            label4.Name = "label4";
            label4.Size = new Size(142, 18);
            label4.TabIndex = 44;
            label4.Text = "Current Password";
            // 
            // showUserInfoControl1
            // 
            showUserInfoControl1.BackgroundImage = (Image)resources.GetObject("showUserInfoControl1.BackgroundImage");
            showUserInfoControl1.Location = new Point(3, 49);
            showUserInfoControl1.Name = "showUserInfoControl1";
            showUserInfoControl1.Size = new Size(776, 293);
            showUserInfoControl1.TabIndex = 45;
            // 
            // ChangeUserPassFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(786, 521);
            Controls.Add(showUserInfoControl1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SaveButton);
            Controls.Add(CancelButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(CurrentPassTextBox);
            Controls.Add(ConfirmPasswordTextBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ChangeUserPassFrm";
            Text = "Change User Password";
            Load += ShowUser_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox CurrentPassTextBox;
        private Guna.UI2.WinForms.Guna2TextBox ConfirmPasswordTextBox;
        private Guna.UI2.WinForms.Guna2TextBox PasswordTextBox;
        private Guna.UI2.WinForms.Guna2Button SaveButton;
        private Guna.UI2.WinForms.Guna2Button CancelButton;
        private ErrorProvider errorProvider1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private User_Control.showUserInfoControl showUserInfoControl1;
    }
}