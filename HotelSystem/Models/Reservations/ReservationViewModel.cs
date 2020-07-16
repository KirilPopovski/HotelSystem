using System;

namespace HotelSystem.Models.Reservations
{
    public class ReservationViewModel
    {
        public DateTime ChechIn { get; set; }

        public DateTime CheckOut { get; set; }

        public string HotelUrl { get; set; }
    }
}
