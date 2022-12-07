using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVCCore1.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Emp = new HashSet<Emp>();
        }

        public decimal Deptno { get; set; }
        public string Dname { get; set; }
        public string Loc { get; set; }

        public virtual ICollection<Emp> Emp { get; set; }
    }
}
