using SharedLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Objects
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; } // senere: hash
        public Role Role { get; set; }
        public string? DisplayName { get; set; }
    }
}
