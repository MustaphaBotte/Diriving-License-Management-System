using DesktopApp.AllLicensesHistory;
using DesktopApp.LocDrivingLicense;
using DLMS.EntitiesNamespace;
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
        int CurrentLicensID = -1;
        decimal DamagedFees = 0;
        decimal LostFees = 0;
        public ReplaceLostORDamagedLicFrm()
        {
            InitializeComponent();
            this.LostFees = DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(Entities.ClsApplication.enApplicationType.ReplaceLostDrivingLicense);
            this.DamagedFees = DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(Entities.ClsApplication.enApplicationType.ReplaceDamagedDrivingLicense);

        }
        private void ReplaceLostORDamagedLicFrm_Load(object sender, EventArgs e)
        {
            this.AppType.SelectedIndex = 0;
            this.licenseControlWithFilter1.OnLicenseSelected += (int LicenseID) =>
            {
                this.License = licenseControlWithFilter1.License;
                this.CurrentLicensID = LicenseID;
                CheckLicenseStatus();
                this.ShowLicenseInfo.Enabled = false;

            };
        }

        private void CheckLicenseStatus()
        {
            this.ShowLicenseInfo.Enabled = true;
            this.ShowLicensesHistory.Enabled = true; FillAppInfo();

            if (License?.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show($"This license was expired .\n The Expiration date is {License.ExpirationDate.ToString("yyyy-MM-dd")}\n" +
                    $"please renew it", "Operation Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IssueButton.Enabled = false;
                return;
            }
            if (!License.IsActive)
            {
                MessageBox.Show($"We cant replace your license because its inactive", "License InActive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IssueButton.Enabled = false;
                return;
            }
            
            this.IssueButton.Enabled = true;
        }

        private void FillAppInfo()
        {
            int AppTypeID = AppType.SelectedIndex == 0 ? 3 : 4;
            this.AppDateLbl.Text = DateTime.Now.ToString("yyyy-MM-dd");
            decimal AppFees =
             DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees((Entities.ClsApplication.enApplicationType)AppTypeID); //3 or 4
            this.ApplicationFees.Text = AppFees.ToString();
            this.OldLicenseIdLbl.Text = License.LicenseID.ToString();
            this.CreatedByLbl.Text = DesktopApp.LogedInUser.ClslogedInUser.logedInUser.UserName;
            this.ReplacedLicenseIdLabel.Text = "N/A";
            this.REP_L_ApplicationIDLbl.Text = "N/A";
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
            DialogResult Res = MessageBox.Show("Are you sure you want to replace?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.No)
            {
                return;
            }
            int AppTypeID = AppType.SelectedIndex == 0 ? 3 : 4;

            int NewLicenseID = DLMS.BusinessLier.ReplaceLostOrDamagedLic.ReplaceLostOrDamagedLicLogic.ReplaceLicense(this.CurrentLicensID,
                (Entities.ClsApplication.enApplicationType)AppTypeID,LogedInUser.ClslogedInUser.logedInUser.UserId,Notes.Text.Trim(),out int AppID);
            if (NewLicenseID > 0)
            {
                MessageBox.Show($"Operation success your new license application ID is {NewLicenseID}", "Operation Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CurrentLicensID = NewLicenseID;
                this.License = DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(licenseID: CurrentLicensID);
                this.CurrentLicensID = NewLicenseID;
                IssueButton.Enabled = false;
                this.REP_L_ApplicationIDLbl.Text = AppID.ToString();
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
                MessageBox.Show($" We cant replace your license because its inactive", "License Inctive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NewLicenseID == -3)
            {
                MessageBox.Show($"We cant replace your license because its  expired. \n Expiration Date: {License.ExpirationDate} \n" +
                    $"Please Renew It then you can replace it", "License Expired ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NewLicenseID == 0)
            {
                MessageBox.Show($"We cant save the application in the moment refresh and try again", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
            ShowLicenseFrm Frm = new ShowLicenseFrm(LicenseID: CurrentLicensID);
            if (!Frm.IsDisposed)
                Frm.ShowDialog();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
