using SharedLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Objects
{
    public class Diagnosis
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Severity Severity { get; set; }
    }
}
