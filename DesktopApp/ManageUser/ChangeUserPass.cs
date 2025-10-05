using DLMS.BusinessLier.User;
using DLMS.EntitiesNamespace;
using Guna.UI2.WinForms;

namespace DesktopApp.ManageUser
{
    public partial class ChangeUserPassFrm : Form
    {
        private int UserId = -1;
        private Entities.ClsUser? CurrentUser = new Entities.ClsUser();

        public ChangeUserPassFrm(int UserId)
        {
            InitializeComponent();
            this.UserId = UserId;
        }

        private void ShowUser_Load(object sender, EventArgs e)
        {
            this.showUserInfoControl1.SetUptheControlByUserId(UserId);
            this.CurrentUser = showUserInfoControl1.User;
            if (CurrentUser == null)
            {
                MessageBox.Show("user not found please refresh and try again", "User not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }



        private void CurrentPassTextBox_Leave(object sender, EventArgs e)
        {
            Guna2TextBox CurrentPassText = (Guna2TextBox)sender;
            if (CurrentPassText.Text.Trim() != this.CurrentUser?.PassWord)
            {
                errorProvider1.SetError(CurrentPassText, "Wrong password please try again!");
                return;
            }
            errorProvider1.Clear();
        }
        private void PasswordTextBox_Leave(object sender, EventArgs e)
        {
            if (CurrentUser == null)
                return;
            Guna2TextBox Obj = (Guna2TextBox)sender;
            if (Obj.Text.Trim().Length < 4 || Obj.Text.Trim().Length > 20)
            {
                errorProvider1.SetError(Obj, "password length must has length between 4 and 20 chars.");
                return;
            }
            if (Obj.Text.Trim() == CurrentUser.PassWord)
            {
                errorProvider1.SetError(Obj, "You cant set you previous password as the new password");
                return;
            }
            errorProvider1.Clear();
        }
        private void ConfirmPasswordTextBox_Leave(object sender, EventArgs e)
        {
            if (CurrentUser == null)
                return;

            Guna2TextBox Obj = (Guna2TextBox)sender;
            if (Obj.Text.Trim() != PasswordTextBox.Text.Trim())
            {
                errorProvider1.SetError(Obj, "The confirm password not match!");
                return;
            }
            errorProvider1.Clear();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.CurrentUser == null)
            {
                MessageBox.Show("Error while searching for the user please try again. " +
                    "and if the problem persists please contact your admin.", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          
            if (!this.ValidateChildren())
            {
                MessageBox.Show($"Please check the fields. \n put the mouse over the red icon to see the errors", "Informations not correct", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = MessageBox.Show("Are you sure you want to change the password", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (DialogResult == DialogResult.OK)
            {
                this.CurrentUser.PassWord = ConfirmPasswordTextBox.Text.Trim();
                string errors = "";
                bool result = UserLogic.Save(CurrentUser, out int Id,ref errors);
                if (result)
                {
                    MessageBox.Show("Password changed", "Operation Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show($"Password Not changed dua the following errors \n{errors} \n please try again", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void ClearInputs()
        {
            CurrentPassTextBox.Text = "";
            PasswordTextBox.Text = "";
            ConfirmPasswordTextBox.Text = "";
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CancelButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void CancelButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void CurrentPassTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            Guna2TextBox CurrentPassText = (Guna2TextBox)sender;
            if (CurrentPassText.Text.Trim() != this.CurrentUser?.PassWord)
            {
                errorProvider1.SetError(CurrentPassText, "Wrong password please try again!");
                e.Cancel = true;
                return;
            }
            errorProvider1.Clear();
        }
        private void PasswordTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            Guna2TextBox Obj = (Guna2TextBox)sender;
            if (Obj.Text.Trim().Length < 4 || Obj.Text.Trim().Length > 20)
            {
                errorProvider1.SetError(Obj, "password length must has length between 4 and 20 chars.");
                e.Cancel = true;
                return;
            }
            if (Obj.Text.Trim() == CurrentUser.PassWord)
            {
                errorProvider1.SetError(Obj, "You cant set you previous password as the new password");
                e.Cancel = true;
                return;
            }
            errorProvider1.Clear();
        }
        private void ConfirmPasswordTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            Guna2TextBox Obj = (Guna2TextBox)sender;
            if (Obj.Text.Trim() != PasswordTextBox.Text.Trim())
            {
                errorProvider1.SetError(Obj, "The confirm password not match!");
                e.Cancel = true;
                return;
            }
            errorProvider1.Clear();
        }

       
    }
}
