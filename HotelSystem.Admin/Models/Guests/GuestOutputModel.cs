using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Admin.Models.Guests
{
    public class GuestOutputModel
    {
        public string Name { get; set; }

        public string CardNumber { get; internal set; }
    }
}
