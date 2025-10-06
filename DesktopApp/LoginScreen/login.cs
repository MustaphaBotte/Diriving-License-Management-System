using DLMS.BusinessLier;
using DLMS.EntitiesNamespace;


using Guna.UI2.WinForms;
using System.Text.Json;
using System.Text;
namespace DesktopApp.LoginScreen
{
    public partial class LoginFrm : Form
    {
        private MainForm DashBoard = null;
        private bool Subscription = false;
        private int UserId = -1;
        public LoginFrm()
        {
            InitializeComponent();
            FillTheStoredUserInfo();

        }
        private void MainFormClosed(object? sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        private void MainFormHided()
        {
            this.Show();
        }
        private void SignInButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void SignInButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void usernameTextbox_Leave(object sender, EventArgs e)
        {
            Guna2TextBox obj = (Guna2TextBox)sender;
            if (obj.Text == "")
            {
                errorProvider1.SetError(obj, "Please Fill This Field");
                return;
            }
            errorProvider1.SetError(obj, null);

        }

        private void FillTheStoredUserInfo()
        {
            Entities.ClsUser? user = DesktopApp.LocalCredential.ClsLocalCredential.GetTheStoredUser();
            if (user != null)
            {
                usernameTextbox.Text = user.UserName;
                passwordTextbox.Text = user.PassWord;
                RememberMeCheck.Checked = true;
            }
        }


        private void SignIn(string username, string password, bool RememberMe)
        {
            Entities.ClsUser? user = DesktopApp.LocalCredential.ClsLocalCredential.GetUser(username, password, RememberMe);
            if (user != null)
            {
                this.UserId = user.UserId;
                if (!user.IsActive)
                {
                    MessageBox.Show("Your Account is Suspended Please Contact Your Administrator",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (DashBoard == null)
                {
                    DashBoard = new MainForm();
                    DashBoard.FormClosed += MainFormClosed;
                    DashBoard.ManageFormHide += MainFormHided;
                    Subscription = true;
                }
                DashBoard.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show("Wrong UserName or Password",
                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.usernameTextbox.Focus();
            }

        }
        private void SignInButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextbox.Text.Trim();
            string password = passwordTextbox.Text.Trim();
            bool RememberMe = RememberMeCheck.Checked;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Plesa Fill The UserName And PassWord Fields",
                    "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SignIn(username, password, RememberMe);
        }

        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassword.Checked)
            {
                passwordTextbox.PasswordChar = '\0'; return;
            }
            passwordTextbox.PasswordChar = '*';
        }
        private void SignUpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpFrm Frm = new SignUpFrm();
            Frm.OnUserCreated += (Entities.ClsUser user) =>
            {
                this.usernameTextbox.Text = user.UserName;
                this.passwordTextbox.Text = user.PassWord;
                this.RememberMeCheck.Checked = true;
                SignInButton.PerformClick();
            };
            if (!Frm.IsDisposed)
                Frm.ShowDialog();
        }

        private void guna2ImageRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
