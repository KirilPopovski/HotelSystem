using System.ComponentModel.DataAnnotations;

namespace HotelSystem.Admin.Models.Identity
{
    public class UserInputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
