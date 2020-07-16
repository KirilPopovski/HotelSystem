using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelSystem.Data.Models
{
    public class Room
    {
        public Room()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Number { get; set; }

        public int Floor { get; set; }

        public int Beds { get; set; }

        public bool Smoking { get; set; }

        [Required]
        [MaxLength(20)]
        public string Scene { get; set; }

        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
