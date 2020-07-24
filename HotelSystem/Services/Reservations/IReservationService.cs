using HotelSystem.Common.Data.Models;
using HotelSystem.Models.Reservations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelSystem.Services.Reservations
{
    public interface IReservationService
    {
        public Task<IEnumerable<ReservationViewModel>> GetAllReservations(int guestId);

        public Task MarkMessageAsPublished(int id);

        public Task<int> AddReservation(DateTime checkIn, DateTime checkOut, string hotelName, int numberOfPeople, int guestId, params Message[] messages);
    }
}
