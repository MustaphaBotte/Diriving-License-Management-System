using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.InternationalDrivingLicense
{
    public partial class InternationalLicenseControl: UserControl
    {
        public InternationalLicenseControl()
        {
            InitializeComponent();
        }      
        public bool FillInfoByInterLicID(int Inter_Lic_ID)
        {
            DLMS.EntitiesNamespace.Entities.ClsInternationalLicense? internationalLicense = DLMS.BusinessLier.InternationDriLicense.InternationDriLicenseLogic.GetLicenseByInterNatID(Inter_Lic_ID);
            if (internationalLicense == null)
                return false;
            if (internationalLicense.Application == null)
                return false;
            DLMS.EntitiesNamespace.Entities.ClsDriver? Driver = DLMS.BusinessLier.Driver.DriverLogic.GetDriverById(internationalLicense.DriverID);
            if (Driver == null)
                return false;
            DLMS.EntitiesNamespace.Entities.ClsPerson? Person = DLMS.BusinessLier.Person.PersonLogic.FindPerson(Driver.PersonID);
            if (Person == null)
                return false;

            this.IL_LicIDLabel.Text = internationalLicense.InternationLicenseID.ToString();
            this.NameLabel.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
            this.LicenseIdLabel.Text = internationalLicense.IssueUsingLocLicID.ToString();
            this.NationalNoLabel.Text = Person.NationalNo;
            this.GenderLabel.Text = Person.Gender == 0 ? "Male" : "Female";
            this.IssueDateLabel.Text = internationalLicense.IssueDate.ToString("yyyy-MM--dd");
            this.ExpirationDateLabel.Text = internationalLicense.ExpirationDate.ToString("yyyy-MM--dd");
            this.IsActiveLabel.Text = internationalLicense.IsActive ? "Active" : "Not Active";
            this.DateOfBirthLabel.Text = Person.DateOfBirth.ToString("yyyy-MM--d");
            this.DriverIDLabel.Text = internationalLicense.DriverID.ToString();
            if (File.Exists(Person.ImagePath))
            {
                this.DriverPictureBox.BackgroundImage = Image.FromFile(Person.ImagePath);
            }
            else
            {
                if (Person.Gender == 1)
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

    }
}
