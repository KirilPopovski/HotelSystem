using Microsoft.AspNetCore.Authorization;

namespace HotelSystem.Common.Infrastructure
{
    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute() => this.Roles = Constants.AdministratorRoleName;
    }
}
