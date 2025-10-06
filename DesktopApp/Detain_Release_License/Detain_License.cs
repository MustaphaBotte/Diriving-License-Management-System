using DesktopApp.AllLicensesHistory;
using DesktopApp.LocDrivingLicense;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Detain_Release_License
{
    public partial class DetainLicenseFrm : Form
    {
        public delegate void LicenseDetained(int LicID, Form Sender);
        public event LicenseDetained OnLicenseDetained = delegate { };
        public DetainLicenseFrm(int LicenseID = -1)
        {
            InitializeComponent();
            if (LicenseID != -1)
            {
                this.FilterValueTextBox.Text = LicenseID.ToString();
                this.FindButton.PerformClick();
                this.FindButton.Enabled = false;
            }
        }
        DLMS.EntitiesNamespace.Entities.ClsLicense? License = null;
        private void FindButton_Click(object sender, EventArgs e)
        {
            this.ShowLicenseInfo.Enabled = false;
            int ID = int.TryParse(FilterValueTextBox.Text.ToString(), out int Res) ? Res : -1;
            if (FilterChoices.SelectedItem?.ToString() == "LicenseID")
            {
                if (!this.licenseControl1.FillTheControlByLoc_DLA_IDOr_LicenseID(LicenseID: ID))
                {
                    MessageBox.Show($"License with ID = {ID} not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.License = DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(licenseID: ID);
            }
            else
            {
                if (!this.licenseControl1.FillTheControlByLoc_DLA_IDOr_LicenseID(Loc_DLA_ID: ID))
                {
                    MessageBox.Show($"Local Driving License with ID = {ID} not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.License = DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(Loc_DLA_ID: ID);
            }
            if (License == null)
            {
                MessageBox.Show($"Internal Error : license not found", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            this.ShowLicensesHistory.Enabled = true;
            if (DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.ISDetained(License.LicenseID))
            {
                MessageBox.Show($"License Already in detain", "System rules violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.IssueButton.Enabled = false;
                return;
            }

            FillAppInfo();
            this.IssueButton.Enabled = true;
        }
        private void FillAppInfo()
        {
            this.DetainDateLbl.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.LicenseIDLbl.Text = License.LicenseID.ToString();
            this.CreatedByLbl.Text = DesktopApp.LogedInUser.ClslogedInUser.logedInUser.UserName;
            this.ShowLicensesHistory.Enabled = true;
        }

        private void CancelButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void CancelButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void IssueButton_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Are you sure you want to detain this license", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.No)
            {
                return;
            }
            DLMS.EntitiesNamespace.Entities.ClsDetainedLicense DLicense = new DLMS.EntitiesNamespace.Entities.ClsDetainedLicense();
            decimal FineFees = decimal.TryParse(this.FineFeesTextBox1.Text, out decimal Fees) ? Fees : 0;
            if (FineFees == 0)
            {
                MessageBox.Show($"Please enter a valid fine fees", "Wrong Fees", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DLicense.DetainDate = DateTime.Now;
            DLicense.ReleaseDate = null;
            DLicense.CreatedByUserID = DesktopApp.LogedInUser.ClslogedInUser.logedInUser.UserId;
            DLicense.IsReleased = false;
            DLicense.LicenseID = this.License.LicenseID;
            DLicense.Fees = FineFees;
            DLicense.ReleaseApplicationID = null;
            DLicense.ReleaseByUserID = null;
            DLicense.ReleaseApplicationID = null;
            int DetainID = DLMS.BusinessLier.Release_Detain_License.Release_Detain_LicenseLogic.DetainLicense(DLicense);
            if (DetainID > 0)
            {
                MessageBox.Show($"license Detain SuccessFyllt\n Detain ID ={DetainID}", "Operation Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ShowLicenseInfo.Enabled = true;
                this.DetainIDLbl.Text = (DetainID).ToString();
                this.IssueButton.Enabled = false;
                OnLicenseDetained?.Invoke(DetainID, this);
                return;
            }
            if (DetainID == -2)
            {
                MessageBox.Show($"This License already in detain", "System Rules Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DetainID == -1)
            {
                MessageBox.Show($"We cannot detain this license in the moment please refresh and try again", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void DetainLicenseFrm_Load(object sender, EventArgs e)
        {
            this.FilterChoices.SelectedIndex = 0;
        }

        private void ShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = DLMS.BusinessLier.Driver.DriverLogic.GetDriverById(License.DriverID)?.PersonID ?? 0;
            ShowAllLicensesHistoryFrm Frm = new ShowAllLicensesHistoryFrm(PersonID);
            Frm.ShowDialog();
        }

        private void ShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseFrm Frm = new ShowLicenseFrm(LicenseID: License.LicenseID);
            Frm.ShowDialog();
        }

        private void FilterValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
