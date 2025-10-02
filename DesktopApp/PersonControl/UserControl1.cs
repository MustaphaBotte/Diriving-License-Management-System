using Azure;
using DLMS.BusinessLier;
using DLMS.EntitiesNamespace;
using Guna.UI2.WinForms;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DesktopApp.PersonControl
{
    public partial class PersonUserControl : UserControl
    {
        public PersonUserControl()
        {
            InitializeComponent();
        }

        Dictionary<short, object>? CountriesAsDict = new Dictionary<short, object>();
        private bool HasProfilePicture = false;
        Entities.ClsPerson Person = new Entities.ClsPerson();
        static string OldImgPath = "";
        static int CurrentPersonId = -1;



        public delegate void SignalToForm(int ID);
        public event SignalToForm? SendSignalToForm;

        public delegate void SignalToFormToClose();
        public event SignalToFormToClose? SendSignalToFormToClose;

        private bool AlternativeImage(byte? Gender)
        {

            try
            {
                if (Gender == 1)
                    UserPicture.Image = Image.FromFile(@"D:\C# Projects\Course 19\DLMS\DLMS\DesktopApp\Images\FemaleUser.png");
                else
                    UserPicture.Image = Image.FromFile(@"D:\C# Projects\Course 19\DLMS\DLMS\DesktopApp\Images\MaleUser.png");

                this.SetImglinkLabel.Visible = true;
                this.RemoveImglinkLabel.Visible = false;
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

   
        private bool FillPicture(string Path)
        {

            try
            {
                if (File.Exists(path: Path))
                {
                    UserPicture.Image = new Bitmap(Path);
                    UserPicture.Tag = Path;
                    this.HasProfilePicture = true;
                    this.SetImglinkLabel.Visible = false;
                    this.RemoveImglinkLabel.Visible = true;
                    return true;
                }

            }
            catch
            {
                return false;
            }
            finally
            {

            }
            return false;
        }
        private bool FillCountriesBox()
        {
            CountriesAsDict = PersonControl.CachedCountries.GetAllCountreis();
            if (CountriesAsDict == null)
            {
                //Try Again
                CountriesAsDict = PersonControl.CachedCountries.GetAllCountreis();
                if (CountriesAsDict == null)
                {
                    return false;
                }
            }
            CountriesBox.DataSource = new BindingSource(CountriesAsDict, null);
            CountriesBox.ValueMember = "Key";
            CountriesBox.DisplayMember = "Value";
            CountriesBox.DropDownHeight = 250;
            CountriesBox.SelectedIndex = 0;
            return true;
        }
        private void PersonUserControl_Load(object sender, EventArgs e)
        {
            this.DateTimePicker.MaxDate = DateTime.Today.AddDays(-(365.25 * 18));
            this.DateTimePicker.MinDate = DateTime.Today.AddYears(-150);

        }
        public void FillDataInControl(Entities.ClsPerson? Person)
        {
            this.Person = Person;
            if (Person != null)
            {

                this.NationalNotextbox.Text = Person.NationalNo;
                this.FirstNametextBox.Text = Person.FirstName;
                this.SecondNametextBox.Text = Person.SecondName;
                this.ThirdNametextBox.Text = Person.ThirdName;
                this.LastNametextBox.Text = Person.LastName;
                this.EmailTextBox.Text = Person.Email;
                this.PhoneTextBox.Text = Person.Phone;
                this.AddressTextBox.Text = Person.Address;
                if (Person.Mode == Entities.EnMode.AddNew)
                {
                    this.DateTimePicker.Value = DateTimePicker.MaxDate;
                }
                else
                    this.DateTimePicker.Value = Person.DateOfBirth == null ? new DateTime() : Person.DateOfBirth.Date;
                FillPicture(Person.ImagePath);
                if (Person.Mode == Entities.EnMode.Update)
                {
                    this.MaleRadioButton.Checked = Person.Gender == 0 ? true : false;
                    this.FemaleRadioButton.Checked = Person.Gender == 1 ? true : false;
                }
                else
                    this.MaleRadioButton.Checked = true;
            }


            if (FillCountriesBox() == false)
            {
                MessageBox.Show("Country data is currently unavailable. \n Please try again later or contact support if the issue persists.",
                 "Data Not Available",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);

            }

            if (Person?.NationalityCountryID != null)
            {

                if (CountriesAsDict != null && CountriesAsDict.ContainsKey(Person.NationalityCountryID))
                {
                    CountriesBox.SelectedValue = Person.NationalityCountryID;
                }
                else
                {
                    CountriesBox.SelectedItem = "Morocco";
                }
            }

        }

        private bool NamesValidator(string Name)
        {
            return (!string.IsNullOrEmpty(Name.Trim()) && !(Name.Length <= 1 || Name.Length > 20));
        }
        private void NametextBox_Leave(object sender, EventArgs e)
        {
             if (sender != null)
            {
                Guna2TextBox TextBox = (Guna2TextBox)sender;
                if (TextBox.Name== "ThirdNametextBox" && TextBox.Text=="")
                {
                    return;
                }
                if (!NamesValidator(TextBox.Text))
                {
                    TextBoxErrorProvider.SetError(TextBox, "Field Required (between 2 and 20  chars )");
                }
                else
                {
                    TextBoxErrorProvider.SetError(TextBox, "");
                }

            }
        }

        private bool PhoneValidator(string Phone)
        {
            string Pattern = @"^(?:0[5-7]\d{8}|\+212[5-7]\d{8})$";
            bool result = Regex.IsMatch(Phone, Pattern);

            return (!string.IsNullOrEmpty(Phone.Trim()) && !(Phone.Length < 10 || Phone.Length > 20) && result == true);
        }
        private void PhoneTextBox_Leave(object sender, EventArgs e)
        {

            if (!PhoneValidator(PhoneTextBox.Text))
            {
                TextBoxErrorProvider.SetError(PhoneTextBox, "Field Required (between 2 and 20  chars)");
            }
            else
            {
                TextBoxErrorProvider.SetError(PhoneTextBox, "");
            }

        }

        private bool EmailValidator(string Mail)
        {
            string Pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            bool result = Regex.IsMatch(Mail.Trim(), Pattern);
            //if email=="" will return true email not required
            return (string.IsNullOrEmpty(Mail) || (result == true && Mail.Length <= 50));
        }
        private void EmailTextBox_Leave(object sender, EventArgs e)
        {

            if (!EmailValidator(EmailTextBox.Text))
            {
                TextBoxErrorProvider.SetError(EmailTextBox, "Field Required (Set a Valid Email Format and Length<=50)");
            }
            else
            {
                TextBoxErrorProvider.SetError(EmailTextBox, "");
            }

        }

        private bool AddressValidator(string Address)
        {
            return (!string.IsNullOrEmpty(AddressTextBox.Text) && !(AddressTextBox.Text.Length < 10 || AddressTextBox.Text.Length > 500));
        }
        private void AddressTextBox_Leave(object sender, EventArgs e)
        {

            if (!AddressValidator(AddressTextBox.Text))
            {
                TextBoxErrorProvider.SetError(AddressTextBox, "Field Required (Address Must Be between 10 and 500  chars)");
            }
            else
            {
                TextBoxErrorProvider.SetError(AddressTextBox, "");
            }

        }

        private bool NationalNoValidator(string N, out bool IsExists)
        {
            if (Person.Mode == Entities.EnMode.Update)
            {
                if (Person.NationalNo == N)
                       IsExists = false;
                else
                    IsExists = DLMS.BusinessLier.Person.PersonLogic.Exists(NationalNo: N.Trim());
            }          
            else
                IsExists = DLMS.BusinessLier.Person.PersonLogic.Exists(NationalNo: N.Trim());
            return (!string.IsNullOrEmpty(N) && !(N.Length < 6) && !IsExists);
        }
        private void NationalNotextbox_Leave(object sender, EventArgs e)
        {

            if (!NationalNoValidator(NationalNotextbox.Text, out bool IsExists))
            {
                string ER = IsExists ? "This National Number is Exixts\n" : "National Number Must Be >6 characters\n";
                TextBoxErrorProvider.SetError(NationalNotextbox, ER);
            }
            else
            {
                TextBoxErrorProvider.SetError(NationalNotextbox, "");
            }
        }


        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender != null && HasProfilePicture == false)
            {
                Guna2RadioButton radio = (Guna2RadioButton)sender;
                if (radio.Name.ToLower() == "maleradiobutton")
                {
                    AlternativeImage(0);
                }
                else if (radio.Name.ToLower() == "femaleradiobutton")
                {
                    AlternativeImage(1);
                }
            }
        }

        private void FillTheObject()
        {

            Person.FirstName = FirstNametextBox.Text.Trim();
            Person.SecondName = SecondNametextBox.Text.Trim();
            Person.ThirdName = ThirdNametextBox.Text.Trim();
            Person.LastName = LastNametextBox.Text.Trim();
            Person.NationalNo = NationalNotextbox.Text.Trim();
            Person.Email = EmailTextBox.Text.Trim();
            Person.Phone = PhoneTextBox.Text.Trim();
            Person.Address = AddressTextBox.Text.Trim();
            Person.DateOfBirth = DateTimePicker.Value;
            Person.Gender = MaleRadioButton.Checked ? (byte)0 : (byte)1;
            if(Person.ImagePath != UserPicture.Tag?.ToString())
                   Person.ImagePath = UserPicture.Tag?.ToString() ?? "";
            Person.NationalityCountryID =Convert.ToInt16(CountriesBox.SelectedValue);

        }
        private void DeletePreviousPicture()
        {
            DLMS.BusinessLier.Person.PersonLogic.DeletePersonPicture(Person.ImagePath);
        }
        public bool Save()
        {
            string Errors = "";
            if (!NamesValidator(FirstNametextBox.Text))
            {
                Errors += "FirstName : Field Required (between 2 and 20  chars )\n";
            }
            if (!NamesValidator(SecondNametextBox.Text))
            {
                Errors += "SecondName : Field Required (between 2 and 20  chars )\n";
            }
            if ( ThirdNametextBox.Text!="" && !NamesValidator(ThirdNametextBox.Text))
            {
                Errors += "ThirdName : Third Name (between 2 and 20  chars )\n";
            }
            if (!NamesValidator(LastNametextBox.Text))
            {
                Errors += "LastName : Field Required (between 2 and 20  chars )\n";
            }

            if (!EmailValidator(EmailTextBox.Text))
            {
                Errors += "Email :Field Required (Set a Valid Email Format and Length<=50)\n";
            }
            if (!NationalNoValidator(NationalNotextbox.Text, out bool IsExists))
            {
                Errors += IsExists ? "This National Number is Exixts\n" : "National Number Must Be >=6 characters\n";
            }
            if (!PhoneValidator(PhoneTextBox.Text))
            {
                Errors += "Phone Number :Field Required (between 2 and 20  chars)\n";
            }
            if (!AddressValidator(AddressTextBox.Text))
            {
                Errors += "Address Must Be between(20 and 500 characters)\n";
            }
            if (CountriesBox.SelectedIndex == -1 && CountriesBox.SelectedValue == null)
            {
                Errors += "Please Select A country\n";
            }
            if (MaleRadioButton.Checked == false && FemaleRadioButton.Checked == false)
            {
                Errors += "Please Check A Gender (No Gays Here)\n";
            }
            if (Errors == "")
            {
                string Operation = Person.Mode == Entities.EnMode.Update ? "Update" : "Add";

                DialogResult result = MessageBox.Show($"Are you sure you want to {Operation} that person", "Confirmation", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {
                    if (Person.Mode == Entities.EnMode.Update && Person.ImagePath != "")
                        DeletePreviousPicture();
                    FillTheObject();
                    bool Saveresult = DLMS.BusinessLier.Person.PersonLogic.Save(Person, out int NewPersonID);

                    if (NewPersonID == -1 && Person.Mode == Entities.EnMode.AddNew || Saveresult == false)
                    {
                        MessageBox.Show($"Failed to {Operation} person Please Try Again and if the the error persists contact the it team",
                            "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (Saveresult)
                    {
                        MessageBox.Show($"Person was {Operation}ed SuccessFully", "Operation Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        // if the output id changed there so its added and we have to assign the new id;
                        if(NewPersonID != -1)
                        {
                            Person.PersonId = NewPersonID;
                        }                      
                        SendSignalToForm?.Invoke(NewPersonID);

                        return true;
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Errors))
                {
                    MessageBox.Show("Please fill in the following fields:\n" + Errors,
                        "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            return false;
        }
        private void SetImgLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog Opener = new OpenFileDialog();
            Opener.Filter = "Images |*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tif;*.tiff";
            Opener.Title = "Select An Profile Picture";
            Opener.Multiselect = false;
            if (Opener.ShowDialog() == DialogResult.OK)
            {
                string Path = Opener.FileName;
                if (!FillPicture(Path))
                {
                    MessageBox.Show("Image Not Set (Try Again)!", "Picture Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void RemoveImglinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (UserPicture.Image != null && Person?.Mode == Entities.EnMode.Update)
            {
                UserPicture.Image.Dispose();
                UserPicture.Image = null;
                DLMS.BusinessLier.Person.PersonLogic.DeletePersonPicture(Person.ImagePath);
                Person.ImagePath = "";
            }

            UserPicture.Tag = "";
            this.HasProfilePicture = false;
            this.SetImglinkLabel.Visible = true;
            this.RemoveImglinkLabel.Visible = false;
            AlternativeImage(Person.Gender);

        }


        private void ButtonSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }
        private void lButtonCance_Click(object sender, EventArgs e)
        {
            string Operation = Person.Mode == Entities.EnMode.AddNew ? "Add New Person" : "Update Person Info";

            DialogResult result = MessageBox.Show($"Are you sure you want to cancel this operation:({Operation})",
                  "Cancel Operation", MessageBoxButtons.OKCancel,
                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.OK)
            {
                SendSignalToFormToClose?.Invoke();
            }

        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
           this.Cursor = Cursors.Default;

        }

        private void NametextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void PhoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(e.KeyChar == '+') && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EmailTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            int Ascii = (int)ch;
            bool IsLatin = Ascii >= 65 && Ascii <= 90 || Ascii >= 97 && Ascii <= 122;
            bool IsDigit = Ascii >= 48 && Ascii <= 57;
            if (IsLatin || IsDigit || ch == '@' || ch == '.' || ch == '_' || ch == '-' || char.IsControl(ch))
            {
                return;
            }
            e.Handled = true;

        }

        private void PersonUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                ButtonSave_Click(sender, e);
            }


        }
    }
}
