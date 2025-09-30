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
        private string Classname = "";
        public ShowlicenseClassInfo(int LicenseClassID=-1,string Classname="")
        {
            this.Classname = Classname;
            this.LicenseClassID = LicenseClassID;
            InitializeComponent();
        }

        private void ShowlicenseClassInfo_Load(object sender, EventArgs e)
        {
            DLMS.EntitiesNamespace.Entities.ClsLicenseClass? LicClass = DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetLisenceClassById(classname: this.Classname);
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
            this.Close();
        }
    }
}
