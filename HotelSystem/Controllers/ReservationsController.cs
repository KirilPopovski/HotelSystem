using HotelSystem.Common.Controllers;
using HotelSystem.Common.Services.Identity;
using HotelSystem.Models.Reservations;
using HotelSystem.Services.Guests;
using HotelSystem.Services.Reservations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Controllers
{
    public class ReservationsController : ApiController
    {
        private readonly ICurrentUserService currentUser;
        private readonly IReservationService reservationService;
        private readonly IGuestsService guestsService;

        public ReservationsController(ICurrentUserService currentUser, IReservationService reservationService, IGuestsService guestsService)
        {
            this.currentUser = currentUser;
            this.reservationService = reservationService;
            this.guestsService = guestsService;
        }

        [HttpGet]
        [Route(nameof(Index))]
        [Authorize]
        public async Task<ActionResult<AllReservationsViewModel>> Index()
        {
            var guestId = await guestsService.GetIdByUser(currentUser.UserId);
            var reservations = await reservationService.GetAllReservations(guestId);
            var result = new AllReservationsViewModel { Reservations = reservations.ToList() };
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route(nameof(New))]
        public async Task<IActionResult> New(ReservationInputModel input)
        {
            var guestId = await guestsService.GetIdByUser(currentUser.UserId);
            var result = await this.reservationService.AddReservation(input.ChechIn, input.CheckOut, input.HotelName, input.NumberOfPeople, guestId);
            if (result >= 0)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
