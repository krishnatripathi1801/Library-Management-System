using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Student name is required.")]
        public string? StudentName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string? Phone { get; set; }
    }

    public class StudentIndexViewModel
    {
        // Search Filter
        public string? SearchTerm { get; set; }

        // Pagination Tracking
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 5; // Records per page
        public int TotalPages { get; set; }

        // Data Payload
        public List<StudentModel> Students { get; set; } = new List<StudentModel>();
    }
}
