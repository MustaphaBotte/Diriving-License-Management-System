using DLMS.BusinessLier.User;
using DLMS.EntitiesNamespace;
namespace DesktopApp.User_Control
{
    public partial class showUserInfoControl : UserControl
    {
        private int userid = -1;
        Entities.ClsUser? User = new Entities.ClsUser();
        Entities.ClsPerson? Person =new Entities.ClsPerson();

        public showUserInfoControl()
        {
            InitializeComponent();
        }
       
        public void SetUptheControlByUserId(int UserId)
        {
            this.userid = UserId;
            FillTheUserInfo();
            FillThePersonControl();
        }
        private void FillThePersonControl()
        {
            if(User!=null)
                PersonControl.FillDataInControl(this.User.PersonId);
        }
        private void FillTheUserInfo()
        {
            this.User =  UserLogic.FindUserByIdOrUser(ID: userid); 
            if(this.User !=null)
            {
               
                this.UseridLabel.Text = User.UserId.ToString();
                this.UsernameLabel.Text = User.UserName;
                this.ActiveStatusLabel.Text = User.IsActive ? "Yes" : "No";
            }
            else
            {
                MessageBox.Show("Please refresh and try again ", "internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Form? CurrentForm = this.FindForm();
                if(CurrentForm != null)
                {
                    CurrentForm.Close();
                }
                return;

            }
        }
    }
}
