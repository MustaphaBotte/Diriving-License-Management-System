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
            this.CurrentUser = UserLogic.FindUserByIdOrUser(UserId);

        }

        private void CancelButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void CancelButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }


        private void CurrentPassTextBox_Leave(object sender, EventArgs e)
        {
            if (CurrentUser == null)
                return;

            Guna2TextBox Obj = (Guna2TextBox)sender;
            if (Obj.Text != this.CurrentUser?.PassWord)
            {
                errorProvider1.SetError(Obj, "Wrong password please try again!");
                return;
            }
            errorProvider1.Clear();

        }
        private void PasswordTextBox_Leave(object sender, EventArgs e)
        {
            if (CurrentUser == null)
                return;
            Guna2TextBox Obj = (Guna2TextBox)sender;
            if (Obj.Text.Length < 4 || Obj.Text.Length > 20)
            {
                errorProvider1.SetError(Obj, "password length must has length between 4 and 20 chars.");
                return;
            }
            if (Obj.Text == CurrentUser.PassWord)
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
            if (Obj.Text != PasswordTextBox.Text)
            {
                errorProvider1.SetError(Obj, "The confirm password not match!");
                return;
            }
            errorProvider1.Clear();
        }
        private void ClearInputs()
        {
            CurrentPassTextBox.Text = "";
            PasswordTextBox.Text = "";
            ConfirmPasswordTextBox.Text = "";
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.CurrentUser == null)
            {
                MessageBox.Show("Error while searching for the user please try again" +
                    "and if the problem persists please contact your admin.", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string Errors = "";
            if (CurrentPassTextBox.Text != this.CurrentUser?.PassWord)
                Errors += "Current password not match\n";

            if (PasswordTextBox.Text.Length < 4 || PasswordTextBox.Text.Length > 20)
                Errors += "New password length must has length between 4 and 20 chars\n";

            if (ConfirmPasswordTextBox.Text != PasswordTextBox.Text)
                Errors += "Confirm Password not macth\n";

            if (Errors != "")
            {
                MessageBox.Show($"Please check those issues :\n{Errors}", "Data Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = MessageBox.Show("Are you sure you want to change the password", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (DialogResult == DialogResult.OK)
            {
                this.CurrentUser.PassWord = ConfirmPasswordTextBox.Text;
                bool result = UserLogic.Save(CurrentUser, out int Id);
                if (result)
                {
                    MessageBox.Show("Password changed", "Operation Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show("Password Not changed please try again", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
