using DLMS.EntitiesNamespace;
using System.Text.Json.Serialization;

namespace DLMS.EntitiesNamespace
{
    public class Entities
    {
        public enum EnMode
        {
            AddNew = 1,
            Update = 2
        }

        public class ClsPerson
        {
            public int PersonId { get; set; } = -1;
            public string NationalNo { get; set; } = "";
            public string FirstName { get; set; } = "";
            public string SecondName { get; set; } = "";
            public string? ThirdName { get; set; } = "";
            public string? LastName { get; set; } = "";
            public DateTime DateOfBirth { get; set; } = DateTime.Now;

            public byte Gender { get; set; }
            public string Address { get; set; } = "";
            public string Phone { get; set; } = "";
            public string? Email { get; set; } = "";

            public short NationalityCountryID { get; set; }
            public string? ImagePath { get; set; } = "";
            public ClsCountry? CountryInfo = null;
            public EnMode Mode = EnMode.AddNew;
            public ClsPerson(int personId, string nationalNo, string firstName, string secondName, string? thirdName, string? lastName,
                       DateTime dateOfBirth, byte gender, string address, string phoneNumber, string? Email, short nationalityCountryID, ClsCountry? CountryInfo, string? imagePath)
            {
                this.PersonId = personId;
                this.NationalNo = nationalNo;
                this.FirstName = firstName;
                this.SecondName = secondName;
                this.ThirdName = thirdName;
                this.LastName = lastName;
                this.DateOfBirth = dateOfBirth;
                this.Gender = gender;
                this.Address = address;
                this.Phone = phoneNumber;
                this.Email = Email;
                this.NationalityCountryID = nationalityCountryID;
                this.ImagePath = imagePath;
                this.CountryInfo = CountryInfo;
                this.Mode = EnMode.Update;
            }
            public ClsPerson()
            {
                this.Mode = EnMode.AddNew;
                this.DateOfBirth = DateOfBirth.AddDays(-(365.28 * 18));
            }
        }

        public class ClsCountry
        {
            public byte? CountryID { get; private set; } = null;
            public string? CountryName { get; private set; }
            public ClsCountry(byte CountryID, string CountryName)
            {
                this.CountryID = CountryID;
                this.CountryName = CountryName;
            }
            public ClsCountry() { }

        }

        public class ClsUser
        {
            public int UserId { get; set; } = -1;
            public int PersonId { get; set; } = -1;
            public ClsPerson? Person = new ClsPerson();
            public string UserName { get; set; } = "";
            public string PassWord { get; set; } = "";
            public bool IsActive { get; set; } = false;

            public EnMode Mode = EnMode.AddNew;

            [JsonConstructor]

            public ClsUser(int UserId, int PersonId,string UserName, string PassWord, bool IsActive)
            {
                this.UserId = UserId;
                this.PersonId = PersonId;
                this.UserName = UserName;
                this.PassWord = PassWord;
                this.IsActive = IsActive;
                this.Mode = EnMode.Update;
            }
            public ClsUser() 
            { }
        }

        public class ClsApplicationType
        {
            public int ApplicationTypeId { private set; get; } = -1;
            public string ApplicationTypeTitle { set; get; } = string.Empty;
            public decimal ApplicationFees { set; get; } = 0.0m;

            public ClsApplicationType(int ApplicationTypeId, string ApplicationTypeName, decimal ApplicationTypeFees)
            {
                this.ApplicationTypeId = ApplicationTypeId;
                this.ApplicationTypeTitle = ApplicationTypeName;
                this.ApplicationFees = ApplicationTypeFees;
            }
            public ClsApplicationType() { }
        }


        public class ClsTestType
        {
            public  enum EnTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 }

            public EnTestType TestTypeID { set; get; }
            public string TestTypetitle { set; get; } = string.Empty;
            public string TestTypeDescription { set; get; } = string.Empty;
            public decimal TestTypeFees { set; get; } = 0.0m;
            public ClsTestType(EnTestType TestTypeId, string TestTypetitle, string TestTypeDescription, decimal TestTypeFees)
            { 
                this.TestTypeID = TestTypeId;
                this.TestTypetitle = TestTypetitle;
                this.TestTypeDescription = TestTypeDescription;
                this.TestTypeFees = TestTypeFees;
            }
            public ClsTestType() { }
        }


        public class ClsApplication
        {
            public enum enApplicationType
            {
                LocalDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
                ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
            };
            public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

