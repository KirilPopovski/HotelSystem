using HotelSystem.Statistics.Models.HotelViews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelSystem.Statistics.Services.HotelViews
{
    public interface IHotelViewService
    {
        public int GetTotalViews(int id);

        public Task<IEnumerable<HotelViewsOutputModel>> GetTotalViews(IEnumerable<int> ids);
        public Task AddHotelView(int hotelId);
    }
}
