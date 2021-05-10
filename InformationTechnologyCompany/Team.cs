using System;
using System.Collections.Generic;
using System.Text;

namespace InformationTechnologyCompany
{
    public class Team : Unit<Employee>
    {
        // Fields
        Employee manager;
        string companyId = "";
        string departmentId = "";

        // Constructors
        public Team(string name, string departmentId, string companyId) : base(name, UnitType.Team)
        {
            this.companyId = companyId;
            this.departmentId = departmentId;
        }

        public Team(string name) : base(name, UnitType.Team)
        {
        }


        // Propeties
        public Employee Manager
        {
            get => manager;
            set
            { 
                manager = value;
                manager.Role = Role.Manager;
                this.Head = value;
            }
        }
        public string DepartmentId { get => departmentId; set => departmentId = value; }
        public string CompanyId { get => companyId; set => companyId = value;} 

        // Methods
        public void AddEmployee(Employee employee)
        {
            employee.CompanyId = this.companyId;
            employee.DepartmentId = this.departmentId;
            employee.TeamId = this.UnitId;
            this.AddMember(employee, true);
        }

        public void RemoveEmployee(Employee employee)
        {
            employee.TeamId = "";
            this.RemoveMember(employee, true);

        }

        public string TeamToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Manager is {0}", manager.ToString());
            string unitToString = ((Unit<Employee>)this).ToString();
            sb.Append(unitToString);
            return sb.ToString();
        }
        

    }
}
