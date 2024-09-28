﻿using PoranMedicalProject.Models.Entites.Doctors;
using PoranMedicalProject.Models.Entites.HospitalRelated;
using PoranMedicalProject.Models.Entites.PatientRelated;
using PoranMedicalProject.Models.Entites.TicketAndVisa;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoranMedicalProject.Models.Entites.TreatmentAndSurgery
{
    public class TreatmentPlan
    {
        public int TreatmentPlanID { get; set; }
        public string RefNo { get; set; }
        public DateTime Date { get; set; }

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }

        public int HospitalId { get; set; }
        [ForeignKey("HospitalId")]
        public virtual Hospital Hospital { get; set; }

        public ICollection<Surgery> Surgeries { get; set; }

        public int StayingHospitalDuration { get; set; }
        public int StayingOutsideDuration { get; set; }

        public string CostCurrency { get; set; }
        public double EstimatedCost { get; set; }

        public ICollection<VisaApply> VisaApplies { get; set; }

        public int ResidenceDoctorId { get; set; }
        [ForeignKey("ResidenceDoctorId")]
        public virtual Doctor ResidenceDoctor { get; set; }

        public int ResidenceHospitalId { get; set; }
        [ForeignKey("ResidenceHospitalId")]
        public virtual Hospital ResidenceHospital { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
