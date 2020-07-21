using HotelSystem.Common.Controllers;
using HotelSystem.Common.Messages.Guests;
using HotelSystem.Common.Services.Identity;
using HotelSystem.Models.Reservations;
using HotelSystem.Services.Guests;
using HotelSystem.Services.Reservations;
using MassTransit;
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
        private readonly IBus publisher;

        public ReservationsController(ICurrentUserService currentUser,
            IReservationService reservationService,
            IGuestsService guestsService,
            IBus publisher)
        {
            this.currentUser = currentUser;
            this.reservationService = reservationService;
            this.guestsService = guestsService;
            this.publisher = publisher;
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
                await this.publisher.Publish(new ReservationCreatedMessage
                {
                    ReservationCount = 1
                });
                return Ok();
            }
            return NotFound();
        }
    }
}
