using Dapper;
using exam.DateContext;
using exam.Entities;
using exam.Sql_Commands;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace exam.Services;

public class EmployeeServices(ApplicationContext dbContext):IEmployees
{
    public async Task<bool> createEmployees(Employees employee)
    {
        try
        {
            await dbContext.Employee.AddAsync(employee);
           return await dbContext.SaveChangesAsync()>0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<Employees>> getAllEmployees()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(Commands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryAsync<Employees>(Commands.GetAllEmployees);
        }
    }

    public async Task<Employees> getEmployeeById(Guid id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(Commands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.QuerySingleAsync<Employees>(Commands.GetEmployeeById, new {id});
        }
    }

    public async Task<bool> UpdateEmployees(Employees employee)
    {
        try
        {
            Employees? existingEmployee = await dbContext.Employee.FindAsync(employee.Id);
            if (existingEmployee == null) return false;

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Email = employee.Email;
            existingEmployee.Phone = employee.Phone;
            existingEmployee.DateOfBirth = employee.DateOfBirth;
            existingEmployee.HireDate = employee.HireDate;
            existingEmployee.Position = employee.Position;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.DepartmentId = employee.DepartmentId;
            existingEmployee.ManagerId = employee.ManagerId;
            existingEmployee.IsActive = employee.IsActive;
            existingEmployee.Address = employee.Address;
            existingEmployee.City = employee.City;
            existingEmployee.Country = employee.Country;

           return await dbContext.SaveChangesAsync()>0;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<bool> DeleteEmployees(Guid id)
    {
        try
        {
            Employees? employees = await dbContext.Employee.FindAsync(id);
            if (employees == null) return false;
            dbContext.Employee.Remove(employees);
            return await dbContext.SaveChangesAsync()>0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<Employees>> GetEmployeesByStatus(bool? isActive)
    {
        using (var connection = new NpgsqlConnection(Commands.connectionString))
        {
            await connection.OpenAsync();
            var employees = await connection.QueryAsync<Employees>(
                Commands.GetAllEmployeesByStatus,
                new { isActive }
            );
            return employees;
        }
    }

    public async Task<IEnumerable<Employees>> GetEmployeesByDepartment(Guid departmentId)
    {
        using (var connection = new NpgsqlConnection(Commands.connectionString))
        {
            await connection.OpenAsync();
            var employees = await connection.QueryAsync<Employees>(
                Commands.GetEmployeesByDepartment,
                new { departmentId }
            );
            return employees;
        }
    }

   

    public async Task<IEnumerable<Employees>> GetEmployeesByBirthdays(DateTime startDate, DateTime endDate)
    {
        using (var connection = new NpgsqlConnection(Commands.connectionString))
        {
            await connection.OpenAsync();
            var employees = await connection.QueryAsync<Employees>(
                Commands.GetEmployeesByBornsDate,
                new { startDate, endDate }
            );
            return employees;
        }
    }
}
