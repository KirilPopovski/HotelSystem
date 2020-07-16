using HotelSystem.Data;
using HotelSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Services.Guests
{
    public class GuestsService : IGuestsService
    {
        private readonly GuestsDbContext db;

        public GuestsService(GuestsDbContext db)
        {
            this.db = db;
        }
        public async Task CreateGuestContactAsync(string email, string phoneNumber)
        {
            var contact = new GuestContact { Email = email, PhoneNumber = phoneNumber };
            await db.GuestContacts.AddAsync(contact);
            await db.SaveChangesAsync();
        }

        public async Task<Guest> FindByUser(string userId)
        {
            var guest = await this.db.Guests.FirstOrDefaultAsync(x => x.ApplicationUserId == userId);
            return guest;
        }

        public int GetContactsId(string email)
        {
            int result = db.GuestContacts.FirstOrDefault(x => x.Email == email).Id;
            return result;
        }

        public async Task<int> GetIdByUser(string userId)
        {
            var res = await db.Guests.FirstOrDefaultAsync(x => x.ApplicationUserId == userId);
            if (res == null)
            {
                throw new InvalidOperationException("This user is not a guest.");
            }
            int result = res.Id;
            return result;
        }

        public async Task Save(Guest guest)
        {
            await db.Guests.AddAsync(guest);
            await db.SaveChangesAsync();
        }
    }
}
