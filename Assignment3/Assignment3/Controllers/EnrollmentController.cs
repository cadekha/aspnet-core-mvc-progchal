using Assignment3.Data;
using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Assignment3.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly AssignmentDbContext _context; // DbContext
        public EnrollmentController(AssignmentDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Get CourseList for user to choose from
            var courses = await _context.Courses.ToListAsync();
            ViewBag.CourseList = courses.Select(c => new SelectListItem
            {
                Value = c.CourseID, // StudentID is submitted in the form
                Text = c.CourseID + " - " + c.Title        // Dropdown field entry
            }).ToList();

            // Get StudentList for user to choose from
            var students = await _context.Students.ToListAsync();
            ViewBag.StudentList = students.Select(s => new SelectListItem
            {
                Value = s.StudentID, // StudentID is submitted in the form
                Text = s.StudentID + " - " + s.FirstName + " " + s.LastName         // Dropdown field entry
            }).ToList();


            return View();
        }

        // POST: Enrollment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseID,StudentID")] Enrollment enrollment)
        {

            if (ModelState.IsValid)
            {
                // Check if enrollment already exists in the database
                bool enrollmentExists = await _context.Enrolled
                    .AnyAsync(e => e.StudentID == enrollment.StudentID && e.CourseID == enrollment.CourseID);

                if (enrollmentExists)
                {
                    // Display error message to the user
                    ModelState.AddModelError("", "The student selected is already enrolled in this course.");
                }
                else
                {
                    _context.Add(enrollment);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Student enrolled successfully.";
                    return RedirectToAction("Index", "Course"); // Return user back to Courses view
                }

            }

            // If invalid, repopulate the StudentList and CourseList
            var courses = await _context.Courses.ToListAsync();
            ViewBag.CourseList = courses.Select(c => new SelectListItem
            {
                Value = c.CourseID, // StudentID is submitted in the form
                Text = c.CourseID + " - " + c.Title        // Dropdown field entry
            }).ToList();

            var students = await _context.Students.ToListAsync();
            ViewBag.StudentList = students.Select(s => new SelectListItem
            {
                Value = s.StudentID, // StudentID is submitted in the form
                Text = s.StudentID + " - " + s.FirstName + " " + s.LastName         // Dropdown field entry
            }).ToList();

            return View("Index", enrollment);
        }



    }
}
