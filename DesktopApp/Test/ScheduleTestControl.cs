using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLMS.EntitiesNamespace;
using static DLMS.EntitiesNamespace.Entities;

namespace DesktopApp.Test
{
    public partial class ScheduleTestControl : UserControl
    {
        private int Loc_DLA_ID = -1;

        private ClsTestAppointment CurrentAppointment = new ClsTestAppointment();
        enum _EnCreationMode { FirstTime = 1, ScheduleRetakeTest = 2 };
        private enum _TestMode { AddNew = 1, Update = 2 };

        _EnCreationMode _CreationMode = _EnCreationMode.FirstTime;
        _TestMode _Mode = _TestMode.AddNew;

        ClsTestType.EnTestType _TestTypeID;
        public Entities.ClsTestType.EnTestType EnTestType
        {
            set
            {
                this._TestTypeID = value;
                SetTestPicture();
            }
            get
            {
                return _TestTypeID;
            }
        }

        public delegate void Adding_SendSignalTorefreshTheFrid(int NewAppointmentID);
        public event Adding_SendSignalTorefreshTheFrid OnAddNewAppointment = delegate { };

        public delegate void Edited_SendSignalTorefreshTheFrid(ClsTestAppointment Appointment);
        public event Edited_SendSignalTorefreshTheFrid OnEditAppointment = delegate { };
        public ScheduleTestControl()
        {
            InitializeComponent();
        }
        private void SetTestPicture()
        {
            if (this._TestTypeID == ClsTestType.EnTestType.VisionTest)
            {
                this.Text = "Take Vision Test ";
                this.guna2PictureBox1.BackgroundImage = Properties.Resources.icons8_vision_100; return;
            }
            if (this._TestTypeID == ClsTestType.EnTestType.WrittenTest)
            {
                this.Text = "Take Writing Test ";
                this.guna2PictureBox1.BackgroundImage = Properties.Resources.icons8_main_qui_écrit_1001; return;
            }
            if (this._TestTypeID == ClsTestType.EnTestType.StreetTest)
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
        private void ChangeTitle()
        {
            if (this._CreationMode == _EnCreationMode.FirstTime)
            {
                this.TestLabel.Visible = true;
                this.RetakeTestLabel.Visible = false;
                return;
            }
            this.TestLabel.Visible = false;
            this.RetakeTestLabel.Visible = true;
        }
        private void SetPictureAndTitles()
        {
            SetTestPicture();
            ChangeTitle();
        }
        public void AddNewAppointment(int Loc_DLA_ID, ClsTestType.EnTestType TestTypeID)
        {
            this._Mode = _TestMode.AddNew;
            this._TestTypeID = TestTypeID;
            this.Loc_DLA_ID = Loc_DLA_ID;
            FillTestInfo();
            if (DLMS.BusinessLier.Test.Testlogic.IsFailedBefore(this.Loc_DLA_ID, (int)this._TestTypeID))
            {
                FillRetakeTestInfo();
                this._CreationMode = _EnCreationMode.ScheduleRetakeTest;
            }
            else
            {
                this.RetakeTestGroupBox.Visible = false;
                this._CreationMode = _EnCreationMode.FirstTime;
            }

            SetPictureAndTitles();

        }
        public void EditAppointment(int AppointmentID)
        {
            this.CurrentAppointment = DLMS.BusinessLier.Test.Testlogic.GetTestAppointmentBYID(AppointmentID);
            if (CurrentAppointment == null)
            {
                MessageBox.Show("We cannot update that appointment date in the moment please refresh and try again?", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.SaveButton.Enabled = false;
                return;
            }
            this._Mode = _TestMode.Update;
            this._TestTypeID = (ClsTestType.EnTestType)CurrentAppointment.TestTypeId;
            this.Loc_DLA_ID = CurrentAppointment.LocDLA_ID;
            FillTestInfo();
            if (DLMS.BusinessLier.Test.Testlogic.IsFailedBefore(this.Loc_DLA_ID, (int)this._TestTypeID))
            {
                FillRetakeTestInfo();
                this._CreationMode = _EnCreationMode.ScheduleRetakeTest;
            }
            else
                this.RetakeTestGroupBox.Visible = false;

            if (DLMS.BusinessLier.Test.Testlogic.IsAppointmentLocked(this.CurrentAppointment.TestAppointmentId))
            {
                LockAndShowTestResult();
            }
            SetPictureAndTitles();
        }
        private void FillTestInfo()
        {
            Entities.ClsLocDriApplication? DriLicInfo = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetLocDriLicAppInfo(this.Loc_DLA_ID);
            if (DriLicInfo == null)
            {
                MessageBox.Show("We can't show the local driving application details right now please refresh and try again", "internal error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
                return;
            }
            this.Loc_DLA_IDLbl.Text = DriLicInfo.LocDriApplicationID.ToString();
            this.ClassTitleLbl.Text = DriLicInfo.LicenseClassInfo?.ClassName;
            this.FullNameLbl.Text = DriLicInfo.ApplicantPersonInfo?.FullName;
            this.LocAppDate.MinDate = DateTime.Now;
            if (this._Mode == _TestMode.Update)
            {
                DateTime? Date = DLMS.BusinessLier.Test.Testlogic.GetTestAppointmentBYID(this.CurrentAppointment.TestAppointmentId)?.TestAppointmentDate;
                this.LocAppDate.Value = Date != null && Date > LocAppDate.MinDate ? Date.Value : DateTime.Now;
            }
            else
                this.LocAppDate.Value = DateTime.Now;

            this.FeesLbl.Text = DLMS.BusinessLier.Test.Testlogic.GetTestFees((int)this._TestTypeID).ToString();
            this.TrialLbl.Text = DLMS.BusinessLier.Test.Testlogic.TrialCountPerTest(DriLicInfo.LocDriApplicationID, (int)this._TestTypeID).ToString();
        }
        private void FillRetakeTestInfo()
        {
            this.RetakeTestGroupBox.Visible = true;
            decimal TestFees = DLMS.BusinessLier.Test.Testlogic.GetTestFees((int)this._TestTypeID);
            decimal AppFees = DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(Entities.ClsApplication.enApplicationType.RetakeTest);
            decimal totalFees = TestFees + AppFees;

            this.AppFees.Text = AppFees.ToString();
            this.TotalLbl.Text = totalFees.ToString();
            ClsTest? Test = DLMS.BusinessLier.Test.Testlogic.GetTestByAppointmentID(this.CurrentAppointment.TestAppointmentId);
            this.TestTypetitleLabel.Text = this._TestTypeID.ToString()+ " ID ";
            this.VisTestIdLbl.Text = Test != null ? Test.TestID.ToString() : "N/A";
            //we will not reach that function until his failed before
            this.RetakeTestGroupBox.Visible = true;
            this.AppID.Text = this.CurrentAppointment.RetakeApplicationID == null ? "N/A" : this.CurrentAppointment.RetakeApplicationID.ToString();

        }
        private void LockAndShowTestResult()
        {
            this.WarningLabel.Visible = true;
            this.ResultInfolabel.Visible = true;
            this.Resultlabel.Visible = true;
            this.Resultlabel.Text = DLMS.BusinessLier.Test.Testlogic.IsSucceededBefore(this.Loc_DLA_ID, (int)this._TestTypeID) ? "Succeded" : "Failed";
            this.Resultlabel.ForeColor = this.Resultlabel.Text == "Succeded" ? Color.Green : Color.Red;
            this.RetakeTestGroupBox.Enabled = false;
            this.TestInfoGroupBox.Enabled = false;
            SaveButton.Enabled = false;
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
            if (this._CreationMode == _EnCreationMode.ScheduleRetakeTest)
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
            // RetakeAppID initialized with null so null never less or equal tp 0
            //condition is true only if the app not saved in business layer
            if (RetakeAppID <= 0)
            {
                MessageBox.Show($"application not added maybe person no longer exists or application type deleted", "Operation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //create the appointment
            ClsTestAppointment appointment = new ClsTestAppointment();
            appointment.TestAppointmentDate = this.LocAppDate.Value;
            appointment.TestTypeId = (int)this._TestTypeID;
            appointment.LocDLA_ID = Convert.ToInt32(this.Loc_DLA_IDLbl.Text);
            appointment.PaidFees = DLMS.BusinessLier.Test.Testlogic.GetTestFees((int)this._TestTypeID);
            appointment.CreatedByUserId = LogedInUser.ClslogedInUser.logedInUser.UserId;
            appointment.IsLocked = false;
            appointment.RetakeApplicationID = RetakeAppID;

            int NewVisionTestAppointmentId = DLMS.BusinessLier.Test.Testlogic.AddNewTestAppointment(appointment);
            if (NewVisionTestAppointmentId > 0)
            {
                this.AppID.Text = appointment.RetakeApplicationID.ToString();
                MessageBox.Show($"Appointment Added succesfylly with id ={NewVisionTestAppointmentId}.", "Operation success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnAddNewAppointment?.Invoke(NewVisionTestAppointmentId);
                return;
            }
            if (NewVisionTestAppointmentId == -2)
            {
                MessageBox.Show($"You already Succedd in that test", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NewVisionTestAppointmentId == -3)
            {
                MessageBox.Show($"You Must pass the previous test. the rules are :\n VisionTest -->WritingTest -->StreetTest", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.WarningLabel.Visible = true;
                this.WarningLabel.Text = $"You Must Pass The {((ClsTestType.EnTestType)appointment.TestTypeId - 1).ToString()}";
                this.WarningLabel.ForeColor = Color.Red;
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
            this.CurrentAppointment.TestAppointmentDate = NewDate;
            bool Result = DLMS.BusinessLier.Test.Testlogic.EditTestAppointmentDateByAppointmentID(this.CurrentAppointment.TestAppointmentId, NewDate);
            if (Result)
            {
                MessageBox.Show($"Appointment date updated succesfully", "Operation success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.OnEditAppointment?.Invoke(CurrentAppointment);
                return;
            }
            MessageBox.Show($"Appointment date not updated please try again and if the problem persists please contact your admin.", "Operation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (this._Mode == _TestMode.Update)
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

    }
}
