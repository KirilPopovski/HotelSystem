using HotelSystem.Statistics.Models.Statistics;
using System.Threading.Tasks;

namespace HotelSystem.Statistics.Services.Statistics
{
    public interface IStatisticsService
    {
        public Task<int> All();

        public Task AddReservation();
    }
}
