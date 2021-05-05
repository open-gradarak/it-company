using System;
namespace InformationTechnologyCompany
{
    //public enum PersonalTitle {
    //    Undefined,
    //    Mr,
    //    Ms,
    //    Mrs,
    //    Miss        
    //}
    public class Person
    {
        string personalId;
        DateTime birthDate;
        DateTime deceasedDate;

        string firstName;
        string lastName;

        //PersonalTitle personalTitle;
        
        public Person(string personalId, string firstName, string lastName, DateTime birthDate)
        {
            this.personalId = personalId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
        }

        public string PersonalId { get => personalId; }
        public DateTime BirthDate { get => birthDate;}
        public DateTime DeceasedDate { get => deceasedDate; set => deceasedDate = value; }
        public string FirstName { get => firstName; }
        public string LastName { get => lastName; }
    }
}
