using DLMS.EntitiesNamespace;
using DLMS.BusinessLier;
using DLMS.BusinessLier.Person;
using Guna.UI2.WinForms;
using DLMS.BusinessLier.User;
using DesktopApp.ManagePerson;
namespace DesktopApp.ManageUser
{
    public partial class Add_edit_UserFrm : Form
    {
        Entities.ClsUser User = new Entities.ClsUser();
        Entities.ClsPerson? Person = new Entities.ClsPerson();

        public delegate void SignaltoRefresh();
        public event SignaltoRefresh SendSignaltoRefresh = delegate { };

        public Add_edit_UserFrm()
        {
            InitializeComponent();
            this.FormTitle.Text = "Add New User";
        }
        public Add_edit_UserFrm(int PersonID)
        {
            InitializeComponent();
            SearchForPerson(PersonID,alreadyAUser:true);
        }

        private void FillTheUserForm()
        {
            UserIdLbl.Text = User.UserId.ToString();
            UsernameTextBox.Text = User.UserName;
            PasswordTextBox.Text = User.PassWord;
            ConfirmPasswordTextBox.Text = User.PassWord;
            StatucCheck.Checked = User.IsActive;
        }
        public void SearchForPerson(int ID = -1, string NationalNo = "", bool alreadyAUser = false)
        {
            if (ID == -1 && string.IsNullOrEmpty(NationalNo))
                return;
            bool PrsnExitst = PersonLogic.Exists(ID, NationalNo);
            if (!PrsnExitst)
            {
                string attribut = ID == -1 ? "National Number" : "ID";
                object Value = ID == -1 ? NationalNo : ID;

                MessageBox.Show($"Person With {attribut} : {Value} Does Not Exists In The System",
                   "Invalid Info", MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
                return;
            }
            PersonControl.FillDataInControl(ID, NationalNo);
            if (PersonControl.IsControlFilled)
            {
                this.Person = PersonControl.Person;
                this.NextButton.Enabled = true;
                ClearUserAndPassForm();
                User = new Entities.ClsUser();
                ChangeTheModeOfForm();
            }
            if (alreadyAUser)
            {
                this.FormTitle.Text = "Edit User Info";
                FilterGroupBox1.Enabled = false;
                Entities.ClsUser? User = UserLogic.FindUserByPersonID(ID);
                if (User != null)
                {
                    this.User = User;
                    ChangeTheModeOfForm();
                    FillTheUserForm();
                }
            }

        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            string Filter = FilterChoices.SelectedItem?.ToString()?.ToLower() ?? "";
            if (Filter == "")
            {
                return;
            }


            if (Filter == "personid")
            {
                int ID = int.TryParse(FilterValueTextBox.Text.ToString(), out int OutPut) ? OutPut : 0;
                if (ID <= 0)
                {
                    MessageBox.Show("please enter a valid id (Numbers Only And Positive)", "Invalid Id", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    return;
                }
                SearchForPerson(ID);
            }
            if (Filter == "national_no")
            {
                string NationNo = !string.IsNullOrEmpty(FilterValueTextBox.Text) ? FilterValueTextBox.Text : "";
                if (NationNo == "")
                {
                    MessageBox.Show("please Fill the National Number Field ", "Invalid National Number", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    return;
                }
                SearchForPerson(NationalNo: NationNo);
            }
        }

        private void ClearUserAndPassForm()
        {

            UsernameTextBox.Text = "";
            PasswordTextBox.Text = "";
            ConfirmPasswordTextBox.Text = "";
            UserIdLbl.Text = "???";
            StatucCheck.Checked = true;
        }
        private void NextButton_Click(object sender, EventArgs e)
        {

            PagesTab.SelectedIndex = 1;
        }


        private void UsernameTextBox_Leave(object sender, EventArgs e)
        {
            Guna2TextBox obj = (Guna2TextBox)sender;
            if (obj.Text.Length < 4 || obj.Text.Length > 20)
            {
                errorProvider1.SetError(obj, "username pass length must has length between 4 and 20 chars");
                return;
            }
            if (UserLogic.Exists(Username: obj.Text))
            {
                errorProvider1.SetError(obj, "Username exists please choose another one");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void PasswordTextBox_Leave(object sender, EventArgs e)
        {
            Guna2TextBox obj = (Guna2TextBox)sender;
            if (obj.Text.Length < 4 || obj.Text.Length > 20)
            {
                errorProvider1.SetError(obj, "password length must has length between 4 and 20 chars");
                return;
            }
            else
            {
                errorProvider1.Clear();

            }
        }

        private void ConfirmPasswordTextBox_Leave(object sender, EventArgs e)
        {
            Guna2TextBox obj = (Guna2TextBox)sender;
            if (obj.Text != PasswordTextBox.Text)
            {
                errorProvider1.SetError(obj, "The confirm password not match");
                return;
            }
            errorProvider1.Clear();
        }

        private void ChangeTheModeOfForm()
        {
            if (User.Mode == Entities.EnMode.Update)
                this.ActionNameOfUser.Text = "Update User Info";
            if (User.Mode == Entities.EnMode.AddNew)
                this.ActionNameOfUser.Text = "Add New User";

        }
        private bool Save()
        {


            bool result = UserLogic.Save(User, out int ID);
            if (result)
            {
                // if the id is not -1 so its added a new user so we have to assign the id
                if (ID != -1)
                {
                    User.UserId = ID;
                    return true;
                }
                //reach here if the mode update 
                return true;
            }
            return false;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string usermane = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            string Cofpassword = ConfirmPasswordTextBox.Text;
            bool IsActive = StatucCheck.Checked;

            if (usermane.Length < 4 || usermane.Length > 20 || password.Length < 4 || password.Length > 20)
            {
                MessageBox.Show("please fill the fields (user and pass length must has length between 4 and 20 chars)", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }
            if (password != Cofpassword)
            {
                MessageBox.Show("The confirm password not match", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }
            if (Person == null)
            {
                MessageBox.Show("something wrong please go back and find the person again", "Unkown Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }
            User.UserName = usermane;
            User.PersonId = this.Person.PersonId;
            User.PassWord = password;
            User.IsActive = IsActive;
            string Operation = User.Mode == Entities.EnMode.AddNew ? "Add New User" : "Edit User Info";

            DialogResult = MessageBox.Show($"are you sure you want to do this operation?", "Confirmation",
                  MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (DialogResult == DialogResult.Cancel)
            {
                return;
            }
            if (User.Mode == Entities.EnMode.AddNew)
            {
                if (UserLogic.ExistsByPersonID(User.PersonId))
                {
                    MessageBox.Show($"The person with ID= {User.PersonId} already is a user please choose or create another person.", "integrity violation",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (this.Save())
            {
                this.UserIdLbl.Text = User.UserId.ToString();
                ChangeTheModeOfForm();
                MessageBox.Show($"The Operation Of ({Operation}) ended with success.\n The User Id :{User.UserId}", "Operation success",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                SendSignaltoRefresh?.Invoke();
                return;
            }
            else
            {
                MessageBox.Show($"The Operation Of ({Operation}) ended with Erros. please try again and  if the error persists" +
                    $"please contact your admin.", "Operation failed",
                  MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            PagesTab.SelectedIndex = 0;
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void GetTheAddedPersonIdFromTheChildForm(int PersonID)
        {
            SearchForPerson(PersonID);
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddEditPersonFrm Frm = new AddEditPersonFrm();
            Frm.SendTheAddedPersonID += GetTheAddedPersonIdFromTheChildForm;
            Frm.ShowDialog();

        }

        private void FilterValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (FilterChoices.SelectedItem == null)
                return;

            string? choice = FilterChoices.SelectedItem.ToString()?.ToLower();
            if (choice != "" && (char)13 == e.KeyChar)
                FindButton.PerformClick();

            if (choice == "personid")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

            }
        }
    }

}