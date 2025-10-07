using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLMS.EntitiesNamespace;
using Guna.UI2.WinForms;
namespace DesktopApp.LoginScreen
{
    public partial class SignUpFrm : Form
    {
        public delegate void UserCreated(DLMS.EntitiesNamespace.Entities.ClsUser NewUser);
        public event UserCreated OnUserCreated = delegate { };
        int PersonID = -1;
        public SignUpFrm()
        {
            InitializeComponent();
            DialogResult Res = MessageBox.Show("You have to create a new person to link it with a new user", "Required Step", MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question);
            if (Res == DialogResult.Cancel)
            {
                this.Close();
                return;
            }

        }
        private void CreateUser()
        {
            DialogResult Res = MessageBox.Show($"Person was Created successfully with ID={this.PersonID}.\n" +
                $" are you sure you want to create a new user", "Confirmation", MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question);
            if (Res == DialogResult.Cancel)
            {
                this.Close();
                return;
            }
            DLMS.EntitiesNamespace.Entities.ClsUser NewUser = new Entities.ClsUser();
            NewUser.UserName = usernameTextbox.Text.Trim();
            NewUser.PassWord = passwordTextbox.Text.Trim();
            NewUser.PersonId = this.PersonID;
            NewUser.IsActive = true;
            int UserID = -1;
            string Errors = "";
            if (DLMS.BusinessLier.User.UserLogic.Save(NewUser, out UserID, ref Errors))
            {
                MessageBox.Show($"User created SuccessFully with Id= {UserID}", "operation Success", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                OnUserCreated?.Invoke(NewUser);
                this.Close();
            }
            else
            {
                MessageBox.Show($"User was not created due the following errors:\n{Errors}", "operation Failed", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                this.Close();
            }
        }


        void SignUpButton_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please verify the given information\nput the mouse over the red icon to see the error", "Missing Fields",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CreateUser();
        }

        private void usernameTextbox_Validating(object sender, CancelEventArgs e)
        {
            if (DLMS.BusinessLier.User.UserLogic.Exists(Username: usernameTextbox.Text.Trim()))
            {
                errorProvider1.SetError(usernameTextbox, "Username is taken before");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(usernameTextbox, null);
        }

        private void passwordTextbox_Validating(object sender, CancelEventArgs e)
        {
            string pass = passwordTextbox.Text.Trim();
            if (pass.Length < 4 || pass.Length > 20)
            {
                errorProvider1.SetError(passwordTextbox, "Please enter a password between 4 and 20 characters");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(passwordTextbox, null);
        }

        private void ConfpasswordTextbox_Validating(object sender, CancelEventArgs e)
        {

            if (passwordTextbox.Text.Trim() != ConfpasswordTextbox.Text.Trim())
            {
                errorProvider1.SetError(ConfpasswordTextbox, "Please verify the confirm password");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(ConfpasswordTextbox, null);
        }

        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            Guna2CustomCheckBox Box = (Guna2CustomCheckBox)sender;
            if (Box.Checked)
            {
                if (Box.Tag?.ToString() == "Pass")
                {
                    passwordTextbox.PasswordChar = '\0'; return;
                }
                ConfpasswordTextbox.PasswordChar = '\0'; return;
            }
            if (!Box.Checked)
            {
                if (Box.Tag?.ToString() == "Pass")
                {
                    passwordTextbox.PasswordChar = '*'; return;
                }
                ConfpasswordTextbox.PasswordChar = '*'; return;
            }
        }

        private async Task PrintDeadLine()
        {
            this.TimeLabel.Text = "";
            this.TimeLabel.Visible = true;
            for (short i = 5; i >=0; i--)
            {
                await Task.Delay(1000);
                this.TimeLabel.Text = $"{i}s";
            }
        }
        private void SignUpFrm_Shown(object sender, EventArgs e)
        {
            ManagePerson.AddEditPersonFrm Frm = new ManagePerson.AddEditPersonFrm();
            Frm.SendTheAddedPersonID += (int PrsnID) =>
            {
                this.PersonID = PrsnID;
                Frm.Close();
            };
            Frm.FormClosed += async (object? sender, FormClosedEventArgs e) =>
            {
                if (this.PersonID != -1)
                    return;

                this.ConfpasswordTextbox.Enabled = false;
                this.passwordTextbox.Enabled = false;
                this.usernameTextbox.Enabled = false;
                this.SignUpButton.Enabled = false;
                Warning.Visible = true;
                await PrintDeadLine();
                this.Close();
            };
            Frm.ShowDialog();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {



        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
