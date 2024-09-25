using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoranMedicalProject.Models.DTO;
using PoranMedicalProject.Models;
using PoranMedicalProject.Models.DAL;
using Microsoft.EntityFrameworkCore;
using PoranMedicalProject.Models.Entites.TreatmentAndSurgery;

namespace PoranMedicalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicinesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedicinesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicineDto>>> GetMedicines()
        {
            var medicines = await _context.Medicines.ToListAsync();
            return Ok(medicines);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicineDto>> GetMedicine(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null) return NotFound();
            return Ok(medicine);
        }

        [HttpPost]
        public async Task<ActionResult<MedicineDto>> CreateMedicine(MedicineDto dto)
        {
            var medicine = new Medicine
            {
                MedicineName = dto.MedicineName,
                Price = dto.Price,
                OrderDate = dto.OrderDate
            };
            _context.Medicines.Add(medicine);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMedicine), new { id = medicine.MedicineID }, medicine);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicine(int id, MedicineDto dto)
        {
            if (id != dto.MedicineID) return BadRequest();

            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null) return NotFound();

            medicine.MedicineName = dto.MedicineName;
            medicine.Price = dto.Price;
            medicine.OrderDate = dto.OrderDate;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null) return NotFound();

            _context.Medicines.Remove(medicine);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
