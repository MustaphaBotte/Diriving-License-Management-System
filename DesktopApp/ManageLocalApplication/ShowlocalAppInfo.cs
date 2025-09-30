using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.ManageLocalApplication
{
    public partial class ShowlocalAppInfo : Form
    {
        private int LocalDLAID = -1;
        public ShowlocalAppInfo(int LocalDLAID)
        {
            this.LocalDLAID = LocalDLAID;
            InitializeComponent();
        }

        private void ShowlocalAppInfo_Load(object sender, EventArgs e)
        {
            if(!DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.Exists(LocalDLAID))
            {
                MessageBox.Show("This Local Driving Application does't exists in the system please refresh and try again", "Internal Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if(!applicationInfoControl1.FillTheControlById(LocalDLAID))
            {
                this.Close();
            }
        }
    }
}
