using DesktopApp.ManageAppType;
using DesktopApp.ManageTestType;
using DLMS.EntitiesNamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.ManageTests
{
    public partial class ManageTestTypesFrm : Form
    {
        public ManageTestTypesFrm()
        {
            InitializeComponent();
        }

        private void ManageTestTypesFrm_Load(object sender, EventArgs e)
        {
            FillTheGrid();
        }
        private void FillTheGrid()
        {

            DataTable? Applications = DLMS.BusinessLier.TestTypes.TestTypesLogic.GetAllTestTypes();
            if (Applications == null)
            {
                MessageBox.Show("No Test type found in the system for now plaese try again\n and if the problem persists please contact your admin",
                    "Empty Table", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            DataGrid.AutoGenerateColumns = true;
            DataGrid.DataSource = Applications;
            DataGrid.Columns[0].HeaderText = "ID";
            DataGrid.Columns[0].Width = 120;

            DataGrid.Columns[1].HeaderText = "Title";
            DataGrid.Columns[1].Width = 200;

            DataGrid.Columns[2].HeaderText = "Description";
            DataGrid.Columns[2].Width = 400;

            DataGrid.Columns[3].HeaderText = "Fees";
            DataGrid.Columns[3].Width = 100;
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
            if (e.Button == MouseButtons.Right)
            {
                TestTypesMenuStrip.Show(Cursor.Position);
            }
        }

        private void EditTestTypeMenuItem_Click(object sender, EventArgs e)
        {
            if(!DataGrid.SelectedRows[0].Cells.Contains(DataGrid.SelectedRows[0].Cells["testtypeid"]))
            {
                MessageBox.Show("Error while trying to show the edit test type environment.\n please refresh or reopen the app.", "Internal Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error); return;
            }
            int Id = Convert.ToInt32(DataGrid.SelectedRows[0].Cells["TestTypeid"].Value);
            EditTestTypeFrm Frm = new EditTestTypeFrm((Entities.ClsTestType.EnTestType)Id);
            Frm.TestTypeEdited += refreshTheGrid;
            Frm.ShowDialog();
        }
    }



}
