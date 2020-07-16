using HotelSystem.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Data
{
    public class HotelSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public HotelSystemDbContext(DbContextOptions<HotelSystemDbContext> options)
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasOne(au => au.Guest)
                .WithOne(g => g.User)
                .HasForeignKey<Guest>(g => g.ApplicationUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
