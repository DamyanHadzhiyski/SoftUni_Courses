using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System.Net;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> options) : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<StudentCourse> StudentsCourses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=StudentSystem;encrypt=false;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(e => new { e.StudentId, e.CourseId });
        }
    }
}
