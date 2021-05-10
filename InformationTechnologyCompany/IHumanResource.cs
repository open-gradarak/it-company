using System;
namespace InformationTechnologyCompany
{
    public interface IHumanResource
    {
        // Hire an employee.
        Employee Hire(string personalId, string firstName, string lastName,
            DateTime birthDate,  SpecialistType specialistType,
            QualificationLevel qualificationLevel);
        // Fire an employee.
        void Fire(Employee employee);
        // Assign an employee to a team
        void AssignTeam(Employee employee, Team team);
        // Update employee's qualification
        void UpdateQualification(Employee employee, QualificationLevel qualificationLevel);
    }
}
