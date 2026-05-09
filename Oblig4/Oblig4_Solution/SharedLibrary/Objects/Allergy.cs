using SharedLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Objects
{
    public class Allergy
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Reactions { get; set; }
        public Severity Severity { get; set; }
        public string? Description { get; set; }
    }
}
