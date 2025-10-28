using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore; 

namespace Assignment3.Models
{
    [PrimaryKey(nameof(CourseID), nameof(StudentID))]
    public class Enrollment
    {
        // CourseID
        [Required]
        [ForeignKey("Course")]
        [StringLength(8)]
        public string CourseID { get; set; } = null!;

        // StudentID
        [Required]
        [ForeignKey("Student")]
        [StringLength(8)]
        public string StudentID { get; set; } = null!;

        // ------------------------------------- Navigation Properties -------------------------------------

        // Relation: Enrolled has 1 Course
        public Course? Course { get; set; }

        // Relation: Enrolled has 1 Student
        public Student? Student { get; set; }

    }
}
