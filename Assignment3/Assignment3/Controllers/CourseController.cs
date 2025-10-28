using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment3.Data;
using Assignment3.Models;
using System.Diagnostics;

namespace Assignment3.Controllers
{
    public class CourseController : Controller
    {
        private readonly AssignmentDbContext _context; // DbContext
        public CourseController(AssignmentDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Get all Course from Courses table
            var courses = await _context.Courses
               .ToListAsync();
            return View(courses);
        }

        // GET: Course/Students/{id} - Display all currently enrolled students in this course 
        public async Task<IActionResult> Students(string id)
        {
            if (id == null)
                return NotFound();

            // Given this CourseID get all Students enrolled (using Enrolled table)

            var students = await _context.Enrolled
                .Where(e => e.CourseID == id)
                .Include(e => e.Student) // Pull the Student object
                .Select(e => e.Student) // Take only Student objects, nothing from Enrolled
                .ToListAsync(); 

            if (students == null)
                return NotFound();

            var course = await _context.Courses
                .FindAsync(id); // Find 1 Course by ID

            ViewBag.CourseTitle = course.Title; // Pass title to ViewBag to later use in the View

            return View(students); // Return list of Students
        }


    }
}
