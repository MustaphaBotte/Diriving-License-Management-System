
using Guna.UI2.WinForms;
using DLMS.EntitiesNamespace;

namespace DesktopApp.PersonControl
{
    public partial class ShowPersonWithFilter : UserControl
    {
        public ShowPersonWithFilter()
        {
            InitializeComponent();
        }
        public delegate void _OnPersonSelected(int PersonID);
        public event _OnPersonSelected OnPersonSelected = delegate { };

        public int PersonID
        {
            get
            {
                return this.showInfoInControl1.PersonID;
            }
        }
        public Entities.ClsPerson? Person
        {
            get
            {
                return this.showInfoInControl1.Person;
            }
        }

        private void FilterValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (FilterChoices.SelectedIndex == 0 && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;

            if (e.KeyChar == (char)Keys.Enter)
                FindButton.PerformClick();
        }

        private void FilterValueTextBox_TextChanged(object sender, EventArgs e)
        {

            if (FilterChoices.SelectedIndex == 0 && !int.TryParse(((Guna2TextBox)sender).Text, out int res))
            {
                FilterValueTextBox.Text = "";
            }

        }

        public void FindByID(int PersonID)
        {
            this.FilterChoices.SelectedIndex = 0;
            this.FilterValueTextBox.Text = PersonID.ToString();
            FilterGroupBox.Enabled = false;
            this.FindButton.PerformClick();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            if (this.FilterValueTextBox.Text == "")
            {
                MessageBox.Show("Filter cannot be empty", "Invalid Filter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FilterChoices.SelectedIndex == 0)
            {
                int ID = Convert.ToInt32(this.FilterValueTextBox.Text);
                if (this.showInfoInControl1.FillDataInControl(ID))
                {
                    this.OnPersonSelected.Invoke(showInfoInControl1.PersonID);
                }
                return;
            }
            else if (this.FilterChoices.SelectedIndex == 1)
            {
                string N_No = this.FilterValueTextBox.Text.Trim();
                if (this.showInfoInControl1.FillDataInControl(NationalNo: N_No))
                {
                    this.OnPersonSelected.Invoke(showInfoInControl1.PersonID);
                }
                return;
            }
            MessageBox.Show("Person Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowPersonWithFilter_Load(object sender, EventArgs e)
        {
            this.FilterChoices.SelectedIndex = 0;
        }
    }
}
