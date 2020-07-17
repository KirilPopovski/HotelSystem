using System.ComponentModel.DataAnnotations;

namespace HotelSystem.Statistics.Data.Models
{
    public class StatisticsModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int TotalReservations { get; set; }
    }
}
