// ReSharper disable VirtualMemberCallInConstructor
namespace HotelSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public Guest Guest { get; set; }
    }
}
