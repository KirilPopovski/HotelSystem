using HotelSystem.Data.Models;
using HotelSystem.Models.Guests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelSystem.Services.Guests
{
    public interface IGuestsService
    {
        public Task CreateGuestContactAsync(string email, string phoneNumber);

        public int GetContactsId(string email);

        public Task Save(Guest guest);

        public Task<int> GetIdByUser(string userId);

        public Task<Guest> FindByUser(string userId);

        public Task<GuestDetailsOutputModel> GetDetails(int id);


        public Task<bool> IsGuest(string userId);

        public Task<IEnumerable<GuestDetailsOutputModel>> GetAll();
    }
}
