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
    public class FeedbackController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FeedbackController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/feedback
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackDto>>> GetFeedbacks()
        {
            var feedbacks = await _context.Feedbacks
                .Select(fb => new FeedbackDto
                {
                    FeedbackID = fb.FeedbackID,
                    PatientID = fb.PatientID,
                    HospitalID = fb.HospitalID,
                    Comments = fb.Comments,
                    Rating = fb.Rating
                }).ToListAsync();

            return Ok(feedbacks);
        }

        // POST: api/feedback
        [HttpPost]
        public async Task<ActionResult<FeedbackDto>> CreateFeedback([FromBody] FeedbackDto dto)
        {
            var feedback = new Feedback
            {
                PatientID = dto.PatientID,
                HospitalID = dto.HospitalID,
                Comments = dto.Comments,
                Rating = dto.Rating
            };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            dto.FeedbackID = feedback.FeedbackID;

            return CreatedAtAction(nameof(GetFeedbacks), new { id = feedback.FeedbackID }, dto);
        }
    }

}
