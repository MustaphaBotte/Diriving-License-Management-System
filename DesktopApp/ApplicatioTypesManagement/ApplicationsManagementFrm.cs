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

namespace DesktopApp.Applicatios_Management
{
    public partial class ApplicationsManagementFrm : Form
    {
        public ApplicationsManagementFrm()
        {
            InitializeComponent();
        }

        private void ApplicationsManagementFrm_Load(object sender, EventArgs e)
        {
            FillTheGrid();
        }
        private void FillTheGrid()
        {
            DataTable? ApplicationTypes = DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetAllApplicationTypes();
            if (ApplicationTypes == null)
            {
                MessageBox.Show("No Applications in the system for now plaese try again\n and if the problem persists please contact your admin",
                    "Empty Table", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            DataGrid.AutoGenerateColumns = true;
            DataGrid.DataSource = ApplicationTypes;
            DataGrid.Refresh();
            RowsCountlabel.Text = DataGrid.RowCount.ToString();

        }
        private void refreshTheGrid()
        {
            DataGrid.DataSource = "";
            DataGrid.Refresh();
            //for the animation
            DataGrid.DataSource = DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetAllApplicationTypes();
            DataGrid.Refresh();
            RowsCountlabel.Text = DataGrid.RowCount.ToString();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            refreshTheGrid();
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

        private void EditAppTypeMenuItem_Click(object sender, EventArgs e)
        {
            if (!DataGrid.SelectedRows[0].Cells.Contains(DataGrid.SelectedRows[0].Cells["applicationtypeid"]))
            {
                MessageBox.Show("Error while trying to show the edit environment refresh or reopen the app.", "Internal Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error); return;
            }
            int Id = Convert.ToInt32(DataGrid.SelectedRows[0].Cells["applicationtypeid"].Value);
            EditAppTypeFrm Frm = new EditAppTypeFrm(Id);
            Frm.ApplicationTypeedited += refreshTheGrid;
            Frm.ShowDialog();
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
