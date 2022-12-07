using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVCCore1.Models
{
    public partial class Emp
    {
        public decimal Empno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public decimal? Mgr { get; set; }
        public DateTime? Hiredate { get; set; }
        public decimal? Sal { get; set; }
        public decimal? Comm { get; set; }
        public decimal? Deptno { get; set; }

        public virtual Dept DeptnoNavigation { get; set; }
    }
}
