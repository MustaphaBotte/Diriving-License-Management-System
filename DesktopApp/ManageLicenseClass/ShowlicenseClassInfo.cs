using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.ManageLicenseClass
{
    public partial class ShowlicenseClassInfo : Form
    {
        private int LicenseClassID=-1;
        public ShowlicenseClassInfo(int LicenseClassID)
        {
            this.LicenseClassID = LicenseClassID;
            InitializeComponent();
        }

        private void ShowlicenseClassInfo_Load(object sender, EventArgs e)
        {
            DLMS.EntitiesNamespace.Entities.ClsLicenseClass? LicClass = DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetLisenceClassById(this.LicenseClassID);
            if(LicClass!=null)
            {
                this.LicClassIdLabel.Text = LicClass.LicenseCLassId.ToString();
                this.ValLengthLabel.Text = LicClass.DefaultValidityLength.ToString();
                this.MinAgeLabel.Text = LicClass.MinAllowedAge.ToString();
                this.DescriptionLabel.Text = LicClass.ClassDescription;
                this.FeesLabel.Text = LicClass.ClassFees.ToString();
                this.TitleLable.Text = LicClass.ClassName;
                return;
            }
            MessageBox.Show("We cant show this license class in the mement please refresh and try again", "Internal Error", MessageBoxButtons.OK
                , MessageBoxIcon.Error);
            this.Close();
        }
    }
}
