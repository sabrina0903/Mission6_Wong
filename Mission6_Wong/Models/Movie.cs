using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission07_Wong.Models
{
  
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        // Navigation property
        public  Category? Category { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        [Range(1888, 3000, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }

        public string? Director { get; set; }
        public string? Rating { get; set; }

        [Required]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }

        public string? Notes { get; set; }
    }


}
