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
//    public class GuidPatientController : ControllerBase
//    {
//        private readonly AppDbContext _context;

//        public GuidPatientController(AppDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/guidpatient
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<GuidPatientDto>>> GetGuidPatients()
//        {
//            var guidPatients = await _context.GuidPatients
//                .Select(gp => new GuidPatientDto
//                {
//                    GuidPatientID = gp.GuidPatientID,
//                    GuidID = gp.GuidID,
//                    PatientID = gp.PatientID
//                }).ToListAsync();

//            return Ok(guidPatients);
//        }

//        // POST: api/guidpatient
//        [HttpPost]
//        public async Task<ActionResult<GuidPatientDto>> CreateGuidPatient([FromBody] GuidPatientDto dto)
//        {
//            var guidPatient = new GuidPatient
//            {
//                GuidID = dto.GuidID,
//                PatientID = dto.PatientID
//            };

//            _context.GuidPatients.Add(guidPatient);
//            await _context.SaveChangesAsync();

//            dto.GuidPatientID = guidPatient.GuidPatientID;

//            return CreatedAtAction(nameof(GetGuidPatients), new { id = guidPatient.GuidPatientID }, dto);
//        }
//    }

//}
