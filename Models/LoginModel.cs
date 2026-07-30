using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class LoginModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string? username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string? password { get; set; }

        // Not persisted - used only for role redirection after login
        public string? role { get; set; }
    }
}
