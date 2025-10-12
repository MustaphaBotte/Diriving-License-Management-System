namespace DesktopApp.Test
{
    partial class ScheduleTestFrm
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
            scheduleTestControl2 = new ScheduleTestControl();
            SaveButton = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // scheduleTestControl2
            // 
            scheduleTestControl2.EnTestType = DLMS.EntitiesNamespace.Entities.ClsTestType.EnTestType.VisionTest;
            scheduleTestControl2.Location = new Point(9, 11);
            scheduleTestControl2.Name = "scheduleTestControl2";
            scheduleTestControl2.Size = new Size(604, 638);
            scheduleTestControl2.TabIndex = 0;
            // 
            // SaveButton
            // 
            SaveButton.BorderRadius = 15;
            SaveButton.BorderThickness = 1;
            SaveButton.CustomizableEdges = customizableEdges1;
            SaveButton.DisabledState.BorderColor = Color.DarkGray;
            SaveButton.DisabledState.CustomBorderColor = Color.DarkGray;
            SaveButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            SaveButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            SaveButton.FillColor = Color.Transparent;
            SaveButton.Font = new Font("Cambria", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SaveButton.ForeColor = Color.FromArgb(192, 0, 0);
            SaveButton.Location = new Point(328, 585);
            SaveButton.Name = "SaveButton";
            SaveButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            SaveButton.Size = new Size(121, 45);
            SaveButton.TabIndex = 49;
            SaveButton.Text = "Close";
            SaveButton.Click += SaveButton_Click;
            // 
            // ScheduleTestFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(625, 661);
            Controls.Add(SaveButton);
            Controls.Add(scheduleTestControl2);
            Name = "ScheduleTestFrm";
            Text = "Schedule Test";
            ResumeLayout(false);
        }

        #endregion

        public ScheduleTestControl scheduleTestControl2;
        private Guna.UI2.WinForms.Guna2Button SaveButton;
    }
}