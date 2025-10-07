using DesktopApp.ManageAppType;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DesktopApp.AppTypesManagement
{
    public partial class AppTypesManagementFrm : Form
    {
        public AppTypesManagementFrm()
        {
            InitializeComponent();
        }

        private void AppTypesManagementFrm_Load(object sender, EventArgs e)
        {
            FillTheGrid();
        }
        private void FillTheGrid()
        {
            DataTable? ApplicationTypes = DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetAllApplicationTypes();
            if (ApplicationTypes == null)
            {
                MessageBox.Show("No Applications in the system for now please try again\n and if the problem persists please contact your admin",
                    "Empty Table", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            DataGrid.AutoGenerateColumns = true;
            DataGrid.DataSource = ApplicationTypes;
            DataGrid.Columns[0].HeaderText = "ID";
            DataGrid.Columns[0].Width = 110;

            DataGrid.Columns[1].HeaderText = "Title";
            DataGrid.Columns[1].Width = 400;

            DataGrid.Columns[2].HeaderText = "Fees";
            DataGrid.Columns[2].Width = 100;

            DataGrid.Refresh();
            RowsCountlabel.Text = DataGrid.RowCount.ToString();

        }
        private void refreshTheGrid()
        {
            DataGrid.DataSource = "";
            DataGrid.Refresh();
            //for the animation
            FillTheGrid();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            refreshTheGrid();
        }

        private void EditAppTypeMenuItem_Click(object sender, EventArgs e)
        {
            if (!DataGrid.SelectedRows[0].Cells.Contains(DataGrid.SelectedRows[0].Cells["applicationtypeid"]))
            {
                MessageBox.Show("Error while trying to show the edit environment refresh or reopen the app.", "Internal Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error); return;
            }
            int Id = Convert.ToInt32(DataGrid.SelectedRows[0].Cells["applicationtypeid"].Value);
            EditAppTypeFrm Frm = new EditAppTypeFrm(Id);
            Frm.ApplicationTypeEdited += refreshTheGrid;
            Frm.ShowDialog();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void RefreshButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    
        private void DataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ApplicationTypesMenuStrip.Show(Cursor.Position);
            }
        }
    }
}
