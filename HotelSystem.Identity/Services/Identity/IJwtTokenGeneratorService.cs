﻿namespace HotelSystem.Identity.Services.Identity
{
    using Data.Models;

    public interface IJwtTokenGeneratorService
    {
        string GenerateToken(ApplicationUser user);
    }
}