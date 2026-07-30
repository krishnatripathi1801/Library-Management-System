using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LibraryManagement.Models
{
    public enum PublicationType
    {
        Newspaper,
        Magazine
    }

    public class Publication
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(100)]
        public string? Title { get; set; }

        [Required(ErrorMessage = "The Publisher field is required.")]
        [StringLength(50)]
        public string? Publisher { get; set; }

        [Required(ErrorMessage = "The Published Date field is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; }

        [Required]
        public PublicationType Type { get; set; } // Differentiates Newspaper vs Magazine

        [Display(Name = "Available")]
        public bool IsAvailable { get; set; } = true;
    }
}
