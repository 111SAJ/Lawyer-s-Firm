using System.ComponentModel.DataAnnotations;

namespace LawyersFirm.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Email format is not valid")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone is Required")]
        [MaxLength(10, ErrorMessage = "Phone should be 10 digits")]
        [MinLength(10, ErrorMessage = "Phone should be 10 digits")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string? Message { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
