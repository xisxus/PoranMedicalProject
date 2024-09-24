using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoranMedicalProject.Models.DTO;
using PoranMedicalProject.Models;
using PoranMedicalProject.Models.DAL;
using Microsoft.EntityFrameworkCore;

namespace PoranMedicalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsuranceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InsuranceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuranceDto>>> GetInsurance()
        {
            var insurance = await _context.Insurances.ToListAsync();
            return Ok(insurance);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceDto>> GetInsurance(int id)
        {
            var insurance = await _context.Insurances.FindAsync(id);
            if (insurance == null) return NotFound();
            return Ok(insurance);
        }

        [HttpPost]
        public async Task<ActionResult<InsuranceDto>> CreateInsurance(InsuranceDto insuranceDto)
        {
            var insurance = new Insurance
            {
                InsuranceProvider = insuranceDto.InsuranceProvider,
                PolicyNumber = insuranceDto.PolicyNumber,
                PatientID = insuranceDto.PatientID
            };
            _context.Insurances.Add(insurance);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInsurance), new { id = insurance.InsuranceID }, insurance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInsurance(int id, InsuranceDto insuranceDto)
        {
            if (id != insuranceDto.InsuranceID) return BadRequest();

            var insurance = await _context.Insurances.FindAsync(id);
            if (insurance == null) return NotFound();

            insurance.InsuranceProvider = insuranceDto.InsuranceProvider;
            insurance.PolicyNumber = insuranceDto.PolicyNumber;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurance(int id)
        {
            var insurance = await _context.Insurances.FindAsync(id);
            if (insurance == null) return NotFound();

            _context.Insurances.Remove(insurance);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
