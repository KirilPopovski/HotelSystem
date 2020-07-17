using System.ComponentModel.DataAnnotations;

namespace HotelSystem.Statistics.Data.Models
{
    public class HotelView
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int HotelId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
