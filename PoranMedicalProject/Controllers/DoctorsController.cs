using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoranMedicalProject.Models.DAL;
using PoranMedicalProject.Models.Entites.Doctors;
using PoranMedicalProject.Models.Input_Models;
using PoranMedicalProject.Models.OutputModel;
using System.IO;

namespace PoranMedicalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly string _doctorImageFolder;

        public DoctorsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _doctorImageFolder = Path.Combine(env.ContentRootPath, "wwwroot", "Doctor"); // Adjust path as needed
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


        // POST: api/doctors
        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromForm] DoctorInputModel model)
        {
            if (model == null)
            {
                return BadRequest("Doctor data is null.");
            }

            var doctor = new Doctor
            {
                DoctorName = model.DoctorName,
                DoctorDasignation = model.DoctorDesignation,
                HospitalID = model.HospitalID,
            };

            // Handle file upload
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var fileName = Path.GetFileName(model.ImageFile.FileName);
                var filePath = Path.Combine(_doctorImageFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(stream);
                }

                doctor.ImageUrl = $"/Doctor/{fileName}"; // URL to access the image
            }

            // Add the doctor to the database
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();

            // Add qualifications
            foreach (var qualificationId in model.Qualifications)
            {
                var qualification = await _context.DoctorQualifications.FindAsync(qualificationId);
                if (qualification != null)
                {
                    doctor.DoctorQualifications.Add(qualification);
                }
            }

            // Add experiences
            foreach (var experienceId in model.Experiences)
            {
                var experience = await _context.DoctorExperiences.FindAsync(experienceId);
                if (experience != null)
                {
                    doctor.DoctorExperiences.Add(experience);
                }
            }

            // Update timestamps
            doctor.CreatedAt = DateTime.Now;
            doctor.UpdatedAt = DateTime.Now;

            // Save changes to include qualifications and experiences
            await _context.SaveChangesAsync();

            return Ok();
        }


        // PUT: api/doctors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromForm] DoctorInputModel model)
        {
            if (model == null || id != model.HospitalID)
            {
                return BadRequest("Invalid doctor data.");
            }

            var doctor = await _context.Doctors
                .Include(d => d.DoctorQualifications)
                .Include(d => d.DoctorExperiences)
                .FirstOrDefaultAsync(d => d.DoctorId == id);

            if (doctor == null)
            {
                return NotFound();
            }

            // Update basic information
            doctor.DoctorName = model.DoctorName;
            doctor.DoctorDasignation = model.DoctorDesignation;
            doctor.HospitalID = model.HospitalID;

            // Handle file upload for image
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                // Optionally delete the old image if necessary
                // var oldImagePath = Path.Combine(_uploadsFolderPath, doctor.ImageUrl);
                // if (System.IO.File.Exists(oldImagePath))
                // {
                //     System.IO.File.Delete(oldImagePath);
                // }

                var fileName = Path.GetFileName(model.ImageFile.FileName);
                var filePath = Path.Combine(_doctorImageFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(stream);
                }

                doctor.ImageUrl = $"/Doctor/{fileName}"; // Update the image URL
            }

            // Clear existing qualifications and experiences before updating
            doctor.DoctorQualifications.Clear();
            doctor.DoctorExperiences.Clear();

            // Add new qualifications
            foreach (var qualificationId in model.Qualifications)
            {
                var qualification = await _context.DoctorQualifications.FindAsync(qualificationId);
                if (qualification != null)
                {
                    doctor.DoctorQualifications.Add(qualification);
                }
            }

            // Add new experiences
            foreach (var experienceId in model.Experiences)
            {
                var experience = await _context.DoctorExperiences.FindAsync(experienceId);
                if (experience != null)
                {
                    doctor.DoctorExperiences.Add(experience);
                }
            }

            // Update timestamps
            doctor.UpdatedAt = DateTime.Now;

           
            await _context.SaveChangesAsync();

           
            return Ok(new
            {
                DoctorId = doctor.DoctorId,
                Url = "/dashboard/all"
            });
        }


        //[HttpPost]
        //public async Task<ActionResult<DoctorOutputModel>> PostDoctor(DoctorInputModel doctorInput)
        //{
        //    var doctor = new Doctor
        //    {
        //        DoctorName = doctorInput.DoctorName,
        //        DoctorDasignation = doctorInput.DoctorDesignation,
        //        HospitalID = doctorInput.HospitalID
        //    };

        //    // Deserialize the qualifications and experiences
        //    if (doctorInput.Qualifications != null && doctorInput.Qualifications.Count > 0)
        //    {
        //        foreach (var qualification in doctorInput.Qualifications)
        //        {
        //            var existingQualification = await _context.DoctorQualifications
        //                .FirstOrDefaultAsync(q => q.QualificationName == qualification.QualificationName);

        //            if (existingQualification != null)
        //            {
        //                doctor.DoctorQualifications.Add(existingQualification);
        //            }
        //            else
        //            {
        //                var newQualification = new DoctorQualification
        //                {
        //                    QualificationName = qualification.QualificationName,
        //                    QualificationDescription = qualification.QualificationDescription
        //                };
        //                doctor.DoctorQualifications.Add(newQualification);
        //            }
        //        }
        //    }

        //    // Deserialize the experiences
        //    if (doctorInput.Experiences != null && doctorInput.Experiences.Count > 0)
        //    {
        //        foreach (var experience in doctorInput.Experiences)
        //        {
        //            var existingExperience = await _context.DoctorExperiences
        //                .FirstOrDefaultAsync(e => e.ExpTitle == experience.ExpTitle);

        //            if (existingExperience != null)
        //            {
        //                doctor.DoctorExperiences.Add(existingExperience);
        //            }
        //            else
        //            {
        //                var newExperience = new DoctorExperience
        //                {
        //                    ExpTitle = experience.ExpTitle,
        //                    Description = experience.Description
        //                };
        //                doctor.DoctorExperiences.Add(newExperience);
        //            }
        //        }
        //    }

        //    // Handle Image Upload
        //    if (doctorInput.ImageFile != null && doctorInput.ImageFile.Length > 0)
        //    {
        //        var imagePath = Path.Combine("wwwroot", "doctor", doctorInput.ImageFile.FileName); // Save in the 'doctor' folder
        //        using (var stream = new FileStream(imagePath, FileMode.Create))
        //        {
        //            await doctorInput.ImageFile.CopyToAsync(stream);
        //        }
        //        doctor.ImageUrl = $"/doctor/{doctorInput.ImageFile.FileName}"; // Store URL in the database
        //    }

        //    _context.Doctors.Add(doctor);
        //    await _context.SaveChangesAsync();

        //    return Ok(new
        //    {
        //        data = doctor,
        //        url = "/doctor/getAll/"
        //    });
        //}



        // PUT: api/Doctors/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDoctor(int id, DoctorInputModel doctorInput)
        //{
        //    var doctor = await _context.Doctors
        //        .Include(d => d.DoctorQualifications)
        //        .Include(d => d.DoctorExperiences)
        //        .FirstOrDefaultAsync(d => d.DoctorId == id);

        //    if (doctor == null)
        //    {
        //        return NotFound();
        //    }

        //    doctor.DoctorName = doctorInput.DoctorName;
        //    doctor.DoctorDasignation = doctorInput.DoctorDesignation;
        //    doctor.HospitalID = doctorInput.HospitalID;
        //    doctor.UpdatedAt = DateTime.Now;

        //    // Update Qualifications
        //    doctor.DoctorQualifications.Clear(); // Clear existing qualifications
        //    foreach (var qualification in doctorInput.Qualifications)
        //    {
        //        var existingQualification = await _context.DoctorQualifications
        //            .FirstOrDefaultAsync(q => q.QualificationName == qualification.QualificationName);

        //        if (existingQualification != null)
        //        {
        //            doctor.DoctorQualifications.Add(existingQualification);
        //        }
        //        else
        //        {
        //            var newQualification = new DoctorQualification
        //            {
        //                QualificationName = qualification.QualificationName,
        //                QualificationDescription = qualification.QualificationDescription
        //            };
        //            doctor.DoctorQualifications.Add(newQualification);
        //        }
        //    }

        //    // Update Experiences
        //    doctor.DoctorExperiences.Clear(); // Clear existing experiences
        //    foreach (var experience in doctorInput.Experiences)
        //    {
        //        var existingExperience = await _context.DoctorExperiences
        //            .FirstOrDefaultAsync(e => e.ExpTitle == experience.ExpTitle);

        //        if (existingExperience != null)
        //        {
        //            doctor.DoctorExperiences.Add(existingExperience);
        //        }
        //        else
        //        {
        //            var newExperience = new DoctorExperience
        //            {
        //                ExpTitle = experience.ExpTitle,
        //                Description = experience.Description
        //            };
        //            doctor.DoctorExperiences.Add(newExperience);
        //        }
        //    }

        //    // Handle Image Upload
        //    if (doctorInput.ImageFile != null && doctorInput.ImageFile.Length > 0)
        //    {
        //        var imagePath = Path.Combine("wwwroot", "Doctor", doctorInput.ImageFile.FileName); // Save in the 'doctor' folder
        //        using (var stream = new FileStream(imagePath, FileMode.Create))
        //        {
        //            await doctorInput.ImageFile.CopyToAsync(stream);
        //        }
        //        doctor.ImageUrl = $"/Doctor/{doctorInput.ImageFile.FileName}"; // Update URL in the database
        //    }

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DoctorExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Ok(new
        //    {
        //        data = doctor,
        //        url = "/doctor/getAll/"
        //    });
        //}


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

            return Ok(new
            {
                data = doctor,
                url = "/doctor/getAll/"
            });
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
                UpdatedAt = doctor.UpdatedAt,
                ImageUrl = doctor.ImageUrl // Include image URL
            };
        }
    }
}
