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
        Dictionary<string, Employee> employeeDictionary = new Dictionary<string, Employee> ();

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
        public Employee Manager { get => manager; set { manager = value; this.Head = value; } }
        public string DepartmentId { get => departmentId; set => departmentId = value; }
        public string CompanyId { get => companyId; set => companyId = value;} 

        // Methods
        public void AddEmployee(Employee employee)
        {
            employeeDictionary.Add(employee.EmployeeId, employee);
            employee.CompanyId = this.companyId;
            employee.DepartmentId = this.departmentId;
            employee.TeamId = this.UnitId;
            this.AddMember(employee, true);
        }

        public Employee GetEmployee(string employeeId)
        {
            if (employeeDictionary.ContainsKey(employeeId))
            {
                return employeeDictionary.GetValueOrDefault(employeeId, null);
            }
            return null;
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
