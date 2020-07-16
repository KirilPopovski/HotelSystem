using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelSystem.Data.Models
{
    public class HotelContact 
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(12)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(12)]
        public string Fax { get; set; }

        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }
    }
}
