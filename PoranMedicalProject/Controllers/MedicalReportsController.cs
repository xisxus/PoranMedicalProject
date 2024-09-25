using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoranMedicalProject.Models.DTO;
using PoranMedicalProject.Models;
using PoranMedicalProject.Models.DAL;
using Microsoft.EntityFrameworkCore;
using PoranMedicalProject.Models.Entites.PatientRelated;

namespace PoranMedicalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalReportsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedicalReportsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalReportDto>>> GetMedicalReports()
        {
            var reports = await _context.MedicalReports.ToListAsync();
            return Ok(reports);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalReportDto>> GetMedicalReport(int id)
        {
            var report = await _context.MedicalReports.FindAsync(id);
            if (report == null) return NotFound();
            return Ok(report);
        }

        [HttpPost]
        public async Task<ActionResult<MedicalReportDto>> CreateMedicalReport(MedicalReportDto dto)
        {
            var report = new MedicalReport
            {
                Name = dto.Name,
                Type = dto.Type,
                Description = dto.Description,
                PatientID = dto.PatientID
            };
            _context.MedicalReports.Add(report);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMedicalReport), new { id = report.MedicalReportID }, report);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalReport(int id, MedicalReportDto dto)
        {
            if (id != dto.MedicalReportID) return BadRequest();

            var report = await _context.MedicalReports.FindAsync(id);
            if (report == null) return NotFound();

            report.Name = dto.Name;
            report.Type = dto.Type;
            report.Description = dto.Description;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalReport(int id)
        {
            var report = await _context.MedicalReports.FindAsync(id);
            if (report == null) return NotFound();

            _context.MedicalReports.Remove(report);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
