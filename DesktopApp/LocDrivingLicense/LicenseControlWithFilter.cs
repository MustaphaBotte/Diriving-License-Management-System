using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLMS.EntitiesNamespace;
using Guna.UI2.WinForms;

namespace DesktopApp.LocDrivingLicense
{
    public partial class LicenseControlWithFilter : UserControl
    {
        public LicenseControlWithFilter()
        {
            InitializeComponent();
            this.FilterChoices.SelectedIndex = 0;
        }


        public int LicenseID
        {
            get
            {
                return this.licenseControl1.LicenseID;
            }
        }
        public Entities.ClsLicense? License
        {
            get
            {
                return this.licenseControl1.License;
            }
        }

        public delegate void Del_OnLicenseSelected(int LicenseID);
        public event Del_OnLicenseSelected OnLicenseSelected = delegate { };



        private void FindButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void FindButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            if (this.FilterValueTextBox.Text == "")
            {
                MessageBox.Show("License Id cannot be empty", "Invalid License Id ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int ID = Convert.ToInt32(this.FilterValueTextBox.Text);
            if (this.FilterChoices.SelectedIndex == 0)
            {
                if (this.licenseControl1.LoadByLicenseID(ID))
                {
                    this.OnLicenseSelected?.Invoke(licenseControl1.LicenseID);
                }
            }
            else
            {
                if (this.licenseControl1.LoadByLocDriID(ID))
                {
                    this.OnLicenseSelected?.Invoke(licenseControl1.LicenseID);
                }
            }
        }

        public void FindByID(int LicenseID,bool DisableSearch=true,bool RaiseEvent= true)
        {
            if(DisableSearch)
                 FilterGroupBox.Enabled = false;
            if (RaiseEvent)
            {
                this.FilterValueTextBox.Text = LicenseID.ToString();
                this.FindButton.PerformClick();
            }
            else
                this.licenseControl1.LoadByLicenseID(LicenseID);
        }
        private void FilterValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;

            if (e.KeyChar == (char)Keys.Enter)
                FindButton.PerformClick();
        }

        private void FilterValueTextBox_TextChanged(object sender, EventArgs e)
        {
            if(! int.TryParse(((Guna2TextBox)sender).Text,out int res))
            {
                FilterValueTextBox.Text = "";
            }
                 
        }

        public void LicenseTextFocus()
        {
            this.FilterValueTextBox.Focus();
        }
    }
}
