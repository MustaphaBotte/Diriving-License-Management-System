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
using static DLMS.EntitiesNamespace.Entities;

namespace DesktopApp.RenewLicense
{
    public partial class RenewLicenseFrm : Form
    {
        DLMS.EntitiesNamespace.Entities.ClsLicense? License = null;
        int NewLicenseID = -1;
        public RenewLicenseFrm()
        {
            InitializeComponent();
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
            if (!License.IsActive)
            {
                MessageBox.Show($"We cant renew your license because its inactive", "License InActive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IssueButton.Enabled = false;
                return;
            }
            if (License.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show($"This license has not expired yet.\n The Expiration date is {License.ExpirationDate.ToString("yyyy-MM-dd")}", "Operation Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IssueButton.Enabled = false;
                return;
            }

            FillAppInfo();
            this.IssueButton.Enabled = true;
        }

        private void FillAppInfo()
        {
            this.IssueDateLabel.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.AppDateLbl.Text = DateTime.Now.ToString("yyyy-MM-dd");
            decimal AppFees = DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(2); //2 means Renew
            this.ApplicationFees.Text = AppFees.ToString();
            decimal licenseClassFees = DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetlisenceFees(License.LicenseClassID);
            this.licenseFeesLbl.Text = licenseClassFees.ToString();
            this.OldLicenseIdLbl.Text = License.LicenseID.ToString();
            this.ExpDateLbl.Text = DateTime.Now.AddYears(DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetlisenceValidityLength(License.LicenseClassID)).ToString("yyyy-MM-dd");
            this.CreatedByLbl.Text = DLMS.BusinessLier.ClslogedInUser.logedInUser.UserName;
            this.totalfeesLbl.Text = (AppFees + licenseClassFees).ToString();
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
            DialogResult Res = MessageBox.Show("Are you sure you want to renew?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            DLMS.EntitiesNamespace.Entities.ClsApplication NewApp = new DLMS.EntitiesNamespace.Entities.ClsApplication();
            NewApp.ApplicationStatus = 1;
            NewApp.ApplicantPersonId = oldApp.ApplicantPersonId;
            NewApp.ApplicantionDate = DateTime.Now;
            NewApp.ApplicationTypeId = 2;//renew
            NewApp.LastStatusDate = DateTime.Now;
            NewApp.PaidFees = DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(2);
            NewApp.CreatedByUserId = DLMS.BusinessLier.ClslogedInUser.logedInUser.UserId;

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
            Newlicense.ExpirationDate = DateTime.Now.AddYears(DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetlisenceValidityLength(OldLicense.LicenseClassID));
            Newlicense.IssueDate = DateTime.Now;
            Newlicense.PaidFees = DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetlisenceFees(OldLicense.LicenseClassID);
            Newlicense.IssueReason = 2;// renew
            Newlicense.Notes = this.Notes.Text;
            Newlicense.LicenseClassID = OldLicense.LicenseClassID;
            int NewLicenseID = DLMS.BusinessLier.RenewLicense.RenewLicenseLogic.RenewLicense(Newlicense, OldLicense, ref ER);
            if (NewLicenseID > 0)
            {
                MessageBox.Show($"Operation success your new license application ID is {NewLicenseID}", "Operation Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.License = Newlicense;
                this.NewLicenseID = NewLicenseID;
                IssueButton.Enabled = false;
                this.R_L_ApplicationIDLbl.Text = Newlicense.ApplicationID.ToString();
                this.RenewedLicenseIdLabel.Text = NewLicenseID.ToString();
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
                MessageBox.Show($"We cant renew your license because its inactive", "License InActive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NewLicenseID == -3)
            {
                MessageBox.Show($"We cant renew your license because its not expired. \n Expiration Date: {OldLicense.ExpirationDate}", "Not Expired Yet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NewLicenseID == 0)
            {
                MessageBox.Show($"We cant save the application in the moment refresh and try again", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
            if(!Frm.IsDisposed)
                   Frm.ShowDialog();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RenewLicenseFrm_Load(object sender, EventArgs e)
        {
            this.FilterChoices.SelectedIndex = 0;
        }
    }
}
