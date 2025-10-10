using DLMS.EntitiesNamespace;
using System.Data;

namespace DLMS.BusinessLier.Test
{
    public class Testlogic
    {
        public static bool HasOpenAppointment(int LocDLA_ID,int TestTypeID)
        {
            if (LocDLA_ID <= 0)
                return false;
            return DLMS.Data_access.Test.TestData.HasOpenAppointmentByLocDriLicAppID(LocDLA_ID,TestTypeID);
        }
        public static int AddNewTest(Entities.ClsTest test,int Loc_Driving_Lic_App_ID,int TestTypeID,int? RetakeAppID=-1 ,bool Retake = false)
        {
            if(IsAppointmentLocked(test.TestAppointmentID))
            {
                return -1;
            }      
           
            if(!DLMS.Data_access.Appointments.TestAppointmentsData.IsExists(test.TestAppointmentID))
            {
                return -1 ; 
                //  we must make sure that this test has a valid appointment in db
            }
            if(DLMS.BusinessLier.Test.Testlogic.IsSucceededBefore(Loc_Driving_Lic_App_ID,TestTypeID))
            {
                return -2;
            }
            if (TestTypeID==2 && !DLMS.BusinessLier.Test.Testlogic.IsSucceededBefore(Loc_Driving_Lic_App_ID,1))
            {
                return -3;
            }
            if (TestTypeID == 3 && !DLMS.BusinessLier.Test.Testlogic.IsSucceededBefore(Loc_Driving_Lic_App_ID, 2))
            {
                return -3;
            }
            LockTestAppointment(test.TestAppointmentID);
            int TestResult = DLMS.Data_access.Test.TestData.AddNewTest(test);
            if (RetakeAppID > 0 && Retake)
                DLMS.Data_access.Applications.ApplicationData.SetApplicationStatus((int)RetakeAppID, 3);

            return TestResult;
        }
        public static Entities.ClsTest? GetTestByAppointmentID(int AppointmentID)
        {
            return DLMS.Data_access.Test.TestData.GetTestByAppointmentID(AppointmentID);
        }
        public static int AddNewTestAppointment(Entities.ClsTestAppointment Appointment)
        {
            if(HasOpenAppointment(Appointment.LocDLA_ID,Appointment.TestTypeId))
            {
                return -1;
            }
            if (DLMS.BusinessLier.Test.Testlogic.IsSucceededBefore(Appointment.LocDLA_ID, Appointment.TestTypeId))
            {
                return -2;
            }
            if (Appointment.TestTypeId == 2 && !DLMS.BusinessLier.Test.Testlogic.IsSucceededBefore(Appointment.LocDLA_ID, 1))
            {
                return -3;
            }
            if (Appointment.TestTypeId == 3 && !DLMS.BusinessLier.Test.Testlogic.IsSucceededBefore(Appointment.LocDLA_ID, 2))
            {
                return -3;
            }
            int NewAppID = DLMS.Data_access.Appointments.TestAppointmentsData.AddNewAppointment(Appointment);
            return NewAppID;
        }
        public static DataTable? GetAllTestsAppointByLocDLA_ID_andTestId(int LocDLA_ID, int TestTypeID)
        {
            if(LocDLA_ID<=0)
            {
                return null;
            }
            return DLMS.Data_access.Appointments.TestAppointmentsData.GetAllAppointmentsBy_LDLAID_AndTestTypeID(LocDLA_ID,TestTypeID);
        }
        public static bool IsFailedBefore(int DriLicAppID, int TestTypeID)
        {
            return DLMS.Data_access.Test.TestData.IsFailedBeforeInTest(DriLicAppID,  TestTypeID);        
        }
        public static bool IsSucceededBefore(int DriLicAppID, int TestTypeID)
        {
            return DLMS.Data_access.Test.TestData.IsSucceededBeforeInTest(DriLicAppID,  TestTypeID);
        }
        public static decimal GetTestFees(int TestTypeID)
        {
            return DLMS.Data_access.Test.TestData.GetTestFees(TestTypeID);
        }
        public static int TrialCountPerTest(int DriLicAppID, int TestTypeID)
        {
            //if -1 its unknown due an internal error
            return DLMS.Data_access.Test.TestData.TrialCountPerTest(DriLicAppID, TestTypeID);
        }
        public static Entities.ClsTestAppointment? GetTestAppointmentBYID(int TestAppointmentID)
        {
            //if -1 its unknown due an internal error
            if (TestAppointmentID <= 0)
                return null;
            return DLMS.Data_access.Appointments.TestAppointmentsData.GetAppointmentById(TestAppointmentID);
        }
        public static bool LockTestAppointment(int AppointmentID)
        {
            return DLMS.Data_access.Appointments.TestAppointmentsData.LockTestAppointment(AppointmentID);
        }

        public bool IsAppointmentExists(int AppointmentID)
        {
            return DLMS.Data_access.Appointments.TestAppointmentsData.IsExists(AppointmentID);
        }
        public static bool IsAppointmentLocked(int AppointmentID)
        {
            return DLMS.Data_access.Appointments.TestAppointmentsData.IsAppointmentLocked(AppointmentID);
        }
        public static bool EditTestAppointmentDateByAppointmentID(int AppointmentID, DateTime NewDate)
        {
            if(IsAppointmentLocked(AppointmentID))
            {
                return false;
            }
            if(NewDate.Date < DateTime.Now.Date)
            {
                return false;
            }
            return DLMS.Data_access.Appointments.TestAppointmentsData.EditTestAppointmentDateByAppointmentID(AppointmentID, NewDate);
        }

    }
}
