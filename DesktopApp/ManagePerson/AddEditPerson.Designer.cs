namespace DesktopApp.ManagePerson
{
    partial class AddEditPersonFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditPersonFrm));
            LabelUpdateModeOption = new Guna.UI2.WinForms.Guna2HtmlLabel();
            PersonIDValue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            PersonIdlbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            personUserControl1 = new DesktopApp.PersonControl.PersonUserControl();
            LabelAddNewPersonOption = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // LabelUpdateModeOption
            // 
            LabelUpdateModeOption.BackColor = Color.Transparent;
            LabelUpdateModeOption.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelUpdateModeOption.ForeColor = Color.Black;
            LabelUpdateModeOption.Location = new Point(243, 2);
            LabelUpdateModeOption.Name = "LabelUpdateModeOption";
            LabelUpdateModeOption.Size = new Size(352, 38);
            LabelUpdateModeOption.TabIndex = 1;
            LabelUpdateModeOption.Text = "Edit Person Informations";
            LabelUpdateModeOption.Visible = false;
            // 
            // PersonIDValue
            // 
            PersonIDValue.BackColor = Color.Transparent;
            PersonIDValue.Font = new Font("Cambria", 20.25F, FontStyle.Bold);
            PersonIDValue.Location = new Point(150, 33);
            PersonIDValue.Name = "PersonIDValue";
            PersonIDValue.Size = new Size(25, 34);
            PersonIDValue.TabIndex = 33;
            PersonIDValue.Text = "\"\"";
            // 
            // PersonIdlbl
            // 
            PersonIdlbl.BackColor = Color.Transparent;
            PersonIdlbl.Font = new Font("Cambria", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PersonIdlbl.Location = new Point(12, 33);
            PersonIdlbl.Name = "PersonIdlbl";
            PersonIdlbl.Size = new Size(137, 34);
            PersonIdlbl.TabIndex = 32;
            PersonIdlbl.Text = "Person ID : ";
            // 
            // personUserControl1
            // 
            personUserControl1.BackColor = Color.Gray;
            personUserControl1.Location = new Point(13, 73);
            personUserControl1.Name = "personUserControl1";
            personUserControl1.Size = new Size(810, 348);
            personUserControl1.TabIndex = 34;
            personUserControl1.Load += personUserControl1_Load;
            // 
            // LabelAddNewPersonOption
            // 
            LabelAddNewPersonOption.BackColor = Color.Transparent;
            LabelAddNewPersonOption.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelAddNewPersonOption.ForeColor = Color.Black;
            LabelAddNewPersonOption.Location = new Point(305, 2);
            LabelAddNewPersonOption.Name = "LabelAddNewPersonOption";
            LabelAddNewPersonOption.Size = new Size(232, 38);
            LabelAddNewPersonOption.TabIndex = 35;
            LabelAddNewPersonOption.Text = "Add New Person";
            LabelAddNewPersonOption.Visible = false;
            // 
            // AddEditPersonFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(838, 477);
            Controls.Add(LabelAddNewPersonOption);
            Controls.Add(personUserControl1);
            Controls.Add(PersonIDValue);
            Controls.Add(PersonIdlbl);
            Controls.Add(LabelUpdateModeOption);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "AddEditPersonFrm";
            Text = "EditPerson";
            Load += EditPersonFrm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel LabelUpdateModeOption;
        private Guna.UI2.WinForms.Guna2HtmlLabel PersonIDValue;
        private Guna.UI2.WinForms.Guna2HtmlLabel PersonIdlbl;
        private PersonControl.PersonUserControl personUserControl1;
        private Guna.UI2.WinForms.Guna2HtmlLabel LabelAddNewPersonOption;
    }
}