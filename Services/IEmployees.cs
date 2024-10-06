using exam.Entities;

namespace exam.Services;

public interface IEmployees
{
    Task<bool> createEmployees(Employees employee);
    Task<IEnumerable<Employees>> getAllEmployees();
    Task<Employees> getEmployeeById(Guid id);
    Task<bool> UpdateEmployees(Employees employee);
    Task<bool> DeleteEmployees(Guid id);
    Task<IEnumerable<Employees>> GetEmployeesByStatus(bool? isActive);
    Task<IEnumerable<Employees>> GetEmployeesByDepartment(Guid departmentId);
    Task<IEnumerable<Employees>> GetEmployeesByBirthdays(DateTime startDate, DateTime endDate);

}