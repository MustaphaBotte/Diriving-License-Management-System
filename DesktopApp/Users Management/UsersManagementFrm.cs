using DesktopApp.ManageUser;
using DLMS.BusinessLier.User;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.UsersManagement
{
    public partial class UsersManagementFrm : Form
    {
        private DataTable? Users;
        public UsersManagementFrm()
        {
            InitializeComponent();
        }
        private void FillFilterList()
        {
            FilterChoices.Items.Add("None"); ;
            foreach (DataGridViewColumn Column in DataGrid.Columns)
                FilterChoices.Items.Add(Column.Name);

            FilterChoices.SelectedIndex = 0;
        }
        private void UsersManagement_Load(object sender, EventArgs e)
        {
            this.Users = DLMS.BusinessLier.User.UserLogic.GetAllUsers();

            if (Users == null)
            {
                DataGrid.Visible = false;
                MessageBox.Show(text: "There is no data in database", caption: "No Data",
                    icon: MessageBoxIcon.Information, buttons: MessageBoxButtons.OK);
                return;
            }
            DataGrid.AutoGenerateColumns = true;
            DataGrid.DataSource = Users;
            DataGrid.Refresh();
            FillFilterList();
            DataGrid.Visible = true;
            this.RowsCountlabel.Text = DataGrid.RowCount.ToString();
        }

        private void DataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                UsersMenuStrip.Show(Cursor.Position);
            }
        }
        private void RefreshTheGrid()
        {
            this.Users = DLMS.BusinessLier.User.UserLogic.GetAllUsers();
            if (Users == null)
            {
                DataGrid.Visible = false;
                MessageBox.Show(text: "There is no data in database", caption: "No Data",
                    icon: MessageBoxIcon.Information, buttons: MessageBoxButtons.OK);
                return;
            }
            DataGrid.DataSource = "";
            DataGrid.Refresh();
            //just for animation;
            DataGrid.DataSource = Users;
            DataGrid.Refresh();
            this.RowsCountlabel.Text = DataGrid.RowCount.ToString();
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
                FilterOfStatus.Visible = false;
                return;
            }
            if (FilterChoices.SelectedItem?.ToString()?.ToLower() == "isactive")
            {
                FilterValueTextBox.Visible = false;
                FilterOfStatus.Visible = true;
                return;
            }
            FilterValueTextBox.Visible = true;
            FilterOfStatus.Visible = false;
        }

        private void AppLyFilter(string Filter)
        {
            if (Users == null)
                return;
            try
            {
                Users.DefaultView.RowFilter = Filter;
            }
            catch
            {
                Users.DefaultView.RowFilter = "";
            }
        }
        private void FilterValueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Users == null)
                return;

            string Value = FilterValueTextBox.Text;



            if (string.IsNullOrEmpty(Value) || FilterChoices.SelectedItem == null)
            {
                Users.DefaultView.RowFilter = "";
                return;
            }

            string? ColumnName = FilterChoices.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(ColumnName))
                return;

            //Get the column object
            DataColumn? column = Users.Columns[ColumnName];
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

            if (Types.Contains(Type.GetTypeCode(column.DataType)))
            {
                Filter = $"CONVERT({column.ColumnName},'System.String') like '%{Value.ToString()}%'";
            }
            AppLyFilter(Filter);
        }

        private void FilterOfStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Users == null)
                return;
            string Filter = "";
            if (sender.GetType() == typeof(Guna2ComboBox))
            {
                if (FilterOfStatus.SelectedItem == null)
                {
                    Users.DefaultView.RowFilter = string.Empty;
                    return;
                }
                if (((string)FilterOfStatus.SelectedItem).ToLower() == "all")
                {
                    Users.DefaultView.RowFilter = string.Empty;
                    return;
                }
                else if (((string)FilterOfStatus.SelectedItem).ToLower() == "active")
                {
                    Filter = "isactive = true";
                }
                else if (((string)FilterOfStatus.SelectedItem).ToLower() == "suspended")
                {
                    Filter = "isactive = false";
                }
            }
            AppLyFilter(Filter);
        }

        private void RefreshButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;

        }
        private void RefreshButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            //just for the animation
            this.Cursor = Cursors.WaitCursor;
            RefreshTheGrid();
            this.Cursor = Cursors.Hand;

        }

        private void ButtonDeletePerson_Click(object sender, EventArgs e)
        {

            if (DataGrid.SelectedRows.Count == 0)
            {
                return;
            }

            string IDs = "";
            string Question = DataGrid.SelectedRows.Count > 1 ? "Are you sure you want to delete the following users?" :
                "Are you sure you want to delete this user";

            DataGridViewRow row = DataGrid.SelectedRows[0];
            if (!row.Cells.Contains(row.Cells["Userid"]))
            {
                return;
            }
            foreach (DataGridViewRow Row in DataGrid.SelectedRows)
            {
                int UserID = int.TryParse(Row.Cells["Userid"].Value.ToString(), out int ID) ? ID : -1;
                string? Username = Row.Cells["username"].Value.ToString();
                IDs += $"ID: {UserID} , Username: {Username}\n";
            }

            DialogResult result = MessageBox.Show(
                         $"{Question}\n\n{IDs}\n This action cannot be undone.",
                         "Confirm Users Deletion",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Warning,
                         MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return;
            }

            foreach (DataGridViewRow Row in DataGrid.SelectedRows)
            {
                int UserID = int.TryParse(Row.Cells["UserID"].Value.ToString(), out int ID) ? ID : -1;
                string? Username = Row.Cells["Username"].Value.ToString();
                int Result = UserLogic.DeleteUser(UserID);
                if (Result == -1)
                {
                    string Errors = $"ID :{UserID} Username:{Username}\n";
                    MessageBox.Show(
                    $"Cant delete the following Users :\n{Errors} Because He Has Data linked To it.\n (Error code SQL_547)", "Integrity Violation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                   );
                }
                else if (Result == 1)
                {
                    string Success = $"ID :{UserID} Username:{Username}\n";
                    MessageBox.Show(
                    $"The following User are deleted :\n{Success}",
                    "Deletion Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                }
                else if (Result == 0)
                {
                    string Success = $"ID :{UserID} UserName :{Username}\n";
                    MessageBox.Show(
                    $"due an internal error we cannot delete The following User :\n{Success}",
                    "Deletion failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                }
            }
            RefreshTheGrid();
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            ManageUser.Add_edit_UserFrm Frm = new ManageUser.Add_edit_UserFrm();
            Frm.SendSignaltoRefresh += RefreshTheGrid;
            Frm.ShowDialog();
        }

        private void EditPersonButton_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow Row = DataGrid.SelectedRows[0];
            if (!Row.Cells.Contains(Row.Cells["personid"]))
            {
                return;
            }
            ManageUser.Add_edit_UserFrm Frm = new ManageUser.Add_edit_UserFrm();
            int UserID = Convert.ToInt32(DataGrid.SelectedRows[0].Cells["userid"].Value);
            int personId = Convert.ToInt32(Row.Cells["personid"].Value);

            if (!UserLogic.Exists(UserID))
            {
               DialogResult Res = MessageBox.Show($"sorry the current user not exists you going now to create another one using that person id {personId}" +
                    " .please refresh and try ", "User Not Found",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if(Res==DialogResult.Cancel)
                {
                    return;
                }
            }
            Frm.SearchForPerson(personId, alreadyAUser: true);
            Frm.ShowDialog();
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count == 0)
            {
                return;
            }
            int UserID = Convert.ToInt32(DataGrid.SelectedRows[0].Cells["userid"].Value);
            if (!UserLogic.Exists(UserID))
            {
                MessageBox.Show("sorry the current user not available .please refresh and try ", "User Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ChangeUserPassFrm Frm = new ChangeUserPassFrm(UserID);
            Frm.ShowDialog();
        }

        private void ShowInfoButton_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow Row = DataGrid.SelectedRows[0];
            if (!Row.Cells.Contains(Row.Cells["UserID"]))
            {
                return;
            }
            int UserID = int.TryParse(Row.Cells["UserID"].Value.ToString(), out int ID) ? ID : -1;
            if (!UserLogic.Exists(UserID))
            {
                MessageBox.Show("sorry the current user not available .please refresh and try ", "User Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ShowUserInfoFrm Frm = new ShowUserInfoFrm(UserID);
            Frm.ShowDialog();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FilterValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (FilterChoices.SelectedItem == null)
                return;
            string? choice = FilterChoices.SelectedItem.ToString()?.ToLower();
            if (choice == "userid" || choice == "personid")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

            }
        }
    }
}
