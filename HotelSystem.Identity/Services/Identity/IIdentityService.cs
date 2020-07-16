namespace HotelSystem.Identity.Services.Identity
{
    using System.Threading.Tasks;
    using Data.Models;
    using HotelSystem.Common.Services;
    using Models.Identity;

    public interface IIdentityService
    {
        Task<Result<ApplicationUser>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(string UserId, ChangePasswordInputModel changePasswordInput);
    }
}
