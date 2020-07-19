using HotelSystem.Common.Controllers;
using HotelSystem.Common.Infrastructure;
using HotelSystem.Common.Services;
using HotelSystem.Common.Services.Identity;
using HotelSystem.Data.Models;
using HotelSystem.Models.Guests;
using HotelSystem.Services.Guests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
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

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<GuestDetailsOutputModel>> Details(int id)
            => await this.guests.GetDetails(id);

        [HttpPut]
        [Authorize]
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

        [HttpGet]
        [Authorize]
        [Route("Id")]
        public async Task<ActionResult<int>> GetGuestId()
        {
            bool isGuest = await this.guests.IsGuest(this.currentUser.UserId);

            if(!isGuest)
            {
                return this.BadRequest("This user is not a guest!");
            }

            return await this.guests.GetIdByUser(this.currentUser.UserId);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(CreateGuestInputModel input)
        {
            await guests.CreateGuestContactAsync(input.Email, input.PhoneNumber);
            var contactsId = guests.GetContactsId(input.Email);

            var guest = new Guest
            {
                EGN = input.EGN,
                CardNumber = input.CardNumber,
                Name = input.Name,
                GuestContactId = contactsId,
                ApplicationUserId = this.currentUser.UserId,
            };

            await guests.Save(guest);
            return Ok();
        }

        [HttpGet]
        [AuthorizeAdministrator]
        public async Task<IEnumerable<GuestDetailsOutputModel>> All()
        {
            return await this.guests.GetAll();
        }
    }
}
