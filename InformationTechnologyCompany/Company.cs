using System;
using System.Collections.Generic;

namespace InformationTechnologyCompany
{
    public class Company : Unit<Department>
    {
        // Fields
        Employee chiefExecutiveOfficer;
        string phone;
        string email;
        string address;

        // Constructors
        public Company(string name, string phone, string email, string address) : base(name, UnitType.Company)
        {
        }

        // Properties
        public Employee ChiefExecutiveOfficer {
            get
            {
                return chiefExecutiveOfficer;
            }
            set
            {
                chiefExecutiveOfficer = value;
                chiefExecutiveOfficer.Role = Role.ChiefExecutiveOfficer;
                this.Head = value;
            }
        }

        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }



        // Methods
        public void AddDepartment(Department department)

        {
            department.CompanyId = this.UnitId;
            this.AddMember(department, true);
        }
    }
}