            public int ApplicationId { get; set; } = -1;
            public int ApplicantPersonId { get; set; } = -1;
            public DateTime ApplicantionDate { get; set; } = new DateTime();
            public DateTime LastStatusDate { get; set; } = new DateTime();
            public decimal PaidFees { get; set; } = 0m;
            public int CreatedByUserId { get; set; } = -1;

            public enApplicationType ApplicationType { get; set; }    
            public enApplicationStatus ApplicationStatus { get; set; }
            public Entities.ClsUser? CreatedByUser = null;
            public Entities.ClsApplicationType? ApplicationTypeInfo = null;
            public Entities.ClsPerson? ApplicantPersonInfo = null;


            public EnMode Mode = EnMode.AddNew;

            public ClsApplication(int applicationId, int applicantPersonId, DateTime applicantionDate,
                                 enApplicationType applicationType, enApplicationStatus applicationStatus, DateTime lastStatusDate, decimal paidFees, int createdByUserId)
            {
                this.ApplicationId = applicationId;
                this.ApplicantPersonId = applicantPersonId;
                this.ApplicantionDate = applicantionDate;
                this.ApplicationStatus = applicationStatus;
                this.LastStatusDate = lastStatusDate;
                this.PaidFees = paidFees;
                this.CreatedByUserId = createdByUserId;
                this.Mode = EnMode.Update;

            }
            public ClsApplication() { }
        }


        public class ClsLicenseClass
        {
            public int LicenseCLassId { private set; get; } = -1;
            public string ClassName { private set; get; } = "";
            public string ClassDescription { private set; get; } = "";
            public byte MinAllowedAge { private set; get; } = 0;
            public byte DefaultValidityLength { private set; get; } = 0;
            public decimal ClassFees { private set; get; } = 0.0m;

            public ClsLicenseClass(int id, string name, string description, byte minAge, byte validity, decimal fees)
            {
                this.LicenseCLassId = id;
                this.ClassName = name;
                this.ClassDescription = description;
                this.MinAllowedAge = minAge;
                this.DefaultValidityLength = validity;
                this.ClassFees = fees;
            }
            public ClsLicenseClass() { }
        }


        public class ClsTestAppointment
        {
            public int TestAppointmentId { get; private set; } = -1;
            public int TestTypeId { get; set; } = -1;
            public int LocDLA_ID { get; set; } = -1;
            public DateTime TestAppointmentDate { get; set; } = new DateTime();
            public bool IsLocked { get; set; } = false;
            public decimal PaidFees { get; set; } = 0m;
            public int CreatedByUserId { get; set; } = -1;

            public int? RetakeApplicationID { get; set; } = null;
            public EnMode Mode = EnMode.AddNew;

            public ClsTestAppointment(int TestAppointmentId, int TestTypeId, DateTime TestAppointmentDate, int LocDLA_ID,
                                 bool IsLocked, decimal paidFees, int createdByUserId,int? RetakeApplicationID)
            {
                this.TestAppointmentId = TestAppointmentId;
                this.TestTypeId = TestTypeId;
                this.LocDLA_ID = LocDLA_ID;
                this.IsLocked = IsLocked;
                this.TestAppointmentDate = TestAppointmentDate;
                this.PaidFees = paidFees;
                this.CreatedByUserId = createdByUserId;
                this.RetakeApplicationID = RetakeApplicationID;
                this.Mode = EnMode.Update;

            }
            public ClsTestAppointment() { }
        }

        public class ClsTest
        {
            public int TestID { get; private set; } = -1;
            public int TestAppointmentID { get; set; } = -1;
            public bool TestResult { get; set; } = false;
            public string Notes { get; set; } = string.Empty;
            public int CreatedByUserID { get; set; } = -1;

            public EnMode Mode = EnMode.AddNew;
            public ClsTest(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
            {
                this.TestID = testID;
                this.TestAppointmentID = testAppointmentID;
                this.TestResult = testResult;
                this.Notes = notes;
                this.CreatedByUserID = createdByUserID;
                this.Mode = EnMode.Update;
            }
            public ClsTest() { }
        }

