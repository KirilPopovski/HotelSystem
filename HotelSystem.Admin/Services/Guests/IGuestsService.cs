using HotelSystem.Admin.Models.Guests;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Admin.Services.Guests
{
    public interface IGuestsService
    {
        [Get("/Guests")]
        Task<IEnumerable<GuestDetailsOutputModel>> All();

        [Get("/Guests/{id}")]
        Task<GuestDetailsOutputModel> Details(int id);

        [Put("/Guests/{id}")]
        Task Edit(int id, GuestInputModel guest);
    }
}
