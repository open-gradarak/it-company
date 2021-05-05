using System;
using System.Text;

namespace InformationTechnologyCompany
{
    public enum QualificationLevel
    {
        Undefined,
        Intern,
        EntryLevel,
        Junior,
        Intermediate,
        Senior,
        Manager,
        Director,
        ChiefExecutiveOfficer

    }
    public enum SpecialistType
    {
        Undefined,
        HumanResourceSpecialist,
        FinancilSpecialist,
        SoftwareEngineer,
        QualityAssurenceEngineer,
        ProjectManagementSpecialist,
        MarketingingSpecialist,
    }

    public class Employee : Person, IReportable
    {
        // Fields
        string employeeId = CompanyUtil.getGuid();
        string companyId = "";
        string departmentId = "";
        string teamId = "";
        QualificationLevel qualificationLevel;
        SpecialistType specialistType = SpecialistType.Undefined;
        DateTime startDate = DateTime.UtcNow;
        DateTime updateDate;
        DateTime endDate;
        uint salary;

        // Constructors
        public Employee(string companyId, string teamId, string departmentId, SpecialistType specialistType,
            QualificationLevel qualificationLevel, uint salary,
            string personalId, string firstName, string lastName, DateTime birthDate)
            : base(personalId, firstName, lastName, birthDate)
        {
            this.companyId = companyId;
            this.departmentId = departmentId;
            this.teamId = teamId;
            this.qualificationLevel = qualificationLevel;
            this.specialistType = specialistType;
            this.salary = salary;
        }
        // Prospective(candidate) employee
        public Employee(SpecialistType specialistType,
            QualificationLevel qualificationLevel,
            string personalId, string firstName, string lastName, DateTime birthDate)
            : base(personalId, firstName, lastName, birthDate)
        {

            this.qualificationLevel = qualificationLevel;
            this.specialistType = specialistType;
        }

        // copy constructor
        public Employee(Employee otherEmployee):
            base(otherEmployee.PersonalId, otherEmployee.FirstName, otherEmployee.LastName, otherEmployee.BirthDate)
        {
            this.companyId = otherEmployee.companyId;
            this.departmentId = otherEmployee.departmentId;
            this.teamId = otherEmployee.teamId;
            this.qualificationLevel = otherEmployee.qualificationLevel;
            this.specialistType = otherEmployee.specialistType;
            this.salary = otherEmployee.salary;
        }

        public Employee ShallowCopy()
        {
            return (Employee)this.MemberwiseClone();
        }

        // Properties
        public string EmployeeId { get => employeeId; }
        public string CompanyId { get => companyId; set => companyId = value; }
        public string DepartmentId { get => departmentId; set => departmentId = value; }
        public string TeamId { get => teamId; set => teamId = value; }
        public QualificationLevel QualificationLevel { get => qualificationLevel; set => qualificationLevel = value; }
        public SpecialistType SpecialistType { get => specialistType; set => specialistType = value; }
        public DateTime StartDate { get => startDate; }
        public DateTime UpdateDate { get => updateDate; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public uint Salary { get => salary; set => salary = value; }
        


        // Methods
        override
        public string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("first name = {0}, last name = {1}, " +
                "birthdate = {2}, personal id = {3}, qualification = {4} {5}",
                this.FirstName, this.LastName, this.BirthDate, this.PersonalId, this.qualificationLevel, this.specialistType);
            return stringBuilder.ToString();
        }

        public void GenerateReport()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
