using DLMS.EntitiesNamespace;
namespace DesktopApp.IssueLocalDrivingLicense
{
    public partial class IssueDrivingLicenseFrm : Form
    {
        private int ApplicantPersonID = -1;
        Entities.ClsLocDriApplication locDriApplication = new Entities.ClsLocDriApplication();

        public delegate void LicenseSavedWithSuccess( ) ;
        public event LicenseSavedWithSuccess ON_LicenseSavedWithSuccess=delegate { };
        public IssueDrivingLicenseFrm(int Loc_DLA_ID)
        {
            InitializeComponent();
            if (!applicationInfoControl1.FillTheControlById(Loc_DLA_ID))
            {
                this.Close();
            }
            this.ApplicantPersonID = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetApplicantPersonIdByLocDriId(Loc_DLA_ID);
            locDriApplication = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetBasicLocDriLicAppInfo(Loc_DLA_ID);
            if (locDriApplication == null || this.ApplicantPersonID<=0)
            {
                MessageBox.Show("Sorry we cannot load certain data please refresh and try again", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void IssueDrivingLicenseFrm_Load(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            int driverID = -1;
            if (DLMS.BusinessLier.Driver.DriverLogic.IsAlreadyDriver(ApplicantPersonID))
            {
                driverID = DLMS.BusinessLier.Driver.DriverLogic.GetDriverID(ApplicantPersonID);
            }
            else
            {   
                Entities.ClsDriver Driver = new Entities.ClsDriver();
                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedBy = DesktopApp.LogedInUser.ClslogedInUser.logedInUser.UserId;
                Driver.CreationDate = DateTime.Now;
                driverID = DLMS.BusinessLier.Driver.DriverLogic.AddNewDriver(Driver);
            }
            if(driverID<=0)
            {
                MessageBox.Show("We cannot add driver in the moment please refresh try again", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            DLMS.EntitiesNamespace.Entities.ClsLicense License = new DLMS.EntitiesNamespace.Entities.ClsLicense();
            License.DriverID = driverID;
            License.ApplicationID = this.locDriApplication.ApplicantionID;
            License.LicenseClassID = this.locDriApplication.LicenseClassID;
            License.CreatedByUserID = DesktopApp.LogedInUser.ClslogedInUser.logedInUser.UserId;
            License.IsActive = true;
            License.IssueDate = DateTime.Now;
            License.PaidFees = DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetlisenceFees(this.locDriApplication.LicenseClassID);
            int ValidityLength = DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetlisenceValidityLength(this.locDriApplication.LicenseClassID);
            License.ExpirationDate = ValidityLength <= 0 ? DateTime.Now : DateTime.Now.AddYears(ValidityLength);
            License.Notes = this.NotesTextBox.Text;
            License.IssueReason = 1;
            //1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.

            DialogResult Result = MessageBox.Show($"Are you sure you want to save", "Confirmation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(Result == DialogResult.No)
            {
                return;
            }
            int NewLicenseID = DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.AddNewLocalDrivinLicense(License);
            if(NewLicenseID>0)
            {
                MessageBox.Show($"The new license added successFully to the system with ID ={NewLicenseID} For the Driver ID {driverID}", "Operation Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ON_LicenseSavedWithSuccess.Invoke();
                this.Close();
                return;
            }
            if (NewLicenseID ==-1)
            {
                MessageBox.Show($"The new license was not added to the system because one of those no longer exists in the system \n " +
                    $"Application Or Driver or LicenseType \n Please refresh and try again", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if (NewLicenseID == -2)
            {
                MessageBox.Show($"This Driver Has An active license class from this type", "System rules violation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            if (NewLicenseID == -3)
            {
                MessageBox.Show($"license was not added to the system because the application was locked before", "System rules violation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            MessageBox.Show($"Due an internal error we cannot save in the moment please refresh and try again", "Operation failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
