using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVCCore1.Models
{
    public partial class mydatabaseContext : DbContext
    {
        public mydatabaseContext()
        {
        }

        public mydatabaseContext(DbContextOptions<mydatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blobfiles> Blobfiles { get; set; }
        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentData> StudentData { get; set; }
        public virtual DbSet<Studept> Studept { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=HSHLT-1694\\SQLEXPRESS01;Database=mydatabase;Trusted_Connection=True; trustservercertificate = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blobfiles>(entity =>
            {
                entity.ToTable("blobfiles");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateModified)
                    .HasColumnName("dateModified")
                    .HasColumnType("datetime");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnName("filename")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Filesize).HasColumnName("filesize");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path");
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasKey(e => e.Deptno)
                    .HasName("pk_dept");

                entity.ToTable("dept");

                entity.Property(e => e.Deptno)
                    .HasColumnName("deptno")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Dname)
                    .HasColumnName("dname")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Loc)
                    .HasColumnName("loc")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Empno)
                    .HasName("pk_emp");

                entity.ToTable("emp");

                entity.Property(e => e.Empno)
                    .HasColumnName("empno")
                    .HasColumnType("numeric(4, 0)");

                entity.Property(e => e.Comm)
                    .HasColumnName("comm")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Deptno)
                    .HasColumnName("deptno")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Ename)
                    .HasColumnName("ename")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("hiredate")
                    .HasColumnType("date");

                entity.Property(e => e.Job)
                    .HasColumnName("job")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Mgr)
                    .HasColumnName("mgr")
                    .HasColumnType("numeric(4, 0)");

                entity.Property(e => e.Sal)
                    .HasColumnName("sal")
                    .HasColumnType("numeric(7, 2)");

                entity.HasOne(d => d.DeptnoNavigation)
                    .WithMany(p => p.Emp)
                    .HasForeignKey(d => d.Deptno)
                    .HasConstraintName("fk_deptno");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Class).HasColumnName("class");

                entity.Property(e => e.DeptId).HasColumnName("deptId");

                entity.Property(e => e.ExamDate)
                    .HasColumnName("exam_date")
                    .HasColumnType("date");

                entity.Property(e => e.Marks1)
                    .HasColumnName("marks1")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Marks2)
                    .HasColumnName("marks2")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Sname)
                    .HasColumnName("sname")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentData>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.ToTable("studentData");

                entity.Property(e => e.StudentId)
                    .HasColumnName("studentId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.ContactNo)
                    .HasColumnName("contactNo")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Standard).HasColumnName("standard");
            });

            modelBuilder.Entity<Studept>(entity =>
            {
                entity.ToTable("studept");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Deptid).HasColumnName("deptid");

                entity.Property(e => e.Dname)
                    .IsRequired()
                    .HasColumnName("dname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Incharge)
                    .IsRequired()
                    .HasColumnName("incharge")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
