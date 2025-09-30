using DLMS.EntitiesNamespace;
using System.Data;
using DLMS.BusinessLier;
using DesktopApp.User_Control;
using Microsoft.VisualBasic.Devices;
using System.ComponentModel;
using DesktopApp.AllLicensesHistory;

namespace DesktopApp.ApplicationsManagement
{
    public partial class ApplicationsManagementFrm : Form
    {
        public ApplicationsManagementFrm()
        {
            InitializeComponent();
        }

        private DataTable LocApplications = new DataTable();
        private int CurrentLocAppInProcess = -1;
        private int SelectedRowInProcess = -1;
        private void ApplicationsManagementFrm_Load(object sender, EventArgs e)
        {
            FillTheGrid();
        }
        private void FillFilterList()
        {
            FilterChoices.Items.Add("None"); ;
            foreach (DataGridViewColumn Column in DataGrid.Columns)
                FilterChoices.Items.Add(Column.Name);

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

            DataGrid.AutoGenerateColumns = true;
            DataGrid.DataSource = LocApplications;
            if (DataGrid.Columns.Contains("ApplicationDate"))
            {
                DataGrid.Sort(DataGrid.Columns["ApplicationDate"], ListSortDirection.Descending);
                if (LocApplications.Columns.Contains("LocDLA_ID"))
                    LocApplications.PrimaryKey = new DataColumn[] { LocApplications.Columns["LocDLA_ID"] };
            }
            DataGrid.Refresh();
            RowsCountlabel.Text = DataGrid.RowCount.ToString();
            FillFilterList();


        }
        private void refreshTheGrid()
        {
            DataGrid.DataSource = "";
            LocApplications = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetAllLocalApplications();
            DataGrid.Refresh();
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
            {
                return;
            }

            DisableAllOrEnableAllGridItems(false);
            int LocDriLicAppId = Convert.ToInt32(DataGrid.SelectedRows[0].Cells["LocDLA_ID"].Value);
            int PersonID = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetApplicantPersonIdByLocDriId(LocDriLicAppId);
            bool AlreadyADriver = DLMS.BusinessLier.Driver.DriverLogic.IsAlreadyDriver(PersonID);
            if(AlreadyADriver)
            {
                showLicencesHistoryToolStripMenuItem.Enabled = true;
            }

            string? Status = DataGrid.SelectedRows[0].Cells["ApplicationStatus"].Value?.ToString()?.ToLower();
            if (Status == "completed")
            {
                showLicenseInfoToolStripMenuItem.Enabled = true;
                LocApplicationsMenuStrip.Show(Cursor.Position);
                return;
            }
            if (Status == "canceled")
            {
                ShowInfoButton.Enabled = true;
                DeleteButton.Enabled = true;
                LocApplicationsMenuStrip.Show(Cursor.Position);
                return;
            }
            scheduleTestsToolStripMenuItems.Enabled = true;
            DeleteButton.Enabled = true;
            CancelButton.Enabled = true;
            EditButton.Enabled   = true;

            if (!DLMS.BusinessLier.Test.Testlogic.IsSucceededBefore(LocDriLicAppId, 1))
            {

                SchedulevisionTestToolStripMenuItem.Enabled = true;
                scheduleWritingTestToolStripMenuItem.Enabled = false;
                scheduleStreetToolStripMenuItem.Enabled = false;
                LocApplicationsMenuStrip.Show(Cursor.Position);
                return;
            }
            else if (!DLMS.BusinessLier.Test.Testlogic.IsSucceededBefore(LocDriLicAppId, 2))
            {
                SchedulevisionTestToolStripMenuItem.Enabled = false;
                scheduleWritingTestToolStripMenuItem.Enabled = true;
                scheduleStreetToolStripMenuItem.Enabled = false;
                issueLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseInfoToolStripMenuItem.Enabled = false;
                LocApplicationsMenuStrip.Show(Cursor.Position);
                return;
            }
            else if (!DLMS.BusinessLier.Test.Testlogic.IsSucceededBefore(LocDriLicAppId, 3))
            {
                SchedulevisionTestToolStripMenuItem.Enabled = false;
                scheduleWritingTestToolStripMenuItem.Enabled = false;
                scheduleStreetToolStripMenuItem.Enabled = true;
                issueLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseInfoToolStripMenuItem.Enabled = false;
                LocApplicationsMenuStrip.Show(Cursor.Position);
                return;
            }
            scheduleTestsToolStripMenuItems.Enabled = false;

            int? LicenseClassID = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetBasicLocDriLicAppInfo(LocDriLicAppId)?.LicenseClassID;

            if (AlreadyADriver)
            {
                if (DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetlisenceStatusOfAperson(PersonID, (LicenseClassID == null ? -1 : Convert.ToInt32(LicenseClassID))).Contains(3))
                {
                    issueLicenseFirstTimeToolStripMenuItem.Enabled = false;
                    showLicenseInfoToolStripMenuItem.Enabled = true;
                }
                else
                {
                    issueLicenseFirstTimeToolStripMenuItem.Enabled = true;
                }
            }
            else
            {
                issueLicenseFirstTimeToolStripMenuItem.Enabled = true;
                showLicenseInfoToolStripMenuItem.Enabled = false;
            }
            LocApplicationsMenuStrip.Show(Cursor.Position);
        }

