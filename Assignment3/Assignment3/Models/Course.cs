using System.ComponentModel.DataAnnotations;

namespace Assignment3.Models
{
    // Course Model
    public class Course
    {
        [Key] // Primary key
        [Required]
        [RegularExpression(@"^COSC\d{4}$", ErrorMessage = "CourseID must start with COSC and be followed by 4 digits.")] // eg. COSC2363
        public string CourseID { get; set; } = null!;

        // Title
        [Required] // Must not be empty
        [StringLength(100)] // string(100)
        public string Title { get; set; } = null!;

        // Credit Points
        [Required]
        [Range(1, 12)] // Must be within the range 1 to 12
        public int CreditPoints { get; set; }

        // Career
        [Required]
        [StringLength(30)] // string(30)
        // Must be either Undergraduate or Postgraduate
        [RegularExpression(@"^(Undergraduate|Postgraduate)$", ErrorMessage = "Career must be one of the following values: 'Undergraduate' or 'Postgraduate'")]
        public string Career { get; set; } = null!;

        // Coordinator - name of coordinator
        [Required]
        [StringLength(50)] // string(50)
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$")] // First character upper case, only contains letters and spaces
        public string Coordinator {  get; set; } = null!;

        // ------------------------------------- Navigation Properties -------------------------------------

        // Relation: Course has many enrollments
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>(); // initialize to empty list
    }

}
