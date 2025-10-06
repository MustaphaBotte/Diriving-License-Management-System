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

namespace DesktopApp.ReplaceDamagedOrLostLicense
{
    public partial class ReplaceLostORDamagedLicFrm : Form
    {
        DLMS.EntitiesNamespace.Entities.ClsLicense? License = null;
        int NewLicenseID = -1;
        decimal DamagedFees = 0;
        decimal LostFees = 0;
        public ReplaceLostORDamagedLicFrm()
        {
            InitializeComponent();
            this.LostFees = DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(3);
            this.DamagedFees = DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(4);

        }
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

            if (License.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show($"This license was expired .\n The Expiration date is {License.ExpirationDate.ToString("yyyy-MM-dd")}\n" +
                    $"please renew it", "Operation Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IssueButton.Enabled = false;
                return;
            }
            if (!License.IsActive)
            {
                MessageBox.Show($"TWe cant replace your license because its inactive", "License InActive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IssueButton.Enabled = false;
                return;
            }
            ShowLicenseInfo.Enabled = true;
            FillAppInfo();
            this.IssueButton.Enabled = true;
        }
        private void FillAppInfo()
        {
            int AppTypeID = AppType.SelectedIndex == 0 ? 3 : 4;
            this.AppDateLbl.Text = DateTime.Now.ToString("yyyy-MM-dd");
            decimal AppFees = DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(AppTypeID); //3 or 4
            this.ApplicationFees.Text = AppFees.ToString();
            this.OldLicenseIdLbl.Text = License.LicenseID.ToString();
            this.CreatedByLbl.Text = DesktopApp.LogedInUser.ClslogedInUser.logedInUser.UserName;
            this.totalfeesLbl.Text = (AppFees).ToString();
            this.ShowLicensesHistory.Enabled = true;
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
        private void CancelButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void CancelButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

        }

        private void ReplaceLostORDamagedLicFrm_Load(object sender, EventArgs e)
        {
            AppType.SelectedIndex = 0;
            this.FilterChoices.SelectedIndex = 0;
        }

        private void IssueButton_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Are you sure you want to replace?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.No)
            {
                return;
            }

            DLMS.EntitiesNamespace.Entities.ClsApplication? oldApp = DLMS.BusinessLier.Application.ApplicationLogic.GetApplicationByID(License.ApplicationID);
            if (oldApp == null)
            {
                MessageBox.Show($"Something wrong please refresh and try again", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int AppTypeID = (AppType.SelectedIndex == 0 ? 3 : 4);
            DLMS.EntitiesNamespace.Entities.ClsApplication NewApp = new DLMS.EntitiesNamespace.Entities.ClsApplication();
            NewApp.ApplicationStatus = 1;
            NewApp.ApplicantPersonId = oldApp.ApplicantPersonId;
            NewApp.ApplicantionDate = DateTime.Now;
            NewApp.ApplicationTypeId = (short)AppTypeID;
            NewApp.LastStatusDate = DateTime.Now;
            NewApp.PaidFees = AppTypeID == 3 ? LostFees : DamagedFees;
            NewApp.CreatedByUserId = DesktopApp.LogedInUser.ClslogedInUser.logedInUser.UserId;

            string ER = "";
            int NewAppId = DLMS.BusinessLier.Application.ApplicationLogic.AddNewApplication(NewApp, ref ER);
            if (NewAppId <= 0)
            {
                MessageBox.Show($"We cant save the application in the moment refresh and try again", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DLMS.EntitiesNamespace.Entities.ClsLicense? OldLicense = DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(licenseID: License.LicenseID);
            if (OldLicense == null)
            {
                MessageBox.Show($"We cant save the application because the old license was not found \n refresh and try again", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DLMS.EntitiesNamespace.Entities.ClsLicense Newlicense = new DLMS.EntitiesNamespace.Entities.ClsLicense();
            Newlicense.ApplicationID = NewAppId;
            Newlicense.DriverID = OldLicense.DriverID;
            Newlicense.IsActive = true;
            Newlicense.CreatedByUserID = OldLicense.CreatedByUserID;
            Newlicense.ExpirationDate = OldLicense.ExpirationDate;
            Newlicense.IssueDate = OldLicense.IssueDate;
            Newlicense.PaidFees = OldLicense.PaidFees;
            Newlicense.IssueReason = AppTypeID == 3 ? 4 : 3;
            Newlicense.Notes = this.Notes.Text;
            Newlicense.LicenseClassID = OldLicense.LicenseClassID;
            int NewLicenseID = DLMS.BusinessLier.ReplaceLostOrDamagedLic.ReplaceLostOrDamagedLicLogic.ReplaceLicense(Newlicense, OldLicense, ref ER);
            if (NewLicenseID > 0)
            {
                MessageBox.Show($"Operation success your new license application ID is {NewLicenseID}", "Operation Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.License = Newlicense;
                this.NewLicenseID = NewLicenseID;
                IssueButton.Enabled = false;
                this.REP_L_ApplicationIDLbl.Text = Newlicense.ApplicationID.ToString();
                this.ReplacedLicenseIdLabel.Text = NewLicenseID.ToString();
                this.ShowLicenseInfo.Enabled = true;
                return;
            }
            if (NewLicenseID == -1)
            {
                MessageBox.Show($"We cant save the application because Driver OR LicenseClassId or Application no longer exists \n refresh and try again", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NewLicenseID == -2)
            {
                MessageBox.Show($"We cant replace your license because its inactive", "License InActive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NewLicenseID == -3)
            {
                MessageBox.Show($"We cant replace your license because its  expired. \n Expiration Date: {OldLicense.ExpirationDate} \n" +
                    $"Please Renew It then you can replace it", "License Expired ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NewLicenseID == 0)
            {
                MessageBox.Show($"We cant save the application in the moment refresh and try again", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void FindButton_Click_1(object sender, EventArgs e)
        {
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
            if (!License.IsActive)
            {
                MessageBox.Show($"We cant replace your license because its inactive", "License InActive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IssueButton.Enabled = false;
                return;
            }
            if (License.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show($"This license was expired yet.\n The Expiration date is {License.ExpirationDate.ToString("yyyy-MM-dd")}\n"
                    , "Operation Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FillAppInfo();
            this.IssueButton.Enabled = true;
        }

        private void AppType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ = AppType.SelectedIndex == 0 ? this.ApplicationFees.Text = LostFees.ToString() : this.ApplicationFees.Text = DamagedFees.ToString();
        }

        private void ShowLicensesHistory_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = DLMS.BusinessLier.Driver.DriverLogic.GetDriverById(License.DriverID)?.PersonID ?? 0;
            ShowAllLicensesHistoryFrm Frm = new ShowAllLicensesHistoryFrm(PersonID);
            Frm.ShowDialog();
        }

        private void ShowLicenseInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseFrm Frm = new ShowLicenseFrm(LicenseID: License.LicenseID);
            if (!Frm.IsDisposed)
                Frm.ShowDialog();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FilterValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
