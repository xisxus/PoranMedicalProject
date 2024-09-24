using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoranMedicalProject.Models.DTO;
using PoranMedicalProject.Models;
using PoranMedicalProject.Models.DAL;

namespace PoranMedicalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            var employeeDto = new EmployeeDto
            {
                EmployeeID = employee.EmployeeID,
                UserID = employee.UserID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Department = employee.Department,
                Position = employee.Position,
                HireDate = employee.HireDate,
                Salary = employee.Salary
            };

            return Ok(employeeDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                UserID = employeeDto.UserID,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Department = employeeDto.Department,
                Position = employeeDto.Position,
                HireDate = employeeDto.HireDate,
                Salary = employeeDto.Salary
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmployeeID }, employeeDto);
        }
    }
}
