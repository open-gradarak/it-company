using System;
using System.Collections.Generic;

namespace InformationTechnologyCompany
{
    public class HumanResourceOperations
    {
        Dictionary<string, Employee> employeesPool = new Dictionary<string, Employee>();
        Dictionary<string, Team> teamPool = new Dictionary<string, Team>();
        Dictionary<string, Department> departmentPool = new Dictionary<string, Department>();
        Dictionary<string, Company> companyPool = new Dictionary<string, Company>();


        public HumanResourceOperations()
        {
        }

        //Methods
        //Company related operations
        public Company CreateCompany(string name, string phone, string email, string address)
        {
            Company company = new Company(name, phone, email, address);
            companyPool.Add(company.UnitId, company);
            return company;
        }

        public void UpdateCompanyPhone(Company company, string phone)
        {
            company.Phone = phone;

        }

        public void UpdateCompanyEmail(Company company, string email)
        {
            company.Email = email;

        }
        public void AssignCompanyCeo(Company company, Employee ceo)
        {
            company.ChiefExecutiveOfficer = ceo;

        }

        // Department related operations
        public Department CreateDepartment(DepartmentName departmentName, string companyId)
        {
            Department department = new Department(departmentName, companyId);
            departmentPool.Add(department.UnitId, department);
            return department;
        }

        public void RemoveDepartment(Department department)
        {
            departmentPool.Remove(department.UnitId);

        }

        // Employee related operations

        public Employee Hire(string personalId, string firstName, string lastName, DateTime birthDate, SpecialistType specialistType, QualificationLevel qualificationLevel)
        {
            Employee employee = new Employee(personalId, firstName, lastName,
                birthDate, specialistType, qualificationLevel);
            employeesPool.Add(employee.EmployeeId, employee);
            return employee;
        }

        public bool Fire(Employee employee)
        {
            if (employeesPool.ContainsKey(employee.EmployeeId))
            {
                Team team = GetTeamById(employee.TeamId);
                if (team != null)
                {
                    // remove from the team first;
                    team.RemoveEmployee(employee);

                }
                employeesPool.Remove(employee.EmployeeId);
                return true;
            }
            return false;
        }

        public void AssignToTeam(Employee employee, Team team)
        {

            if (employee.IsAssignedToTeam())
            {
                //remove the employee from the old team
                Team oldTeam = GetTeamById(employee.EmployeeId);
                if (oldTeam != null)
                {
                    oldTeam.RemoveEmployee(employee);
                    employeesPool.Remove(employee.EmployeeId);
                }
            }
            // assign the employee to the new team
            team.AddEmployee(employee);
        }


        public void UpdateQualification(Employee employee, QualificationLevel qualificationLevel)
        {
            employee.QualificationLevel = qualificationLevel;
        }

        private Team GetTeamById(string teamId)
        {
            if (teamPool.ContainsKey(teamId))
            {
                return teamPool.GetValueOrDefault(teamId, null);
            }
            return null;
        }
    }
}