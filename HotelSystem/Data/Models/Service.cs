using System;
using System.ComponentModel.DataAnnotations;

namespace HotelSystem.Data.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public double Price { get; set; }

        public DateTime Date { get; set; }

        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }
    }
}
