using System.ComponentModel.DataAnnotations;

namespace HotelSystem.Admin.Models.Guests
{
    public class GuestInputModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(8)]
        public string CardNumber { get; internal set; }
    }
}
