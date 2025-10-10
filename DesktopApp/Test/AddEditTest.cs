using DLMS.BusinessLier;
using DLMS.EntitiesNamespace;
using static DLMS.EntitiesNamespace.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace DesktopApp.VisionTest
{
    public partial class AddEditTest : Form
    {
        private int TestTypeID=-1;
        private int Loc_DLA_ID = -1;

        private DLMS.EntitiesNamespace.Entities.ClsTestAppointment CurrentAppointment = new DLMS.EntitiesNamespace.Entities.ClsTestAppointment();
        enum TestMode { ScheduleTest = 1, ScheduleRetakeTest = 2 ,EditTest=3};
        private TestMode Mode;
        public delegate void Adding_SendSignalTorefreshTheFrid(int NewAppointmentID);
        public event Adding_SendSignalTorefreshTheFrid adding_ReadyToRefresh = delegate {};

        public delegate void Edited_SendSignalTorefreshTheFrid(DateTime newdate);
        public event Edited_SendSignalTorefreshTheFrid Editing_ReadyToRefresh = delegate { };

        
        public AddEditTest(int Loc_DLA_ID ,int TestTypeID ,int AppointmentID=-1,bool IsEditMode=false)
        {
            if (IsEditMode && AppointmentID > 0)
            {
                this.CurrentAppointment = DLMS.BusinessLier.Test.Testlogic.GetTestAppointmentBYID(AppointmentID);
                if(CurrentAppointment==null)
                {
                    MessageBox.Show("We cannot update that appointment date in the moment please refresh and try again?", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                this.Mode = TestMode.EditTest;
            }
            this.Loc_DLA_ID = Loc_DLA_ID;
            this.TestTypeID = TestTypeID;          
            InitializeComponent();
        }
        private void ChangeMode()
        {
            if (this.Mode == TestMode.ScheduleTest)
            {
                this.TestLabel.Visible = true;
                this.RetakeTestLabel.Visible = false;
                return;
            }
            this.TestLabel.Visible = false;
            this.RetakeTestLabel.Visible = true;
        }
        private void SetTestPicture()
        {
            if (this.TestTypeID == 1)
            {
                this.Text = "Take Vision Test ";
                this.guna2PictureBox1.BackgroundImage = Properties.Resources.icons8_vision_100;return;
            }
            if (this.TestTypeID == 2)
            {
                this.Text = "Take Writing Test ";
                this.guna2PictureBox1.BackgroundImage = Properties.Resources.icons8_main_qui_écrit_100; return;
            }
            if (this.TestTypeID == 3)
            {
                this.Text = "Take Street Test ";
                this.guna2PictureBox1.BackgroundImage = Properties.Resources.icons8_au_volant_64; return;
            }
            else
            {
                this.Text = "Error while loading the form ";
                this.guna2PictureBox1.BackgroundImage = Properties.Resources.icons8_point_d_interrogation_100;
            }
        }
        private void FillTestInfo()
        {
            Entities.ClsLocDriApplication? DriLicInfo = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetLocDriLicAppInfo(this.Loc_DLA_ID);
            if (DriLicInfo == null)
            {
                MessageBox.Show("We can't show the local driving application details right now please refresh and try again", "internal error",
                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                this.Dispose();
                return;
            }
            this.Loc_DLA_IDLbl.Text = DriLicInfo.LocDriApplicationID.ToString();
            this.ClassTitleLbl.Text = DriLicInfo.LicenseClassInfo?.ClassName;
            this.FullNameLbl.Text = DriLicInfo.ApplicantPersonInfo?.FullName;
            this.LocAppDate.MinDate = DateTime.Now;
            if(this.Mode == TestMode.EditTest)
            {
                DateTime? Date = DLMS.BusinessLier.Test.Testlogic.GetTestAppointmentBYID(this.CurrentAppointment.TestAppointmentId)?.TestAppointmentDate;
                this.LocAppDate.Value = this.Mode == TestMode.EditTest ? Date != null && Date > LocAppDate.MinDate ? Date.Value : DateTime.Now : DateTime.Now;
            }
            else
            this.LocAppDate.Value = DateTime.Now;
            this.FeesLbl.Text = DLMS.BusinessLier.Test.Testlogic.GetTestFees(this.TestTypeID).ToString();
            this.TrialLbl.Text = DLMS.BusinessLier.Test.Testlogic.FailingCount(DriLicInfo.LocDriApplicationID, this.TestTypeID).ToString();
            this.Mode = TestMode.ScheduleTest;
            this.RetakeTestGroupBox.Visible = false;
            ChangeMode();
        }
        private void FillRetakeTestInfo()
        {
            decimal TestFees = DLMS.BusinessLier.Test.Testlogic.GetTestFees(this.TestTypeID);
            decimal AppFees = DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(Entities.ClsApplication.enApplicationType.RetakeTest);
            decimal totalFees = TestFees + AppFees;

            this.AppFees.Text = AppFees.ToString();
            this.TestFeesLbl.Text = TestFees.ToString();
            this.TotalLbl.Text = totalFees.ToString();
            DLMS.EntitiesNamespace.Entities.ClsTest? Test = DLMS.BusinessLier.Test.Testlogic.GetTestByAppointmentID(this.CurrentAppointment.TestAppointmentId);
            this.VisTestIdLbl.Text =Test!=null ? Test.TestID.ToString():"N/A";
            //we will not reach that function until his failed before
            this.Mode = TestMode.ScheduleRetakeTest;
            this.RetakeTestGroupBox.Visible = true;
            this.AppID.Text = this.CurrentAppointment.RetakeApplicationID ==null?"N/A" : this.CurrentAppointment.RetakeApplicationID.ToString();

            ChangeMode();
        }
        private void LockAndShowTestResult()
        {
            this.WarningLabel.Visible = true;
            this.ResultInfolabel.Visible = true;
            this.Resultlabel.Visible = true;
            this.Resultlabel.Text = DLMS.BusinessLier.Test.Testlogic.IsSucceededBefore(this.Loc_DLA_ID, this.TestTypeID) ? "Succeded" : "Failed";
            this.Resultlabel.ForeColor = this.Resultlabel.Text == "Succeded" ? Color.Green : Color.Red;
            this.RetakeTestGroupBox.Enabled = false;
            this.TestInfoGroupBox.Enabled = false;
            SaveButton.Enabled = false;
            this.Mode = TestMode.EditTest;
        }
        private void AddEditVisionTest_Load(object sender, EventArgs e)
        {
            SetTestPicture();
            if (this.Mode == TestMode.EditTest)
            {
                FillTestInfo();
                if (DLMS.BusinessLier.Test.Testlogic.IsFailedBefore(this.Loc_DLA_ID, this.TestTypeID))
                {
                    FillRetakeTestInfo();
                }
                if (DLMS.BusinessLier.Test.Testlogic.IsAppointmentLocked(this.CurrentAppointment.TestAppointmentId))
                {
                    LockAndShowTestResult();
                }
                this.Mode = TestMode.EditTest;
                return;
            }
            FillTestInfo();
            if (DLMS.BusinessLier.Test.Testlogic.IsFailedBefore(this.Loc_DLA_ID, this.TestTypeID))
            {
                FillRetakeTestInfo();               
            }
            if (DLMS.BusinessLier.Test.Testlogic.IsAppointmentLocked(this.CurrentAppointment.TestAppointmentId))
            {
                LockAndShowTestResult();  
            }

        }

        private void AddAppointment()
        {
            DialogResult Res = MessageBox.Show("Are you sure you want to add this appointment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.No)
            {
                return;
            }
            int? RetakeAppID = null;
            string er = "";
            if (DLMS.BusinessLier.Test.Testlogic.IsFailedBefore(this.Loc_DLA_ID, this.TestTypeID))
            {
                ClsApplication Application = new ClsApplication();
                Application.ApplicantPersonId = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetApplicantPersonIdByLocDriId(this.Loc_DLA_ID);
                Application.ApplicantionDate = DateTime.Now;
                Application.ApplicationStatus = ClsApplication.enApplicationStatus.New;//new;
                Application.ApplicationType = ClsApplication.enApplicationType.RetakeTest; ;//retake test
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = 
                DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(Entities.ClsApplication.enApplicationType.RetakeTest);
                Application.CreatedByUserId = LogedInUser.ClslogedInUser.logedInUser.UserId;
                RetakeAppID = DLMS.BusinessLier.Application.ApplicationLogic.AddNewApplication(Application, ref er);

            }
            if(RetakeAppID<=0)
            {
                MessageBox.Show($"application not added maybe person no longer exists or application type deleted", "Operation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            DLMS.EntitiesNamespace.Entities.ClsTestAppointment appointment = new DLMS.EntitiesNamespace.Entities.ClsTestAppointment();
            appointment.TestAppointmentDate = this.LocAppDate.Value;
            appointment.TestTypeId = this.TestTypeID; 
            appointment.LocDLA_ID = Convert.ToInt32(this.Loc_DLA_IDLbl.Text);
            appointment.PaidFees = Mode == TestMode.ScheduleRetakeTest ? Convert.ToDecimal(this.FeesLbl.Text) + 5 : Convert.ToDecimal(this.FeesLbl.Text);
            appointment.CreatedByUserId = DesktopApp.LogedInUser.ClslogedInUser.logedInUser.UserId;
            appointment.IsLocked = false;
            appointment.RetakeApplicationID = RetakeAppID;

            int NewVisionTestAppointmentId = DLMS.BusinessLier.Test.Testlogic.AddNewTestAppointment(appointment);
            if (NewVisionTestAppointmentId > 0)
            {
                this.AppID.Text = appointment.RetakeApplicationID.ToString();
                MessageBox.Show($"Appointment Added succesfylly with id ={NewVisionTestAppointmentId}.", "Operation success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                adding_ReadyToRefresh?.Invoke(NewVisionTestAppointmentId);
                this.Close();
                return;
            }

            if (NewVisionTestAppointmentId == -2)
            {
                MessageBox.Show($"You already Succedd in that test", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); return;
            }
            if (NewVisionTestAppointmentId ==-3)
            {
                MessageBox.Show($"You Must pass the previous test. the rules are :\n VisionTest -->WritingTest -->StreetTest", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); 
                return;
            }
            MessageBox.Show($"Appointment not added please try again and if the error persists please contact your admin.", "Operation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void EditAppointment()
        {
            DialogResult Res = MessageBox.Show("Are you sure you want to edit this appointment date?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.No)
            {
                return;
            }
            DateTime NewDate = new DateTime(LocAppDate.Value.Year, LocAppDate.Value.Month, LocAppDate.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            bool Result = DLMS.BusinessLier.Test.Testlogic.EditTestAppointmentDateByAppointmentID(this.CurrentAppointment.TestAppointmentId, NewDate);
            if (Result)
            {
                MessageBox.Show($"Appointment date updated succesfylly", "Operation success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Editing_ReadyToRefresh?.Invoke(NewDate);
                this.Close();
                return;
            }
            MessageBox.Show($"Appointment date not updetd please try again and if the error persists please contact your admin.", "Operation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.Mode == TestMode.EditTest)
            {
                EditAppointment();
                return;
            }
            AddAppointment();
        }
        private void guna2Button2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void guna2Button2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
 
    }
}
