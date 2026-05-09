using System;
using System.Collections.Generic;
using System.Text;
using SharedLibrary.Enum;

namespace SharedLibrary.Objects
{
    public class Medication
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Dosage { get; set; }
        public string? Frequency { get; set; }
        public Route Route { get; set; }
    }
}
