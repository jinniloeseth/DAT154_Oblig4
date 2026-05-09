using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Objects
{
    public class TeacherObservation
    {
        public int Id { get; set; }

        public string? Observation { get; set; }

        public DateTime Timestamp { get; set; }

        public int CaseScenarioId { get; set; }

        public CaseScenario? CaseScenario { get; set; }
    }
}
