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


    }
}
