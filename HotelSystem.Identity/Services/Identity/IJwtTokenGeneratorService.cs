namespace HotelSystem.Identity.Services.Identity
{
    using Data.Models;
    using System.Collections.Generic;

    public interface IJwtTokenGeneratorService
    {
        string GenerateToken(ApplicationUser user, IEnumerable<string> roles = null);
    }
}
