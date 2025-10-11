using DLMS.EntitiesNamespace;
using DLMS.BusinessLier.LocalDrivingLicenseApplication;
using System.Data;
using DLMS.BusinessLier;
using DesktopApp.User_Control;
using Microsoft.VisualBasic.Devices;
using System.ComponentModel;
using DesktopApp.AllLicensesHistory;

namespace DesktopApp.ApplicationsManagement
{
    public partial class AppTypesManagementFrm : Form
    {
        public AppTypesManagementFrm()
        {
            InitializeComponent();
        }

        private DataTable? LocApplications = new DataTable();
        private int CurrentLocAppInProcess = -1;
        private int SelectedRowInProcess = -1;
        private void AppTypesManagementFrm_Load(object sender, EventArgs e)
        {
            FillTheGrid();
        }
        private void FillFilterList()
        {
            FilterChoices.Items.Clear();//remove any previous items
            FilterChoices.Items.Add("None"); ;
            foreach (DataGridViewColumn Column in DataGrid.Columns)
                FilterChoices.Items.Add(Column.HeaderText);
            
            FilterChoices.SelectedIndex = 1;
        }
        private void FillTheGrid()
        {
            LocApplications = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetAllLocalApplications();
            if (LocApplications == null)
            {
                MessageBox.Show("No Applications in the system for now plaese try again\n and if the problem persists please contact your admin",
                    "Empty Table", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LocApplications.PrimaryKey =new DataColumn[]{ LocApplications.Columns[0] };
            DataGrid.AutoGenerateColumns = true;
            DataGrid.DataSource = LocApplications;
            DataGrid.Columns[0].HeaderText = "L.D.L.AppID";
            DataGrid.Columns[0].Width = 120;

            DataGrid.Columns[1].HeaderText = "Driving Class";
            DataGrid.Columns[1].Width = 180;

            DataGrid.Columns[2].HeaderText = "National No.";
            DataGrid.Columns[2].Width = 100;

            DataGrid.Columns[3].HeaderText = "Full Name";
            DataGrid.Columns[3].Width = 250;

            DataGrid.Columns[4].HeaderText = "Application Date";
            DataGrid.Columns[4].Width = 170;

            DataGrid.Columns[5].HeaderText = "Passed Tests";
            DataGrid.Columns[5].Width = 80;

            DataGrid.Refresh();
            RowsCountlabel.Text = DataGrid.RowCount.ToString();
            FillFilterList();
        }
        private void refreshTheGrid()
        {
            FillTheGrid();
        }
        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            refreshTheGrid();
            this.Cursor = Cursors.Hand;
        }

        private void DisableAllOrEnableAllGridItems(bool choice)
        {
            scheduleTestsToolStripMenuItems.Enabled = choice;
            SchedulevisionTestToolStripMenuItem.Enabled = choice;
            scheduleWritingTestToolStripMenuItem.Enabled = choice;
            scheduleStreetToolStripMenuItem.Enabled = choice;
            issueLicenseFirstTimeToolStripMenuItem.Enabled = choice;
            showLicenseInfoToolStripMenuItem.Enabled = choice;
            showLicencesHistoryToolStripMenuItem.Enabled = choice;
            CancelButton.Enabled = choice;
            DeleteButton.Enabled = choice;
            EditButton.Enabled = choice;

        }
        private void DataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                return;

            DisableAllOrEnableAllGridItems(false);
            int LocDriLicAppId = Convert.ToInt32(DataGrid.SelectedRows[0].Cells["LocDLA_ID"].Value);
            Entities.ClsLocDriApplication? locDriApplication = LocDriviLicAppLogic.GetLocDriLicAppInfo(LocDriLicAppId);
            if (locDriApplication == null)
                return; //it will show all items disabled 

            bool AlreadyADriver = DLMS.BusinessLier.Driver.DriverLogic.IsAlreadyDriver(locDriApplication.ApplicantPersonId);
            if(AlreadyADriver)
            {
                showLicencesHistoryToolStripMenuItem.Enabled = true;
            }
            if (locDriApplication.ApplicationStatus == Entities.ClsLocDriApplication.enApplicationStatus.Completed)
            {
                showLicenseInfoToolStripMenuItem.Enabled = true;
                LocApplicationsMenuStrip.Show(Cursor.Position);
                return;
            }
            if (locDriApplication.ApplicationStatus == Entities.ClsLocDriApplication.enApplicationStatus.Cancelled)
            {
                ShowInfoButton.Enabled = true;
                DeleteButton.Enabled = true;
                LocApplicationsMenuStrip.Show(Cursor.Position);
                return;
            }
            DeleteButton.Enabled = true;
            CancelButton.Enabled = true;
            EditButton.Enabled   = true;

            bool PassedVisionTest  = DLMS.BusinessLier.Test.Testlogic.IsSucceededBefore(LocDriLicAppId, 1);
            bool PassedWritingTest = DLMS.BusinessLier.Test.Testlogic.IsSucceededBefore(LocDriLicAppId, 2);
            bool PassedStreetTest  = DLMS.BusinessLier.Test.Testlogic.IsSucceededBefore(LocDriLicAppId, 3);

            scheduleTestsToolStripMenuItems.Enabled = (!PassedVisionTest || !PassedWritingTest || !PassedStreetTest) && 
                                                      (locDriApplication.ApplicationStatus == Entities.ClsLocDriApplication.enApplicationStatus.New);

            if(scheduleTestsToolStripMenuItems.Enabled)
            {
                SchedulevisionTestToolStripMenuItem.Enabled  = PassedVisionTest && (!PassedWritingTest && !PassedStreetTest);
                scheduleWritingTestToolStripMenuItem.Enabled = !SchedulevisionTestToolStripMenuItem.Enabled;
                scheduleStreetToolStripMenuItem.Enabled      = !scheduleWritingTestToolStripMenuItem.Enabled;
            }

            if (AlreadyADriver)
            {
                issueLicenseFirstTimeToolStripMenuItem.Enabled = !DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetlisenceStatusOfAperson(locDriApplication.ApplicantPersonId, locDriApplication.LicenseClassID).Contains(3);
                showLicenseInfoToolStripMenuItem.Enabled = !issueLicenseFirstTimeToolStripMenuItem.Enabled;      
            }
            LocApplicationsMenuStrip.Show(Cursor.Position);
        }

