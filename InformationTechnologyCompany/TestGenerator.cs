using System;
using System.Collections.Generic;

namespace InformationTechnologyCompany
{
    public class TestGenerator
    {
        static HashSet<string> emailNameSet = new HashSet<string>();

        public static Employee GenerateFutureEmployee()
        {
            SpecialistType specialistType = TestGeneratorUtil.GetSpecialistType();
           
            QualificationLevel qualificationLevel = TestGeneratorUtil.GetQualificationLevel();

            string firstName = TestGeneratorUtil.GetFirstName();
            string lastName = TestGeneratorUtil.GetLastName();
            DateTime birthDate = TestGeneratorUtil.GetDateOfBirth(18, 70);
            string personalId = CompanyUtil.getGuid();
            Employee employee = new Employee( personalId, firstName, lastName, birthDate, specialistType, qualificationLevel);
            //Employee otherEmployee = employee.ShallowCopy();
            //Console.WriteLine(employee.ToString());
            return employee;

        }
        public static List<Employee> GenerateFutureEmployeePool(uint futureEmployeeCount)
        {
            List<Employee> futureEmployeeList = new List<Employee>();
            for (uint i = 0; i <= futureEmployeeCount; i++)
            {
                futureEmployeeList.Add(GenerateFutureEmployee());
            }

            return futureEmployeeList;
        }

        public static Company GenerateCompany()
        {
            Company company = new Company("Consulting Corp", "4085555555", "consultcorp@gmail.com", "1050 Mashtots Ave., Yerevan, 0002, Armenia");
            company.ChiefExecutiveOfficer = GenerateFutureEmployee();
            Department finDepartment = GenerateDepartment(DepartmentName.Finance);
            company.AddDepartment(finDepartment);
            Department hrDepartment = GenerateDepartment(DepartmentName.HumanResource);
            company.AddDepartment(hrDepartment);
            Department devDepartment = GenerateDepartment(DepartmentName.Development);
            company.AddDepartment(devDepartment);
            Department qaDepartment = GenerateDepartment(DepartmentName.QualityAssurance);
            company.AddDepartment(qaDepartment);
            return company;
        }

        public static Team GenerateTeam(string teamName)
        {
            Team team = new Team(teamName);
            team.Manager = GenerateFutureEmployee();
            team.AddEmployee(GenerateFutureEmployee());
            team.AddEmployee(GenerateFutureEmployee());
            team.AddEmployee(GenerateFutureEmployee());
            return team;
        }

        public static Department GenerateDepartment(DepartmentName departmentName)
        {
            Department department = new Department(departmentName);
            department.Director = GenerateFutureEmployee();
            Team teamA = GenerateTeam(departmentName + " Team A");
            Team teamB = GenerateTeam(departmentName + " Team B");
            department.AddTeam(teamA);
            department.AddTeam(teamB);
            return department;
        }
    }
}
