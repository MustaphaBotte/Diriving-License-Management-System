using DesktopApp.AllLicensesHistory;
using DesktopApp.LocDrivingLicense;
using DLMS.EntitiesNamespace;
using static DLMS.EntitiesNamespace.Entities;

namespace DesktopApp.RenewLicense
{
    public partial class RenewLicenseFrm : Form
    {
        DLMS.EntitiesNamespace.Entities.ClsLicense? License = null;
        int CurrentLicenseID = -1;
        public RenewLicenseFrm()
        {
            InitializeComponent();
        }

        private void FillAppInfo()
        {
            this.IssueDateLabel.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.AppDateLbl.Text = DateTime.Now.ToString("yyyy-MM-dd");
            decimal AppFees = 
                DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(Entities.ClsApplication.enApplicationType.RenewDrivingLicense); //2 means Renew
            this.ApplicationFees.Text = AppFees.ToString();
            decimal licenseClassFees = this.licenseControlWithFilter1.License.LicenseClassInfo.ClassFees;
            this.licenseFeesLbl.Text = licenseClassFees.ToString();
            this.OldLicenseIdLbl.Text = License.LicenseID.ToString();
            this.ExpDateLbl.Text = DateTime.Now.AddYears(this.licenseControlWithFilter1.License.LicenseClassInfo.DefaultValidityLength).ToString("yyyy-MM-dd");
            this.CreatedByLbl.Text = DesktopApp.LogedInUser.ClslogedInUser.logedInUser.UserName;
            this.totalfeesLbl.Text = (AppFees + licenseClassFees).ToString();
            this.R_L_ApplicationIDLbl.Text = "N/A";
            this.RenewedLicenseIdLabel.Text = "N/A";

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
            string _Notes = this.Notes.Text;

            int NewLicenseID = DLMS.BusinessLier.RenewLicense.RenewLicenseLogic.RenewLicense(this.CurrentLicenseID,LogedInUser.ClslogedInUser.logedInUser.UserId, _Notes,out int NewAppID);
            if (NewLicenseID > 0)
            {
                MessageBox.Show($"Operation success your new license application ID is {NewLicenseID}", "Operation Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.License = DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(licenseID:CurrentLicenseID);
                this.CurrentLicenseID = NewLicenseID;
                IssueButton.Enabled = false;
                this.R_L_ApplicationIDLbl.Text = NewAppID.ToString();
                this.RenewedLicenseIdLabel.Text = NewLicenseID.ToString();
                this.licenseControlWithFilter1.FindByID(NewLicenseID,DisableSearch: false,RaiseEvent: false);
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
                MessageBox.Show($"We cant renew your license because its not expired. \n Expiration Date: {License?.ExpirationDate}", "Not Expired Yet", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ShowLicenseFrm Frm = new ShowLicenseFrm(LicenseID: CurrentLicenseID);
            if (!Frm.IsDisposed)
                Frm.ShowDialog();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CheckLicenseStatus()
        {
            this.ShowLicenseInfo.Enabled = true;
            this.ShowLicensesHistory.Enabled = true;
            this.R_L_ApplicationIDLbl.Text = "N/A";
            this.RenewedLicenseIdLabel.Text = "N/A";

            if (License.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show($"This license has not expired yet.\n The Expiration date is {License.ExpirationDate.ToString("yyyy-MM-dd")}", "Operation Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IssueButton.Enabled = false;
                return;
            }
            if (!License.IsActive)
            {
                MessageBox.Show($"We cant renew your license because its inactive", "License InActive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IssueButton.Enabled = false;
                return;
            }
            FillAppInfo();
            this.IssueButton.Enabled = true;
        }
        private void RenewLicenseFrm_Load(object sender, EventArgs e)
        {
            this.licenseControlWithFilter1.LicenseTextFocus();

            this.licenseControlWithFilter1.OnLicenseSelected += (int LicenseID) =>
            {
                this.License = licenseControlWithFilter1.License;
                this.CurrentLicenseID = LicenseID;
                CheckLicenseStatus();
                this.ShowLicenseInfo.Enabled = false;
            };
        }

    }
}
