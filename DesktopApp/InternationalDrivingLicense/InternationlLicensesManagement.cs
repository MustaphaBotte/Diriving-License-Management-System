using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.InternationalDrivingLicense
{
    public partial class InternationlLicensesManagement : Form
    {
        DataTable? Licenses = new DataTable();
        public InternationlLicensesManagement()
        {
            InitializeComponent();
        }
        private void FillFilterList()
        {
            FilterChoices.Items.Add("None");
            foreach (DataGridViewColumn Column in DataGrid.Columns)
                FilterChoices.Items.Add(Column.HeaderText);

            FilterChoices.SelectedIndex = 1;
            this.FilterValueTextBox.Focus();
        }
        private void FillTheGrid()
        {
            Licenses = DLMS.BusinessLier.InternationDriLicense.InternationDriLicenseLogic.GetAllInternationalLicenses();

            if (Licenses == null || Licenses.Rows.Count == 0)
            {
                MessageBox.Show("There is no driver in the system", "No Drivers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (DataRow Row in Licenses.Rows)
            {
                int Index = DataGrid.Rows.Add();
                DataGrid.Rows[Index].Cells["InternationalLicenseID"].Value = Row["InternationalLicenseID"];
                DataGrid.Rows[Index].Cells["ApplicationID"].Value = Row["ApplicationID"];
                DataGrid.Rows[Index].Cells["DriverID"].Value = Row["DriverID"];
                DataGrid.Rows[Index].Cells["IssuedUsingLocalLicenseID"].Value = Row["IssuedUsingLocalLicenseID"];
                DataGrid.Rows[Index].Cells["IssueDate"].Value = Row["IssueDate"];
                DataGrid.Rows[Index].Cells["ExpirationDate"].Value = Row["ExpirationDate"];
                DataGrid.Rows[Index].Cells["IsActive"].Value = Row["IsActive"];
                DataGrid.Rows[Index].Cells["CreatedByUserID"].Value = Row["CreatedByUserID"];
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
                FilterValueTextBox.Text = "";
                FilterValueTextBox_TextChanged(sender, e);//show them all witout filter
                return;
            }

            if (FilterChoices.SelectedItem.ToString()?.ToLower() == "issued" || FilterChoices.SelectedItem.ToString()?.ToLower() == "expires")
            {
                FilterValueTextBox.Visible = false;
                DateTimePicker.Visible = true;
                DateTimePicker.Value = DateTime.Now;
                FilterValueTextBox.Text = "";
                return;
            }
            FilterValueTextBox.Visible = true;
            DateTimePicker.Visible = false;
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            FillTheGrid();
        }

        private void InternationlLicensesManagement_Load(object sender, EventArgs e)
        {
            FillTheGrid();
            foreach (DataGridViewColumn col in DataGrid.Columns)
            {
                switch (col.Name)
                {
                    case "InternationalLicenseID": col.HeaderText = "ID"; break;
                    case "ApplicationID": col.HeaderText = "AppID"; break;
                    case "DriverID": col.HeaderText = "Driver"; break;
                    case "IssuedUsingLocalLicenseID": col.HeaderText = "LocalLic"; break;
                    case "IssueDate": col.HeaderText = "Issued"; break;
                    case "ExpirationDate": col.HeaderText = "Expires"; break;
                    case "IsActive": col.HeaderText = "Active"; break;
                    case "CreatedByUserID": col.HeaderText = "User"; break;
                }
            }
            FillFilterList();
        }

        private void FilterValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
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
                }
                this.RowsCountlabel.Text = RowCount.ToString();
                return;
            }
            int SelectedIndex = FilterChoices.SelectedIndex;
            if (Filter.ToLower() == "issued" || Filter.ToLower() == "expires")
            {
                foreach (DataGridViewRow Row in DataGrid.Rows)
                {
                    DateTime Date = (DateTime)Row.Cells[SelectedIndex - 1].Value;
                    if (Date.ToString("yyyy-MM-dd") != DateTimePicker.Value.ToString("yyyy-MM-dd").ToLower())
                    {
                        Row.Visible = false;
                        RowCount -= 1;
                    }
                    else
                    {
                        Row.Visible = true;
                    }
                }
                this.RowsCountlabel.Text = RowCount.ToString();
                return;
            }
            foreach (DataGridViewRow Row in DataGrid.Rows)
            {
                if (!Row.Cells[SelectedIndex - 1].Value?.ToString()?.ToLower().Contains(FilterValueTextBox.Text.ToString().ToLower()) ?? false)
                {
                    Row.Visible = false;
                    RowCount -= 1;
                }
                else
                {
                    Row.Visible = true;
                }
            }

            this.RowsCountlabel.Text = RowCount.ToString();
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            FilterValueTextBox_TextChanged(sender, e);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowInfoButton_Click(object sender, EventArgs e)
        {
            int DriverID = (int)DataGrid.SelectedRows[0].Cells["DriverID"].Value;
            int PersonID = DLMS.BusinessLier.Driver.DriverLogic.GetDriverById(DriverID)?.PersonID ?? 0;
            ManagePerson.ShowPerson Frm = new ManagePerson.ShowPerson(PersonID);
            Frm.ShowDialog();
        }

        private void ShowLicensesHistoryBtn_Click(object sender, EventArgs e)
        {
            int DriverID = (int)DataGrid.SelectedRows[0].Cells["DriverID"].Value;
            int PersonID = DLMS.BusinessLier.Driver.DriverLogic.GetDriverById(DriverID)?.PersonID ?? 0;
            AllLicensesHistory.ShowAllLicensesHistoryFrm Frm = new AllLicensesHistory.ShowAllLicensesHistoryFrm(PersonID);
            Frm.ShowDialog();
        }

        private void ShowLicensebtn_Click(object sender, EventArgs e)
        {
            int licenseID = (int)DataGrid.SelectedRows[0].Cells["InternationalLicenseID"].Value;
            ShowInternationalLicenseFrm Frm = new ShowInternationalLicenseFrm(licenseID);
            Frm.ShowDialog();
        }

        private void DataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.licenseMenuStrip.Show(Cursor.Position);
            }
        }

        private void IssueNewLicensebtn_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void IssueNewLicensebtn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void InsertNewLicense(int LicesseId,Form sender)
        {
            DLMS.EntitiesNamespace.Entities.ClsInternationalLicense? license = DLMS.BusinessLier.InternationDriLicense.InternationDriLicenseLogic.GetLicenseByInterNatID(LicesseId);
            if(license !=null)
            {
                DataGridViewRow Row = new DataGridViewRow();
                Row.CreateCells(DataGrid);
                int Index = DataGrid.Rows.Add();
                Row.Cells[0].Value= license.InternationLicenseID;
                Row.Cells[1].Value = license.ApplicationID;
                Row.Cells[2].Value= license.DriverID;
                Row.Cells[3].Value = license.IssueUsingLocLicID;
                Row.Cells[4].Value= license.IssueDate;
                Row.Cells[5].Value = license.ExpirationDate;
                Row.Cells[6].Value = license.IsActive;
                Row.Cells[7].Value = license.CreatedByUserID;
                DataGrid.Rows.Insert(0, Row);
                DataGrid.ClearSelection();
                Row.Selected = true;
                if (sender != null)
                    sender.Close();
            }
        }
        private void IssueNewLicensebtn_Click(object sender, EventArgs e)
        {
            IssueInternationalDrivingLicenseFrm Frm = new IssueInternationalDrivingLicenseFrm();
            Frm.OnLicenseIssued += InsertNewLicense;
            Frm.ShowDialog();
        }
    }
}