        private void AddTheNewLocalAppToTheGrid(int LocAppId)
        {
            if (LocApplications == null)
                return;

            Entities.ClsLocDriApplication? locDriApplication = LocDriviLicAppLogic.GetLocDriLicAppInfo(LocAppId);
            DataRow Row = LocApplications.NewRow();
            try
            {
                if (locDriApplication!=null)
                {
                    Row[0] = locDriApplication.LocDriApplicationID;
                    Row[1] = locDriApplication.LicenseClassInfo?.ClassName;
                    Row[2] = locDriApplication.ApplicantPersonInfo?.NationalNo;
                    Row[3] = locDriApplication.ApplicantPersonInfo?.FullName;
                    Row[4] = locDriApplication.ApplicantionDate;
                    Row[5] = LocDriviLicAppLogic.PassesTests(locDriApplication.LocDriApplicationID);
                    Row[6] = locDriApplication.ApplicationStatus;
                              
                    LocApplications.Rows.InsertAt(Row,0);
                    DataGrid.ClearSelection();
                    DataGrid.Rows[0].Selected = true;
                }
            }
            catch
            {
                MessageBox.Show($"please Refresh the data grid", "Required Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void ShowNewEditedInfoOfLocApp()
        {
            try
            {
                Entities.ClsLocDriApplication? locDriApplication = LocDriviLicAppLogic.GetLocDriLicAppInfo(CurrentLocAppInProcess);
                DataGrid.ReadOnly = false;
                if (locDriApplication != null)
                {
                     LocApplications.Rows[SelectedRowInProcess][0] = locDriApplication.LocDriApplicationID;
                     LocApplications.Rows[SelectedRowInProcess][1] = locDriApplication.LicenseClassInfo?.ClassName;
                     LocApplications.Rows[SelectedRowInProcess][2] = locDriApplication.ApplicantPersonInfo?.NationalNo;
                     LocApplications.Rows[SelectedRowInProcess][3] = locDriApplication.ApplicantPersonInfo?.FullName;
                     LocApplications.Rows[SelectedRowInProcess][4] = locDriApplication.ApplicantionDate;
                     LocApplications.Rows[SelectedRowInProcess][5] = LocDriviLicAppLogic.PassesTests(locDriApplication.LocDriApplicationID);
                     LocApplications.Rows[SelectedRowInProcess][6] = locDriApplication.ApplicationStatus;
                }
            }
            catch
            {
                refreshTheGrid();
            }
        }
        private void FilterValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (FilterChoices.SelectedItem == null)
                return;
            string? choice = FilterChoices.SelectedItem.ToString();
            if (choice == "L.D.L.AppID" || choice == "Passed Tests")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        }

        private void FilterChoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FilterChoices.SelectedItem == null || FilterChoices.SelectedItem.ToString() == "")
            {
                return;
            }

            if (FilterChoices.SelectedItem.ToString()?.ToLower() == ("none"))
            {
                FilterValueTextBox.Visible = false;
                DateTimePicker.Visible = false;
                this.LocApplications.DefaultView.RowFilter = "";
                this.RowsCountlabel.Text = DataGrid.Rows.Count.ToString();

                return;
            }

            if (FilterChoices.SelectedItem.ToString()?.ToLower() == ("application date"))
            {
                FilterValueTextBox.Visible = false;
                DateTimePicker.Visible = true;
                return;
            }
            FilterValueTextBox.Visible = true;
            FilterValueTextBox.Text = "";
            DateTimePicker.Visible = false;
            if (LocApplications != null)
            {
                LocApplications.DefaultView.RowFilter = string.Empty;
                this.RowsCountlabel.Text = DataGrid.Rows.Count.ToString();

            }
        }

