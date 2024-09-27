﻿namespace PoranMedicalProject.Models.Entites.TreatmentAndSurgery
{
    public class TeleMedichineRequest
    {
        public int TeleMedichineRequestId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? AppointmentDate { get; set; }
     
        public string PatientContactInfo { get; set; }
        public string?  DoctorContactInfo { get; set; }

        public decimal  Charge { get; set; }

        public string RequestStatus { get; set; }
    }
}
