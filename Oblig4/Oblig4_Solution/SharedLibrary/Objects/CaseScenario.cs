using System;

using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Objects
{
    public class CaseScenario
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = new();
        public List<VitalSigns> VitalSignsHistory { get; set; } = new();
        public List<Goal> Goals { get; set; } = new();
        public List<Medication> Medications { get; set; } = new();
        public List<ActionLog> ActionLogs { get; set; } = new();
        public bool IsTeacherOnly { get; set; }
        public List<TeacherObservation> TeacherObservations { get; set; } = new();

    } 
}
