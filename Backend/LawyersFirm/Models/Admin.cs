using System.ComponentModel.DataAnnotations;

namespace LawyersFirm.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
