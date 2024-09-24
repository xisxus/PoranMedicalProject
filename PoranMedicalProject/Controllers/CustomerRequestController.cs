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
//    public class CustomerRequestController : ControllerBase
//    {
//        private readonly AppDbContext _context;

//        public CustomerRequestController(AppDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/customerrequest
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<CustomerRequestDto>>> GetCustomerRequests()
//        {
//            var requests = await _context.CustomerRequests
//                .Select(cr => new CustomerRequestDto
//                {
//                    CustomerRequestID = cr.CustomerRequestID,
//                    Name = cr.Name,
//                    MobileNo = cr.MobileNo,
//                    Status = cr.Status,
//                    PatientID = cr.PatientID
//                }).ToListAsync();

//            return Ok(requests);
//        }

//        // POST: api/customerrequest
//        [HttpPost]
//        public async Task<ActionResult<CustomerRequestDto>> CreateCustomerRequest([FromBody] CustomerRequestDto dto)
//        {
//            var customerRequest = new CustomerRequest
//            {
//                Name = dto.Name,
//                MobileNo = dto.MobileNo,
//                Status = dto.Status,
//                PatientID = dto.PatientID
//            };

//            _context.CustomerRequests.Add(customerRequest);
//            await _context.SaveChangesAsync();

//            dto.CustomerRequestID = customerRequest.CustomerRequestID;

//            return CreatedAtAction(nameof(GetCustomerRequests), new { id = customerRequest.CustomerRequestID }, dto);
//        }

//        // PUT: api/customerrequest/{id}
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateCustomerRequest(int id, [FromBody] CustomerRequestDto dto)
//        {
//            if (id != dto.CustomerRequestID)
//            {
//                return BadRequest();
//            }

//            var customerRequest = await _context.CustomerRequests.FindAsync(id);
//            if (customerRequest == null)
//            {
//                return NotFound();
//            }

//            customerRequest.Name = dto.Name;
//            customerRequest.MobileNo = dto.MobileNo;
//            customerRequest.Status = dto.Status;
//            customerRequest.PatientID = dto.PatientID;

//            _context.Entry(customerRequest).State = EntityState.Modified;
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        // DELETE: api/customerrequest/{id}
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteCustomerRequest(int id)
//        {
//            var customerRequest = await _context.CustomerRequests.FindAsync(id);
//            if (customerRequest == null)
//            {
//                return NotFound();
//            }

//            _context.CustomerRequests.Remove(customerRequest);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }
//    }

//}
