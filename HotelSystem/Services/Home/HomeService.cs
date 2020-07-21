using HotelSystem.Data;
using HotelSystem.Models.Home;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Services.Home
{
    public class HomeService : IHomeService
    {
        private readonly GuestsDbContext db;

        public HomeService(GuestsDbContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<HotelViewModel>> GetAllHotels()
        {
            var hotels = await db.Hotels.Select(x => new HotelViewModel { Address = x.Address, Name = x.Name, ImageUrl = x.ImageUrl }).ToListAsync();
            return hotels;
        }

        public async Task<HotelViewModel> GetDetails(int id)
        {
            var hotel =await  this.db.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            if (hotel != null)
            {
                var model = new HotelViewModel
                {
                    Address = hotel.Address,
                    ImageUrl = hotel.ImageUrl,
                    Name = hotel.Name,
                };
                return model;
            }
            else return null;
        }
    }
}
