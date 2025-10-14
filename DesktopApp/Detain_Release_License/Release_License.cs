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

            DLMS.EntitiesNamespace.Entities.ClsDetainedLicense? detainedLicense = DLMS.BusinessLier.Release_Detain_License.Release_Detain_LicenseLogic.FindbyLicenseID(License.LicenseID);
            if (detainedLicense == null)
            {
                MessageBox.Show($"This license is not detained or not exists", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.PersonID = DLMS.BusinessLier.Driver.DriverLogic.GetDriverById(License.DriverID)?.PersonID ?? 0;
            this.DetainIDLbl.Text = detainedLicense.DetainID.ToString();
            decimal AppFees =
            DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(Entities.ClsApplication.enApplicationType.ReleaseDetainedDrivingLicsense); // 5= release 
            this.LicenseIDLbl.Text = detainedLicense.LicenseID.ToString();
            this.CreatedByLbl.Text = DLMS.BusinessLier.User.UserLogic.FindUserByIdOrUser(detainedLicense.CreatedByUserID)?.UserName;
            this.FineFeesLabel.Text = detainedLicense.Fees.ToString();
            this.TotalFeesLbl.Text = (detainedLicense.Fees + AppFees).ToString();
            this.AppFeesLabel.Text = AppFees.ToString();
            this.DetainDateLbl.Text = detainedLicense.DetainDate.ToString();
        }

        private void IssueButton_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Are you sure you want to release?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.No)
            {
                return;
            }

            DLMS.EntitiesNamespace.Entities.ClsApplication? App = new DLMS.EntitiesNamespace.Entities.ClsApplication();
            App.ApplicationStatus = DLMS.EntitiesNamespace.Entities.ClsApplication.enApplicationStatus.New;
            App.ApplicantPersonId = PersonID;
            App.ApplicantionDate = DateTime.Now;
            App.ApplicationType = DLMS.EntitiesNamespace.Entities.ClsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;//release
            App.LastStatusDate = DateTime.Now;
            App.PaidFees = DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(Entities.ClsApplication.enApplicationType.ReleaseDetainedDrivingLicsense);
            App.CreatedByUserId = DesktopApp.LogedInUser.ClslogedInUser.logedInUser.UserId;

            string ER = "";
            int NewAppId = DLMS.BusinessLier.Application.ApplicationLogic.AddNewApplication(App, ref ER);
            if (NewAppId <= 0)
            {
                MessageBox.Show($"We cant save the application in the moment refresh and try again", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int Result = DLMS.BusinessLier.Release_Detain_License.Release_Detain_LicenseLogic.ReLeaseLicense(License.LicenseID, DateTime.Now, DesktopApp.LogedInUser.ClslogedInUser.logedInUser
                .UserId, NewAppId);
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
            this.ShowLicenseInfo.Enabled = true;
            this.ShowLicensesHistory.Enabled = true;
            if (License.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show($"This license is expired.\n The Expiration date is {License.ExpirationDate.ToString("yyyy-MM-dd")}", "Operation Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
