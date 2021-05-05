using System;
namespace InformationTechnologyCompany
{
    public class HumanResourceDeparment : Department
    {
        // Constructors
        public HumanResourceDeparment(): base(DepartmentName.HumanResource)
        {
        }
        public HumanResourceDeparment(string companyId) : base(DepartmentName.HumanResource, companyId)
        {
        }

        //Methods
        public void Hire(Employee applicant, Team team )
        {
            Employee hiredEmployee = applicant.ShallowCopy();
            team.AddEmployee(hiredEmployee);
        }
    }
}
