using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoranMedicalProject.Models.DTO;
using PoranMedicalProject.Models;
using PoranMedicalProject.Models.DAL;
using PoranMedicalProject.Models.Entites.TreatmentAndSurgery;

namespace PoranMedicalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AppointmentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/appointment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointments()
        {
            var appointments = await _context.Appointments
                .Select(a => new AppointmentDto
                {
                    AppointmentID = a.AppointmentID,
                    PatientID = a.PatientID,
                    HospitalID = a.HospitalID,
                    AppointmentDate = a.AppointmentDate,
                    Description = a.Description
                }).ToListAsync();

            return Ok(appointments);
        }

        // GET: api/appointment/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            var appointmentDto = new AppointmentDto
            {
                AppointmentID = appointment.AppointmentID,
                PatientID = appointment.PatientID,
                HospitalID = appointment.HospitalID,
                AppointmentDate = appointment.AppointmentDate,
                Description = appointment.Description
            };

            return Ok(appointmentDto);
        }

        // POST: api/appointment
        [HttpPost]
        public async Task<ActionResult<AppointmentDto>> CreateAppointment([FromBody] AppointmentDto appointmentDto)
        {
            var appointment = new Appointment
            {
                PatientID = appointmentDto.PatientID,
                HospitalID = appointmentDto.HospitalID,
                AppointmentDate = appointmentDto.AppointmentDate,
                Description = appointmentDto.Description
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            appointmentDto.AppointmentID = appointment.AppointmentID;

            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.AppointmentID }, appointmentDto);
        }

        // PUT: api/appointment/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] AppointmentDto appointmentDto)
        {
            if (id != appointmentDto.AppointmentID)
            {
                return BadRequest();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            appointment.PatientID = appointmentDto.PatientID;
            appointment.HospitalID = appointmentDto.HospitalID;
            appointment.AppointmentDate = appointmentDto.AppointmentDate;
            appointment.Description = appointmentDto.Description;

            _context.Entry(appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
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

        // DELETE: api/appointment/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentID == id);
        }
    }
}
