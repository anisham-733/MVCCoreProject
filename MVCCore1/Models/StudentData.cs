using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVCCore1.Models
{
    public partial class StudentData
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Standard { get; set; }
        public string Gender { get; set; }
        public decimal ContactNo { get; set; }
    }
}
