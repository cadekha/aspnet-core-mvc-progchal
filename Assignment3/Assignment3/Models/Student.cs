using System.ComponentModel.DataAnnotations;

namespace Assignment3.Models
{
    public class Student
    {
        // StudentID
        [Key] // Primary key
        [StringLength(8)] // string(8)
        [RegularExpression(@"^s\d{7}$", ErrorMessage = "StudentID must start with s and be followed by 7 digits.")] // eg. s1234567
        public string StudentID { get; set; } = null!;

        // FirstName
        [Required]
        [StringLength(30)] // string(30)
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")] // First character upper case, only contains letters
        public string FirstName { get; set; } = null!;

        // LastName
        [Required]
        [StringLength(30)] // string(30)
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")] // First character upper case, only contains letters
        public string LastName { get; set; } = null!;

        // Email
        [Required]
        [StringLength(320)] // string(320)
        [EmailAddress] // Must be a valid email address
        public string Email { get; set; } = null!;

        // MobilePhone
        [StringLength(10)] // string(10)
        [RegularExpression(@"^04\d{8}$", ErrorMessage = "MobilePhone must start with 04 and be followed by 8 digits.")] 
        public string? MobilePhone { get; set; } // Can be nullable

        // ------------------------------------- Navigation Properties -------------------------------------

        // Relation: Student has many enrollments
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>(); // initialize to empty list



    }
}
