using DLMS;
using System.Data;



partial class Program
{
    public static void Main()
    {
    DLMS.EntitiesNamespace.Entities.ClsPerson Per =    DLMS.Data_access.Person.PersonData.FindPerson(NationalNo:"n1");
        Console.ReadLine();
    }




}