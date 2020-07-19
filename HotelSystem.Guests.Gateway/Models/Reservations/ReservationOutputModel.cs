using System;

namespace HotelSystem.Guests.Gateway.Models.Reservations
{
    public class ReservationOutputModel
    {
        public DateTime ChechIn { get; set; }

        public DateTime CheckOut { get; set; }

        public string HotelUrl { get; set; }
    }
}
