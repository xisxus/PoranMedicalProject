using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PoranMedicalProject.Models.DTO;
using PoranMedicalProject.Models.Entites;

namespace PoranMedicalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUserDto>> GetApplicationUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var userDto = new ApplicationUserDto
            {
                Id = user.Id,
                Name = user.Name,
                Patients = user.Patients.Select(p => p.PatientID).ToList(),
                Employees = user.Employees.Select(e => e.EmployeeID).ToList(),
                CommissionAgents = user.CommissionAgents.Select(c => c.AgentID).ToList()
            };

            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplicationUser([FromBody] ApplicationUserDto userDto)
        {
            var user = new ApplicationUser { UserName = userDto.Name, Name = userDto.Name };
            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded) return BadRequest(result.Errors);

            return CreatedAtAction(nameof(GetApplicationUserById), new { id = user.Id }, userDto);
        }
    }
}
