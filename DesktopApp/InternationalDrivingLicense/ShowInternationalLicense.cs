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
    public partial class ShowInternationalLicenseFrm: Form
    {
        public ShowInternationalLicenseFrm(int InterNatioLicID)
        {
            InitializeComponent();
            if (!this.internationalLicenseControl1.FillInfoByInterLicID(InterNatioLicID))
            {
                MessageBox.Show("We cannot show this driver information in the moment please refresh and try again and if the problem persists please" +
                    " contact your admin", "Invalid Driver Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }
    }
}
