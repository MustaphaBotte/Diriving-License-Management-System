
namespace DesktopApp.VisionTest
{
    public partial class ApplicationInfoControl : UserControl
    {
        private int _LocalApplicationID = -1;
        public Dictionary<string, object> LocalAppInfo = new Dictionary<string, object>();
        DLMS.EntitiesNamespace.Entities.ClsApplication? application = new DLMS.EntitiesNamespace.Entities.ClsApplication();
        private bool ControlFilled = false;
        public ApplicationInfoControl()
        {
            InitializeComponent();
        }
        public ApplicationInfoControl(int ApplicationID)
        {
            this._LocalApplicationID = ApplicationID;
        }
        private bool FillLocalDrivingLicenseAppInfo()
        {
            LocalAppInfo = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetLocalDrivingLicAppById(this._LocalApplicationID);
            if (LocalAppInfo.Count == 0)
            {
                return false;
            }
            this.LocDLA_ID_LBL.Text = LocalAppInfo["LocDLA_ID"].ToString();
            this.LicenseClassLBL.Text = LocalAppInfo["ClassName"].ToString();
            this.PassedTestsLBL.Text = LocalAppInfo["PassedTests"].ToString() + "/3";
            return true;
        }

        private bool FillBasicAppInfo()
        {
            int AppId = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetAppIdByLocalDrivingId(this._LocalApplicationID);
            if (AppId == -1)
                return false;
            application = DLMS.BusinessLier.Application.ApplicationLogic.GetApplicationByID(AppId);
            if (application == null)
                return false;
            this.AppIDLbl.Text = application.ApplicationId.ToString();
            this.ApplicantLbl.Text = LocalAppInfo["FullName"].ToString();
            this.FeesLbl.Text = application.PaidFees.ToString();
            this.StatusLbl.Text = LocalAppInfo["Applicationstatus"].ToString();
            this.Typelbl.Text = DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetAppTypeTitleByAppID(application.ApplicationId);
            this.DateLbl.Text = application.ApplicantionDate.ToString("dd/MM/yyyy");
            this.LastStatusDateLbl.Text = application.LastStatusDate.ToString("dd/MM/yyyy");
            this.CreatedByLbl.Text = DLMS.BusinessLier.User.UserLogic.GetUserNameByUserId(application.CreatedByUserId);
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
                    if (!FillLocalDrivingLicenseAppInfo() || !FillBasicAppInfo())
                    {
                        MessageBox.Show("We can't show the local driving application details right now please refresh and try again", "internal error",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                return false;
            }
            return true;
        }

        private void ApplicationInfoControl_Load(object sender, EventArgs e)
        {

        }

        private void ShowPersonInfoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (application?.ApplicationId > 0)
            {
                DesktopApp.ManagePerson.ShowPerson Frm = new DesktopApp.ManagePerson.ShowPerson(application.ApplicantPersonId);
                Frm.ShowDialog();
            }
        }

        private void PersonInfoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (application == null || application.ApplicantPersonId <= 0)
                return;

            DesktopApp.ManagePerson.ShowPerson Frm = new DesktopApp.ManagePerson.ShowPerson(application.ApplicantPersonId);
            Frm.ShowDialog();
        }

        private void LicenseInfoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (application == null || !LocalAppInfo.Keys.Contains("ClassName"))
                return;
            string? ClassName = LocalAppInfo["ClassName"].ToString();
            if( !string.IsNullOrEmpty(ClassName))
            {
                DesktopApp.ManageLicenseClass.ShowlicenseClassInfo Frm = new DesktopApp.ManageLicenseClass.ShowlicenseClassInfo(Classname:ClassName);
                Frm.ShowDialog();
            }
        }
    }
}
