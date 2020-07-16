using HotelSystem.Common.Controllers;
using HotelSystem.Common.Services;
using HotelSystem.Common.Services.Identity;
using HotelSystem.Models.Guests;
using HotelSystem.Services.Guests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelSystem.Controllers
{
    public class GuestsController : ApiController
    {
        private readonly IGuestsService guests;
        private readonly ICurrentUserService currentUser;

        public GuestsController(
            IGuestsService guests,
            ICurrentUserService currentUser)
        {
            this.guests = guests;
            this.currentUser = currentUser;
        }

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(int id, EditGuestInputModel input)
        {
            var guest = await this.guests.FindByUser(this.currentUser.UserId);

            if (id != guest.Id)
            {
                return BadRequest(Result.Failure("You cannot edit this guest."));
            }

            guest.Name = input.Name;
            guest.CardNumber = input.CardNumber;

            await this.guests.Save(guest);

            return Ok();
        }
    }
}
