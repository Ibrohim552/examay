namespace exam.Entities;

public class Employees
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime HireDate { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
    public string DepartmentId { get; set; }
    public Guid? ManagerId { get; set; }
    public bool IsActive { get; set; } = true;
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}