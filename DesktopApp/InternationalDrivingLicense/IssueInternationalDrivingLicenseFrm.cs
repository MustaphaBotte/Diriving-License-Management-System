using System.ComponentModel.Design;

namespace DesktopApp.InternationalDrivingLicense
{
    public partial class IssueInternationalDrivingLicenseFrm : Form
    {
        public IssueInternationalDrivingLicenseFrm()
        {
            InitializeComponent();
        }
        DLMS.EntitiesNamespace.Entities.ClsLicense? License = null;
        DLMS.EntitiesNamespace.Entities.ClsDriver? Driver = null;
        int InterNatLicID = -1;
        private void FindButton_Click(object sender, EventArgs e)
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
                return;
            }
            this.ShowLicensesHistory.Enabled = true;
            this.Driver = DLMS.BusinessLier.Driver.DriverLogic.GetDriverById(License.DriverID);
            if (Driver == null)
            {
                MessageBox.Show($"We cant load the driver info please refresh and try again", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IssueButton.Enabled = false;
                return;
            }
            if (!License.IsActive)
            {
                MessageBox.Show($"We cant issue a new internationa license because this license  its inactive", "License InActive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IssueButton.Enabled = false;
                return;
            }
            if (License.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show($"We cant issue a new internationa license because. this license  its expired\n The Expiration date is {License.ExpirationDate.ToString("yyyy-MM-dd")}"
                  , "Operation Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FillAppInfo();
            this.IssueButton.Enabled = true;
        }

        private void FillAppInfo()
        {
            this.I_L_ApplicationIDLbl.Text = "N/A";
            this.IssueDateLbl.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.ExpirationDateLbl.Text = DateTime.Now.AddYears(1).ToString("yyyy/MM/dd");
            this.ApplicationDateLbl.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.FeesLbl.Text = DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(6).ToString();
            this.I_L_LicenseIDLbl.Text = "N/A";
            this.LocalLicenseIDLbl.Text = this.License?.LicenseID.ToString();
            this.CreatedBYLbl.Text = DesktopApp.LogedInUser.ClslogedInUser.logedInUser.UserName;
            ShowLicensesHistory.Enabled = true;
        }
        private void IssueInternationalDrivingLicenseFrm_Load(object sender, EventArgs e)
        {
            FilterChoices.SelectedIndex = 0;
        }

        private void FindButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void FindButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void IssueButton_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Are you sure you want to save ?", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (Res != DialogResult.OK)
            {
                return;
            }
            DLMS.EntitiesNamespace.Entities.ClsInternationalLicense internationalLicense = new DLMS.EntitiesNamespace.Entities.ClsInternationalLicense();
            internationalLicense.Application.ApplicantionDate = DateTime.Now;
            internationalLicense.Application.LastStatusDate = DateTime.Now;
            internationalLicense.Application.ApplicantPersonId = this.Driver.PersonID;
            internationalLicense.Application.ApplicationStatus = 1; //new
            internationalLicense.Application.ApplicationTypeId = 6; //International License
            internationalLicense.Application.CreatedByUserId = DesktopApp.LogedInUser.ClslogedInUser.logedInUser.UserId;
            internationalLicense.Application.PaidFees = DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(6);

            internationalLicense.CreatedByUserID = DesktopApp.LogedInUser.ClslogedInUser.logedInUser.UserId;
            internationalLicense.DriverID = this.Driver.DriverID;
            internationalLicense.IssueUsingLocLicID = this.License.LicenseID;
            internationalLicense.IsActive = true;
            internationalLicense.IssueDate = DateTime.Now;
            internationalLicense.ExpirationDate = DateTime.Now.AddYears(1);

            internationalLicense.Application.ApplicationId = DLMS.BusinessLier.InternationDriLicense.InternationDriLicenseLogic.AddNewInternationLicenseApplication(internationalLicense.Application);
            string ERROR = "";

            int Result = DLMS.BusinessLier.InternationDriLicense.InternationDriLicenseLogic.AddNewInternationDrivingLicense(internationalLicense, ref ERROR);
            if (Result > 0)
            {
                MessageBox.Show($"New Internationl License Issued SuccessFylly with ID= {Result}", "Opeartion Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.I_L_ApplicationIDLbl.Text = internationalLicense.Application.ApplicationId.ToString();
                this.I_L_LicenseIDLbl.Text = Result.ToString();
                this.ShowLicenseInfo.Enabled = true;
                this.IssueButton.Enabled = false;
                this.InterNatLicID = Result;
                return;
            }
            if (Result == -2)
            {
                MessageBox.Show("This Local license is not active", "Rules Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Result == -3)
            {
                MessageBox.Show("This driver already has an active international license", "Rules Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Result == -4)
            {
                MessageBox.Show("The driver must have a driving licenses from class three [Class 3 - Ordinary driving license]", "Rules Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Result == -1)
            {
                MessageBox.Show("The application or local license of this international license is not exists please refresh and try again", "Rules Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Result == 0)
            {
                MessageBox.Show("internal error please refresh and try again", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DesktopApp.AllLicensesHistory.ShowAllLicensesHistoryFrm Frm = new DesktopApp.AllLicensesHistory.ShowAllLicensesHistoryFrm(this.Driver.PersonID);
            Frm.ShowDialog();
        }

        private void ShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowInternationalLicenseFrm Frm = new ShowInternationalLicenseFrm(this.InterNatLicID);
            Frm.ShowDialog();
        }

        private void FilterValueTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FilterValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
