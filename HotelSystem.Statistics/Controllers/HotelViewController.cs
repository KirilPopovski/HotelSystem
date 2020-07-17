using HotelSystem.Common.Controllers;
using HotelSystem.Statistics.Models.HotelViews;
using HotelSystem.Statistics.Services.HotelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelSystem.Statistics.Controllers
{
    public class HotelViewController : ApiController
    {
        private readonly IHotelViewService hotelViews;

        public HotelViewController(IHotelViewService hotelViews)
        {
            this.hotelViews = hotelViews;
        }

        [HttpGet]
        [Route(Id)]
        public int TotalViews(int id)
        {
            return this.hotelViews.GetTotalViews(id);
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<HotelViewsOutputModel>> TotalViews(
            [FromQuery] IEnumerable<int> ids)
            => await this.hotelViews.GetTotalViews(ids);
    }
}
