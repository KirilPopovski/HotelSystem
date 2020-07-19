using HotelSystem.Common.Controllers;
using HotelSystem.Guests.Gateway.Models.Reservations;
using HotelSystem.Guests.Gateway.Services.Feedback;
using HotelSystem.Guests.Gateway.Services.Reservations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelSystem.Guests.Gateway.Controllers
{
    public class ReservationsController : ApiController
    {
        private readonly IReservationsService reservations;
        private readonly IFeedbackService feedback;

        public ReservationsController(IReservationsService reservations, IFeedbackService feedback)
        {
            this.reservations = reservations;
            this.feedback = feedback;
        }
        [HttpGet]
        [Authorize]
        [Route(nameof(MyReservations))]
        public async Task<MyResAndScoreOutputModel> MyReservations()
        {
            var myReservations = await this.reservations.MyReservations();

            var score = await this.feedback.Score();

            var model = new MyResAndScoreOutputModel
            {
                MyReservations = myReservations,
                Score = score.Score
            };

            return model;
        }
    }
}
