using HotelSystem.Common.Controllers;
using HotelSystem.Common.Messages.Hotels;
using HotelSystem.Models.Home;
using HotelSystem.Services.Home;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelSystem.Controllers
{
    public class HomeController : ApiController
    {
        private readonly IHomeService homeService;
        private readonly IBus publisher;

        public HomeController(IHomeService homeService,
            IBus publisher)
        {
            this.homeService = homeService;
            this.publisher = publisher;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<ActionResult<AllHotelsViewModel>> Index()
        {
            var model = new AllHotelsViewModel { Hotels = await homeService.GetAllHotels() };
            return Ok(model);
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<HotelViewModel>> Details(int id)
        {
            var result = await this.homeService.GetDetails(id);
            await publisher.Publish(new HotelVisitedMessage
            {
                HotelId = id,
            });
            return result;
        }
    }
}
