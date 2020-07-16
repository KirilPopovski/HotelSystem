using HotelSystem.Models.Home;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelSystem.Services.Home
{
    public interface IHomeService
    {
        public Task<IEnumerable<HotelViewModel>> GetAllHotels();
    }
}
