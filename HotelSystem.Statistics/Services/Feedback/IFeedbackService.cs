using System.Threading.Tasks;

namespace HotelSystem.Statistics.Services.Feedback
{
    public interface IFeedbackService
    {
        public Task AddFeedbackAsync(float score, string content, string userId);

        public Task<float> GetTotalScore();
    }
}