        private void AddTheNewLocalAppToTheGrid(int LocAppId)
        {
            if (LocApplications == null)
                return;

            Dictionary<string, object> NewLocDriApp = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetLocalDrivingLicAppById(LocAppId);
            DataRow Row = LocApplications.NewRow();
            try
            {
                if (NewLocDriApp.Count > 0)
                {
                    int Index = 0;
                    foreach (object value in NewLocDriApp.Values)
                    {
                        Row[Index] = value ?? null;
                        Index++;
                    }
                    LocApplications.Rows.Add(Row);
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
                Dictionary<string, object> NewInfo = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetLocalDrivingLicAppById(CurrentLocAppInProcess);
                if (NewInfo.Count > 0)
                {
                    byte index = 0;
                    foreach (object Value in NewInfo.Values)
                    {
                        this.LocApplications.Columns[index].ReadOnly = false;
                        LocApplications.Rows[this.SelectedRowInProcess][index] = Value;
                        index++;
                    }
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
            string? choice = FilterChoices.SelectedItem.ToString()?.ToLower();
            if (choice == "locdla_id" || choice == "passedtests")
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
                return;
            }

            if (FilterChoices.SelectedItem.ToString()?.ToLower() == ("applicationdate"))
            {
                FilterValueTextBox.Visible = false;
                DateTimePicker.Visible = true;
                return;
            }
            FilterValueTextBox.Visible = true;
            DateTimePicker.Visible = false;
            if (LocApplications != null)
            {
                LocApplications.DefaultView.RowFilter = string.Empty;
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
                    return;
                }
            }

            else if (string.IsNullOrEmpty(Value) || FilterChoices.SelectedItem == null)
            {
                LocApplications.DefaultView.RowFilter = "";
                return;
            }

            string? ColumnName = FilterChoices.SelectedItem?.ToString();
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

        }

        private void ShowTheApplicationAsCanceled(int RowIndex)
        {
            if (RowIndex >= 0 && RowIndex < DataGrid.Rows.Count)
            {
                if (LocApplications != null && LocApplications.Columns.Contains("ApplicationStatus"))
                {
                    LocApplications.Columns["ApplicationStatus"].ReadOnly = false;

                }
                DataGrid.Rows[RowIndex].Cells["ApplicationStatus"].Value = "Canceled";
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
            ManageApplication.AddEditLocalApp Frm = new ManageApplication.AddEditLocalApp(true, Loc_DLA_ID);
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
                        RowsToDelete.Add(LocAppId);
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

        private void UpdateRowOfCurrentLocAppInProcess()
        {
            try
            {
                Dictionary<string, object> NewInfo = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetLocalDrivingLicAppById(CurrentLocAppInProcess);
                if (NewInfo.Count > 0)
                {
                    byte index = 0;
                    foreach (object Value in NewInfo.Values)
                    {
                        this.LocApplications.Columns[index].ReadOnly = false;
                        LocApplications.Rows[this.SelectedRowInProcess][index] = Value;
                        index++;
                    }
                }
            }
            catch
            {
                refreshTheGrid();
            }
        }
        private void ShowTestDestinationForm(int TestTypeID)
        {
            this.CurrentLocAppInProcess = int.TryParse(DataGrid.SelectedRows[0].Cells["LocDLA_ID"].Value.ToString(), out int Val) ? Val : 0;
            this.SelectedRowInProcess = DataGrid.SelectedRows[0].Index;
            if (CurrentLocAppInProcess != 0)
            {
                ScheduleTest.TestAppointmentFrm Frm = new ScheduleTest.TestAppointmentFrm(CurrentLocAppInProcess, TestTypeID);
                Frm.OnApplicationInfoChanged += UpdateRowOfCurrentLocAppInProcess;
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
            Frm.ON_LicenseSavedWithSuccess += UpdateRowOfCurrentLocAppInProcess;
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
            int PersonID = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetApplicantPersonIdByLocDriId(LocDLAId);
            ShowAllLicensesHistoryFrm Frm = new ShowAllLicensesHistoryFrm(PersonID);
            Frm.ShowDialog();
        }
    }
}
