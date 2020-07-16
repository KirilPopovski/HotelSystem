﻿using HotelSystem.Data;
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
        private readonly HotelSystemDbContext db;

        public HomeService(HotelSystemDbContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<HotelViewModel>> GetAllHotels()
        {
            var hotels = await db.Hotels.Select(x => new HotelViewModel { Address = x.Address, Name = x.Name, ImageUrl = x.ImageUrl }).ToListAsync();
            return hotels;
        }
    }
}
