using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoranMedicalProject.Models.DAL;
using PoranMedicalProject.Models.Entites.Doctors;
using PoranMedicalProject.Models.Input_Models;
using PoranMedicalProject.Models.OutputModel;

namespace PoranMedicalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DoctorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorOutputModel>>> GetDoctors()
        {
            var doctors = await _context.Doctors
                .Include(d => d.DoctorQualifications)
                .Include(d => d.DoctorExperiences)
                .ToListAsync();

            return doctors.Select(d => MapDoctorToOutputModel(d)).ToList();
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorOutputModel>> GetDoctor(int id)
        {
            var doctor = await _context.Doctors
                .Include(d => d.DoctorQualifications)
                .Include(d => d.DoctorExperiences)
                .FirstOrDefaultAsync(d => d.DoctorId == id);

            if (doctor == null)
            {
                return NotFound();
            }

            return MapDoctorToOutputModel(doctor);
        }

        [HttpPost]
        public async Task<ActionResult<DoctorOutputModel>> PostDoctor(DoctorInputModel doctorInput)
        {
            var doctor = new Doctor
            {
                DoctorName = doctorInput.DoctorName,
                DoctorDasignation = doctorInput.DoctorDesignation,
                HospitalID = doctorInput.HospitalID,
                DoctorQualifications = await _context.DoctorQualifications
                    .Where(q => doctorInput.QualificationIds.Contains(q.DoctorQualificationId))
                    .ToListAsync(),
                DoctorExperiences = await _context.DoctorExperiences
                    .Where(e => doctorInput.ExperienceIds.Contains(e.DoctorExperienceId))
                    .ToListAsync()
            };

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            // Reload the doctor with all related data
            await _context.Entry(doctor)
                .Reference(d => d.Hospital)
                .LoadAsync();
            await _context.Entry(doctor)
                .Collection(d => d.DoctorQualifications)
                .LoadAsync();
            await _context.Entry(doctor)
                .Collection(d => d.DoctorExperiences)
                .LoadAsync();

            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.DoctorId }, MapDoctorToOutputModel(doctor));
        }

        // PUT: api/Doctors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, DoctorInputModel doctorInput)
        {
            var doctor = await _context.Doctors
                .Include(d => d.DoctorQualifications)
                .Include(d => d.DoctorExperiences)
                .FirstOrDefaultAsync(d => d.DoctorId == id);

            if (doctor == null)
            {
                return NotFound();
            }

            doctor.DoctorName = doctorInput.DoctorName;
            doctor.DoctorDasignation = doctorInput.DoctorDesignation;
            doctor.HospitalID = doctorInput.HospitalID;
            doctor.UpdatedAt = DateTime.Now;

            // Update qualifications
            doctor.DoctorQualifications = await _context.DoctorQualifications
                .Where(q => doctorInput.QualificationIds.Contains(q.DoctorQualificationId))
                .ToListAsync();

            // Update experiences
            doctor.DoctorExperiences = await _context.DoctorExperiences
                .Where(e => doctorInput.ExperienceIds.Contains(e.DoctorExperienceId))
                .ToListAsync();

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.DoctorId == id);
        }

        private DoctorOutputModel MapDoctorToOutputModel(Doctor doctor)
        {
            return new DoctorOutputModel
            {
                DoctorId = doctor.DoctorId,
                DoctorName = doctor.DoctorName,
                DoctorDesignation = doctor.DoctorDasignation,
                HospitalID = doctor.HospitalID,
                Qualifications = doctor.DoctorQualifications.Select(q => new DoctorQualificationOutputModel
                {
                    DoctorQualificationId = q.DoctorQualificationId,
                    QualificationName = q.QualificationName,
                    QualificationDescription = q.QualificationDescription,
                    CreatedAt = q.CreatedAt,
                    UpdatedAt = q.UpdatedAt
                }).ToList(),
                Experiences = doctor.DoctorExperiences.Select(e => new DoctorExperienceOutputModel
                {
                    DoctorExperienceId = e.DoctorExperienceId,
                    ExpTitle = e.ExpTitle,
                    Description = e.Description,
                    CreatedAt = e.CreatedAt,
                    UpdatedAt = e.UpdatedAt
                }).ToList(),
                CreatedAt = doctor.CreatedAt,
                UpdatedAt = doctor.UpdatedAt
            };
        }
    }
}
