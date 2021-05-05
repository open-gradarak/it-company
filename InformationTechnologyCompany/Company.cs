using System;
using System.Collections.Generic;

namespace InformationTechnologyCompany
{
    public class Company : Unit<Department>
    {
        // Fields
        Employee chiefExecutiveOfficer;

        // Constructors
        public Company(string name) : base(name, UnitType.Company)
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
                this.Head = value;
            }
        }



        // Methods
        public void AddDepartment(Department department)

        {
            department.CompanyId = this.UnitId;
            this.AddMember(department, true);
        }
    }
}
