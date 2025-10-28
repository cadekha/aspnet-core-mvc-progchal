using Microsoft.EntityFrameworkCore; 
using Assignment3.Models;

namespace Assignment3.Data
{
    public class AssignmentDbContext : DbContext
    {
        public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options)
            : base(options)
        {
        }

        // Convert Models into DbSet 
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrolled { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationship Mapping

            // ---------------------------------------------------------------------------------

            // Courses - Enrolled: 1 to *
            modelBuilder.Entity<Enrollment>() // Start from whichever holds the FK of the other (dependent)
                .HasOne(e => e.Course) // Enrollment has 1 Course
                .WithMany(c => c.Enrollments) // Course has many Enrollments
                .HasForeignKey(e => e.CourseID); // Specify FK

            // Students - Enrolled: 1 to *
            modelBuilder.Entity<Enrollment>() // Start from whichever holds the FK of the other (dependent)
                .HasOne(e => e.Student) // Enrollment has 1 Student
                .WithMany(s => s.Enrollments) // Student has many Enrollments
                .HasForeignKey(e => e.StudentID); // Specify FK


            // ---------------------------------------------------------------------------------

            base.OnModelCreating(modelBuilder);
        }
    }
}