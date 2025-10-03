
namespace DesktopApp.ManagePerson
{
    public partial class ShowPerson : Form
    {
        private int _ID=-1;
        private string _NationalNo="";
        public ShowPerson(int ID)
        {
            this._ID = ID;
            InitializeComponent();
        }
        public ShowPerson(string NationalNo)
        {
            this._NationalNo = NationalNo;
            InitializeComponent();
        }
        private void ShowPerson_Load(object sender, EventArgs e)
        {           
            if(!showInfoInControl1.FillDataInControl(this._ID,this._NationalNo))
            {
                MessageBox.Show("Sorry We can't show the info please refresh and try again", "internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
