namespace HotelSystem.Identity.Services.Identity
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Models;
    using HotelSystem.Common.Services;
    using Microsoft.AspNetCore.Identity;
    using Models.Identity;

    public class IdentityService : IIdentityService
    {
        private const string InvalidErrorMessage = "Invalid credentials.";

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IJwtTokenGeneratorService jwtTokenGenerator;

        public IdentityService(UserManager<ApplicationUser> userManager, IJwtTokenGeneratorService jwtTokenGenerator)
        {
            this.userManager = userManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result<ApplicationUser>> Register(UserInputModel userInput)
        {
            var user = new ApplicationUser
            {
                Email = userInput.Email,
                UserName = userInput.Email
            };

            var identityResult = await this.userManager.CreateAsync(user, userInput.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result<ApplicationUser>.SuccessWith(user)
                : Result<ApplicationUser>.Failure(errors);
        }

        public async Task<Result<UserOutputModel>> Login(UserInputModel userInput)
        {
            var user = await this.userManager.FindByEmailAsync(userInput.Email);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, userInput.Password);
            if (!passwordValid)
            {
                return InvalidErrorMessage;
            }

            var token = this.jwtTokenGenerator.GenerateToken(user);

            return new UserOutputModel(token);
        }

        public async Task<Result> ChangePassword(string UserId, ChangePasswordInputModel changePasswordInput)
        {
            var user = await this.userManager.FindByIdAsync(UserId);

            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var identityResult = await this.userManager.ChangePasswordAsync(
                user,
                changePasswordInput.CurrentPassword,
                changePasswordInput.NewPassword);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }
    }
}
