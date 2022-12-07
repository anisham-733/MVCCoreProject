using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVCCore1.Models
{
    public partial class Student
    {
        public string Id { get; set; }
        public string Sname { get; set; }
        public int Class { get; set; }
        public DateTime ExamDate { get; set; }
        public decimal Marks1 { get; set; }
        public decimal Marks2 { get; set; }
        public int DeptId { get; set; }
    }
}
