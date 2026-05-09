using SharedLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Objects
{
    public class Patient
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        public double Weight { get; set; }
        public double Height { get; set; }

        public List<Diagnosis> Diagnoses { get; set; } = new();
        public List<Allergy> Allergies { get; set; } = new();



        // History
        public string? MedicalHistory { get; set; }
        public string? SurgicalHistory { get; set; }
        public string? SocialHistory { get; set; }
        public string? FamilyHistory { get; set; }


        // Extra
        public string? Room { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string? AdmittingDiagnosis { get; set; }
        
    }
}
