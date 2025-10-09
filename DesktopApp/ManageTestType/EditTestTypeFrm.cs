using DLMS.BusinessLier.ApplicationTypes;
using DLMS.BusinessLier.TestTypes;
using DLMS.EntitiesNamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.ManageTestType
{
    public partial class EditTestTypeFrm : Form
    {
        private Entities.ClsTestType.EnTestType _TestTypeId ;
        Entities.ClsTestType? TestType = null;


        public delegate void TheTestTypeEdited();
        public event TheTestTypeEdited TestTypeEdited = delegate { };

        public EditTestTypeFrm(Entities.ClsTestType.EnTestType TestTypeID)
        {
            this._TestTypeId = TestTypeID;
            InitializeComponent();
        }
        private void EditTestTypeFrm_Load(object sender, EventArgs e)
        {
            TestType = DLMS.BusinessLier.TestTypes.TestTypesLogic.GetTestTypeById(this._TestTypeId);
            if (TestType == null)
            {
                MessageBox.Show("Error while trying to show the edit environment please try again", "Internal Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
            }
            this.TestTypeIDLAbel.Text = ((int?)TestType?.TestTypeID)?.ToString();
            this.TestTypeTitleTextBox.Text = TestType?.TestTypetitle;
            this.TestTypeDescriptionTextBox.Text = TestType?.TestTypeDescription;
            this.TestTypeFeeTextBox.Text = TestType?.TestTypeFees.ToString();
        }
        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;  
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string testName = TestTypeTitleTextBox.Text;
            string testdesc = TestTypeDescriptionTextBox.Text;

            bool isFees = decimal.TryParse(TestTypeFeeTextBox.Text, out decimal Value);
            if (testName.ToString().Trim().Length == 0)
            {
                MessageBox.Show("Please enter a valid Test Name", "Data violation", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (testdesc.ToString().Trim().Length == 0)
            {
                MessageBox.Show("Please enter a valid Test Description", "Data violation", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (!isFees)
            {
                MessageBox.Show("Please enter a valid Test Fees", "Data violation", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (TestType != null)
            {
                TestType.TestTypetitle = testName;
                TestType.TestTypeDescription = testdesc;
                TestType.TestTypeFees = Value;
                if (TestTypesLogic.UpdateTestType(TestType))
                {
                    MessageBox.Show($"Test type with ID: {TestType.TestTypeID} updated SuccessFully"
                        , "Operation Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    this.TestTypeEdited?.Invoke();
                }
                else
                {
                    MessageBox.Show("Cant update now please try again later", "internal error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void TestypeFeeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != (char)'.')
            {
                e.Handled = true;
            }
        }

    }
}
