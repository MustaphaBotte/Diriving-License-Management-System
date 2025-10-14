using DesktopApp.InternationalDrivingLicense;
using DesktopApp.LocDrivingLicense;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.AllLicensesHistory
{
    public partial class ShowAllLicensesHistoryFrm : Form
    {
        private int _PersonID = -1;
        public ShowAllLicensesHistoryFrm(int PerosnID)
        {
            InitializeComponent();
            this._PersonID = PerosnID;
        }
        public ShowAllLicensesHistoryFrm()
        {
            InitializeComponent();
        }
        private void ShowAllLicensesHistoryFrm_Load(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                this.showPersonWithFilter1.FindByID(_PersonID);
                this.licensesHistoryControl1.LoadByPersonID(_PersonID);
            }
            else
            {
                this.showPersonWithFilter1.OnPersonSelected += OnPersonSelected;
            }
        }
        private void OnPersonSelected(int PersonID)
        {
            this.licensesHistoryControl1.Clear();
            this.licensesHistoryControl1.LoadByPersonID(PersonID);
        }
    }
}
