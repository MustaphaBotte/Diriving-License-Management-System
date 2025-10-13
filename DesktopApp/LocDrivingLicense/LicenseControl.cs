using DLMS.BusinessLier.LocalDrivingLicense;
using DLMS.EntitiesNamespace;

namespace DesktopApp.LocDrivingLicense
{
    public partial class LicenseControl : UserControl
    {
        public LicenseControl()
        {
            InitializeComponent();
        }
        private int _LicenseID = -1;
        public Entities.ClsLicense _License;
        public int LicenseID
        {
            get
            {
                return this._LicenseID;
            }
        }
        public Entities.ClsLicense License
        {
            get
            {
                return this._License;
            }
        }

        private void LoadPersonImg()
        {
            if (File.Exists(License.DriverInfo?.PersonInfo?.ImagePath??""))
            {
                this.DriverPictureBox.BackgroundImage = Image.FromFile(License?.DriverInfo?.PersonInfo?.ImagePath ?? "");
            }
            else
            {
                if (License?.DriverInfo?.PersonInfo?.Gender == 1)
                {
                    this.DriverPictureBox.BackgroundImage = Image.FromFile(@"D:\C# Projects\Course 19\DLMS\DLMS\DesktopApp\Images\FemaleUser.png");
                }
                else
                {
                    this.DriverPictureBox.BackgroundImage = Image.FromFile(@"D:\C# Projects\Course 19\DLMS\DLMS\DesktopApp\Images\MaleUser.png");
                }
            }
        }
        private bool DrawData(Entities.ClsLicense? License)
        {
            if(License==null)
            {
                MessageBox.Show("License Not Found PLease check your License ID", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }         
            if (License.DriverInfo == null)
                return false;
            if (License.DriverInfo.PersonInfo == null)
                return false;


            this._LicenseID = License.LicenseID;
            this._License = License;

            this.NameLabel.Text = License.DriverInfo.PersonInfo.FirstName + " " + License.DriverInfo.PersonInfo.SecondName + " " +
                                  License.DriverInfo.PersonInfo.ThirdName + " " + License.DriverInfo.PersonInfo.LastName;

            this.ClassLabel.Text = License.LicenseClassInfo?.ClassName;
            this.LicenseIdLabel.Text = License.LicenseID.ToString();
            this.NationalNoLabel.Text = License.DriverInfo.PersonInfo.NationalNo;
            this.GenderLabel.Text = License.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female";
            this.IssueDateLabel.Text = License.IssueDate.ToString("yyyy-MM--dd");
            string[] Reasons = ["FirstTime", "Renew", " Replacement for Damaged", "Replacement for Lost"];
            this.IssueReasonLabel.Text = Reasons[(int)License.IssueReason - 1];
            this.ExpirationDateLabel.Text = License.ExpirationDate.ToString("yyyy-MM--dd");
            this.NotesLabel.Text = string.IsNullOrEmpty(License.Notes) ? "No Notes " : License.Notes;
            this.IsActiveLabel.Text = License.IsActive ? "Active" : "Not Active";
            this.DateOfBirthLabel.Text = License.DriverInfo.PersonInfo.DateOfBirth.ToString("yyyy-MM--d");
            this.DriverIDLabel.Text = License.DriverID.ToString();
            this.IsDetainedLabel.Text = DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.ISDetained(License.LicenseID) ? "Yes" : "No";
            LoadPersonImg();
            return true;
        }
        public bool LoadByLicenseID(int LicenseID)
        {
            Entities.ClsLicense? License =
            LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(licenseID: LicenseID);
            return DrawData(License);
        }

        public bool LoadByLocDriID(int LocDriID)
        {
            Entities.ClsLicense? License =
            LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(Loc_DLA_ID: LocDriID);
            return DrawData(License);
        }
    }
}
