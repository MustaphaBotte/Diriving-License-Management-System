using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DesktopApp.LocDrivingLicense
{
    public partial class LicenseControl : UserControl
    {
        public LicenseControl()
        {
            InitializeComponent();
        }
        public bool FillTheControlByLoc_DLA_IDOr_LicenseID(int Loc_DLA_ID=-1,int LicenseID=-1)
        {  
            if(Loc_DLA_ID==-1 && LicenseID==-1)
            {
                return false;
            }
            DLMS.EntitiesNamespace.Entities.ClsLicense? License = Loc_DLA_ID==-1?
            DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(licenseID: LicenseID) :
            DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(Loc_DLA_ID:Loc_DLA_ID);

            if (License == null)
                return false;          
            DLMS.EntitiesNamespace.Entities.ClsDriver? Driver = DLMS.BusinessLier.Driver.DriverLogic.GetDriverById(License.DriverID);
            if (Driver == null)
                return false;
            DLMS.EntitiesNamespace.Entities.ClsPerson? Person = DLMS.BusinessLier.Person.PersonLogic.FindPerson(Driver.PersonID);
            if (Person == null)
                return false;

            this.NameLabel.Text=Person.FirstName+" "+Person.SecondName+" " + Person.ThirdName + " " + Person.LastName; 
            this.ClassLabel.Text = DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetLisenceClassById(License.LicenseClassID)?.ClassName ?? "Unknown";
            this.LicenseIdLabel.Text = License.LicenseID.ToString();
            this.NationalNoLabel.Text = Person.NationalNo;
            this.GenderLabel.Text = Person.Gender == 0 ? "Male" : "Female";
            this.IssueDateLabel.Text = License.IssueDate.ToString("yyyy-MM--dd");
            string[] Reasons = ["FirstTime", "Renew", " Replacement for Damaged", "Replacement for Lost"];
            this.IssueReasonLabel.Text = Reasons[License.IssueReason - 1];
            this.ExpirationDateLabel.Text = License.ExpirationDate.ToString("yyyy-MM--dd");
            this.NotesLabel.Text = string.IsNullOrEmpty(License.Notes) ? "No Notes " : License.Notes;
            this.IsActiveLabel.Text = License.IsActive ? "Active" : "Not Active";
            this.DateOfBirthLabel.Text = Person.DateOfBirth.ToString("yyyy-MM--d");
            this.DriverIDLabel.Text = License.DriverID.ToString();
            this.IsDetainedLabel.Text = DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.ISDetained(License.LicenseID) ? "Yes" : "No";
            if(File.Exists(Person.ImagePath))
            {
                this.DriverPictureBox.BackgroundImage = Image.FromFile(Person.ImagePath);
            }
            else
            {
                if(Person.Gender==1)
                {
                    this.DriverPictureBox.BackgroundImage = Image.FromFile(@"D:\C# Projects\Course 19\DLMS\DLMS\DesktopApp\Images\FemaleUser.png");                  
                }
                else
                {
                    this.DriverPictureBox.BackgroundImage = Image.FromFile(@"D:\C# Projects\Course 19\DLMS\DLMS\DesktopApp\Images\MaleUser.png");
                }
            }
            return true;
        }

        private void LicenseControl_Load(object sender, EventArgs e)
        {

        }
    }
}
