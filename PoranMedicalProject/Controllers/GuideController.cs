//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using PoranMedicalProject.Models.DTO;
//using PoranMedicalProject.Models;
//using PoranMedicalProject.Models.DAL;

//namespace PoranMedicalProject.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class GuideController : ControllerBase
//    {
//        private readonly AppDbContext _context;

//        public GuideController(AppDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/guide
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<GuideDto>>> GetGuides()
//        {
//            var guides = await _context.Guids
//                .Select(g => new GuideDto
//                {
//                    GuidID = g.GuidID,
//                    GuidName = g.GuidName,
//                    PhoneNo = g.PhoneNo,
//                    GuidPatientIDs = g.GuidPatients.Select(gp => gp.GuidPatientID).ToList()
//                }).ToListAsync();

//            return Ok(guides);
//        }

//        // POST: api/guide
//        [HttpPost]
//        public async Task<ActionResult<GuideDto>> CreateGuide([FromBody] GuideDto dto)
//        {
//            var guide = new Guide
//            {
//                GuidName = dto.GuidName,
//                PhoneNo = dto.PhoneNo
//            };

//            _context.Guids.Add(guide);
//            await _context.SaveChangesAsync();

//            dto.GuidID = guide.GuidID;

//            return CreatedAtAction(nameof(GetGuides), new { id = guide.GuidID }, dto);
//        }

//        // PUT: api/guide/{id}
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateGuide(int id, [FromBody] GuideDto dto)
//        {
//            if (id != dto.GuidID)
//            {
//                return BadRequest();
//            }

//            var guide = await _context.Guids.FindAsync(id);
//            if (guide == null)
//            {
//                return NotFound();
//            }

//            guide.GuidName = dto.GuidName;
//            guide.PhoneNo = dto.PhoneNo;

//            _context.Entry(guide).State = EntityState.Modified;
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        // DELETE: api/guide/{id}
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteGuide(int id)
//        {
//            var guide = await _context.Guids.FindAsync(id);
//            if (guide == null)
//            {
//                return NotFound();
//            }

//            _context.Guids.Remove(guide);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }
//    }

//}
