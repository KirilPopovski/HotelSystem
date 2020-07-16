using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelSystem.Data.Models
{
    public class Hotel
    {
        public Hotel()
        {
            this.Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        [MaxLength(200)]
        public string ImageUrl { get; set; }

        public int UIC { get; set; }

        public ICollection<HotelContact> HotelContacts { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
