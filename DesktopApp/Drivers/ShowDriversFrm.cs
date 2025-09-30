using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Drivers
{
    public partial class ShowDriversFrm : Form
    {
        public ShowDriversFrm()
        {
            InitializeComponent();
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
            DataTable? Drivers = DLMS.BusinessLier.Driver.DriverLogic.GetAllDrivers();

            if (Drivers == null || Drivers.Rows.Count == 0)
            {
                MessageBox.Show("There is no driver in the system", "No Drivers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (DataRow Row in Drivers.Rows)
            {
                int RowIndex = DataGrid.Rows.Add();
                DataGrid.Rows[RowIndex].Cells["DriverID"].Value = Row["DriverID"];
                DataGrid.Rows[RowIndex].Cells["PersonID"].Value = Row["PersonID"];
                DataGrid.Rows[RowIndex].Cells["NationalNo"].Value = Row["NationalNo"];
                DataGrid.Rows[RowIndex].Cells["FullName"].Value = Row["FullName"];
                DataGrid.Rows[RowIndex].Cells["CreatedDate"].Value = Row["CreatedDate"];
                DataGrid.Rows[RowIndex].Cells["Active_Licenses"].Value = Row["Active_Licenses"];

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
                FilterValueTextBox_TextChanged(sender, e);//show them all witout filter
                return;
            }

            if (FilterChoices.SelectedItem.ToString()?.ToLower() == ("createddate"))
            {
                FilterValueTextBox.Visible = false;
                DateTimePicker.Visible = true;
                DateTimePicker.Value = DateTime.Now;
                return;
            }
            FilterValueTextBox.Visible = true;
            DateTimePicker.Visible = false;

        }
        private void ShowDriversFrm_Load(object sender, EventArgs e)
        {
            FillTheGrid();
            FillFilterList();
        }

        private void FilterValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string? Filter = FilterChoices.SelectedItem?.ToString();
            if (Filter == "")
                return;

            if ((Filter == "PersonID" || Filter == "DriverID" || Filter == "Active_Licenses") && !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
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
                    this.RowsCountlabel.Text = RowCount.ToString();
                }
                return;
            }

            if (((List<string>)["PersonID", "DriverID", "Active_Licenses", "FullName", "NationalNo"]).Contains(Filter))
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
            if (Filter == "CreatedDate")
            {
                foreach (DataGridViewRow Row in DataGrid.Rows)
                {
                    if (Row.Cells["CreatedDate"].Value == DBNull.Value)
                    {
                        Row.Visible = false;
                        RowCount -= 1;
                        continue;
                    }

                    if (((DateTime)Row.Cells["CreatedDate"].Value).Date != DateTimePicker.Value.Date)
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
    }
}
