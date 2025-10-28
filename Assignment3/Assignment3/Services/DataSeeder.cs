using Assignment3.Data;
using Assignment3.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Assignment3.Services
{
    public class DataSeeder
    {
        private readonly AssignmentDbContext _context; 
        private readonly ILogger<DataSeeder> _logger;

        public DataSeeder(AssignmentDbContext context, ILogger<DataSeeder> logger) 
        {
            _context = context;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            // Data Seeding
            // Runs whenever you start the application, if there is no data in the Courses OR Students OR Enrolled tables

            if (await _context.Courses.AnyAsync() || await _context.Students.AnyAsync() || await _context.Enrolled.AnyAsync())
            {
                _logger.LogInformation("Default data already present. Skipping data seeding.");
            }
            else
            {
                // Seed data into the db

                // Course1 - PK COSC2276
                var course1 = new Course
                {
                    CourseID = "COSC2276",
                    Title = "Advanced API Course",
                    CreditPoints = 6,
                    Career = "Postgraduate",
                    Coordinator = "John Smith"
                };

                // Course2 - PK COSC3134
                var course2 = new Course
                {
                    CourseID = "COSC3134",
                    Title = "Foundations of Computing Math",
                    CreditPoints = 3,
                    Career = "Undergraduate",
                    Coordinator = "Jane Doe"
                };

                // Save to db
                _context.Courses.Add(course1);
                _context.Courses.Add(course2);
                await _context.SaveChangesAsync();

                // Student1 - PK s3123456
                var student1 = new Student
                {
                    StudentID = "s3123456",
                    FirstName = "Cade",
                    LastName = "Kha",
                    Email = "realemail@gmail.com",
                    MobilePhone = "0412345678"

                };

                // Student2 - PK s4246800
                var student2 = new Student
                {
                    StudentID = "s4246800",
                    FirstName = "Dang",
                    LastName = "Nguyen",
                    Email = "fakeemail@gmail.com"
                };

                // Save to db
                _context.Students.Add(student1);
                _context.Students.Add(student2);
                await _context.SaveChangesAsync();

                // Enrollments
                var enrollment1 = new Enrollment
                {
                    CourseID = course1.CourseID,
                    StudentID = student1.StudentID
                };

                var enrollment2 = new Enrollment
                {
                    CourseID = course2.CourseID,
                    StudentID = student2.StudentID
                };

                // Save to db
                _context.Enrolled.Add(enrollment1);
                _context.Enrolled.Add(enrollment2);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Default data seeded.");

            }


        }
    }
}