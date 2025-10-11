
namespace DesktopApp.VisionTest
{
    public partial class ApplicationInfoControl : UserControl
    {
        private int _LocalApplicationID = -1;
        private DLMS.EntitiesNamespace.Entities.ClsLicense? _License = null;
        public DLMS.EntitiesNamespace.Entities.ClsLocDriApplication? LocalAppInfo1 = new DLMS.EntitiesNamespace.Entities.ClsLocDriApplication();
        public ApplicationInfoControl()
        {
            InitializeComponent();
        }

        private bool FillLocalDrivingLicenseAppInfo()
        {
            LocalAppInfo1 = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetLocDriLicAppInfo(_LocalApplicationID);
            if (LocalAppInfo1 == null)
            {
                return false;
            }
            this.LocDLA_ID_LBL.Text = LocalAppInfo1.LocDriApplicationID.ToString();
            this.LicenseClassLBL.Text = LocalAppInfo1.LicenseClassInfo?.ClassName;
            this.PassedTestsLBL.Text =
                DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.PassesTests(_LocalApplicationID).ToString() + "/3";
            return true;
        }

        private bool FillBasicAppInfo()
        {
            if (LocalAppInfo1 == null)
                return false;

            this.AppIDLbl.Text = LocalAppInfo1.ApplicantionID.ToString();
            this.ApplicantLbl.Text = LocalAppInfo1.ApplicantPersonInfo?.FullName;
            this.FeesLbl.Text = LocalAppInfo1.PaidFees.ToString();
            this.StatusLbl.Text = LocalAppInfo1.ApplicationStatus.ToString();
            this.Typelbl.Text = LocalAppInfo1.ApplicationType.ToString();
            this.DateLbl.Text = LocalAppInfo1.ApplicantionDate.ToString("dd/MM/yyyy");
            this.LastStatusDateLbl.Text = LocalAppInfo1.LastStatusDate.ToString("dd/MM/yyyy");
            this.CreatedByLbl.Text = LocalAppInfo1.CreatedByUser?.UserName;
            return true;
        }

        public bool FillTheControlById(int localApplicationID)
        {
            this._LocalApplicationID = localApplicationID;
            if (!FillLocalDrivingLicenseAppInfo() || !FillBasicAppInfo())
            {
                DialogResult Res = MessageBox.Show("We can't show the local driving application details right now please refresh and try again", "internal error",
                     MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (Res == DialogResult.Retry)
                {
                    FillTheControlById(localApplicationID);
                }
                return false;
            }
            this._License = DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(Loc_DLA_ID:this._LocalApplicationID);
            if (this._License != null)
            {
                this.DriverLicenseLink.Visible = true;
            }
            else
                this.DriverLicenseLink.Visible = false;
            return true;
        }
        private void ShowPersonInfoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LocalAppInfo1?.ApplicantPersonInfo?.PersonId > 0)
            {
                DesktopApp.ManagePerson.ShowPerson Frm = new DesktopApp.ManagePerson.ShowPerson(LocalAppInfo1.ApplicantPersonInfo.PersonId);
                Frm.ShowDialog();
            }
        }

        private void PersonInfoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (LocalAppInfo1?.ApplicantPersonInfo?.PersonId > 0)
            {
                DesktopApp.ManagePerson.ShowPerson Frm = new DesktopApp.ManagePerson.ShowPerson(LocalAppInfo1.ApplicantPersonInfo.PersonId);
                Frm.ShowDialog();
            }
        }

        private void LicenseInfoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LocalAppInfo1 == null || LocalAppInfo1.LicenseClassID <= 0)
                return;

            DesktopApp.ManageLicenseClass.ShowlicenseClassInfo Frm = new DesktopApp.ManageLicenseClass.ShowlicenseClassInfo(LocalAppInfo1.LicenseClassID);
            Frm.ShowDialog();

        }

        private void DriverLicenseLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this._License != null)
            {
                DesktopApp.LocDrivingLicense.ShowLicenseFrm Frm = new DesktopApp.LocDrivingLicense.ShowLicenseFrm(LicenseID: _License.LicenseID);
                if(!Frm.IsDisposed)
                     Frm.ShowDialog();
            }
        }
    }
}
