using HotelSystem.Admin.Infrastructure;
using HotelSystem.Admin.Models.Identity;
using HotelSystem.Admin.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using HotelSystem.Common.Infrastructure;
using System.Threading.Tasks;

namespace HotelSystem.Admin.Controllers
{
    public class IdentityController : AdministrationController
    {
        private readonly IIdentityService identityService;

        public IdentityController(
            IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserInputModel model)
            => await this.Handle(
                async () =>
                {
                    var result = await this.identityService
                        .Login(model);

                    this.Response.Cookies.Append(
                        InfrastructureConstants.AuthenticationCookieName,
                        result.Token,
                        new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true,
                            MaxAge = TimeSpan.FromDays(1)
                        });
                },
                success: RedirectToAction(nameof(GuestsController.Index), "Guests"),
                failure: View("../Home/Index", model));

        [AuthorizeAdministrator]
        public IActionResult Logout()
        {
            this.Response.Cookies.Delete(InfrastructureConstants.AuthenticationCookieName);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
