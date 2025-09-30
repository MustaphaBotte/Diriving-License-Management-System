using DLMS.BusinessLier.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.ManageUser
{
    public partial class ShowUserInfoFrm : Form
    {
        public ShowUserInfoFrm()
        {
            InitializeComponent();
        }
        private int UserId = -1;
        public ShowUserInfoFrm(int UserId)
        {
            this.UserId = UserId;
            InitializeComponent();
        }

        private void ShowUserInfo_Load(object sender, EventArgs e)
        {
            if (!UserLogic.Exists(UserId))
            {
                this.Close();
                MessageBox.Show("sorry the current user not available .please refresh and try ", "User Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            showUserInfoControl1.SetUptheControlByUserId(UserId);
        }

        private void CancelButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void CancelButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
