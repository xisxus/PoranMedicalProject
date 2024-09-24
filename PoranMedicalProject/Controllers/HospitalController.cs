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
//    public class HospitalController : ControllerBase
//    {
//        private readonly AppDbContext _context;

//        public HospitalController(AppDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/hospital
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<HospitalDto>>> GetHospitals()
//        {
//            var hospitals = await _context.Hospitals
//                .Select(h => new HospitalDto
//                {
//                    HospitalID = h.HospitalID,
//                    HospitalName = h.HospitalName,
//                    Location = h.Location,
//                    AppointmentIDs = h.Appointments.Select(a => a.AppointmentID).ToList()
//                }).ToListAsync();

//            return Ok(hospitals);
//        }

//        // POST: api/hospital
//        [HttpPost]
//        public async Task<ActionResult<HospitalDto>> CreateHospital([FromBody] HospitalDto dto)
//        {
//            var hospital = new Hospital
//            {
//                HospitalName = dto.HospitalName,
//                Location = dto.Location
//            };

//            _context.Hospitals.Add(hospital);
//            await _context.SaveChangesAsync();

//            dto.HospitalID = hospital.HospitalID;

//            return CreatedAtAction(nameof(GetHospitals), new { id = hospital.HospitalID }, dto);
//        }
//    }

//}
