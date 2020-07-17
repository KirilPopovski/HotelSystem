using HotelSystem.Common.Controllers;
using HotelSystem.Statistics.Models.Statistics;
using HotelSystem.Statistics.Services.Statistics;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelSystem.Statistics.Controllers
{
    public class StatisticsController : ApiController
    {
        private readonly IStatisticsService statistics;

        public StatisticsController(IStatisticsService statistics)
            => this.statistics = statistics;

        [HttpGet]
        public async Task<StatisticsOutputModel> All()
        {
            var model = new StatisticsOutputModel { TotalReservations = await statistics.All() };
            return model;
        }
    }
}
