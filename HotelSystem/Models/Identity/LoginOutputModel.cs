namespace HotelSystem.Models.Identity
{
    public class LoginOutputModel
    {
        public LoginOutputModel(string token, int guestId)
        {
            this.Token = token;
            this.GuestId = guestId;
        }

        public int GuestId { get; }

        public string Token { get; }
    }
}
