using HotelSystem.Data;
using HotelSystem.Data.Models;
using HotelSystem.Models.Reservations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Services.Reservations
{
    public class ReservationsService : IReservationService
    {
        private readonly GuestsDbContext db;

        public ReservationsService(GuestsDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddReservation(DateTime checkIn, DateTime checkOut, string hotelName, int numberOfPeople, int guestId)
        {
            var room = this.db.Rooms.FirstOrDefault(x => x.Hotel.Name == hotelName && x.Capacity == numberOfPeople);
            if(room == null)
            {
                return -1;
            }
            var reservation = new Reservation
            {
                CheckIn = checkIn,
                CheckOut = checkOut,
                GuestId = guestId,
                RoomId = room.Id,
            };
            await this.db.Reservations.AddAsync(reservation);
            await this.db.SaveChangesAsync();
            return 0;
        }

        public async Task<IEnumerable<ReservationViewModel>> GetAllReservations(int guestId)
        {
            var Reservations = await this.db.Reservations
                    .Where(x => x.GuestId == guestId)
                    .Select(x => new ReservationViewModel
                    {
                        ChechIn = x.CheckIn,
                        CheckOut = x.CheckOut,
                        HotelUrl = this.db.Hotels.Where(y => y.Rooms.Where(z => z.Id == x.RoomId).Any()).FirstOrDefault().ImageUrl,
                    })
                    .ToListAsync();
            return Reservations;
        }
    }
}
