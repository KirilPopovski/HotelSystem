using System.Collections.Generic;

namespace HotelSystem.Guests.Gateway.Models.Reservations
{
    public class MyReservationsOutputModel
    {
        public IEnumerable<ReservationOutputModel> Reservations { get; set; }
    }
}
