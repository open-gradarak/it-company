using System;
using System.Collections.Generic;

namespace InformationTechnologyCompany
{
    public enum DepartmentName
    {
        Undefined,
        Marketing,
        Finance,
        ProjectManagement,
        HumanResource,
        Development,
        QualityAssurance
    }


    public class Department : Unit<Team>
    {
        // Fields
        Employee director;
        string companyId = "";

        // Constructors
        public Department(DepartmentName departmentName, string companyId) : base (departmentName.ToString(), UnitType.Department)
        {
            this.companyId = companyId;
        }

        public Department(DepartmentName departmentName) : base(departmentName.ToString(), UnitType.Department)
        {
        }

      
        // Propeties
        public Employee Director
        {
            get => director;
            set
            {
                director = value;
                director.Role = Role.Director;
                this.Head = value;
            }
        }
        public string CompanyId { get => companyId; set => companyId = value; }

        // Methods
        public void AddTeam(Team team)
        {
            team.DepartmentId = this.UnitId;
            this.AddMember(team, true);
        }

        
    }
}
