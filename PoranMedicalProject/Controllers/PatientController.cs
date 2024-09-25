using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoranMedicalProject.Models.DTO;
using PoranMedicalProject.Models;
using PoranMedicalProject.Models.DAL;
using Microsoft.EntityFrameworkCore;
using PoranMedicalProject.Models.Entites.PatientRelated;

namespace PoranMedicalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PatientController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetPatientById(int id)
        {
            var patient = await _context.Patients
                                        .Include(p => p.MedicalReports)
                                        .Include(p => p.Appointments)
                                        .Include(p => p.Costs)
                                        .Include(p => p.Visa)
                                        .FirstOrDefaultAsync(p => p.PatientID == id);

            if (patient == null) return NotFound();

            var patientDto = new PatientDto
            {
                PatientID = patient.PatientID,
                Name = patient.Name,
                ContactInfo = patient.ContactInfo,
                Passport = patient.Passport,
                MedicalReports = patient.MedicalReports.Select(m => m.MedicalReportID).ToList(),
                Appointments = patient.Appointments.Select(a => a.AppointmentID).ToList(),
                Costs = patient.Costs.Select(c => c.CostID).ToList(),
                VisaId = patient.Visa?.VisaID ?? 0
            };

            return Ok(patientDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] PatientDto patientDto)
        {
            var patient = new Patient
            {
                Name = patientDto.Name,
                ContactInfo = patientDto.ContactInfo,
                Passport = patientDto.Passport
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPatientById), new { id = patient.PatientID }, patientDto);
        }
    }
}
