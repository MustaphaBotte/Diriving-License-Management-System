using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLMS;
using DesktopApp.ManagePerson;

namespace DesktopApp.PersonControl
{
    public partial class ShowInfoInControl : UserControl
    {
        private int PersonID=-1;
        public DLMS.EntitiesNamespace.Entities.ClsPerson? Person = new DLMS.EntitiesNamespace.Entities.ClsPerson();
        public bool IsControlFilled = false;
      
        public ShowInfoInControl()
        {
            InitializeComponent();
        }
           
        private bool AlternativeImage(byte? Gender)
        {

            try
            {
                if (Gender == 1)
                    UserPicture.Image = Image.FromFile(@"D:\C# Projects\Course 19\DLMS\DLMS\DesktopApp\Images\FemaleUser.png");
                else
                    UserPicture.Image = Image.FromFile(@"D:\C# Projects\Course 19\DLMS\DLMS\DesktopApp\Images\MaleUser.png");

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {

            }
            //  return false;
        }
        private bool FillPicture(string? Path)
        {
            try
            {
                if (File.Exists(path: Path))
                {
                    UserPicture.Image = new Bitmap(Path);
                    UserPicture.Tag = Path;
                    return true;
                }
                else
                {
                    AlternativeImage(Person?.Gender);
                    return false;
                }

            }
            catch
            {
                return false;
            }
            finally
            {

            }
        }
        public bool FillDataInControl(int ID=-1,string NationalNo="")
        {
            this.Person = DLMS.BusinessLier.Person.PersonLogic.FindPerson(ID, NationalNo);
            if (Person != null)
            {
               
                this.PersonID = Person.PersonId;
                this.IDLabel.Text = Person.PersonId.ToString();
                this.FNLabel.Text = Person.FirstName;
                this.LNLabel.Text = Person.LastName;
                this.SNLabel.Text = Person.SecondName;
                this.THLabel.Text = Person.ThirdName;
                this.NationalNLabel.Text = Person.NationalNo;
                this.GenderLabel.Text = Person.Gender == 0 ? "Male" : "Female";
                this.EmailLabel.Text = Person.Email;
                this.PhoneLabel.Text = Person.Phone;
                this.NationalityLabel.Text = Person.CountryInfo?.CountryName??"Unknown";     
                this.AddressLabel.Text = Person.Address;
                this.DateOfBirthLabel.Text = Person.DateOfBirth.Date.ToString("yyyy-MM-dd");
                FillPicture(Person.ImagePath);
                IsControlFilled = true;
                return true;
            }
            ClearControl();
            return false;
        }

        private  void UserUpdated()
        {
            FillDataInControl(this.PersonID);
        }
        private void EditPersonLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddEditPersonFrm UserForm = new AddEditPersonFrm(Person.PersonId); 
            UserForm.SendSignalToRefresh += UserUpdated;
            UserForm.ShowDialog();
        }
        private void ClearControl()
        {
            // if you want to use it
            this.PersonID = -1;
            this.IDLabel.Text = "";
            this.FNLabel.Text = "";
            this.LNLabel.Text = "";
            this.SNLabel.Text = "";
            this.THLabel.Text = "";
            this.NationalNLabel.Text ="";
            this.GenderLabel.Text = "";
            this.EmailLabel.Text =  "";
            this.PhoneLabel.Text =  "";
            this.NationalityLabel.Text = "";
            this.AddressLabel.Text = "";
            this.DateOfBirthLabel.Text = "";
            UserPicture.Image = null;
            UserPicture.Tag = "";
            IsControlFilled = false ;
        }

    }
}
