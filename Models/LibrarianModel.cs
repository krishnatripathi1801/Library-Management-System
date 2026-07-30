using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class LibrarianModel
    {
        public int LibrarianId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 100, ErrorMessage = "Enter a valid age.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string? Phone { get; set; }
    }

    public class LibrarianIndexViewModel
    {
        public List<LibrarianModel> Librarians { get; set; } = new();
        public string? SearchTerm { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;
    }
}
