using HotelSystem.Statistics.Data;
using HotelSystem.Statistics.Models.HotelViews;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Statistics.Services.HotelViews
{
    public class HotelViewService : IHotelViewService
    {
        private readonly StatisticsDbContext db;

        public HotelViewService(StatisticsDbContext db)
        {
            this.db = db;
        }

        public int GetTotalViews(int id)
        {
            int count = db.HotelViews.Where(x => x.HotelId == id).Count();
            return count;
        }

        public async Task<IEnumerable<HotelViewsOutputModel>> GetTotalViews(IEnumerable<int> ids)
        {
            var result = await db.HotelViews.Where(v => ids.Contains(v.HotelId))
                .GroupBy(v => v.HotelId)
                .Select(gr => new HotelViewsOutputModel
                {
                    HotelId = gr.Key,
                    TotalViews = gr.Count()
                })
                .ToListAsync();

            return result;
        }
    }
}
