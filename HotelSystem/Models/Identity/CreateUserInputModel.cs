namespace HotelSystem.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class CreateUserInputModel : UserInputModel
    {
        [Required]
        [MinLength(7)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        public string CardNumber { get; set; }

        [Required]
        [MaxLength(10)]
        public string EGN { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(12)]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
