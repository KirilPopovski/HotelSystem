using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Models.Guests
{
    public class CreateGuestInputModel
    {
        [EmailAddress]
        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Email { get; set; }

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
