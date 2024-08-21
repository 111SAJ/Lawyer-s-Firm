using System.ComponentModel.DataAnnotations;

namespace LawyersFirm.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [Required(ErrorMessage = "Job Position is required")]
        public string? Position { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public string? Category { get; set; }
        [Required(ErrorMessage = "Internship duration is required")]
        public string? InternshipMonths { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
