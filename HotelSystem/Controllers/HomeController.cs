using HotelSystem.Common.Controllers;
using HotelSystem.Models.Home;
using HotelSystem.Services.Home;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelSystem.Controllers
{
    public class HomeController : ApiController
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<ActionResult<AllHotelsViewModel>> Index()
        {
            var model = new AllHotelsViewModel { Hotels = await homeService.GetAllHotels() };
            return Ok(model);
        }
    }
}
