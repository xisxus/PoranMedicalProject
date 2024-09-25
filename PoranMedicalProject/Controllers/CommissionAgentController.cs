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
    public class CommissionAgentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommissionAgentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/commissionagent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommissionAgentDto>>> GetCommissionAgents()
        {
            var agents = await _context.CommissionAgents
                .Select(a => new CommissionAgentDto
                {
                    AgentID = a.AgentID,
                    UserID = a.UserID,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    CommissionRate = a.CommissionRate,
                    TotalCommissionEarned = a.TotalCommissionEarned,
                    CommissionIDs = a.Commissions.Select(c => c.CommissionID).ToList()
                }).ToListAsync();

            return Ok(agents);
        }

        // POST: api/commissionagent
        [HttpPost]
        public async Task<ActionResult<CommissionAgentDto>> CreateCommissionAgent([FromBody] CommissionAgentDto agentDto)
        {
            var agent = new CommissionAgent
            {
                UserID = agentDto.UserID,
                FirstName = agentDto.FirstName,
                LastName = agentDto.LastName,
                CommissionRate = agentDto.CommissionRate,
                TotalCommissionEarned = agentDto.TotalCommissionEarned
            };

            _context.CommissionAgents.Add(agent);
            await _context.SaveChangesAsync();

            agentDto.AgentID = agent.AgentID;

            return CreatedAtAction(nameof(GetCommissionAgents), new { id = agent.AgentID }, agentDto);
        }
    }

}
