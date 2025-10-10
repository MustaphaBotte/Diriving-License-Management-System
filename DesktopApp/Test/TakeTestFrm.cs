using DLMS.EntitiesNamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.VisionTest
{
    public partial class TakeTestFrm : Form
    {
        DLMS.EntitiesNamespace.Entities.ClsTestAppointment? appointment = new DLMS.EntitiesNamespace.Entities.ClsTestAppointment();
        int Loc_Driving_Lic_App_ID = -1;
        private bool LockedForm = false;

        public delegate void added_SendSignalTorefreshTheFrid();
        public event added_SendSignalTorefreshTheFrid TestTaked_ReadyToRefresh = delegate { };

    

        public TakeTestFrm(int TestAppointmentID)
        {

            this.appointment = DLMS.BusinessLier.Test.Testlogic.GetTestAppointmentBYID(TestAppointmentID);        
            if(this.appointment==null)
            {
                MessageBox.Show("We cannot load the environment in the moment please refresh and try again?", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            
            InitializeComponent();
        }
        private void SetTestPicture()
        {
            if (appointment.TestTypeId == 1)
            {
                this.TestTitleLabel.Text = "Vision Test";
                this.Text = "Take Vision Test ";
                this.guna2PictureBox1.BackgroundImage = Properties.Resources.icons8_vision_100; return;
            }
            if (appointment.TestTypeId == 2)
            {
                this.Text = "Take Writing Test ";
                this.TestTitleLabel.Text = "Writing Test";
                this.guna2PictureBox1.BackgroundImage = Properties.Resources.icons8_main_qui_écrit_100; return;
            }
            if (appointment.TestTypeId == 3)
            {
                this.TestTitleLabel.Text = "Street Test";
                this.Text = "Take Street Test ";
                this.guna2PictureBox1.BackgroundImage = Properties.Resources.icons8_au_volant_64; return;
            }
            else
            {
                this.TestTitleLabel.Text = "Unknown";
                this.Text = "Error while loading the form ";
                this.guna2PictureBox1.BackgroundImage = Properties.Resources.icons8_point_d_interrogation_100;
            }
        }
        private void FillTestInfo()
        {


            if (appointment == null)
            {
                MessageBox.Show("We can't take that test now due an internal error plesase refresh and try again", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            Entities.ClsLocDriApplication? LocalApplicationInfo = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetLocDriLicAppInfo(appointment?.LocDLA_ID ?? -1);
            if (appointment != null && LocalApplicationInfo!=null)
            {
                this.Loc_DLA_IDLbl.Text = LocalApplicationInfo.LocDriApplicationID.ToString();
                this.ClassTitleLbl.Text = LocalApplicationInfo.LicenseClassInfo?.ClassName;
                this.FullNameLbl.Text = LocalApplicationInfo.ApplicantPersonInfo?.FullName;
                this.TrialLbl.Text = DLMS.BusinessLier.Test.Testlogic.TrialCountPerTest(appointment.LocDLA_ID, appointment.TestTypeId).ToString(); 
                this.DateLabel.Text = appointment.TestAppointmentDate.ToString("yyyy-MM-dd");
                this.FeesLbl.Text = appointment.PaidFees.ToString(); //get it from app table because maybe its a retake test so is possible to that app has +5 dollars
                this.TestIdLabel.Text = "Not Taken Yet";
                Loc_Driving_Lic_App_ID = appointment.LocDLA_ID;

            }
            if (appointment?.IsLocked == true)
            {
                DLMS.EntitiesNamespace.Entities.ClsTest? Test = DLMS.BusinessLier.Test.Testlogic.GetTestByAppointmentID(appointment.TestAppointmentId);
                this.WarningLabel.Visible = true;
                this.TestResultLabel.Visible = true;
                this.LabelOfResultInfo.Visible = true;
                this.TestResultLabel.Text = Test?.TestResult == true ? "Succeded" : "Failed";
                this.TestResultLabel.ForeColor = Test?.TestResult == true ? Color.Green : Color.Red;
                this.TestIdLabel.Text = Test?.TestID.ToString();
                TakeTestGroupBox.Enabled = false;
                this.SaveButton.Enabled = false;
                this.LockedForm = true;
            }
        }

        private void SaveButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void SaveButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void TakeTestFrm_Load(object sender, EventArgs e)
        {
            SetTestPicture();
            FillTestInfo();
        }
        private void AddTest()
        {

            bool TestResult = PassCheckedBox.Checked ? true : false;
            if (this.NotesTextBox.Text.Length > 500)
            {
                MessageBox.Show("Maximum Length of notes is 500 character", "Notes Rule violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!appointment?.IsLocked==true && appointment?.TestAppointmentDate.Date < DateTime.Now.Date)
            {
                MessageBox.Show("The Test Appointment Date Has passed And We Will Lock That Appointment Now", "Date Rules violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DLMS.BusinessLier.Test.Testlogic.LockTestAppointment(this.appointment.TestAppointmentId);
                this.Close();
                return;
            }
            if (appointment?.TestAppointmentDate.Date > DateTime.Now.Date)
            {
                MessageBox.Show("The Test Appointment Has Not Coming Yet Please Respect The Appointments Dates", "Date Rules violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            string Notes = this.NotesTextBox.Text.ToString();
            DLMS.EntitiesNamespace.Entities.ClsTest Test = new DLMS.EntitiesNamespace.Entities.ClsTest();
            Test.TestResult = TestResult;
            Test.Notes = Notes;
            Test.TestAppointmentID = this.appointment.TestAppointmentId;
            Test.CreatedByUserID = DesktopApp.LogedInUser.ClslogedInUser.logedInUser.UserId;
           

            DialogResult Res = MessageBox.Show("Are you sure you want save that test", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.No)
            {
                return;
            }
            int NewTestID = DLMS.BusinessLier.Test.Testlogic.AddNewTest(Test, this.Loc_Driving_Lic_App_ID, appointment.TestTypeId,appointment.RetakeApplicationID,true);
        
            if (NewTestID > 0)
            {
                MessageBox.Show($"Test saved succesfully with ID ={NewTestID}", "Operation Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                this.TestTaked_ReadyToRefresh?.Invoke();
                return;
            }
            if (NewTestID ==-2)
            {
                MessageBox.Show($"You already Succedd in that test", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();                return;
            }
            if (NewTestID == -3)
            {
                MessageBox.Show($"You Must pass the previous test the rules are :\n VisionTest -->WritingTest -->StreetTest", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); return;
            }
            MessageBox.Show($"Test not Added please refresh and try again", "Operation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
      
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.LockedForm)
                return;
            AddTest();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
