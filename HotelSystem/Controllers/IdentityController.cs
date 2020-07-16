namespace HotelSystem.Controllers
{
    using System.Threading.Tasks;
    using HotelSystem.Data.Models;
    using HotelSystem.Models.Identity;
    using HotelSystem.Services.Guests;
    using HotelSystem.Services.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class IdentityController : ApiController
    {
        private readonly IIdentityService identity;
        private readonly ICurrentUserService currentUser;
        private readonly IGuestsService guests;

        public IdentityController(
            IIdentityService identity,
            ICurrentUserService currentUser,
            IGuestsService guests)
        {
            this.identity = identity;
            this.currentUser = currentUser;
            this.guests = guests;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(
            CreateUserInputModel input)
        {
            var result = await this.identity.Register(input);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            var user = result.Data;

            await guests.CreateGuestContactAsync(user.Email, input.PhoneNumber);

            var guest = new Guest
            {
                Name = input.Name,
                CardNumber = input.CardNumber,
                EGN = input.EGN,
                ApplicationUserId = user.Id,
                GuestContactId = guests.GetContactsId(user.Email),
            };

            await this.guests.Save(guest);

            return Ok();
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(
            UserInputModel input)
        {
            var result = await this.identity.Login(input);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            var user = result.Data;

            var guestId = await this.guests.GetIdByUser(user.UserId);

            return new LoginOutputModel(user.Token, guestId);
        }

        [HttpPut]
        [Authorize]
        [Route(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(
            ChangePasswordInputModel input)
            => await this.identity.ChangePassword(new ChangePasswordInputModel
            {
                UserId = this.currentUser.UserId,
                CurrentPassword = input.CurrentPassword,
                NewPassword = input.NewPassword
            });
    }
}