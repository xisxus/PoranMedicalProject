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
    public class FollowUpController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FollowUpController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/followup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FollowUpDto>>> GetFollowUps()
        {
            var followUps = await _context.FollowUps
                .Select(fu => new FollowUpDto
                {
                    FollowUpID = fu.FollowUpID,
                    PatientID = fu.PatientID,
                    FollowUpDate = fu.FollowUpDate,
                    Notes = fu.Notes
                }).ToListAsync();

            return Ok(followUps);
        }

        // POST: api/followup
        [HttpPost]
        public async Task<ActionResult<FollowUpDto>> CreateFollowUp([FromBody] FollowUpDto dto)
        {
            var followUp = new FollowUp
            {
                PatientID = dto.PatientID,
                FollowUpDate = dto.FollowUpDate,
                Notes = dto.Notes
            };

            _context.FollowUps.Add(followUp);
            await _context.SaveChangesAsync();

            dto.FollowUpID = followUp.FollowUpID;

            return CreatedAtAction(nameof(GetFollowUps), new { id = followUp.FollowUpID }, dto);
        }
    }

}