        private void FilterValueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (LocApplications == null)
                return;

            string Value = FilterValueTextBox.Text;

            //check if the event is from the date box
            if (sender.GetType() == DateTimePicker.GetType())
            {
                if (DateTimePicker == null)
                {
                    LocApplications.DefaultView.RowFilter = "";
                    this.RowsCountlabel.Text = DataGrid.Rows.Count.ToString();
                    return;
                }
            }

            else if (string.IsNullOrEmpty(Value) || FilterChoices.SelectedItem == null)
            {
                LocApplications.DefaultView.RowFilter = "";
                this.RowsCountlabel.Text = DataGrid.Rows.Count.ToString();

                return;
            }

            string? ColumnName = LocApplications.Columns[FilterChoices.SelectedIndex-1]?.ToString(); //-1 becuase the none filter choice
            if (string.IsNullOrEmpty(ColumnName))
                return;

            //Get the column object
            DataColumn? column = LocApplications.Columns[ColumnName];
            if (column == null)
            {
                MessageBox.Show(text: "Invalid column or something else please try again or restart the program ", caption: "Technical Issue",
                 MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }
            string Filter = "";

            HashSet<TypeCode> Types = new HashSet<TypeCode>
            {
                TypeCode.Int64 ,TypeCode.Int32,TypeCode.Int16, TypeCode.Byte,
                TypeCode.Decimal, TypeCode.Double, TypeCode.Decimal, TypeCode.Single, TypeCode.UInt16,TypeCode.UInt32,TypeCode.UInt64,
                TypeCode.SByte
            };

            if (column.DataType == typeof(string))
            {
                Filter = $"{column.ColumnName} like '%{Value.Replace("'", "''")}%'";
            }
            if (column.DataType == typeof(DateTime))
            {
                string date = DateTimePicker.Value.Date.ToString("M/d/yyyy");
                Filter = $"CONVERT({column.ColumnName},'System.String') like '%{date}%'";
            }
            if (Types.Contains(Type.GetTypeCode(column.DataType)))
            {
                Filter = $"CONVERT({column.ColumnName},'System.String') like '%{Value.ToString()}%'";
            }

            if (column.DataType == typeof(bool) && bool.TryParse(Value, out bool _))
            {
                Filter = $"{column.ColumnName} = '{Value}'";
            }
            try
            {
                LocApplications.DefaultView.RowFilter = Filter;
            }
            catch
            {
                LocApplications.DefaultView.RowFilter = "";
            }
            finally
            {
                this.RowsCountlabel.Text = DataGrid.Rows.Count.ToString();
            }
        }

