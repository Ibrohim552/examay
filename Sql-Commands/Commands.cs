using exam.Entities;

namespace exam.Sql_Commands
{
    public class Commands
    {
        public const string connectionString =
            "Server=127.0.0.1;Port=5432;Database=Hospital_db;User Id=postgres;Password=12345;";

        public const string GetEmployeeById = "SELECT * FROM \"Employees\" WHERE \"Id\" = @Id";
        public const string GetAllEmployees = "SELECT * FROM \"Employees\"";
        public const string GetAllEmployeesByStatus = "SELECT * FROM \"Employees\" WHERE \"IsActive\" = @isActive";

        public const string GetEmployeesByDepartment =
            "SELECT * FROM \"Employees\" WHERE \"DepartmentId\" = @departmentId;";
        public const string GetAvarageSalary = "SELECT AVG(\"Salary\") AS AverageSalary FROM \"Employees\"";
        
        public const string GetEmployeesByBornsDate="SELECT * FROM \"Employees\" WHERE \"DateOfBirth\" BETWEEN @startDate AND @endDate;";


    }
}