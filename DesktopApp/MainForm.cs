using DesktopApp.ManageUser;
using DesktopApp.PeopleManagement;
using DesktopApp.UsersManagement;
using DLMS.EntitiesNamespace;
using DLMS.BusinessLier;
using DesktopApp.ManageTests;
using DesktopApp.ManageApplication;
using DesktopApp.Drivers;
using DesktopApp.InternationalDrivingLicense;
using DesktopApp.ReplaceDamagedOrLostLicense;
using DesktopApp.Detain_Release_License;
using DesktopApp.ApplicationsManagement;

namespace DesktopApp
{
    public partial class MainForm : Form
    {
        public delegate void FormHide();
        public event FormHide ManageFormHide = delegate { };
        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonManagePeople_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void ButtonManagePeople_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

        }

        private void ButtonManagePeople_Click(object sender, EventArgs e)
        {
            PeopleManagementFrm frm = new PeopleManagementFrm();
            frm.ShowDialog();

        }

        private void ButtonAccountSettings_Click(object sender, EventArgs e)
        {
            AccountsettingMenuStrip.Show(Cursor.Position);
        }

        private void signOutButton_Click(object sender, EventArgs e)
        {
            this.ManageFormHide?.Invoke();
            this.Hide();
        }

        private void ButtonManageUsers_Click(object sender, EventArgs e)
        {
            UsersManagement.UsersManagementFrm Frm = new UsersManagementFrm();
            Frm.ShowDialog();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entities.ClsUser? CurrentUser = ClslogedInUser.logedInUser;
            if (CurrentUser == null)
            {
                MessageBox.Show("We cant edit your password right now. try again later", "Internal Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            ChangeUserPassFrm Frm = new ChangeUserPassFrm(CurrentUser.UserId);
            Frm.ShowDialog();

        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entities.ClsUser? CurrentUser = ClslogedInUser.logedInUser;
            if (CurrentUser == null)
            {
                MessageBox.Show("We cant show your info right now. try again later", "Internal Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            ShowUserInfoFrm Frm = new ShowUserInfoFrm(CurrentUser.UserId);
            Frm.ShowDialog();
        }

        private void ButtonApplications_Click(object sender, EventArgs e)
        {
            ApplicationsMenuStrip.Show(Cursor.Position);
        }

        private void AppTypesMenuItem_Click(object sender, EventArgs e)
        {
            Applicatios_Management.ApplicationsManagementFrm Frm = new Applicatios_Management.ApplicationsManagementFrm();
            Frm.Show();

        }

        private void TestTypesMenuItem_Click(object sender, EventArgs e)
        {
            ManageTestTypesFrm Frm = new ManageTestTypesFrm();
            Frm.Show();
        }

        private void manageApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationsManagement.ApplicationsManagementFrm Frm = new ApplicationsManagement.ApplicationsManagementFrm();
            Frm.ShowDialog();
        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditLocalApp Frm = new AddEditLocalApp();
            Frm.ShowDialog();
        }

        private void DriversButton_Click(object sender, EventArgs e)
        {
            ShowDriversFrm Frm = new ShowDriversFrm();
            Frm.ShowDialog();
        }

        private void ManageInternaDrivingLicense_Click(object sender, EventArgs e)
        {
            InternationalDrivingLicense.IssueInternationalDrivingLicenseFrm Frm = new InternationalDrivingLicense.IssueInternationalDrivingLicenseFrm();
            Frm.ShowDialog();
        }

        private void internationalDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueInternationalDrivingLicenseFrm Frm = new IssueInternationalDrivingLicenseFrm();
            Frm.ShowDialog();
        }

        private void renewExpiredLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenewLicense.RenewLicenseFrm Frm = new RenewLicense.RenewLicenseFrm();
            Frm.ShowDialog();
        }

        private void replaceLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplaceLostORDamagedLicFrm Frm = new ReplaceLostORDamagedLicFrm();
            Frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainedLicensesManagementFrm Frm = new DetainedLicensesManagementFrm();
            Frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DetainLicenseFrm Frm = new DetainLicenseFrm();
            Frm.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Release_LicenseFrm Frm = new Release_LicenseFrm();
            Frm.ShowDialog();
        }
        private void RetakeTesttoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ApplicationsManagementFrm Frm = new ApplicationsManagementFrm();
            Frm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            guna2ShadowPanel1.Width = this.Width;
            this.Text += $" (Loged In User: {DLMS.BusinessLier.ClslogedInUser.logedInUser.UserName}";
        }
    }
}