        private void ShowTheApplicationAsCanceled(int RowIndex)
        {
            if (RowIndex >= 0 && RowIndex < DataGrid.Rows.Count)
            {
                if (LocApplications != null && LocApplications.Columns.Contains("ApplicationStatus"))
                {
                    LocApplications.Columns["ApplicationStatus"].ReadOnly = false;
                    DataGrid.Rows[RowIndex].Cells["ApplicationStatus"].Value = "Canceled";
                }
            }
        }
        private void RemoveARowById(int ID)
        {
            try
            {
                DataRow? Row = LocApplications?.Rows.Find(ID);
                if (Row != null)
                {
                    Row.Delete();
                }
            }
            catch
            {
                MessageBox.Show($"please Refresh", "Required Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            ManageApplication.AddEditLocalApp Frm = new ManageApplication.AddEditLocalApp();
            Frm.OnAddingNewApp += AddTheNewLocalAppToTheGrid;
            Frm.ShowDialog();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            int LocDriLicAppId = Convert.ToInt32(DataGrid.SelectedRows[0].Cells["LocDLA_ID"].Value);
            int RowIndex = DataGrid.SelectedRows[0].Index;

            if (DataGrid.SelectedRows[0].Cells["ApplicationStatus"].Value.ToString()?.ToLower() == "canceled")
            {
                MessageBox.Show("It's Already canceled ( You Can to delete it from the menu by right clicking)", "Unecessary action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DataGrid.SelectedRows[0].Cells["ApplicationStatus"].Value.ToString()?.ToLower() == "completed")
            {
                MessageBox.Show("you can't cancel a completed application lol", "System Rules Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult Res = MessageBox.Show("Are you sure you want to cancel this application", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.No)
            {
                return;
            }

            if (!DLMS.BusinessLier.Application.ApplicationLogic.SetApplicationStatus(LocDriLicAppId, 2)) // 2 means canceled
            {
                MessageBox.Show("We cant change the status right now please try again", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ShowTheApplicationAsCanceled(RowIndex);
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            int Loc_DLA_ID = int.TryParse(DataGrid.SelectedRows[0].Cells["LocDLA_ID"].Value.ToString(), out int Loc_ID) ? Loc_ID : -1;
            this.CurrentLocAppInProcess = int.TryParse(DataGrid.SelectedRows[0].Cells["LocDLA_ID"].Value.ToString(), out int Row_Index) ? Row_Index : 0;
            this.SelectedRowInProcess = DataGrid.SelectedRows[0].Index;
            ManageApplication.AddEditLocalApp Frm = new ManageApplication.AddEditLocalApp(Loc_DLA_ID);
            Frm.OnEditingApp += ShowNewEditedInfoOfLocApp;
            if (!Frm.IsDisposed)
            {
                Frm.ShowDialog();
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            List<int> RowsToDelete = new List<int>();
            for (int i = 0; i < DataGrid.SelectedRows.Count; i++)
            {
                if (DataGrid.SelectedRows[i].Cells["ApplicationStatus"].Value.ToString()?.ToLower() == "completed")
                {
                    MessageBox.Show($"you can't Delete a the application with ID ={DataGrid.SelectedRows[i].Cells["LocDLA_ID"].Value} because it's already complete"
                        , "System Rules Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                int LocAppId = int.TryParse(DataGrid.SelectedRows[i].Cells["LocDLA_ID"].Value.ToString(), out int Val) ? Val : 0;
                int ApplicationID = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetAppIdByLocalDrivingId(LocAppId);
                if (LocAppId == 0 || ApplicationID == -1)
                {
                    MessageBox.Show($"We can't Delete the application with ID ={DataGrid.SelectedRows[i].Cells["LocDLA_ID"].Value} please refresh and try again", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error); continue;
                }
                DialogResult Res = MessageBox.Show($"Are you sure you want delete this Local Driving Application With Id = {LocAppId}", "Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Res == DialogResult.Yes)
                {
                    int ResultOfDeletion = DLMS.BusinessLier.Application.ApplicationLogic.DeleteApplication(ApplicationID);
                    if (ResultOfDeletion == 1)
                    {
                        MessageBox.Show($"Local Driving Application With Id = {LocAppId} Was Deleted SuccessFully", "Operation Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RowsToDelete.Add(i);
                        continue;
                    }
                    if (ResultOfDeletion == -1)
                    {
                        MessageBox.Show($"Local Driving Application With Id = {LocAppId} Was not deleted because it has data linked to it", "Data integrity violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                    if (ResultOfDeletion == 0)
                    {
                        MessageBox.Show($"Local Driving Application With Id = {LocAppId} Was not deleted due an internal error", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                }
            }
            foreach (int ID in RowsToDelete)
            {
                RemoveARowById(ID);
            }
        }

        private void ShowTestDestinationForm(int TestTypeID)
        {
            this.CurrentLocAppInProcess = int.TryParse(DataGrid.SelectedRows[0].Cells["LocDLA_ID"].Value.ToString(), out int Val) ? Val : 0;
            this.SelectedRowInProcess = DataGrid.SelectedRows[0].Index;
            if (CurrentLocAppInProcess != 0)
            {
                ScheduleTest.TestAppointmentFrm Frm = new ScheduleTest.TestAppointmentFrm(CurrentLocAppInProcess, TestTypeID);
                Frm.OnApplicationInfoChanged += ShowNewEditedInfoOfLocApp;
                Frm.ShowDialog();
            }
        }
        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTestDestinationForm(1);
        }
        private void scheduleWritingTestToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ShowTestDestinationForm(2);
        }
        private void scheduleStreetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTestDestinationForm(3);
        }
        private void ShowInfoButton_Click(object sender, EventArgs e)
        {
            int LocDLA_Id = int.TryParse(DataGrid.SelectedRows[0].Cells["LocDLA_Id"].Value.ToString(), out int Val) ? Val : 0;
            DesktopApp.ManageLocalApplication.ShowlocalAppInfo Frm = new DesktopApp.ManageLocalApplication.ShowlocalAppInfo(LocDLA_Id);
            Frm.ShowDialog();
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void issueLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CurrentLocAppInProcess = int.TryParse(DataGrid.SelectedRows[0].Cells["LocDLA_ID"].Value.ToString(), out int CurrentLocAppInProcess) ? CurrentLocAppInProcess : 0;
            this.SelectedRowInProcess = DataGrid.SelectedRows[0].Index;

            int LocDLA_Id = int.TryParse(DataGrid.SelectedRows[0].Cells["LocDLA_Id"].Value.ToString(), out int LocDLAId) ? LocDLAId : 0;
            IssueLocalDrivingLicense.IssueDrivingLicenseFrm Frm = new IssueLocalDrivingLicense.IssueDrivingLicenseFrm(LocDLA_Id);
            Frm.ON_LicenseSavedWithSuccess += this.ShowNewEditedInfoOfLocApp;
            Frm.ShowDialog();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocDLA_Id = int.TryParse(DataGrid.SelectedRows[0].Cells["LocDLA_Id"].Value.ToString(), out int LocDLAId) ? LocDLAId : 0;
            DesktopApp.LocDrivingLicense.ShowLicenseFrm Frm = new LocDrivingLicense.ShowLicenseFrm(LocDLA_Id);
            if (!Frm.IsDisposed)
                Frm.ShowDialog();
        }

        private void showLicencesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocDLA_Id = int.TryParse(DataGrid.SelectedRows[0].Cells["LocDLA_Id"].Value.ToString(), out int LocDLAId) ? LocDLAId : 0;
            int PersonID = LocDriviLicAppLogic.GetApplicantPersonIdByLocDriId(LocDLAId);
            ShowAllLicensesHistoryFrm Frm = new ShowAllLicensesHistoryFrm(PersonID);
            Frm.ShowDialog();
        }
    }
}
