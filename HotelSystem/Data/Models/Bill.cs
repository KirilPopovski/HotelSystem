namespace HotelSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bill
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public bool IsPaid { get; set; }

        public int GuestId { get; set; }

        public Guest Guest { get; set; }
    }
}
