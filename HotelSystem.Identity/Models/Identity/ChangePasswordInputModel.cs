namespace HotelSystem.Identity.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class ChangePasswordInputModel
    {
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
