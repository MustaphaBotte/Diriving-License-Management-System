using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLMS.BusinessLier;
using DLMS.EntitiesNamespace;

namespace DesktopApp.ManagePerson
{
    public partial class AddEditPersonFrm : Form
    {
        private int _PersonID = -1;
        private Entities.ClsPerson? Person = new Entities.ClsPerson();
        Entities.EnMode Mode = new Entities.EnMode();

        public delegate void SignalToRefresh();
        public event SignalToRefresh? SendSignalToRefresh;

        public delegate void _SendTheAddedPersonID(int ID);
        public event _SendTheAddedPersonID? SendTheAddedPersonID;
        public AddEditPersonFrm(int PersonID = -1)
        {
            InitializeComponent();
            this._PersonID = PersonID;
            personUserControl1.SendSignalToFormToClose += ControlClosed;
        }
        private void EditPersonFrm_Load(object sender, EventArgs e)
        {
            personUserControl1.SendSignalToForm += PersonAddedOrUpdated;
            if (this._PersonID==-1)
            {
                this.Mode = Entities.EnMode.AddNew;
                this.LabelUpdateModeOption.Visible = false;
                this.LabelAddNewPersonOption.Visible = true;
                personUserControl1.FillDataInControl(new Entities.ClsPerson());
                return;
            }
            this.Person = DLMS.BusinessLier.Person.PersonLogic.FindPerson(this._PersonID);
            if (  Person != null)
            {
                this.Mode = Entities.EnMode.Update;
                PersonIDValue.Text = Person.PersonId.ToString();
                this.LabelUpdateModeOption.Visible = true;
                this.LabelAddNewPersonOption.Visible = false;
                personUserControl1.FillDataInControl(Person);
            }
            else
            {
                MessageBox.Show($"Person with ID= {this._PersonID} not foudn", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }
        private void PersonAddedOrUpdated(int ID)
        {
            if (ID != -1)
            {
                this.PersonIDValue.Text = ID.ToString();
                this.Mode = Entities.EnMode.Update;
                this.LabelUpdateModeOption.Visible = true;
                this.LabelAddNewPersonOption.Visible = false;
            }
            SendTheAddedPersonID?.Invoke(ID);
            SendSignalToRefresh?.Invoke();
        }
        private void ControlClosed()
        {
            this.Close();
        }

        private void personUserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
