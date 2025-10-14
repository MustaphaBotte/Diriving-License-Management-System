using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLMS.EntitiesNamespace;
using DesktopApp.InternationalDrivingLicense;
using DesktopApp.LocDrivingLicense;

namespace DesktopApp.LicensesHistory
{
    public partial class LicensesHistoryControl : UserControl
    {
        private int DriverId = -1;
        Entities.ClsDriver? _Driver = null;
        public LicensesHistoryControl()
        {
            InitializeComponent();
        }
        private void FillLocalLicenses()
        {
            DataTable? LocalLicenses = DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.GetAllLocalDriverLicenses(this.DriverId);
            if (LocalLicenses == null)
                return;
            foreach (DataRow Row in LocalLicenses.Rows)
            {
                int RowIndex = LocalLicencesGrid.Rows.Add();
                LocalLicencesGrid.Rows[RowIndex].Cells["Lic_ID"].Value = Row["LicenseID"];
                LocalLicencesGrid.Rows[RowIndex].Cells["AppId"].Value = Row["ApplicationID"];
                LocalLicencesGrid.Rows[RowIndex].Cells["ClassName"].Value = Row["ClassName"];
                LocalLicencesGrid.Rows[RowIndex].Cells["IssueDate"].Value = Row["IssueDate"];
                LocalLicencesGrid.Rows[RowIndex].Cells["ExpirationDate"].Value = Row["ExpirationDate"];
                LocalLicencesGrid.Rows[RowIndex].Cells["IsActive"].Value = Row["IsActive"];
            }
            LocalLicencesGrid.Refresh();
            LocalRowCountLBL.Text = LocalLicencesGrid.RowCount.ToString();
        }
        private void FillInternationalLicenses()
        {
            DataTable? InternationalLicenses = DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.GetAllInternationalDriverLicenses(this.DriverId);
            if (InternationalLicenses == null)
                return;
            foreach (DataRow Row in InternationalLicenses.Rows)
            {
                int RowIndex = InternatiolLicensesGrid.Rows.Add();
                InternatiolLicensesGrid.Rows[RowIndex].Cells["IL_LicID"].Value = Row["InternationalLicenseID"];
                InternatiolLicensesGrid.Rows[RowIndex].Cells["InterGridAppID"].Value = Row["ApplicationID"];
                InternatiolLicensesGrid.Rows[RowIndex].Cells["LocalLicenseID"].Value = Row["IssuedUsingLocalLicenseID"];
                InternatiolLicensesGrid.Rows[RowIndex].Cells["InterGridIssueDate"].Value = Row["IssueDate"];
                InternatiolLicensesGrid.Rows[RowIndex].Cells["InterGridExpDate"].Value = Row["ExpirationDate"];
                InternatiolLicensesGrid.Rows[RowIndex].Cells["InterGridIsActive"].Value = Row["IsActive"];
            }
            LocalLicencesGrid.Refresh();
            InterRowCountLabel.Text = LocalLicencesGrid.RowCount.ToString();
        }

        public void LoadByPersonID(int PersonID)
        {
            _Driver = DLMS.BusinessLier.Driver.DriverLogic.GetDriverByPersonId(PersonID);
            if (_Driver == null)
            {
                MessageBox.Show($"Person with ID = {PersonID} is not a driver", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DriverId = _Driver.DriverID;
            FillLocalLicenses();
            FillInternationalLicenses();
        }
        public void LoadByDriverID(int DriverID)
        {
            _Driver = DLMS.BusinessLier.Driver.DriverLogic.GetDriverById(DriverID);
            if (_Driver == null)
            {
                MessageBox.Show($"Driver with ID = {DriverID} not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DriverId = _Driver.DriverID;
            FillLocalLicenses();
            FillInternationalLicenses();
        }
        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Lic_ID = 0;
            if (Pages.SelectedIndex == 0)
            {
                Lic_ID = int.TryParse(LocalLicencesGrid.SelectedRows[0].Cells["Lic_ID"].Value.ToString(), out int Val) ? Val : 0;
                ShowLicenseFrm Frm = new ShowLicenseFrm(LicenseID: Lic_ID);
                Frm.ShowDialog();
            }
            else if (Pages.SelectedIndex == 1)
            {
                Lic_ID = int.TryParse(InternatiolLicensesGrid.SelectedRows[0].Cells["IL_LicID"].Value.ToString(), out int Val) ? Val : 0;
                ShowInternationalLicenseFrm Frm = new ShowInternationalLicenseFrm(Lic_ID);
                Frm.ShowDialog();
            }
        }
        private void Grids_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ShowLicenseMenuStrip.Show(Cursor.Position);
            }
        }
        public void Clear()
        {
            InternatiolLicensesGrid.Rows.Clear();
            LocalLicencesGrid.Rows.Clear();
        }
        private void Pages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Pages.SelectedIndex == 0)
                LocalRowCountLBL.Text = LocalLicencesGrid.Rows.Count.ToString();
            else
                InterRowCountLabel.Text = InternatiolLicensesGrid.Rows.Count.ToString();

        }

    }
}
