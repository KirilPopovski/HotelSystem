using HotelSystem.Guests.Gateway.Models.Reservations;
using Refit;
using System.Threading.Tasks;

namespace HotelSystem.Guests.Gateway.Services.Reservations
{
    public interface IReservationsService
    {
        [Get("/Reservations/Index")]
        Task<MyReservationsOutputModel> MyReservations();
    }
}
