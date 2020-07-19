using HotelSystem.Admin.Models.Guests;
using HotelSystem.Admin.Services.Guests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelSystem.Admin.Controllers
{
    public class GuestsController : AdministrationController
    {
        private readonly IGuestsService guests;

        public GuestsController(IGuestsService guests)
        {
            this.guests = guests;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
            => View(await this.guests.All());

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var guest = await this.guests.Details(id);

            var guestForm = new GuestOutputModel { CardNumber = guest.CardNumber, Name = guest.Name };

            return View(guestForm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, GuestOutputModel model)
            => await this.Handle(
                async () => await this.guests
                    .Edit(id, new GuestInputModel { Name = model.Name, CardNumber = model.CardNumber}),
                success: RedirectToAction(nameof(Index)),
                failure: View(model));
    }
}
