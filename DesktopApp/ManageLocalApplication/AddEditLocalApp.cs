using DLMS.BusinessLier.ApplicationTypes;
using DesktopApp.ManagePerson;
using DLMS.BusinessLier;
using DLMS.BusinessLier.Person;
using DLMS.EntitiesNamespace;
using System.Data;
using System.DirectoryServices.ActiveDirectory;


namespace DesktopApp.ManageApplication
{
    public partial class AddEditLocalApp : Form
    {
        private Entities.ClsPerson? Person = null;
        private bool IsEditMode = false;
        Dictionary<string, object> LocAppInfo = new Dictionary<string, object>();


        public delegate void Adding_SendSignalToRefreshTheGris(int NewLocAppId);
        public event Adding_SendSignalToRefreshTheGris OnAddingNewApp = delegate { };

        public delegate void Editing_SendSignalToRefreshTheGris();
        public event Editing_SendSignalToRefreshTheGris OnEditingApp = delegate { };

        public AddEditLocalApp(bool IsEditing = false, int Loc_DLA_ID=-1)
        {         
            if(IsEditing)
            {
                this.LocAppInfo = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetLocalDrivingLicAppById(Loc_DLA_ID);
                if (LocAppInfo.Count == 0)
                {
                    MessageBox.Show("We Cant edit this local application right now because data are lost :( please refresh try again", "Internal Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    this.Close(); 
                    return;
                }
                this.IsEditMode = true;
            }           
            InitializeComponent();
        }    
        private void guna2Button3_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void FindButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void ChangeFormMode()
        {
            this.FormModeTitleLabel.Text = "Edit An Existing Local Driving License";
            this.Text = " Edit Application";
        }  
        private void FillThePersonInfo()
        {
            SearchForPerson(NationalNo:this.LocAppInfo["NationalNo"].ToString());
            if(!PersonControl.IsControlFilled)
            {
                MessageBox.Show($"We cant edit this local application in the moment please refresh and try again", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FilterChoices.SelectedIndex = 0;
            this.FindButton.Enabled = false;
            this.AddButton.Enabled = false;
        }
        private void AddNewApp_Load(object sender, EventArgs e)
        {
            if(this.IsEditMode)
            {
                ChangeFormMode();
                FillThePersonInfo();
                
            }
            FillTheApplicationDefaultInfo();
        }
        private bool FillLicenseClassesInComboBox()
        {
            DataTable? data = DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetAllLicenseClasses();
            if (data == null || data.Rows.Count == 0)
            {
                return false;
            }
            try
            {
                Dictionary<int, string> classes = new Dictionary<int, string>();
                foreach (DataRow Row in data.Rows)
                {
                    string ClassName = Row["ClassName"] == DBNull.Value ? "" : (string)Row["ClassName"];
                    classes.Add((int)Row["LicenseClassID"], ClassName);
                }
                LisenceClassesComboBox.DataSource = new BindingSource(classes, null);
                LisenceClassesComboBox.ValueMember = "key";
                LisenceClassesComboBox.DisplayMember = "value";
                if(this.IsEditMode)
                        LisenceClassesComboBox.SelectedItem = this.LocAppInfo["ClassName"];



                return true;
            }
            catch
            {
                return false;
            }
        }

        private decimal getfeesOfLocalDrivingLicenseAplication()
        {
            return ApplicationTypesLogic.GetApplicationFees(1);
        }
        private void FillTheApplicationDefaultInfo()
        {
            CreatedByLbl.Text = ClslogedInUser.logedInUser != null ? ClslogedInUser.logedInUser.UserName : "loged In User";
            ApplicationDataLbl.Text = DateTime.Today.ToString("yyyy-MM-dd");
            if (!FillLicenseClassesInComboBox())
            {
                MessageBox.Show("We Cant add a new application right now because data are lost from Database. please try again", "Database issue", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
            }
            if (IsEditMode)
                this.Loc_DL_IdLbl.Text = this.LocAppInfo["LocDLA_ID"].ToString();

            ApplicationFeesLbl.Text = getfeesOfLocalDrivingLicenseAplication().ToString();
        }

        public void SearchForPerson(int ID = -1, string NationalNo = "", bool alreadyAUser = false)
        {
            if (ID == -1 && string.IsNullOrEmpty(NationalNo))
                return;
            bool PrsnExitst = PersonLogic.Exists(ID, NationalNo);
            if (!PrsnExitst)
            {
                string attribut = ID == -1 ? "National Number" : "ID";
                object Value = ID == -1 ? NationalNo : ID;

                MessageBox.Show($"Person With {attribut} : {Value} Does Not Exists In The System",
                   "Invalid Info", MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);


                return;
            }
            PersonControl.FillDataInControl(ID, NationalNo);
            if (PersonControl.IsControlFilled)
            {
                this.Person = PersonControl.Person;
                this.NextButton.Enabled = true;
            }
        }
        private void FindButton_Click(object sender, EventArgs e)
        {
            string Filter = FilterChoices.SelectedItem?.ToString()?.ToLower() ?? "";
            if (Filter == "")
            {
                return;
            }


            if (Filter == "personid")
            {
                int ID = int.TryParse(FilterValueTextBox.Text.ToString(), out int OutPut) ? OutPut : 0;
                if (ID <= 0)
                {
                    MessageBox.Show("please enter a valid id (Numbers Only And Positive)", "Invalid Id", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    return;
                }
                SearchForPerson(ID);
            }
            if (Filter == "national_no")
            {
                string NationNo = !string.IsNullOrEmpty(FilterValueTextBox.Text) ? FilterValueTextBox.Text : "";
                if (NationNo == "")
                {
                    MessageBox.Show("please Fill the National Number Field ", "Invalid National Number", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    return;
                }
                SearchForPerson(NationalNo: NationNo);
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            PagesTab.SelectedIndex = 1;
        }
        private void GetTheAddedPersonIdFromTheChildForm(int PersonID)
        {
            SearchForPerson(PersonID);
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            AddEditPersonFrm Frm = new AddEditPersonFrm();
            Frm.SendTheAddedPersonID += GetTheAddedPersonIdFromTheChildForm;
            Frm.ShowDialog();
        }

        private void FilterValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (FilterChoices.SelectedItem == null)
                return;
            string? choice = FilterChoices.SelectedItem.ToString()?.ToLower();
            if (choice == "personid")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            PagesTab.SelectedIndex = 0;
        }

      

        private void InsertNewLocalApp(Entities.ClsApplication App ,int LicenseClassID,out int NewLocDriAppId )
        {
            string message = "";
            NewLocDriAppId = -1;
            int Result = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.AddNewLocalDrivingLicApplication(App, LicenseClassID,ref message);

            if(message!="")
            {
                MessageBox.Show(message, "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if (Result==0)
            {
                MessageBox.Show("Operation failed Please Check The fields and try again", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(Result==-1)
            {
                MessageBox.Show("This person already has an incompleted application from this license type .", "system rules violation", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }
            if (Result == -3)
            {
                MessageBox.Show("This person already has an completed application from license type .", "system rules violation", MessageBoxButtons.OK, MessageBoxIcon.Error);  
                return;
            }
            if (Result>0)
            {
                 NewLocDriAppId = Result;
            }
        }
        private void AddNewLocApplication()
        {
            if (Person == null)
            {
                MessageBox.Show("Please find a person first to add a new local driving application", "Person Not Loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int LicenseId = Convert.ToInt16(LisenceClassesComboBox.SelectedValue);
            
            Entities.ClsApplication App = new Entities.ClsApplication();
            App.ApplicantPersonId = Person.PersonId;
            App.ApplicantionDate = DateTime.Now;
            App.ApplicationTypeId = 1; // because the data is fixed in the application types
            App.ApplicationStatus = 1; // 1 means new
            App.LastStatusDate = DateTime.Now;
            App.PaidFees = getfeesOfLocalDrivingLicenseAplication();
            App.CreatedByUserId = ClslogedInUser.logedInUser.UserId;

            DialogResult Result = MessageBox.Show("Are you sure you want to Save", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Result == DialogResult.Cancel)
            {
                return;
            }
            short MinAgeAllod = DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetMinimumAllowedAge(LicenseId);
            if (Person.DateOfBirth.AddYears(MinAgeAllod) > DateTime.Now)
            {
                MessageBox.Show($"The minmum age allowed is {MinAgeAllod} years old", "Age rules violation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                return;
            }
            InsertNewLocalApp(App, LicenseId, out int NewLocDriAppId);          
            if (NewLocDriAppId > 0)
            {
                MessageBox.Show("Local Driving license app added successfully ", "Operation success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Loc_DL_IdLbl.Text = NewLocDriAppId.ToString();
                OnAddingNewApp?.Invoke(NewLocDriAppId);
                this.Close();
            }

        }
        private void EditExistingLocApplication()
        {
            if (Person == null)
            {
                MessageBox.Show("Error while trying to get person info. please refresh and try again", "Person Not Loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int LicenseId = Convert.ToInt16(LisenceClassesComboBox.SelectedValue);

            int UpdatedLicenseClassID = Convert.ToInt16(LisenceClassesComboBox.SelectedValue);
            int Loc_DLA_ID = int.TryParse(this.LocAppInfo["LocDLA_ID"].ToString(), out int Val) ? Val : -1;
            DialogResult Result = MessageBox.Show("Are you sure you want to Save", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Result == DialogResult.Cancel)
            {
                return;
            }

            int result = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.EditLocalDriLicApplicationClass(Loc_DLA_ID, UpdatedLicenseClassID);
            if(result==1)
            {      
                MessageBox.Show($"This local application has successfully updated to {LisenceClassesComboBox.SelectedItem}", "Operation Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.OnEditingApp?.Invoke();
                this.Close();
                return;
            }
            if (result == -2)
            {
                MessageBox.Show($"This Application Is Canceled you cannot edit it", "System rules violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == -3)
            {
                MessageBox.Show($"This Application Is completed you cannot edit it.", "System rules violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == -4)
            {
                MessageBox.Show($"This Person already has an application from this license class type", "System rules violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == -5)
            {
                MessageBox.Show($"This Person already pass some tests or has an open appointments releated to this application you cannot modify it", "System rules violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == 0)
            {
                MessageBox.Show($"Due an internal error we cannot update to  {LisenceClassesComboBox.SelectedItem} in the moment please refresh and try again", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
   
        }
        private void AddNewLocButton_Click(object sender, EventArgs e)
        {
            if(!this.IsEditMode)
            {
                AddNewLocApplication();
                return;
            }
            EditExistingLocApplication();
        }
    }
}
