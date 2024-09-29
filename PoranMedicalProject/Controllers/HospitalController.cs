using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoranMedicalProject.Models.DAL;
using PoranMedicalProject.Models.Entites.HospitalRelated;
using PoranMedicalProject.Models.Input_Models;
using PoranMedicalProject.Models.OutputModel;

namespace PoranMedicalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HospitalController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllHospitals()
        {
            var hospitals = await _context.Hospitals
                .Include(h => h.Doctors)
                .Include(h => h.TreatmentsPlans)
                .Include(h => h.HospitalFacilities)
                    .ThenInclude(hf => hf.Facilities)
                .Include(h => h.Appointments)
                .Select(h => new HospitalOutputModel
                {
                    HospitalID = h.HospitalID,
                    HospitalName = h.HospitalName,
                    Address = h.Address,
                    City = h.City,
                    Country = h.Country,
                    Email = h.Email,
                    Phone = h.Phone,
                    PhotoUrl = h.PhotoUrl,
                    Logo = h.Logo,
                    CreatedAt = h.CreatedAt,
                    UpdatedAt = h.UpdatedAt,
                    Doctors = h.Doctors.Select(d => new DoctorOutputModel
                    {
                        DoctorId = d.DoctorId,
                        DoctorName = d.DoctorName
                    }).ToList(),
                    TreatmentPlans = h.TreatmentsPlans.Select(tp => new TreatmentPlanOutputModel
                    {
                        TreatmentPlanID = tp.TreatmentPlanID,
                        RefNo = tp.RefNo,
                        Date = tp.Date
                    }).ToList(),
                    HospitalFacilities = h.HospitalFacilities.Select(hf => new HospitalFacilitiesOutputModel
                    {
                        HospitalFacilitiesId = hf.HospitalFacilitiesId,
                        FacilitiesDescription = hf.Facilities.FacilitiesDescription
                    }).ToList(),
                    Appointments = h.Appointments.Select(a => new AppointmentOutputModel
                    {
                        AppointmentID = a.AppointmentID,
                        AppointmentDate = a.AppointmentDate,
                        Description = a.Description,
                        AppointmentFile = a.AppointmentFile
                    }).ToList()
                }).ToListAsync();

            return Ok(hospitals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHospitalById(int id)
        {
            var hospital = await _context.Hospitals
                .Include(h => h.Doctors)
                .Include(h => h.TreatmentsPlans)
                .Include(h => h.HospitalFacilities)
                    .ThenInclude(hf => hf.Facilities)
                .Include(h => h.Appointments)
                .Where(h => h.HospitalID == id)
                .Select(h => new HospitalOutputModel
                {
                    HospitalID = h.HospitalID,
                    HospitalName = h.HospitalName,
                    Address = h.Address,
                    City = h.City,
                    Country = h.Country,
                    Email = h.Email,
                    Phone = h.Phone,
                    PhotoUrl = h.PhotoUrl,
                    Logo = h.Logo,
                    CreatedAt = h.CreatedAt,
                    UpdatedAt = h.UpdatedAt,
                    Doctors = h.Doctors.Select(d => new DoctorOutputModel
                    {
                        DoctorId = d.DoctorId,
                        DoctorName = d.DoctorName
                    }).ToList(),
                    TreatmentPlans = h.TreatmentsPlans.Select(tp => new TreatmentPlanOutputModel
                    {
                        TreatmentPlanID = tp.TreatmentPlanID,
                        RefNo = tp.RefNo,
                        Date = tp.Date
                    }).ToList(),
                    HospitalFacilities = h.HospitalFacilities.Select(hf => new HospitalFacilitiesOutputModel
                    {
                        HospitalFacilitiesId = hf.HospitalFacilitiesId,
                        FacilitiesDescription = hf.Facilities.FacilitiesDescription
                    }).ToList(),
                    Appointments = h.Appointments.Select(a => new AppointmentOutputModel
                    {
                        AppointmentID = a.AppointmentID,
                        AppointmentDate = a.AppointmentDate,
                        Description = a.Description,
                        AppointmentFile = a.AppointmentFile
                    }).ToList()
                }).FirstOrDefaultAsync();

            if (hospital == null)
            {
                return NotFound();
            }

            return Ok(hospital);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHospital([FromForm] HospitalCreateInputModel hospitalInput)
        {
            var hospital = new Hospital
            {
                HospitalName = hospitalInput.HospitalName,
                Address = hospitalInput.Address,
                City = hospitalInput.City,
                Country = hospitalInput.Country,
                Email = hospitalInput.Email,
                Phone = hospitalInput.Phone,
            };

            // Save Photo and Logo
            if (hospitalInput.Photo != null)
            {
                var photoPath = SaveFile(hospitalInput.Photo, "Hospital");
                hospital.PhotoUrl = photoPath;
            }

            if (hospitalInput.Logo != null)
            {
                var logoPath = SaveFile(hospitalInput.Logo, "Hospital");
                hospital.Logo = logoPath;
            }

            _context.Hospitals.Add(hospital);
            await _context.SaveChangesAsync();

            // Create a URL for the newly created hospital resource
            //var resourceUrl = $"{Request.Scheme}://{Request.Host}/api/Hospital/{hospital.HospitalID}";


            var resourceUrl = $"/api/Hospital/{hospital.HospitalID}";
            return Created(resourceUrl, new
            {
                Url = resourceUrl,
                Data = hospital
            });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHospital(int id, [FromForm] HospitalUpdateInputModel hospitalInput)
        {
            var hospital = await _context.Hospitals.FindAsync(id);
            if (hospital == null)
                return NotFound();

            hospital.HospitalName = hospitalInput.HospitalName;
            hospital.Address = hospitalInput.Address;
            hospital.City = hospitalInput.City;
            hospital.Country = hospitalInput.Country;
            hospital.Email = hospitalInput.Email;
            hospital.Phone = hospitalInput.Phone;

            // Update Photo and Logo
            if (hospitalInput.Photo != null)
            {
                var photoPath = SaveFile(hospitalInput.Photo, "Hospital");
                hospital.PhotoUrl = photoPath;
            }

            if (hospitalInput.Logo != null)
            {
                var logoPath = SaveFile(hospitalInput.Logo, "Hospital");
                hospital.Logo = logoPath;
            }

            _context.Hospitals.Update(hospital);
            await _context.SaveChangesAsync();

            // Create a URL for the updated hospital resource
           // var resourceUrl = $"{Request.Scheme}://{Request.Host}/api/Hospital/{hospital.HospitalID}";


            var resourceUrl = $"/api/Hospital/{hospital.HospitalID}";
            return Ok(new
            {
                Url = resourceUrl,
                Data = hospital
            });
        }


        

        private string SaveFile(IFormFile file, string folderName)
        {
            var uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, folderName);
            if (!Directory.Exists(uploadDir))
                Directory.CreateDirectory(uploadDir);

            var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(uploadDir, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return Path.Combine(folderName, uniqueFileName).Replace("\\", "/");
        }
    }
}
