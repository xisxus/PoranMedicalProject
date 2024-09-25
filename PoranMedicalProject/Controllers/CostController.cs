using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoranMedicalProject.Models.DTO;
using PoranMedicalProject.Models;
using PoranMedicalProject.Models.DAL;
using Microsoft.EntityFrameworkCore;
using PoranMedicalProject.Models.Entites;

namespace PoranMedicalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CostController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CostController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/cost
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CostDto>>> GetCosts()
        {
            var costs = await _context.Costs
                .Select(c => new CostDto
                {
                    CostID = c.CostID,
                    PatientID = c.PatientID,
                    ServiceType = c.ServiceType,
                    Amount = c.Amount
                }).ToListAsync();

            return Ok(costs);
        }

        // POST: api/cost
        [HttpPost]
        public async Task<ActionResult<CostDto>> CreateCost([FromBody] CostDto costDto)
        {
            var cost = new Cost
            {
                PatientID = costDto.PatientID,
                ServiceType = costDto.ServiceType,
                Amount = costDto.Amount
            };

            _context.Costs.Add(cost);
            await _context.SaveChangesAsync();

            costDto.CostID = cost.CostID;

            return CreatedAtAction(nameof(GetCosts), new { id = cost.CostID }, costDto);
        }
    }

}
