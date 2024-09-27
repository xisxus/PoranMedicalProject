using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoranMedicalProject.Models.DTO;
using PoranMedicalProject.Models;
using PoranMedicalProject.Models.DAL;
using Microsoft.EntityFrameworkCore;
using PoranMedicalProject.Models.Entites.TicketAndVisa;

namespace PoranMedicalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VisasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisaDto>>> GetVisas()
        {
            var visas = await _context.Visas.ToListAsync();
            return Ok(visas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VisaDto>> GetVisa(int id)
        {
            var visa = await _context.Visas.FindAsync(id);
            if (visa == null) return NotFound();
            return Ok(visa);
        }

        [HttpPost]
        public async Task<ActionResult<VisaDto>> CreateVisa(VisaDto dto)
        {
            var visa = new VisaProcessing
            {
                PatientID = dto.PatientID,
                VisaStatus = dto.VisaStatus,
                ProcessingFee = dto.ProcessingFee
            };
            _context.Visas.Add(visa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVisa), new { id = visa.VisaProcessingID }, visa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVisa(int id, VisaDto dto)
        {
            if (id != dto.VisaID) return BadRequest();

            var visa = await _context.Visas.FindAsync(id);
            if (visa == null) return NotFound();

            visa.PatientID = dto.PatientID;
            visa.VisaStatus = dto.VisaStatus;
            visa.ProcessingFee = dto.ProcessingFee;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisa(int id)
        {
            var visa = await _context.Visas.FindAsync(id);
            if (visa == null) return NotFound();

            _context.Visas.Remove(visa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
