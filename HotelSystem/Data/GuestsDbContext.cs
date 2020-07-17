using HotelSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Data
{
    public class GuestsDbContext : DbContext
    {
        public GuestsDbContext(DbContextOptions<GuestsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<GuestContact> GuestContacts { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<HotelContact> HotelContacts { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Service> Services { get; set; }
    }
}
