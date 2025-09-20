using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Application.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(150, ErrorMessage = "Title cannot be longer than 150 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        [StringLength(100, ErrorMessage = "Author name cannot be longer than 100 characters.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "ISBN is required.")]
        [RegularExpression(@"^\d{3}-\d{10}$", ErrorMessage = "ISBN must be in format 000-0000000000.")]
        public string ISBN { get; set; }

        [Range(1450, 2100, ErrorMessage = "Published year must be between 1450 and 2100.")]
        public int PublishedYear { get; set; }

        public bool IsAvailable { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [StringLength(100, ErrorMessage = "Publisher cannot exceed 100 characters.")]
        public string Publisher { get; set; }

        [StringLength(50, ErrorMessage = "Language cannot exceed 50 characters.")]
        public string Language { get; set; }
        public required List<int> CategoryIds { get; set; } 
    }
}
