using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Objects
{
    public class VitalSigns
    {
        public int Id { get; set; }
        public int CaseScenarioId { get; set; }
        public CaseScenario? CaseScenario { get; set; } = null!;
        public DateTime TimeStamp { get; set; }
        public int SystolicPressure { get; set; }
        public int DiastolicPressure { get; set; }
        public double OxygenSaturation { get; set; }
        public int RespiratoryRate { get; set; }
        public int HeartRate { get; set; }
        public double Temperature { get; set; }
    }
}
