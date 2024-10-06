using exam.Entities;
using exam.Services;
using Microsoft.AspNetCore.Mvc;

namespace MainApp.Controller;

[ApiController]
[Route("api/employees")]
public class EmployeeController:ControllerBase
{
    private readonly IEmployees _employeeService;
    public EmployeeController(IEmployees employeeService)
    {
        _employeeService = employeeService;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Employees>>> GetEmployees()
    {
        return Ok(await _employeeService.getAllEmployees());
    }

    [HttpGet("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Employees?>> GetEmployeeById([FromRoute]Guid id)
    {
        Employees? employee = await _employeeService.getEmployeeById(id);
        if (employee == null)
            return NotFound("ничего не найдено");
        return Ok(await _employeeService.getEmployeeById(id));
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Employees>> CreateEmployee([FromBody]Employees? employee)
    {
        if (employee == null)
            return BadRequest("Необходимо передать данные employee");
        return Ok(await _employeeService.createEmployees(employee));
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Employees>> UpdateBook([FromBody]Employees? employee)
    {
        if (employee == null)
            return BadRequest("Необходимо передать данные employee");
        return Ok(await _employeeService.UpdateEmployees(employee));
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteBook(Guid id)
    {
        bool res = await _employeeService.DeleteEmployees(id);
        if (res!=true)
        {
            return NotFound("ничего не найдено");
        }
        return Ok(res);
    }
    [HttpGet("status")]
    public async Task<ActionResult<IEnumerable<Employees>>> GetEmployeesByStatus([FromQuery] bool? isActive)
    {
        var employees = await _employeeService.GetEmployeesByStatus(isActive);
        return Ok(employees);
    }

    [HttpGet("department/{departmentId}")]
    public async Task<ActionResult<IEnumerable<Employees>>> GetEmployeesByDepartment(Guid departmentId)
    {
        var employees = await _employeeService.GetEmployeesByDepartment(departmentId);
        return Ok(employees);
    }

    [HttpGet("birthdays")]
    public async Task<ActionResult<IEnumerable<Employees>>> GetEmployeesByBirthdays([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var employees = await _employeeService.GetEmployeesByBirthdays(startDate, endDate);
        return Ok(employees);
    } 
}