        public class ClsLocDriApplication
        {
            public int LocDriApplication { get; private set; } = -1;
            public int ApplicantionID { get; private set; } = -1;
            public int LicenseClassID { get; private set; } = -1;
            public ClsLocDriApplication(int LocDriApplication, int ApplicantionID, int LicenseClassID)
            {
                this.LocDriApplication = LocDriApplication;
                this.LicenseClassID = LicenseClassID;
                this.ApplicantionID = ApplicantionID;
            }
            public ClsLocDriApplication() { }
        }
        public class ClsDriver
        {
            public int DriverID { private set; get; } = -1;
            public int PersonID { set; get; } = -1;
            public int CreatedBy { set; get; } = -1;
            public DateTime CreationDate { set; get; } = DateTime.Now;
            public ClsDriver(int DriverID, int PersonID, int CreatedBy, DateTime CreationDate)
            {
                this.DriverID = DriverID;
                this.PersonID = PersonID;
                this.CreationDate = CreationDate;
            }
            public ClsDriver() { }
        }
        public class ClsLicense
        {
            public int LicenseID { get; private set; } = -1;
            public int ApplicationID { get; set; } = -1;
            public int DriverID { get; set; } = -1;
            public int LicenseClassID { get; set; } = -1;
            public DateTime IssueDate { get; set; } = DateTime.MinValue;
            public DateTime ExpirationDate { get; set; } = DateTime.MinValue;
            public string Notes { get; set; } = string.Empty;
            public decimal PaidFees { get; set; } = 0.0m;
            public bool IsActive { get; set; } = false;
            public int IssueReason { get; set; } = -1;
            public int CreatedByUserID { get; set; } = -1;

            public ClsLicense(int licenseID, int applicationID, int driverID, int licenseClass,
                             DateTime issueDate, DateTime expirationDate, string notes,
                             decimal PaidFees, bool isActive, int issueReason, int createdByUserID)
            {
                this.LicenseID = licenseID;
                this.ApplicationID = applicationID;
                this.DriverID = driverID;
                this.LicenseClassID = licenseClass;
                this.IssueDate = issueDate;
                this.ExpirationDate = expirationDate;
                this.Notes = notes;
                this.PaidFees = PaidFees;
                this.IsActive = isActive;
                this.IssueReason = issueReason;
                this.CreatedByUserID = createdByUserID;
            }

            public ClsLicense() { }
        }
        public class ClsInternationalLicense
        {
            public int InternationLicenseID { get; private set; } = -1;
            public DLMS.EntitiesNamespace.Entities.ClsApplication Application = new ClsApplication();
            public int DriverID { get; set; } = -1;
            public int IssueUsingLocLicID { get; set; } = -1;
            public DateTime IssueDate { get; set; } = DateTime.MinValue;
            public DateTime ExpirationDate { get; set; } = DateTime.MinValue;
            public bool IsActive { get; set; } = false;
            public int CreatedByUserID { get; set; } = -1;

            public ClsInternationalLicense(int InternationLicenseID, DLMS.EntitiesNamespace.Entities.ClsApplication Application, int DriverID, int IssueUsingLocalDriID,
                             DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
            {
                this.InternationLicenseID = InternationLicenseID;
                this.Application = Application;
                this.DriverID = DriverID;
                this.IssueUsingLocLicID = IssueUsingLocalDriID;
                this.IssueDate = issueDate;
                this.ExpirationDate = expirationDate;
                this.IsActive = isActive;
                this.CreatedByUserID = createdByUserID;
            }

            public ClsInternationalLicense() { }

        }
        public class ClsDetainedLicense
        {
            public int DetainID { get; private set; } = -1;
            public int LicenseID { get;  set; } = -1;
            public decimal Fees { set; get; } = 0;
            public int? ReleaseByUserID { get; set; } = null;
            public int CreatedByUserID { get; set; } = -1;
            public bool IsReleased { get; set; } = false;

            public DateTime DetainDate { get; set; }
            public DateTime? ReleaseDate { get; set; } = null;
            public int? ReleaseApplicationID { get; set; } = null;
            public int? ReleasedByUserID { get; set; } = null;

            public ClsDetainedLicense(int detainID, int licenseID, decimal fees,
                                       int createdByUserID, bool isReleased,
                                       DateTime detainDate, DateTime? releaseDate,
                                      int? releasedByUserID, int? releaseApplicationID)
            {
                DetainID = detainID;
                LicenseID = licenseID;
                Fees = fees;
                CreatedByUserID = createdByUserID;
                IsReleased = isReleased;
                DetainDate = detainDate;
                ReleaseDate = releaseDate;
                ReleaseApplicationID = releaseApplicationID;
                ReleasedByUserID = releasedByUserID;
            }
            public ClsDetainedLicense() { }
        }

    }
}