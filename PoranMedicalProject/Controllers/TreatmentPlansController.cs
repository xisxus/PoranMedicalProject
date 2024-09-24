//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using PoranMedicalProject.Models.DTO;
//using PoranMedicalProject.Models;
//using PoranMedicalProject.Models.DAL;
//using Microsoft.EntityFrameworkCore;

//namespace PoranMedicalProject.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class TreatmentPlansController : ControllerBase
//    {
//        private readonly AppDbContext _context;

//        public TreatmentPlansController(AppDbContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<TreatmentPlanDto>>> GetTreatmentPlans()
//        {
//            var plans = await _context.TreatmentPlans.ToListAsync();
//            return Ok(plans);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<TreatmentPlanDto>> GetTreatmentPlan(int id)
//        {
//            var plan = await _context.TreatmentPlans.FindAsync(id);
//            if (plan == null) return NotFound();
//            return Ok(plan);
//        }

//        [HttpPost]
//        public async Task<ActionResult<TreatmentPlanDto>> CreateTreatmentPlan(TreatmentPlanDto dto)
//        {
//            var plan = new TreatmentPlan
//            {
//                Name = dto.Name,
//                Description = dto.Description
//            };
//            _context.TreatmentPlans.Add(plan);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetTreatmentPlan), new { id = plan.TreatmentPlanID }, plan);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateTreatmentPlan(int id, TreatmentPlanDto dto)
//        {
//            if (id != dto.TreatmentPlanID) return BadRequest();

//            var plan = await _context.TreatmentPlans.FindAsync(id);
//            if (plan == null) return NotFound();

//            plan.Name = dto.Name;
//            plan.Description = dto.Description;

//            await _context.SaveChangesAsync();
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteTreatmentPlan(int id)
//        {
//            var plan = await _context.TreatmentPlans.FindAsync(id);
//            if (plan == null) return NotFound();

//            _context.TreatmentPlans.Remove(plan);
//            await _context.SaveChangesAsync();
//            return NoContent();
//        }
//    }

//}
