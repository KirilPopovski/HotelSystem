using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Models.Guests
{
    public class GuestDetailsOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EGN { get; set; }

        public string CardNumber { get; set; }
    }
}
