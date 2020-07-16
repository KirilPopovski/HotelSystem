using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelSystem.Data.Models
{
    public class Reservation
    {
        public Reservation()
        {
            this.Services = new HashSet<Service>();
        }

        public int Id { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }

        public int GuestId { get; set; }

        public Guest Guest { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
