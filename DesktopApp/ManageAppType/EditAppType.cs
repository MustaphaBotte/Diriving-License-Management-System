using DLMS.BusinessLier.ApplicationTypes;
using DLMS.EntitiesNamespace;
namespace DesktopApp.ManageAppType
{
    public partial class EditAppTypeFrm : Form
    {
        private int AppTypeId = -1;
        Entities.ClsApplicationType? Apptype = null;


        public delegate void ApptypeUpdated();
        public event ApptypeUpdated ApplicationTypeedited = delegate { };
        public EditAppTypeFrm(int AppTypeID)
        {
            InitializeComponent();
            this.AppTypeId = AppTypeID;
        }

        private void EditAppType_Load(object sender, EventArgs e)
        {
            Apptype = DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationTypeByIdOrName(this.AppTypeId);
            if (Apptype == null)
            {
                MessageBox.Show("Error while trying to show the edit environment please refresh and try again", "Internal Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
            }
            this.AppTypeIDLAbel.Text = Apptype?.ApplicationTypeId.ToString();
            this.AppTypeTitleTextBox.Text = Apptype?.ApplicationTypeTitle;
            this.AppTypeFeeTextBox.Text = Apptype?.ApplicationFees.ToString();

        }

        private void EditAppTypeFrm_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;

        }

        private void EditAppTypeFrm_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

        }
        private void CloseButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string appName = AppTypeTitleTextBox.Text;
            bool isFees = Single.TryParse(AppTypeFeeTextBox.Text, out Single Value);
            if (appName.Length == 0)
            {
                MessageBox.Show("Please enter a valid Application Name", "Data violation", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (!isFees)
            {
                MessageBox.Show("Please enter a valid Application Fees", "Data violation", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (Apptype != null)
            {
                Apptype.ApplicationTypeTitle = appName;
                Apptype.ApplicationFees = Value;
                if (DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.UpdateApplicationType(Apptype))
                {
                    MessageBox.Show($"Application type with ID: {Apptype.ApplicationTypeId} updated SuccessFully"
                        , "Operation Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    this.ApplicationTypeedited?.Invoke();
                }
                else
                {
                    MessageBox.Show("Cant update now please try again later", "internal error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                    return;
                }
            }

        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

        }

        private void AppTypeFeeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)&& e.KeyChar !=(char)'.')
            {
                e.Handled = true;
            }
        }
    }
}
