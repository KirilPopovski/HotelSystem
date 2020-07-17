using HotelSystem.Statistics.Data;
using HotelSystem.Statistics.Models.Statistics;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Statistics.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly StatisticsDbContext db;

        public StatisticsService(StatisticsDbContext db)
        {
            this.db = db;
        }
        public async Task<int> All()
        {
            return await this.db.Statistics.Select(x => x.TotalReservations).SumAsync();
        }
    }
}
