using HotelSystem.Guests.Gateway.Models.Feedback;
using Refit;
using System.Threading.Tasks;

namespace HotelSystem.Guests.Gateway.Services.Feedback
{
    public interface IFeedbackService
    {
        [Get("/Feedback")]
        Task<FeedbackOutputModel> Score();
    }
}
