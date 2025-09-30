using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.LocDrivingLicense
{
    public partial class ShowLicenseFrm : Form
    {
        public ShowLicenseFrm(int Loc_DLA_ID=-1,int LicenseID=-1)
        {

           InitializeComponent();
           if (!this.licenseControl1.FillTheControlByLoc_DLA_IDOr_LicenseID(Loc_DLA_ID,LicenseID))
           {
               MessageBox.Show("We cannot show this driver information in the moment please refresh and try again and if the problem persists please" +
                   " contact your admin", "Invalid Driver Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
               this.Close();
               return;
           }
        }

        private void ShowLicenseFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
