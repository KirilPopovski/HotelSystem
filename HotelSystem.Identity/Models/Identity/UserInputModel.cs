namespace HotelSystem.Identity.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class UserInputModel
    {
        [EmailAddress]
        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
