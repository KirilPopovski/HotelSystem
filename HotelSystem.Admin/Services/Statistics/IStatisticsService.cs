using HotelSystem.Admin.Models.Statistics;
using Refit;
using System.Threading.Tasks;

namespace HotelSystem.Admin.Services.Statistics
{
    public interface IStatisticsService
    {
        [Get("/Statistics")]
        Task<StatisticsOutputModel> All();
    }
}
