using DesktopApp.VisionTest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.ScheduleTest
{
    public partial class TestAppointmentFrm : Form
    {
        int LocApplicationID = -1;
        int TestTypeID = -1;
        int SelectedRowIndex = -1;

        public delegate void Changes_SendSignalTorefreshTheFrid();
        public event Changes_SendSignalTorefreshTheFrid OnApplicationInfoChanged = delegate { };

        public TestAppointmentFrm(int LocApplicationID,int TestTypeID)
        {
            this.TestTypeID = TestTypeID;
            this.LocApplicationID = LocApplicationID;
            InitializeComponent();
            applicationInfoControl1.FillTheControlById(LocApplicationID);
        }
        private void FillTheGridByAppointments()
        {
            if (applicationInfoControl1.LocalAppInfo1 == null)
            {
                MessageBox.Show("Local Applicaion not found please refresh and try again", "Internal Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
                return;
            }

             this.LocApplicationID = applicationInfoControl1.LocalAppInfo1.LocDriApplicationID;
            DataTable? Appointmnets = DLMS.BusinessLier.Test.Testlogic.GetAllTestsAppointByLocDLA_ID_andTestId(this.LocApplicationID, this.TestTypeID);
            if (Appointmnets != null)
            {
                foreach (DataRow row in Appointmnets.Rows)
                {
                    int RowIndex = DataGrid.Rows.Add();
                    DataGrid.Rows[RowIndex].Cells["AppointmentID"].Value = row["TestAppointmentID"];
                    DataGrid.Rows[RowIndex].Cells["AppointmentDate"].Value = row["AppointmentDate"];
                    DataGrid.Rows[RowIndex].Cells["PaidFees"].Value = row["PaidFees"];
                    DataGrid.Rows[RowIndex].Cells["CreatedByUserID"].Value = row["CreatedByUserID"];
                    DataGrid.Rows[RowIndex].Cells["IsLocked"].Value = row["IsLocked"];
                }
                RowsCountLabel.Text = DataGrid.Rows.Count.ToString();
            }
            else if (Appointmnets == null)
            {
                MessageBox.Show("No Test Appointment Found!", "Set Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void SetFormTitleAndPicture()
        {
            if (this.TestTypeID == 1)
            {
                this.Text = "Vision Test Appointment";
                this.TestTypeTitleLabel.Text = "Vision Test Appointment";
                this.guna2PictureBox1.BackgroundImage = Properties.Resources.icons8_vision_100;
            }
            if (this.TestTypeID == 2)
            {
                this.Text = "Writing Test Appointmentt";
                this.TestTypeTitleLabel.Text = "Writing Test Appointment";
                this.guna2PictureBox1.BackgroundImage = Properties.Resources.icons8_main_qui_écrit_100;
            }
            if (this.TestTypeID == 3)
            {
                this.Text = "Street Test Appointment";
                this.TestTypeTitleLabel.Text = "Street Test Appointment";
                this.guna2PictureBox1.BackgroundImage = Properties.Resources.icons8_au_volant_64;
            }
        }
        private void VsionTestAppointmentFrm_Load(object sender, EventArgs e)
        {
            SetFormTitleAndPicture();
            FillTheGridByAppointments();
        }
        private void AddTheNewAppointmentToGrid(int NewAppoiId)
        {
            DLMS.EntitiesNamespace.Entities.ClsTestAppointment? Appointment = DLMS.BusinessLier.Test.Testlogic.GetTestAppointmentBYID(NewAppoiId);
            try
            {
                if (Appointment != null)
                {
                    int rowIndex = DataGrid.Rows.Add();
                    DataGrid.Rows[rowIndex].Cells["AppointmentID"].Value = Appointment.TestAppointmentId;
                    DataGrid.Rows[rowIndex].Cells["AppointmentDate"].Value = Appointment.TestAppointmentDate;
                    DataGrid.Rows[rowIndex].Cells["PaidFees"].Value = Appointment.PaidFees;
                    DataGrid.Rows[rowIndex].Cells["CreatedByUserID"].Value = Appointment.CreatedByUserId;
                    DataGrid.Rows[rowIndex].Cells["IsLocked"].Value = Appointment.IsLocked;

                }
            }
            catch
            {
                MessageBox.Show("Please refresh the grid", "refresh is required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void UpdateAppointmentRowDate(DateTime newDate)
        {
            DataGrid.SelectedRows[0].Cells["AppointmentDate"].Value = newDate;
        }
        private void AddAppointment_Click(object sender, EventArgs e)
        {
            if (applicationInfoControl1.LocalAppInfo1==null)
            {
                MessageBox.Show("We can't add a new vision test appointment in the moment please close and refresh the grid", "Internal Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string TestName = this.TestTypeID == 1 ? "Vision" : this.TestTypeID == 2 ? "Writing" : this.TestTypeID == 3 ? "Street" : "";
            TestName += " Test";

          
            if (DLMS.BusinessLier.Test.Testlogic.IsSucceededBefore(this.LocApplicationID, this.TestTypeID))
            {
                MessageBox.Show($"This person already succeded in the {TestName}", "Vision Test Rules",
                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (DLMS.BusinessLier.Test.Testlogic.HasOpenAppointment(this.LocApplicationID, this.TestTypeID))
            {
                MessageBox.Show($"This person already has an incompleted {TestName}", "Vision Test Rules",
                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (DLMS.BusinessLier.Test.Testlogic.IsFailedBefore(this.LocApplicationID, this.TestTypeID))
            {
                DialogResult Res = MessageBox.Show($"This person already failed in the {TestName} no we will make an retake test", "Vision Test Rules",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Res == DialogResult.No)
                    return;
            }

            // i used 1 in the function argument cause data fixed in test types
            AddEditTest Frm = new AddEditTest(this.LocApplicationID, this.TestTypeID);
            Frm.adding_ReadyToRefresh += AddTheNewAppointmentToGrid;
            if (!Frm.IsDisposed)
            {
                Frm.ShowDialog();
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.LocApplicationID<=0)
            {
                MessageBox.Show("We can't edit this vision test appointment date in the moment please close and refresh the grid", "Internal Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int AppointmentID = int.TryParse(this.DataGrid.SelectedRows[0].Cells["AppointmentID"].Value.ToString(), out int Val2) ? Val2 : -1;

            AddEditTest Frm = new AddEditTest(this.LocApplicationID,this.TestTypeID,AppointmentID,true);
            Frm.Editing_ReadyToRefresh += UpdateAppointmentRowDate;
            if(!Frm.IsDisposed)
                   Frm.ShowDialog();
        }
       
        private void SetAppointmentAsLocked()
        {
           if (this.SelectedRowIndex == -1)           
                FillTheGridByAppointments();
           else 
                DataGrid.Rows[this.SelectedRowIndex].Cells["IsLocked"].Value = true;
            OnApplicationInfoChanged?.Invoke();
           
        }
        private void TakeTestMenuItem_Click(object sender, EventArgs e)
        {
            int AppointID = Convert.ToInt32(DataGrid.SelectedRows[0].Cells["AppointmentID"].Value);
            TakeTestFrm Frm = new TakeTestFrm(AppointID);
            Frm.TestTaked_ReadyToRefresh += SetAppointmentAsLocked;
            Frm.ShowDialog();

        }

        private void DataGrid_SelectionChanged(object sender, EventArgs e)
        {
            this.SelectedRowIndex = DataGrid.SelectedRows[0].Index;
        }

        private void DataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TestOptionsMenuStrip.Show(Cursor.Position);
            }
        }

        
    }
}
