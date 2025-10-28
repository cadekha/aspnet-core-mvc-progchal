using System.ComponentModel.DataAnnotations;

namespace Assignment3.Models
{
    public class Student
    {
        // StudentID
        [Key] // Primary key
        [RegularExpression(@"^s\d{7}$", ErrorMessage = "StudentID must start with s and be followed by 7 digits.")] // eg. s1234567
        public string StudentID { get; set; } = null!;

        // FirstName
        [Required]
        [MaxLength(50)] // string(30)
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")] // First character upper case, only contains letters
        public string FirstName { get; set; } = null!;

        // LastName
        [Required]
        [MaxLength(50)] // string(30)
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")] // First character upper case, only contains letters
        public string LastName { get; set; } = null!;

        // Email
        [Required]
        [EmailAddress] // Must be a valid email address
        public string Email { get; set; } = null!;

        // MobilePhone
        [MaxLength(10)] // string(10)
        [RegularExpression(@"^04\d{8}$", ErrorMessage = "MobilePhone must start with 04 and be followed by 8 digits.")] 
        public string? PhoneNumber { get; set; } // Can be nullable



    }
}
