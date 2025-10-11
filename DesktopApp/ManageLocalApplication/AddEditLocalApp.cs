using DLMS.BusinessLier.ApplicationTypes;
using DesktopApp.ManagePerson;
using DLMS.BusinessLier.LocalDrivingLicenseApplication;
using DLMS.BusinessLier.Person;
using DLMS.EntitiesNamespace;
using System.Data;
using System.DirectoryServices.ActiveDirectory;


namespace DesktopApp.ManageApplication
{
    public partial class AddEditLocalApp : Form
    {
        public delegate void Adding_SendSignalToRefreshTheGris(int NewLocAppId);
        public event Adding_SendSignalToRefreshTheGris OnAddingNewApp = delegate { };

        public delegate void Editing_SendSignalToRefreshTheGris();
        public event Editing_SendSignalToRefreshTheGris OnEditingApp = delegate { };


        Entities.ClsLocDriApplication? LocAppInfo = new DLMS.EntitiesNamespace.Entities.ClsLocDriApplication();
        private Entities.ClsPerson? Person = null;
        private enum Enmode {AddNew=1,Update=2}
        private Enmode _Mode = Enmode.AddNew;
       
        public AddEditLocalApp()
        {          
            InitializeComponent();
            this._Mode = Enmode.AddNew;
        }
        public AddEditLocalApp(int Loc_DLA_ID)
        {
            InitializeComponent();
            this.LocAppInfo = LocDriviLicAppLogic.GetLocDriLicAppInfo(Loc_DLA_ID);
            if (LocAppInfo==null)
            {
                    MessageBox.Show("We Cant edit this local application right now because data are lost :( please refresh try again", "Internal Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    this.Close(); 
                    return;
            }
            this._Mode = Enmode.Update;                  
        }    
     

        private void ChangeFormTitlesToUpdate()
        {
            this.FormModeTitleLabel.Text = "Edit An Existing Local Driving License";
            this.Text = " Edit Application";
            this._Mode = Enmode.Update;
        }  
        private void FillThePersonInfo()
        {
            SearchForPerson(LocAppInfo?.ApplicantPersonId??0);
            if(!PersonControl.IsControlFilled)
            {
                MessageBox.Show($"We cant edit this local application in the moment please refresh and try again", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FilterChoices.SelectedIndex = 0;//Id by default
            this.FindButton.Enabled = false;
            this.AddButton.Enabled = false;
        }
        private void AddNewApp_Load(object sender, EventArgs e)
        {
            FilterChoices.SelectedIndex = 0;
            if(this._Mode==Enmode.Update)
            {
                ChangeFormTitlesToUpdate();
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
                if (this._Mode==Enmode.Update)
                    LisenceClassesComboBox.SelectedIndex = this.LocAppInfo?.LicenseClassInfo?.LicenseCLassId-1??0;//select his current class

                return true;
            }
            catch
            {
                return false;
            }
        }

        private decimal getfeesOfLocalDrivingLicenseAplication()
        {
            return ApplicationTypesLogic.GetApplicationFees(Entities.ClsApplication.enApplicationType.LocalDrivingLicense);
        }
        private void FillTheApplicationDefaultInfo()
        {
            CreatedByLbl.Text = DesktopApp.LogedInUser.ClslogedInUser.logedInUser != null ? DesktopApp.LogedInUser.ClslogedInUser.logedInUser.UserName : "loged In User";
            ApplicationDataLbl.Text = DateTime.Today.ToString("yyyy-MM-dd");
            if (!FillLicenseClassesInComboBox())
            {
                MessageBox.Show("We Cant add a new application right now because data are lost from Database. please try again", "Database issue", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
            }
            if (this._Mode==Enmode.Update)
                this.Loc_DL_IdLbl.Text = this.LocAppInfo?.LocDriApplicationID.ToString();
            ApplicationFeesLbl.Text = getfeesOfLocalDrivingLicenseAplication().ToString();
        }

        public void SearchForPerson(int ID = -1, string NationalNo = "")
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
      
        private void AddButton_Click(object sender, EventArgs e)
        {
            AddEditPersonFrm Frm = new AddEditPersonFrm();
            Frm.SendTheAddedPersonID += (int PersonID) =>
            {
                SearchForPerson(PersonID);
            };
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
  

        private bool InsertNewLocalApp(Entities.ClsApplication App ,int LicenseClassID,out int NewLocDriAppId )
        {
            string message = "";
            NewLocDriAppId = -1;
            LocDriviLicAppLogic.ClsResultProvider Result = LocDriviLicAppLogic.AddNewLocalDrivingLicApplication(App, LicenseClassID,ref message);

            MessageBoxIcon Icon = Result.ResultCode <= 0 ? MessageBoxIcon.Error : MessageBoxIcon.Information;
            MessageBox.Show(Result.ResultMessage,Result.ResultName, MessageBoxButtons.OK, Icon);
           
            if (Result.NewLocAppId>0&& Result.IsSuccess)
            {
                 NewLocDriAppId = Result.NewLocAppId;
                 return true;
            }
            return false;
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
            App.ApplicantPersonInfo = this.PersonControl.Person;          
            App.ApplicantionDate = DateTime.Now;
            App.ApplicationType = Entities.ClsApplication.enApplicationType.LocalDrivingLicense;
            App.ApplicationStatus = DLMS.EntitiesNamespace.Entities.ClsApplication.enApplicationStatus.New; // 1 means new
            App.LastStatusDate = DateTime.Now;
            App.PaidFees = getfeesOfLocalDrivingLicenseAplication();
            App.CreatedByUserId =LogedInUser.ClslogedInUser.logedInUser.UserId;

            DialogResult Result = MessageBox.Show("Are you sure you want to Save", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Result == DialogResult.Cancel)
            {
                return;
            }                   
            if (InsertNewLocalApp(App, LicenseId, out int NewLocDriAppId))
            {
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
            DialogResult Result = MessageBox.Show("Are you sure you want to Save", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Result == DialogResult.Cancel)
            {
                return;
            }
            short MinAllowedAge = DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetMinimumAllowedAge(LicenseId);
           
            LocDriviLicAppLogic.ClsResultProvider ResultProvider = LocDriviLicAppLogic.EditLocalDriLicApplicationClass(LocAppInfo.LocDriApplicationID, UpdatedLicenseClassID);
            if(ResultProvider.IsSuccess)
            {      
                MessageBox.Show($"This local application has successfully updated to {LisenceClassesComboBox.SelectedItem}", "Operation Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.OnEditingApp?.Invoke();
                this.Close();
                return;
            }
            MessageBox.Show(ResultProvider.ResultMessage, ResultProvider.ResultName, MessageBoxButtons.OK, MessageBoxIcon.Error);             
        }
        private void AddNewLocButton_Click(object sender, EventArgs e)
        {
            if(this._Mode==Enmode.AddNew)
            {
                AddNewLocApplication();
                return;
            }
            EditExistingLocApplication();
        }


        private void guna2Button3_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void FindButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            PagesTab.SelectedIndex = 0;
        }



    }
}
