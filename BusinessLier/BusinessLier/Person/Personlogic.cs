using DLMS.Data_access;
using DLMS.EntitiesNamespace;
using System.Data;


namespace DLMS.BusinessLier.Person
{
    public static class PersonLogic
    {
        public static Entities.ClsPerson? FindPerson(int ID = -1, string NationalNo = "")
        {
            return DLMS.Data_access.Person.PersonData.FindPerson(ID,NationalNo );
        }
        public static int DeletePerson(int ID = -1, string NationalNo = "")
        {
            return DLMS.Data_access.Person.PersonData.DeletePerson( ID,NationalNo );
        }
        public static bool Exists(int ID = -1, string NationalNo = "")
        {
            return DLMS.Data_access.Person.PersonData.Exists(ID , NationalNo );
        }
        public static DataTable? GetAllPeople()
        {
            return DLMS.Data_access.Person.PersonData.GetAllPeople();
        }
        public static bool Save(Entities.ClsPerson Prsn,out int NewPersonID)
        {
            NewPersonID = -1;
            if (Prsn == null) return false;
            string ImgErrors = "";

            if (Prsn.ImagePath!="")
            {
                if (File.Exists(path: Prsn.ImagePath))
                {
                    string DestinationFolder = @"D:\C# Projects\Course 19\DLMS\DLMS\Data_Access\Data_access\Person\Images\";
                    string FileName = Guid.NewGuid().ToString();
                    string Extention = Path.GetExtension(Prsn.ImagePath);
                    string FullPath = Path.Combine(DestinationFolder, FileName)+Extention;
                    try
                    {
                        File.Copy(Prsn.ImagePath, FullPath, overwrite: true);
                        Prsn.ImagePath = FullPath;
                    }
                    catch(Exception EX)
                    {
                        ImgErrors += EX.Message;
                    }

                }
            }
            string SaveErrors = "";
            return  PersonLogic.SaveInternally(Prsn, ref SaveErrors,ref NewPersonID);       
          
        }
        private static bool SaveInternally(Entities.ClsPerson Prsn, ref string Errors,ref int ID)
        {
            switch(Prsn.Mode)
            {
                case  Entities.EnMode.AddNew:
                    ID = DLMS.Data_access.Person.PersonData.AddPerson(Prsn, ref Errors);
                    if (ID!=-1)
                    {
                        Prsn.Mode = Entities.EnMode.Update;
                        return true;
                    }
                    break;
                case Entities.EnMode.Update:
                    if (DLMS.Data_access.Person.PersonData.UpdatePerson(Prsn, ref Errors))
                    {                       
                        return true;
                    }
                    break;
            }
            return false;
        }

    }
}