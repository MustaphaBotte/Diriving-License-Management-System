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

namespace DesktopApp.Detain_Release_License
{
    public partial class Release_LicenseFrm : Form
    {
        DLMS.EntitiesNamespace.Entities.ClsLicense? License = null;
        int CurrentLicenseId = -1;


        int PersonID = -1;
        public delegate void LicenseReleased(int LicID, Form Sender);
        public event LicenseReleased OnLicenseReleased = delegate { };
        public Release_LicenseFrm(int LicenseID = -1)
        {
            InitializeComponent();
            if (LicenseID != -1)
                this.CurrentLicenseId = LicenseID;
        }
    
        private void FillAppInfo()
        {

            if (licenseControlWithFilter1.License == null || licenseControlWithFilter1.License.DetainInfo==null)
            {
                MessageBox.Show($"This license is not detained or not exists", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.PersonID = DLMS.BusinessLier.Driver.DriverLogic.GetDriverById(License.DriverID)?.PersonID ?? 0;
            this.DetainIDLbl.Text = licenseControlWithFilter1.License.DetainInfo.DetainID.ToString();
            decimal AppFees =
            DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(Entities.ClsApplication.enApplicationType.ReleaseDetainedDrivingLicsense); // 5= release 
            this.LicenseIDLbl.Text = licenseControlWithFilter1.License.LicenseID.ToString();
            this.CreatedByLbl.Text = licenseControlWithFilter1.License.DetainInfo.DetainedByUser?.UserName;
            this.FineFeesLabel.Text = licenseControlWithFilter1.License.DetainInfo.Fees.ToString();
            this.TotalFeesLbl.Text = (licenseControlWithFilter1.License.DetainInfo.Fees + (decimal)AppFees ).ToString();
            this.AppFeesLabel.Text = AppFees.ToString();
            this.DetainDateLbl.Text = licenseControlWithFilter1.License.DetainInfo.DetainDate.ToString();
        }

        private void IssueButton_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Are you sure you want to release?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.No)
            {
                return;
            }
    
            int Result = DLMS.BusinessLier.Release_Detain_License.Release_Detain_LicenseLogic.ReLeaseLicense(License.LicenseID, LogedInUser.ClslogedInUser.logedInUser
                .UserId,out int NewAppId);
            if (Result == 1)
            {
                MessageBox.Show($"License with Id= {License.LicenseID} released succesfully", "Operation success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ShowLicenseInfo.Enabled = true;
                this.AppIDLabel.Text = NewAppId.ToString();
                this.OnLicenseReleased?.Invoke(License.LicenseID, this);
            }
            else if (Result == -1)
            {
                MessageBox.Show($"This license is not detained", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Result == -2)
            {
                MessageBox.Show($"This license is expired. please renew it first", "Expired License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Result == 0)
            {
                MessageBox.Show($"Internal error we cannot handle your request in the moment", "INternal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            IssueButton.Enabled = false;
        }

        private void ShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseFrm Frm = new ShowLicenseFrm(LicenseID: License.LicenseID);
            Frm.ShowDialog();
        }

        private void ShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowAllLicensesHistoryFrm Frm = new ShowAllLicensesHistoryFrm(this.PersonID);
            Frm.ShowDialog();
        }

        private void CheckLicenseStatus()
        {
           
            this.ShowLicensesHistory.Enabled = true;

            if (License == null)
            {
                this.IssueButton.Enabled = false;
                this.ShowLicenseInfo.Enabled = false;
                this.ShowLicensesHistory.Enabled = false;
                return;
            }
            if (License.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show($"This license is expired.\n The Expiration date is {License.ExpirationDate.ToString("yyyy-MM-dd")}", "Operation Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IssueButton.Enabled = false;
                return;
            }
            if (!License.IsActive)
            {
                MessageBox.Show($"This license is not active", "Not Active", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IssueButton.Enabled = false;
                return;
            }
            if (!DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.ISDetained(License.LicenseID))
            {
                MessageBox.Show($"This license is not detained", "System rules violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.IssueButton.Enabled = false;
                return;
            }
            FillAppInfo();
            this.IssueButton.Enabled = true;
        }
        private void Release_LicenseFrm_Load(object sender, EventArgs e)
        {
            
            this.licenseControlWithFilter1.OnLicenseSelected += (int LicenseID) =>
            {
                this.License = licenseControlWithFilter1.License;
                this.CurrentLicenseId = LicenseID;
                CheckLicenseStatus();
            };
            if (CurrentLicenseId != -1)
                licenseControlWithFilter1.FindByID(CurrentLicenseId);
        }
    }
}
