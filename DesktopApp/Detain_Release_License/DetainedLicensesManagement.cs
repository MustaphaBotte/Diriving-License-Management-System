using DesktopApp.AllLicensesHistory;
using DesktopApp.LocDrivingLicense;
using DesktopApp.ManagePerson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Detain_Release_License
{
    public partial class DetainedLicensesManagementFrm : Form
    {
        public DetainedLicensesManagementFrm()
        {
            InitializeComponent();
        }
        int CurrentRowInProcess = -1;
        private void DetainedLicensesManagement_Load(object sender, EventArgs e)
        {
            FillTheGrid();
            FillFilterList();
            this.DateTimePicker.Value = DateTime.Now;
        }
        private void RefreshButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void RefreshButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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
            DataTable? DLicenses = DLMS.BusinessLier.Release_Detain_License.Release_Detain_LicenseLogic.GetAllDetainedLicenses();

            if (DLicenses == null || DLicenses.Rows.Count == 0)
            {
                MessageBox.Show("There is no driver in the system", "No Drivers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (DataRow Row in DLicenses.Rows)
            {
                int RowIndex = DataGrid.Rows.Add();
                DataGrid.Rows[RowIndex].Cells["DetainID"].Value = Row["DetainID"];
                DataGrid.Rows[RowIndex].Cells["LicenseID"].Value = Row["LicenseID"];
                DataGrid.Rows[RowIndex].Cells["D_Date"].Value = Row["DetainDate"];
                DataGrid.Rows[RowIndex].Cells["Isreleased"].Value = Row["IsReleased"];
                DataGrid.Rows[RowIndex].Cells["FineFees"].Value = Row["FineFees"];
                DataGrid.Rows[RowIndex].Cells["ReleaseDate"].Value = Row["ReleaseDate"];
                DataGrid.Rows[RowIndex].Cells["N_No"].Value = Row["NationalNo"];
                DataGrid.Rows[RowIndex].Cells["FullName"].Value = Row["FullName"];
                DataGrid.Rows[RowIndex].Cells["ReleaseAppID"].Value = Row["ReleaseApplicationID"];

            }
            DataGrid.Refresh();
            RowsCountlabel.Text = DataGrid.RowCount.ToString();
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
                DetainStatus.Visible = false;
                FilterValueTextBox_TextChanged(sender, e);//to show them all witout filter
                return;
            }

            if (((List<string>)["d_date", "releasedate"]).Contains(FilterChoices.SelectedItem.ToString()?.ToLower() ?? ""))
            {
                FilterValueTextBox.Visible = false;
                DateTimePicker.Visible = true;
                DetainStatus.Visible = false;
                DateTimePicker.Value = DateTime.Now;
                return;
            }
            if (FilterChoices.SelectedItem.ToString()?.ToLower() == "isreleased")
            {
                FilterValueTextBox.Visible = false;
                DateTimePicker.Visible = false;
                DetainStatus.Visible = true;
                return;
            }
            FilterValueTextBox.Visible = true;
            DateTimePicker.Visible = false;
        }
        private void FilterValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string? Filter = FilterChoices.SelectedItem?.ToString();
            if (Filter == "")
                return;


            if ((Filter == "DetainID" || Filter == "LicenseID" || Filter == "ReleaseAppID" || Filter == "FineFees") && !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                if (Filter == "FineFees" && e.KeyChar == '.')
                {
                    return;
                }
                e.Handled = true;
            }
        }
        private void FilterValueTextBox_TextChanged(object sender, EventArgs e)
        {
            string? Filter = FilterChoices.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(Filter))
                return;
            DataGrid.Refresh();
            int RowCount = DataGrid.Rows.Count;
            if (Filter.ToLower() == "none")
            {
                foreach (DataGridViewRow Row in DataGrid.Rows)
                {
                    Row.Visible = true;
                    this.RowsCountlabel.Text = RowCount.ToString();
                }
                return;
            }

            if (((List<string>)["DetainID", "LicenseID", "ReleaseAppID", "FullName", "N_No", "Isreleased", "FineFees"]).Contains(Filter))
            {
                foreach (DataGridViewRow Row in DataGrid.Rows)
                {
                    if (!Row.Cells[Filter].Value?.ToString()?.ToLower().Contains(FilterValueTextBox.Text.ToString().ToLower()) ?? false)
                    {
                        Row.Visible = false;
                        RowCount -= 1;
                    }
                    else
                    {
                        Row.Visible = true;
                    }
                }

            }
            else if (Filter == "D_Date" || Filter == "ReleaseDate")
            {
                foreach (DataGridViewRow Row in DataGrid.Rows)
                {
                    if (Row.Cells[Filter].Value == DBNull.Value)
                    {
                        Row.Visible = false;
                        RowCount -= 1;
                        continue;
                    }

                    if (((DateTime)Row.Cells[Filter].Value).Date != DateTimePicker.Value.Date)
                    {
                        Row.Visible = false;
                        RowCount -= 1;
                    }
                    else
                    {
                        Row.Visible = true;
                    }
                }
            }
            else if (Filter == "IsReleased")
            {
                bool DetainStatus = this.DetainStatus.SelectedIndex == 0 ? true : false;
                foreach (DataGridViewRow Row in DataGrid.Rows)
                {
                    if (Row.Cells[Filter].Value.ToString() != DetainStatus.ToString())
                    {
                        Row.Visible = false;
                        RowCount -= 1;
                    }
                    else
                    {
                        Row.Visible = true;
                    }
                }
            }
            this.RowsCountlabel.Text = RowCount.ToString();
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataGrid.Rows.Clear();
            DataGrid.Refresh();
            FillTheGrid();
            this.Cursor = Cursors.Default;

        }
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //For ReuseAbility
            FilterValueTextBox_TextChanged(sender, e);
        }

        private void DetainStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //For ReuseAbility
            FilterValueTextBox_TextChanged(sender, e);
        }

        private void showLicencesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string? N_No = DataGrid.SelectedRows[0].Cells["N_No"].Value?.ToString();
            int PersonID = DLMS.BusinessLier.Person.PersonLogic.FindPerson(NationalNo: N_No)?.PersonId ?? -1;
            ShowAllLicensesHistoryFrm Frm = new ShowAllLicensesHistoryFrm(PersonID);
            if (!Frm.IsDisposed)
                Frm.ShowDialog();
        }
        private void ShowPersonInfoButton_Click(object sender, EventArgs e)
        {
            string? N_No = DataGrid.SelectedRows[0].Cells["N_No"].Value?.ToString();
            int PersonID = DLMS.BusinessLier.Person.PersonLogic.FindPerson(NationalNo: N_No)?.PersonId ?? -1;
            DesktopApp.ManagePerson.ShowPerson Frm = new ShowPerson(PersonID);
            if (!Frm.IsDisposed)
                Frm.ShowDialog();

        }
        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Lic_ID = int.TryParse(DataGrid.SelectedRows[0].Cells["LicenseID"].Value.ToString(), out int res) ? res : 0;
            ShowLicenseFrm Frm = new ShowLicenseFrm(LicenseID: Lic_ID);
            if (!Frm.IsDisposed)
                Frm.ShowDialog();
        }

        private void DataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                bool IsReleased = bool.TryParse(DataGrid.SelectedRows[0].Cells["IsReleased"].Value.ToString(), out bool res) ? res : false;
                if (IsReleased)
                {
                    releaseDetainedLicenseToolStripMenuItem.Enabled = false;
                }
                if (!IsReleased)
                {
                    releaseDetainedLicenseToolStripMenuItem.Enabled = true;
                }
                DetainedLicMenuStrip.Show(Cursor.Position);
            }
        }

        private void ChangeCurrentRowStatus(int LicenseID=-1,Form? Sender=null)
        {
            if (Sender != null && !Sender.IsDisposed)
                Sender.Close();
            if (this.CurrentRowInProcess != -1)
                DataGrid.Rows[CurrentRowInProcess].Cells["IsReleased"].Value = true;
            
        }
        private void ChangeSpecificLicenseRowStatus(int LicenseID,Form Sender)
        {
            if (Sender != null && !Sender.IsDisposed)
                Sender.Close();
            foreach (DataGridViewRow Row in DataGrid.Rows)
            {
                if (Row.Cells["LicenseID"].Value.ToString() == LicenseID.ToString())
                {
                    Row.Cells["IsReleased"].Value = true;
                }
            }
        }
        private void GetNewDetainedlicenseRecord(int DetainID,Form Sender)
        {
            if (Sender!=null &&!Sender.IsDisposed)
                Sender.Close();
            DataTable? DLicense = DLMS.BusinessLier.Release_Detain_License.Release_Detain_LicenseLogic.GetCompletedInfoByDetainedID(DetainID);

            if (DLicense == null || DLicense.Rows.Count == 0)
            {
                MessageBox.Show("To view new detained licenses please refresh", "New License Detained", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataGridViewRow Row = new DataGridViewRow();
            Row.CreateCells(DataGrid);
            Row.Cells[DataGrid.Columns["DetainID"].Index].Value = DLicense.Rows[0]["DetainID"];
            Row.Cells[DataGrid.Columns["LicenseID"].Index].Value = DLicense.Rows[0]["LicenseID"];
            Row.Cells[DataGrid.Columns["D_Date"].Index].Value = DLicense.Rows[0]["DetainDate"];
            Row.Cells[DataGrid.Columns["IsReleased"].Index].Value = DLicense.Rows[0]["IsReleased"];
            Row.Cells[DataGrid.Columns["FineFees"].Index].Value = DLicense.Rows[0]["FineFees"];
            Row.Cells[DataGrid.Columns["ReleaseDate"].Index].Value = DLicense.Rows[0]["ReleaseDate"];
            Row.Cells[DataGrid.Columns["N_No"].Index].Value = DLicense.Rows[0]["NationalNo"];
            Row.Cells[DataGrid.Columns["FullName"].Index].Value = DLicense.Rows[0]["FullName"];
            Row.Cells[DataGrid.Columns["ReleaseAppID"].Index].Value = DLicense.Rows[0]["ReleaseApplicationID"];
            DataGrid.Rows.Insert(0, Row);
            DataGrid.ClearSelection();
            Row.Selected = true;
            DataGrid.Refresh();          
            RowsCountlabel.Text = DataGrid.RowCount.ToString();

       }
        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int Lic_ID = int.TryParse(DataGrid.SelectedRows[0].Cells["LicenseID"].Value.ToString(), out int LicID) ? LicID : 0;
            this.CurrentRowInProcess = DataGrid.SelectedRows[0].Index;
            Release_LicenseFrm Frm = new Release_LicenseFrm(Lic_ID);
            Frm.OnLicenseReleased += ChangeCurrentRowStatus;                     
            if (!Frm.IsDisposed)
                Frm.ShowDialog();

        }
        private void ReleaseImageButton_Click(object sender, EventArgs e)
        {
            Release_LicenseFrm Frm = new Release_LicenseFrm();
            Frm.OnLicenseReleased += ChangeSpecificLicenseRowStatus;        
            if (!Frm.IsDisposed)
                Frm.ShowDialog();
        }
        private void DetainImageButton_Click(object sender, EventArgs e)
        {
            DetainLicenseFrm Frm = new DetainLicenseFrm();
            Frm.OnLicenseDetained += GetNewDetainedlicenseRecord;
            if (!Frm.IsDisposed)
                Frm.ShowDialog();
        }

        
    }
}
