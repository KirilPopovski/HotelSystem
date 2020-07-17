using HotelSystem.Statistics.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Statistics.Services.Feedback
{
    public class FeedbackService : IFeedbackService
    {
        private readonly StatisticsDbContext db;

        public FeedbackService(StatisticsDbContext db)
        {
            this.db = db;
        }
        public async Task AddFeedbackAsync(float score, string content, string userId)
        {
            var fb = new Data.Models.Feedback { Content = content, Score = score, UserId = userId };
            await db.Feedbacks.AddAsync(fb);
        }

        public async Task<float> GetTotalScore()
        {
            float result = await db.Feedbacks.AverageAsync(x => x.Score);
            return result;
        }
    }
}
