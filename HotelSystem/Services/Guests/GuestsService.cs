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
        private readonly HotelSystemDbContext db;

        public GuestsService(HotelSystemDbContext db)
        {
            this.db = db;
        }
        public async Task CreateGuestContactAsync(string email, string phoneNumber)
        {
            var contact = new GuestContact { Email = email, PhoneNumber = phoneNumber };
            await db.GuestContacts.AddAsync(contact);
            await db.SaveChangesAsync();
        }

        public int GetContactsId(string email)
        {
            int result = db.GuestContacts.FirstOrDefault(x => x.Email == email).Id;
            return result;
        }

        public async Task<int> GetIdByUser(string userId)
        {
            var res =  await db.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (res == null)
            {
                throw new InvalidOperationException("This user is not a guest.");
            }
            var res2 = await db.Guests.FirstOrDefaultAsync(x => x.User.Id == res.Id);
            int result = res2.Id;
            return result;
        }

        public async Task Save(Guest guest)
        {
            await db.Guests.AddAsync(guest);
            await db.SaveChangesAsync();
        }
    }
}
