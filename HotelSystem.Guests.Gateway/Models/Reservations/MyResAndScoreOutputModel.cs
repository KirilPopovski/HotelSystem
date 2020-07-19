using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Guests.Gateway.Models.Reservations
{
    public class MyResAndScoreOutputModel
    {
        public MyReservationsOutputModel MyReservations { get; set; }

        public int Score { get; set; }
    }
}
