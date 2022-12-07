using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVCCore1.Models
{
    public partial class Studept
    {
        public string Id { get; set; }
        public int Deptid { get; set; }
        public string Dname { get; set; }
        public string Incharge { get; set; }
    }
}
