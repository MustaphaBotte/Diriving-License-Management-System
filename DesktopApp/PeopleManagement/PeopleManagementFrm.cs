

using DesktopApp.ManagePerson;
using Guna.UI2.WinForms;
using System.Threading;
using System.Data;
using static Guna.UI2.Native.WinApi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using DesktopApp.User_Control;
using DLMS.BusinessLier.User;
using Microsoft.VisualBasic.ApplicationServices;
using DLMS.BusinessLier.Person;

namespace DesktopApp.PeopleManagement
{
    public partial class PeopleManagementFrm : Form
    {
        private DataTable? People;
        public PeopleManagementFrm()
        {
            InitializeComponent();
        }
        private void FillFilterList()
        {
            FilterChoices.Items.Add("None"); ;
            foreach (DataGridViewColumn Column in DataGrid.Columns)
            {
                if(!((List<string>)["ImagePath", "NationalityCountryID", "Address"]).Contains(Column.Name))
                {
                    FilterChoices.Items.Add(Column.Name);
                }
            }

            FilterChoices.SelectedIndex = 0;
        }      
        private void GridFiller()
        {
            DataGrid.AutoGenerateColumns = true;
            DataGrid.DataSource = People;
            DataGrid.Columns["ImagePath"].Visible = false;
            DataGrid.Columns["NationalityCountryID"].Visible = false;
            DataGrid.Columns["Address"].Visible = false;

            if (DataGrid.Rows.Count > 0)
            {

                DataGrid.Columns["PersonID"].HeaderText = "Person ID";
                DataGrid.Columns["PersonID"].Width = 80;


                DataGrid.Columns["NationalNo"].HeaderText = "National No";
                DataGrid.Columns["NationalNo"].Width = 90;


                DataGrid.Columns["FirstName"].HeaderText = "First Name";
                DataGrid.Columns["FirstName"].Width = 120;


                DataGrid.Columns["SecondName"].HeaderText = "Second Name";
                DataGrid.Columns["SecondName"].Width = 140;


                DataGrid.Columns["thirdName"].HeaderText = "Third Name";
                DataGrid.Columns["ThirdName"].Width = 120;

                DataGrid.Columns["LastName"].HeaderText = "Last Name";
                DataGrid.Columns["LastName"].Width = 120;

                DataGrid.Columns["Gender"].HeaderText = "Gender";
                DataGrid.Columns["Gender"].Width = 60;

                DataGrid.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
                DataGrid.Columns["DateOfBirth"].Width = 140;


                DataGrid.Columns["CountryName"].HeaderText = "Nationality";
                DataGrid.Columns["CountryName"].Width = 100;


                DataGrid.Columns["phone"].HeaderText = "Phone";
                DataGrid.Columns["phone"].Width = 100;

                DataGrid.Columns["Email"].HeaderText = "Email";
                DataGrid.Columns["Email"].Width = 150;
            }

        }
        private void FrmLoad(object sender, EventArgs e)
        {

            this.People = DLMS.BusinessLier.Person.PersonLogic.GetAllPeople();
            if (People == null)
            {
                DataGrid.Visible = false;
                MessageBox.Show(text: "There is no data in database", caption: "No Data",
                    icon: MessageBoxIcon.Information, buttons: MessageBoxButtons.OK);
                return;
            }
            GridFiller();
            FillFilterList();           
            DataGrid.Visible = true;
            DataGrid.Refresh();
            this.RowsCountlabel.Text = DataGrid.RowCount.ToString();
        }
        private void DataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                PeopleMenuStrip.Show(Cursor.Position);
            }
        }
        private void RefreshTheGrid()
        {
            DataGrid.DataSource = "";
            this.Cursor = Cursors.WaitCursor;
            this.People= DLMS.BusinessLier.Person.PersonLogic.GetAllPeople();
            DataGrid.Refresh();
            GridFiller();
            this.RowsCountlabel.Text = DataGrid.RowCount.ToString();
        }
        private void EditPersonButton_Click(object sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            ToolStripMenuItem button = (ToolStripMenuItem)sender;
            if (button.Name?.ToLower() == "editpersonbutton")
            {
                DataGridViewRow Row = DataGrid.SelectedRows[0];
                int PersonId = int.TryParse(Row.Cells["PersonID"].Value.ToString(), out int result) ? result : -1;
                if (!PersonLogic.Exists(PersonId))
                {
                    MessageBox.Show("sorry the current person not available .please refresh and try ", "person Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AddEditPersonFrm PersonFrm = new AddEditPersonFrm(PersonId);
                PersonFrm.SendSignalToRefresh += RefreshTheGrid;
                PersonFrm.ShowDialog();
            }
        }
        private void AddNewButton_Click(object sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            Guna2Button button = (Guna2Button)sender;
            if (button.Name.ToLower() == "addnewbutton")
            {

                AddEditPersonFrm PersonFrm = new AddEditPersonFrm();
                PersonFrm.SendSignalToRefresh += RefreshTheGrid;

                PersonFrm.ShowDialog();
            }
        }
        private void ButtonDeletePerson_Click(object sender, EventArgs e)
        {

            if (DataGrid.SelectedRows.Count == 0)
            {
                return;
            }

            string IDs = "";
            string Question = DataGrid.SelectedRows.Count > 1 ? "Are you sure you want to delete the following persons?" :
                "Are you sure you want to delete this person";

            foreach (DataGridViewRow Row in DataGrid.SelectedRows)
            {
                int PersonID = int.TryParse(Row.Cells["PersonID"].Value.ToString(), out int ID) ? ID : -1;
                string? NationaNo = Row.Cells["NationalNo"].Value.ToString();
                IDs += $"ID: {PersonID} , National Number: {NationaNo}\n";
            }
            DialogResult result = MessageBox.Show(
                      $"{Question}\n\n{IDs}\n This action cannot be undone.",
                      "Confirm Person Deletion",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Warning,
                      MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {

                foreach (DataGridViewRow Row in DataGrid.SelectedRows)
                {
                    int PersonID = int.TryParse(Row.Cells["PersonID"].Value.ToString(), out int ID) ? ID : -1;
                    string? NationaNo = Row.Cells["NationalNo"].Value.ToString();
                    int Result = DLMS.BusinessLier.Person.PersonLogic.DeletePerson(PersonID);
                    if (Result == -1)
                    {
                        string Errors = $"ID :{PersonID} National Number :{NationaNo}\n";
                        MessageBox.Show(
                        $"Cant delete the following person :\n{Errors} Because he Has Data linked To it . (Error code SQL_547)", "Integrity Violation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                       );
                    }
                    else if (Result == 1)
                    {
                        string Success = $"ID :{PersonID} National Number :{NationaNo}\n";
                        MessageBox.Show(
                        $"The following person are deleted :\n{Success}",
                        "Deletion Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                    }
                    else if (Result == 0)
                    {
                        string Success = $"ID :{PersonID} National Number :{NationaNo}\n";
                        MessageBox.Show(
                        $"due an internal error we cannot delete The following person :\n{Success}",
                        "Deletion failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    }
                }

                RefreshTheGrid();
            }


        }
        private void ShowInfoButton_Click(object sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            ToolStripMenuItem? button = (ToolStripMenuItem)sender;
            if (button.Name?.ToLower() == "showinfobutton")
            {
                DataGridViewRow Row = DataGrid.SelectedRows[0];
                int PersonId = int.TryParse(Row.Cells["PersonID"].Value.ToString(), out int result) ? result : -1;
                if (!PersonLogic.Exists(PersonId))
                {
                    MessageBox.Show("sorry the current person not available .please refresh and try ", "person Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ShowPerson PersonFrm = new ShowPerson(PersonId);
                PersonFrm.ShowDialog();

            }
        }
        private void FilterValueTextBox_TextChanged(object sender, EventArgs e)
        {
            
            if (People == null)
                return;

            string Value = FilterValueTextBox.Text;

            if (FilterChoices.SelectedItem?.ToString() == "None")
            {
                People.DefaultView.RowFilter = "";
                return;
            }

            string? ColumnName = FilterChoices.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(ColumnName))
                return;

            //Get the column object
            DataColumn? column = People.Columns[ColumnName];
            if (column == null)
            {
                MessageBox.Show(text: "Invalid column or something else please try again or restart the program ", caption: "Technical Issue",
                 MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                People.DefaultView.RowFilter = "";
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
                People.DefaultView.RowFilter = Filter;
                this.RowsCountlabel.Text = People.DefaultView.Count.ToString();
            }
            catch
            {
                People.DefaultView.RowFilter = "";
            }

        }
        private void PeopleManagementFrm_SizeChanged(object sender, EventArgs e)
        {
            DataGrid.Size = this.Size;
        }
        private void FilterChoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterValueTextBox.Text = "";
            if (FilterChoices.SelectedItem == null || FilterChoices.SelectedItem.ToString() == "")
            {
                return;
            }

            if (FilterChoices.SelectedItem.ToString()?.ToLower() == ("none"))
            {
                FilterValueTextBox.Visible = false;
                DateTimePicker.Visible = false;
                if(People!=null)
                      People.DefaultView.RowFilter="";
                return;
            }

            if (FilterChoices.SelectedItem.ToString()?.ToLower() == ("dateofbirth"))
            {
                FilterValueTextBox.Visible = false;
                DateTimePicker.Visible = true;
                return;
            }
            FilterValueTextBox.Visible = true;
            FilterValueTextBox.Focus();
            FilterValueTextBox.Clear();
            DateTimePicker.Visible = false;
            if (People != null)
            {
                People.DefaultView.RowFilter = string.Empty;
            }
        }
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //for reuseability
            FilterValueTextBox_TextChanged(sender, e);
        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            //just for the animation
            this.Cursor = Cursors.WaitCursor;
            DataGrid.DataSource = "";
            DataGrid.Refresh();
            RefreshTheGrid();
            this.Cursor = Cursors.Hand;

        }
        private void FilterValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (FilterChoices.SelectedItem == null)
                return;
            string? choice = FilterChoices.SelectedItem.ToString()?.ToLower();
            if (choice == "personid" || choice == "nationalitycountryid" || choice == "gender")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
        private void PeopleManagementFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.People?.Clear();
            this.BackgroundImage?.Dispose();
        }
        private void DataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowInfoButton.PerformClick();
        }
    }
}
