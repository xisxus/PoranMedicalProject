using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoranMedicalProject.Models.DTO;
using PoranMedicalProject.Models;
using PoranMedicalProject.Models.DAL;
using Microsoft.EntityFrameworkCore;
using PoranMedicalProject.Models.Entites.CommisionAgent;

namespace PoranMedicalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommissionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommissionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/commission
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommissionDto>>> GetCommissions()
        {
            var commissions = await _context.Commissions
                .Select(c => new CommissionDto
                {
                    CommissionID = c.CommissionID,
                    AgentID = c.AgentID,
                    PatientID = c.PatientID,
                    CommissionAmount = c.CommissionAmount,
                    DateEarned = c.DateEarned
                }).ToListAsync();

            return Ok(commissions);
        }

        // POST: api/commission
        [HttpPost]
        public async Task<ActionResult<CommissionDto>> CreateCommission([FromBody] CommissionDto commissionDto)
        {
            var commission = new Commission
            {
                AgentID = commissionDto.AgentID,
                PatientID = commissionDto.PatientID,
                CommissionAmount = commissionDto.CommissionAmount,
                DateEarned = commissionDto.DateEarned
            };

            _context.Commissions.Add(commission);
            await _context.SaveChangesAsync();

            commissionDto.CommissionID = commission.CommissionID;

            return CreatedAtAction(nameof(GetCommissions), new { id = commission.CommissionID }, commissionDto);
        }
    }

}
