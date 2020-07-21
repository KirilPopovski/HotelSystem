using HotelSystem.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelSystem.Services.Home
{
    public interface IHomeService
    {
        public Task<IEnumerable<HotelViewModel>> GetAllHotels();

        public Task<HotelViewModel> GetDetails(int id);
    }
}
